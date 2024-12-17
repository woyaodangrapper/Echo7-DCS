using Grpc.Net.Client.Balancer;

namespace ECHO.Infrastructure.Consul.Discover.GrpcResolver;

//https://docs.microsoft.com/zh-cn/aspnet/core/grpc/loadbalancing?view=aspnetcore-6.0
public sealed class ConsulGrpcResolver : PollingResolver
{
    private readonly Uri _address;
    private readonly int _port;
    private readonly ConsulClient _client;
    private readonly ILogger<PollingResolver> _logger;
    private readonly CancellationTokenSource _cts = new();

    public ConsulGrpcResolver(Uri address, int defaultPort, ConsulClient client, ILoggerFactory loggerFactory)
        : base(loggerFactory)
    {
        _address = address;
        _port = defaultPort;
        _client = client;
        _logger = loggerFactory.CreateLogger<PollingResolver>();
    }

    protected override void OnStarted()
    {
        base.OnStarted();
        _ = ConsulPacemaker(_cts.Token);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        _cts.Cancel();
    }

    protected override async Task ResolveAsync(CancellationToken cancellationToken)
    {
        var address = _address.Host.Replace("consul://", string.Empty);
        var _consulServiceProvider = new DiscoverProviderBuilder(_client)
            .WithServiceName(address).WithCacheSeconds(5).Build();
        var results = await _consulServiceProvider.GetAllHealthServicesAsync();
        var balancerAddresses = new List<BalancerAddress>();
        results?.ForEach(result =>
        {
            var addressArray = result.Split(":");
            var host = addressArray[0];
            var port = int.Parse(addressArray[1]) + 1;
            balancerAddresses.Add(new BalancerAddress(host, port));
        });
        // Pass the results back to the channel.
        Listener(ResolverResult.ForResult(balancerAddresses));
    }

    private async Task ConsulPacemaker(CancellationToken cancellationToken)
    {
        // 定义服务实例监视Watch
        var eventHandler = new Action<QueryResult<HealthCheck[]>>(result =>
        {
            //_logger.LogInformation($"Service instances changed: {result.Response.Length}");
            foreach (var check in result.Response)
            {
                _logger.LogInformation($"Service {check.ServiceName} instance {check.ServiceID} changed status to {check.Status.Status}");
                if (check.Status.Equals(HealthStatus.Passing))
                    Refresh();
            }
        });

        // 开始监视服务实例状态变化
        var queryOptions = new QueryOptions { Consistency = ConsistencyMode.Consistent };

        var _serviceName = _address.Host.Replace("consul://", string.Empty);
        while (!cancellationToken.IsCancellationRequested)
        {
            var queryResult = await _client.Health.Checks(_serviceName, queryOptions, cancellationToken);
            eventHandler(queryResult);
            // 重置查询选项，以便下一次查询
            queryOptions.WaitIndex = queryResult.LastIndex;
            await Task.Delay(1000 * 10, cancellationToken);
        }
    }
}

public class ConsulGrpcResolverFactory : ResolverFactory
{
    private readonly ConsulClient _consulClient;

    public ConsulGrpcResolverFactory(
       ConsulClient consulClient
        )
    {
        _consulClient = consulClient;
    }

    public override string Name => "consul";

    public override Resolver Create(ResolverOptions options)
     => new ConsulGrpcResolver(options.Address, options.DefaultPort, _consulClient, options.LoggerFactory);
}
﻿namespace ECHO.Infrastructure.Consul.Discover.Balancers;

public interface ILoadBalancer
{
    string Resolve(IList<string> services);
}
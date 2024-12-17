﻿using ECHO.SharedKernel.Application.Caching.SkyApm;

namespace ECHO.SharedKernel.Application.Registrar;

public abstract partial class AbstractApplicationDependencyRegistrar
{
    /// <summary>
    /// 注册Caching相关处理服务
    /// </summary>
    /// <param name="builder"></param>
    protected virtual void AddRedisCaching(Action<IServiceCollection> action = null)
    {
        action?.Invoke(Services);
        if(this.IsEnableSkyApm())
        {
            SkyApm.AddRedisCaching();
        }
        Services.AddDcsInfraRedisCaching(RedisSection,CachingSection);
        var serviceType = typeof(ICachePreheatable);
        var implTypes = ApplicationLayerAssembly.ExportedTypes.Where(type => type.IsAssignableTo(serviceType) && type.IsNotAbstractClass(true));
        if (implTypes.IsNotNullOrEmpty())
        {
            implTypes.ForEach(implType =>
            {
                Services.AddSingleton(implType, implType);
                Services.AddSingleton(x => x.GetRequiredService(implType) as ICachePreheatable);
            });
        }
    }

    /// <summary>
    /// 注册BloomFilter相关处理服务
    /// </summary>
    /// <param name="builder"></param>
    protected virtual void AddBloomFilters(Action<IServiceCollection> action = null)
    {
        action?.Invoke(Services);

        var serviceType = typeof(IBloomFilter);
        var implTypes = ApplicationLayerAssembly.ExportedTypes.Where(type => type.IsAssignableTo(serviceType) && type.IsNotAbstractClass(true)).ToList();
        if (implTypes.IsNotNullOrEmpty())
            implTypes.ForEach(implType => Services.AddSingleton(serviceType, implType));
    }
}
﻿namespace ECHO.Infrastructure.Consul.Discover.Balancers;

public static class TypeLoadBalancer
{
    public static ILoadBalancer RandomLoad => new RandomLoadBalancer();
    public static ILoadBalancer RoundRobinLoad => new RoundRobinLoadBalancer();
}
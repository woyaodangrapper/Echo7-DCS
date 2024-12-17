﻿namespace ECHO.SharedKernel.Const.Caching.Common;

public class CachingConsts
{
    protected CachingConsts()
    { }

    public const string LinkChar = ":";

    public const int OneYear = 365 * 24 * 60 * 60;
    public const int OneMonth = 30 * 24 * 60 * 60;
    public const int OneWeek = 7 * 24 * 60 * 60;
    public const int OneDay = 24 * 60 * 60;
    public const int OneHour = 60 * 60;
    public const int OneMinute = 60;

    //public static string Prefix
    //{
    //    get
    //    {
    //        var prefix = "echo";
    //        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower();
    //        prefix += environment switch
    //        {
    //            "development" => "_dev",
    //            "test" => "_test",
    //            "staging" => "_staging",
    //            "production" => "_prod",
    //            _ => "_unknown",
    //        };
    //        return prefix;
    //    }
    //}

    //public static string WorkerIdSortedSetCacheKey => $"echo:{{0}}:workids";
}
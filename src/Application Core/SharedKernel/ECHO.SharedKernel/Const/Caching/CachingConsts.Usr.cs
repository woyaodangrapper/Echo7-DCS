namespace ECHO.SharedKernel.Const.Caching.Usr;

public class CachingConsts : Common.CachingConsts
{
    //cache key
    public const string MenuListCacheKey = "echo:usr:menus:list";

    public const string MenuTreeListCacheKey = "echo:usr:menus:tree";
    public const string MenuRelationCacheKey = "echo:usr:menus:relation";
    public const string MenuCodesCacheKey = "echo:usr:menus:codes";

    public const string DetpListCacheKey = "echo:usr:depts:list";
    public const string DetpTreeListCacheKey = "echo:usr:depts:tree";
    public const string DetpSimpleTreeListCacheKey = "echo:usr:depts:tree:simple";

    public const string RoleListCacheKey = "echo:usr:roles:list";

    //cache prefix
    public const string UserValidatedInfoKeyPrefix = "echo:usr:users:validatedinfo";

    //bloomfilter
    public const string BloomfilterOfAccountsKey = "echo:usr:bloomfilter:accouts";

    public const string BloomfilterOfCacheKey = "echo:usr:bloomfilter:cachekeys";
}
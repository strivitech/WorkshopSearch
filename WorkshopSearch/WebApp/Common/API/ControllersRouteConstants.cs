namespace WebApp.Common.API;

public static class ControllersRouteConstants
{
    public const string Api = "api/";
    public const string Controller = "[controller]";
    public const string DefaultRestRoute = Api + Controller;
    public const string DefaultControllerActionRoute = DefaultRestRoute + "/[action]";
}
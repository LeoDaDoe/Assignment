namespace Assignment.Config
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder RegisterEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapControllerRoute(
                name: "Calculations",
                pattern: "api/calculate/[action]",
                defaults: new { controller = "Calculations" });
            builder.MapControllerRoute(
                name: "Files",
                pattern: "api/files/[action]",
                defaults: new { controller = "File" });
            return builder;
        }
    }
}

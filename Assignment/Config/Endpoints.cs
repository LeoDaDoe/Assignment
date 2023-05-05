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
            return builder;
        }
    }
}

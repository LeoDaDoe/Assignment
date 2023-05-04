namespace Assignment.Config
{
    public class Endpoints
    {
        public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder builder)
        {
            builder.MapControllerRoute(
                name: "Calculations",
                pattern: "api/calculate/[action]",
                defaults: new { controller = "Calculations" });
            return builder;
        }
    }
}

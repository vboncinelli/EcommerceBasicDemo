namespace Ecommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication
                .CreateBuilder(args);

            builder
                .Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"myspecialsettings.json", optional: true, reloadOnChange: false);


            builder.Services.AddControllers();

            builder.Services.AddLogging();
            
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.MapControllers();

            app.Run();
        }
    }
}

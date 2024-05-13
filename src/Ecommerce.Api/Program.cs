using Ecommerce.Api;
using Ecommerce.Api.Middlewares;
using NLog;
using NLog.Web;

internal class Program
{
    private static void Main(string[] args)
    {
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        logger.Debug("init main");
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Configure Swagger
            builder.Services.ConfigureSwagger();
            // Configure CORS
            builder.Services.ConfigureCors();
            // Configure Dependency Injection
            builder.Services.ConfigureDependencyInjection();
            // Configure NLog
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            // Configure DBContext
            builder.ConfigureDBContext();
            // Configure NewtonsoftJson
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Configure AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline for only Developer
            if (app.Environment.IsDevelopment())
            {
                app.ConfigureSwagger();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseExceptionHandlarMiddleware();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
}
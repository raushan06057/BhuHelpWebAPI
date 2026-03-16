namespace BhuHelpAPI.Application.Extensions;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
    {
        services.AddInfraService(config);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddInfraService(config);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        var mapperConfig = new MapperConfiguration(mod => { mod.AddProfile(new MappingProfile()); });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}

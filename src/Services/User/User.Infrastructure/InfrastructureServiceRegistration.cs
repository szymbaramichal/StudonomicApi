using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts.Infrastructure;
using User.Application.Contracts.Persistence;
using User.Application.Models.Emails;
using User.Infrastructure.Persistence;
using User.Infrastructure.Repositories;
using User.Infrastructure.Services;

namespace User.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var test = configuration.GetConnectionString("UsersConnectionString");
        services.AddDbContext<UserContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")));
        
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<ILabelsRepository, LabelsRepository>();

        services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
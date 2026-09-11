using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Services;
using PayFlow.Domain.Interface;
using PayFlow.Repository.Data.DataConfiguration;
using PayFlow.Repository.Repositories;

namespace PayFlow.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ICreateTransactionService, CreateTransactionService>();
        services.AddScoped<IGetTransactionService, GetTransactionService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICreateUserService, CreateUserService>();
       
        
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        
        
        
      
        
        return services;
    }
}
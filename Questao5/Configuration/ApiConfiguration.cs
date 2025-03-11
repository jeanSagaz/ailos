using Questao5.Application.Queries;
using Questao5.Core.Mediator;
using Questao5.Core.Notifications.Interfaces;
using Questao5.Core.Notifications;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Interfaces;
using Questao5.Infrastructure.Database.Repository;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;
using MediatR;

namespace Questao5.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddRouting(options => options.LowercaseUrls = true);

            // Add services to the container.
            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            // sqlite
            services.AddSingleton(new DatabaseConfig { Name = configuration.GetConnectionString("DefaultConnection") });
            services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            // Domain notification
            services.AddScoped<IDomainNotifier, DomainNotifier>();
            // Repository
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IMovimentRepository, MovimentRepository>();
            services.AddScoped<IEventStore, IdempotencyRepository>();
            // Handlers
            services.AddScoped<IAccountBalanceQueriesHandler, AccountBalanceQueriesHandler>();

        }
    }
}

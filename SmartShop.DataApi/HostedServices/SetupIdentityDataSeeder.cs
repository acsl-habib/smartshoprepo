using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SmartShop.DataApi.HostedServices
{
    public class SetupIdentityDataSeeder : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        public SetupIdentityDataSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IdentityDbInitializer>();
            await seeder.SeedAsync();

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

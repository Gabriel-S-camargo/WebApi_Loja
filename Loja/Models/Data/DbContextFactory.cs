using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Loja.Data{

    public class LojaDbContextFactory : IDesignTimeDbContextFactory<LojaDbContext>{
        public LojaDbContext CreateDbContext(string[] args){

            var optionsBuilder = new DbContextOptionsBuilder<LojaDbContext>();

            // Builda a configuração

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8,0,37)));

            return new LojaDbContext(optionsBuilder.Options);

        }
    }


}
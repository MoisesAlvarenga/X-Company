using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using XCompany.Data.Repositories;
using XCompany.DataContext;
using XCompany.Services;
using Microsoft.Extensions.Configuration;

namespace XCompany
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            // Configurar DI container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Criar provedor de servi�os
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Inicializar o contexto do banco de dados
            var dbContext = serviceProvider.GetRequiredService<XCompanyContext>();
            dbContext.Database.EnsureCreated(); // Garantir que o banco de dados existe

            // Iniciar a aplica��o Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<frmDashboard>());
            //Application.Run(serviceProvider.GetRequiredService<SaleForm>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<XCompanyContext>();
            // Configurar DbContextOptions com PostgreSQL

            var config = LoadConfiguration();

            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<XCompanyContext>(options =>
                options.UseNpgsql(connectionString), ServiceLifetime.Transient);

            services.AddScoped<DbContext>();
            // Registrar reposit�rios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();

            // Registrar formul�rios
            services.AddScoped<CustomerForm>();
            services.AddScoped<ProductForms>();
            services.AddScoped<frmDashboard>();
            services.AddScoped<FrmSale>();
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}

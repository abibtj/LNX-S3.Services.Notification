using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using S3.Common.Logging;
using S3.Common.Metrics;
using S3.Common.Mvc;
using S3.Common.Vault;

namespace S3.Services.Notification
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UseAppMetrics();
    }
}

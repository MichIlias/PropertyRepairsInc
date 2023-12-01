namespace PropertyRepairsIncConsumerAPI.Services
{
    public class WatcherService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<WatcherService> _logger;
        private readonly IRepairService _repairService;

        public WatcherService(IServiceProvider services, ILogger<WatcherService> logger, IRepairService repairService)
        {
            _services = services;
            _logger = logger;
            _repairService = repairService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Your logging logic here
                // Example: Console.WriteLine("Logging something...");

                // Add a delay to avoid high resource consumption
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

                _logger.LogInformation("Background service running");
                try
                {
                    await _repairService.ReadAndStoreRepairMessages();
                }
                catch
                {

                }
            }
        }
    }
}

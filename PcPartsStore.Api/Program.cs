using PcPartsStore.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

await app.ResetDatabaseData();

app.Run();

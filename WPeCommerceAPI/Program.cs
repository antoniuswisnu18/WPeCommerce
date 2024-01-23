using WPeCommerceAPI;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.serviceConfiguration(builder.Services);
var app = builder.Build();
startup.Configure(app, builder.Environment);


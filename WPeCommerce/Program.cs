using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WPeCommerce;
using WPeCommerce.Data;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, builder.Environment);

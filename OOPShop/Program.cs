using Microsoft.EntityFrameworkCore;
using OOPShop.Repositories.Interfaces;
using OOPShop.Repositories;
using OOPShop.Models;


var builder = WebApplication.CreateBuilder(args);

// adding services
builder.Services.AddMvc();
builder.Services.AddSingleton<AbstractApplicationDbContext, ApplicationDbContext>();
// adding repositories
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IOrderItemRepository, OrderItemRepository>();


var app = builder.Build();

// mapping controllers with routes
app.MapControllers();

app.Run();

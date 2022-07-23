using Chatroom.Domain.Settings;
using Chatroom.Service.Extensions;
using Chatroom.SignalRChat;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Chatroom.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ChatroomContextConnection") ?? throw new InvalidOperationException("Connection string 'ChatroomContextConnection' not found.");

builder.Services.AddDbContext<ChatroomContext>(options =>
{
    options.UseSqlite(connectionString);
    options.EnableSensitiveDataLogging(true);
});

builder.Services.AddDefaultIdentity<ChatroomUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ChatroomContext>();

// Add services to the container.

// Binding values from appsettings.
builder.Services.Configure<AppSettings>(options => builder.Configuration?.GetSection("AppSettings").Bind(options));

builder.Services.AddControllersWithViews();

// Enable SignalR using websocket communication.
builder.Services.AddSignalR();
// Inject services for Chatroom.Service dependency lib.
builder.Services.AddServices(builder.Configuration);

// Service responsible to handle commands and publish it to chatroom.
builder.Services.AddSingleton<MessageBot>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");
app.Lifetime.ApplicationStarted.Register(() => RegisterSignalRWithRabbitMQ(app.Services));

app.Run();

static void RegisterSignalRWithRabbitMQ(IServiceProvider serviceProvider)
{
    // Connect to RabbitMQ
    var rabbitMQService = (MessageBot)serviceProvider.GetRequiredService(typeof(MessageBot));
    rabbitMQService.Connect();
}

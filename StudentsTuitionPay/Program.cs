using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Payment.Utility;
using StudentsTuitionPay.Models.Student.Utility;
using StudentsTuitionPay.Data;

var builder = WebApplication.CreateBuilder(args);

string studentConnString = builder.Configuration.GetConnectionString("StudentDbConnection");
string paymentConnString = builder.Configuration.GetConnectionString("PaymentDbConnection");

Console.WriteLine("CONNECTION STRINGS:\n" + studentConnString + "\n" + paymentConnString);

// MySql server version
//var serverVersion = new MySqlServerVersion(new Version(10, 4, 22));
//var serverVersion = ServerVersion.AutoDetect(connectionString);

// Connection to students db
builder.Services.AddDbContext<StudentDbContext>(options =>
  options.UseMySql(
      studentConnString,
      ServerVersion.AutoDetect(studentConnString),
      options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
      ));

// Connection to payments db
builder.Services.AddDbContext<PaymentDbContext>(options =>
  options.UseMySql(
      paymentConnString,
      ServerVersion.AutoDetect(paymentConnString),
      options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
      ));

builder.Services.AddControllers();

var app = builder.Build();

// Initilize data in db tables
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Seed Student db
    var studentContext = services.GetRequiredService<StudentDbContext>();
    //studentContext.Database.EnsureCreated();
    StudentDbInitializer.InitializeModelsInDb(studentContext);

    // Seed Payment db
    var paymentContext = services.GetRequiredService<PaymentDbContext>();
    //paymentContext.Database.EnsureCreated();
    PaymentDbInitializer.InitializeModelsInDb(paymentContext);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
*/

app.MapControllers();

app.Run();

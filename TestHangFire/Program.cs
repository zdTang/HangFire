
using Hangfire;

namespace TestHangFire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHangfire(x => x.UseSqlServerStorage("Data Source=.;Initial Catelog=hangfire-webapi-db;Integrated Security=True;Pooling=False"));
            builder.Services.AddHangfireServer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseHangfireDashboard();// WHY We put it here ??

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
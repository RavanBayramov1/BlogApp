
using BlogApp.BL;
using BlogApp.DAL;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BlogDbContext>(opt=> 
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
            });

            builder.Services.AddJwtOptions(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddFluentValidation();
            builder.Services.AddAutoMapper();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CsvHelper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Interface;
using Hospital_Management_System_Web_Api.Service;
using System.Globalization;
using System.Text;
using System.IO;
using CsvHelper.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hospital_Management_System_Web_Api
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


            Doctor doctor1 = new Doctor();
            doctor1.DoctorCertification = File.ReadAllBytes("F:\\Aplicatie\\Hospital Management System_Web Api\\certification\\certification1.png");
            doctor1.DoctorResume = File.ReadAllBytes("F:\\Aplicatie\\Hospital Management System_Web Api\\DoctorResume\\resume1.png");

            //builder.Services.AddScoped<ICSVService, CSVService>();


        }
            
        
    }
}
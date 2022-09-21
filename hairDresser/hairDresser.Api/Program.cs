using hairDresser.Application.Interfaces;
using hairDresser.Infrastructure;
using hairDresser.Infrastructure.Repositories;
using hairDresser.Presentation.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;

//??? Intrebari:
// 1. Cand creez customer, pot sa creez 2 customeri cu proprietati exact la fel. N-ar trebui sa pun ca username-ul sa fie unic?
//^. HairServiceRepository -> GetAllHairServicesByIdsAsync() - merge dar se poate imbunatati dar nu-mi dau seama cum s-o fac intr-un singur query.

//!!! De facut:
// ar trebui sa mut functionalitatea de verificare a cate apppointment-uri are un customer din GetEmployeeFreeIntervalsForAppointmentByDateQueryHandler in CreateAppointmentCommandHandler.
// ? acolo cand creezi un appointment, sa fac mai frumos in categoria de servicii, sa se vada mai ok.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// What I added (START):
// De fiecare data cand vei vedea ca cineva depinde de IHairServiceRepository, creezi o instanta de HairServiceRepository (la fel si pt. restul).
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHairServiceRepository, HairServiceRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IWorkingIntervalRepository, WorkingIntervalRepository>();
builder.Services.AddScoped<IWorkingDayRepository, WorkingDayRepository>();

//Facem legatura cu server-ul nostru din DB.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Adaugam MediatR, care scaneaza toate mesajele (Queries/Commands) si toate handle-urile, de tipul typeof().
// Cu toate ca noi avem mai multe .AddScoped(), adaugam doar unul dintre ele la typeof() si MediatR le scaneaza pe toate din layer-ul de unde typeof() face parte, adica IHairServiceRepository face parte din Application.
builder.Services.AddMediatR(typeof(IHairServiceRepository));

 // Am adaugat AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Am adaugat AddCors ca sa pot face call la API de pe front-end (din Angular).
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.WithOrigins(new string[] { "http://localhost:4200", "http://yourdomain.com" }).AllowAnyMethod().AllowAnyHeader();
        });
});
// What I added (STOP).

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy"); // What I Added (are legatura cu: builder.Services.AddCors(options => etc...).

app.UseAuthorization();

app.UseMyMiddleware(); // What I added.

app.MapControllers();

app.Run();

public partial class Program{ } // What I added.
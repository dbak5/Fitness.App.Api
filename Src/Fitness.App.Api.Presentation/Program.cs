using Fitness.App.Api.Application.BodyPart.Commands;
using Fitness.App.Api.Application.Category.Commands;
using Fitness.App.Api.Application.Equipment.Commands;
using Fitness.App.Api.Application.Exercise.Commands;
using Fitness.App.Api.Application.Pb.Commands;
using Fitness.App.Api.Application.Program.Commands;
using Fitness.App.Api.Application.Workout.Commands;
using Fitness.App.Api.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FitnessAppContext>(config =>
{
    config.UseNpgsql(
        "User ID=postgres;Password=postgres;Host=fitness-sql.home.local;Port=5432;Database=fitness_app;Connection Lifetime=0;");
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblyContaining<AddBodyPartCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<EditBodyPartCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<AddCategoryCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<AddEquipmentCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<AddExerciseCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<AddPbCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<AddProgramCommandHandler>();
    config.RegisterServicesFromAssemblyContaining<AddWorkoutCommandHandler>();
});

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

using Football.Management.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder
//     .Services
//     .Scan(
//         selector => selector
//             .FromAssemblies(
//                 // Infrastructure.AssemblyReference.Assembly,
//                 Football.Management.Persistence.AssemblyReference.Assembly)
//             .AddClasses(false)
//             .AsImplementedInterfaces()
//             .WithScopedLifetime());
builder.Services.AddSingleton<IPlayerRepository, Football.Management.Persistence.Repositories.PlayerRepositoryInMemory>();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Football.Management.Application.AssemblyReference.Assembly));
builder.Services.AddControllers().AddApplicationPart(Football.Management.Presentation.AssemblyReference.Assembly);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

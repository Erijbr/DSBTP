

using Microsoft.EntityFrameworkCore;
using BatimentsApi.Models;
using Microsoft.AspNetCore.Identity;
using batiment.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur.
builder.Services.AddControllers();

// Contexte principal pour les bâtiments
builder.Services.AddDbContext<BatimentContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultBatimentsConnection")));

// Ajouter la configuration CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", // Nom descriptif
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});

// Configurer les options JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //options.JsonSerializerOptions.WriteIndented = true; // Lisibilité du JSON (facultatif)
});
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<EmailService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurer la politique de redirection HTTPS
var app = builder.Build();

// Configurer le pipeline de requêtes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAllOrigins");



app.UseAuthorization();

app.MapControllers();

app.Run();


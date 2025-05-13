// See https://aka.ms/new-console-template for more information

using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
serviceCollection.AddDbContext<DbContext, Context>();
serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
serviceCollection.AddSingleton<Type>(p => typeof(GenericRepository<>));
//add instance of services
serviceCollection.AddScoped<IPrestataireService, PrestataireService>();
serviceCollection.AddScoped<IPrestationService, PrestationService>();



var serviceProvider = serviceCollection.BuildServiceProvider();

var prs = serviceProvider.GetRequiredService<IPrestataireService>();
var presta = serviceProvider.GetRequiredService<IPrestationService>();
var pres = prs.GetAll();
foreach (var p in pres)
{
    Console.WriteLine(p.TarifHoraire);
}

List<Prestataire> yt = prs.GetFirstThreePrestataire();
Console.WriteLine("*********************");

foreach (var p in yt)
{
    Console.WriteLine(p.TarifHoraire);
}
   double yts = prs.GetMoyTarif(1);
Console.WriteLine(yts);
Console.WriteLine("*********************");

var uup = prs.GetById(16).TarifHoraire;
Console.WriteLine(uup);
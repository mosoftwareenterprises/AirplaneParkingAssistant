using AirplaneParkingAssistant.ParkingAssistant;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirplaneParkingAssistant
{
    public class Program
    {
        public static async Task Main( string[] args )
        {
            var builder = WebAssemblyHostBuilder.CreateDefault( args );
            builder.RootComponents.Add<App>( "#app" );

            builder.Services.AddScoped( sp => new HttpClient { BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) } );
            builder.Services.AddScoped<ParkingAssistant.ParkingAssistant>();
            builder.Services.AddScoped<ParkingAssistant.ParkIngAssistantModel>();
            builder.Services.AddSingleton<IDataStore, DataStore>();

            //Note the order here is important. It MUST be smallest parking slot to biggest!
            builder.Services.AddScoped<IParkingRecommender, PropsParkingRecommender>();
            builder.Services.AddScoped<IParkingRecommender, JetParkingRecommender>();
            builder.Services.AddScoped<IParkingRecommender, JumboParkingRecommender>();
            //See above comment!

            await builder.Build().RunAsync();
        }
    }
}
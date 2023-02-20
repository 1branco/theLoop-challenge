using Currency.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Currency
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region configs and DI
            //SETUP CONFIG FILE
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
                        
            //setup our CUSTOM SERVICES AND CONFIGURATION USE
            var serviceProvider = new ServiceCollection()                  
                .AddSingleton<ICurrenciesAPI, CurrenciesAPI>()
                .AddSingleton<IConfiguration>(configuration)
                .BuildServiceProvider();

            #endregion

            //get our custom service
            var bar = serviceProvider.GetService<ICurrenciesAPI>();

            Console.WriteLine("MOEDA: ");
            var moeda = Console.ReadLine();

            float montanteResult = 0;
            do
            {
                Console.WriteLine("MONTANTE: ");
                var montante = Console.ReadLine();

                float.TryParse(montante, out montanteResult);
            }
            while (montanteResult <= 0);

            Console.WriteLine("MOEDA PARA SER CONVERTIDA: ");
            var moedaConverter = Console.ReadLine();

            var result = bar.ConvertCurrency(moeda, montanteResult, moedaConverter);

            if(result.Result.Error > 0)
            {
                Console.WriteLine("\nErro: {0}\n", result.Result.ErrorMessage);
            }
            else
            {
                Console.WriteLine("\nResultado convertido: {0}\n", result.Result.Amount);
            }
        }
    }
}


using ConsoleAppLearning.scratches;

namespace ConsoleAppLearning
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            // PatternsUI.displayPatterns();
            // ProductManagerUI.EntryPoint();
            // ControlFlowExample.SwitchExample();
            // CollectionScratch.play();
            // PetConsoleUi.EntryPoint();
            /*using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<AsyncDemo>();
                })
                .Build();

            var asyncDemo = host.Services.GetRequiredService<AsyncDemo>();
            await asyncDemo.multipleHttpRequests();
            
            await host.RunAsync();*/
            // PetUI petUi = new PetUI();
            // petUi.PetMenu();
            NumberSratch.play();
            
        }
    }
}
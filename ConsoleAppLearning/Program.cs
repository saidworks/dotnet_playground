using ConsoleAppLearning.scratches;

using System.Globalization;
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
            StringsScratch stringsScratch = new StringsScratch();
            string[] strs = ["flower", "flow", "flight"];
            var prefix = stringsScratch.LongestCommonPrefix(strs);
            
            Console.WriteLine(prefix);
            
            decimal price = 123.45m;
            int discount = 50;
            Console.WriteLine($"Price: {price:C} (Save {discount:C})");

            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            string[] orderItems = orderStream.Split(',');
            Dictionary<String, String> orderDictionary = orderItems
                .Select(item =>
                {
                    if (item.Length <= 3 || item.Length > 4)
                    {
                        return new KeyValuePair<string, string>(item, "Error");
                    }
                    else
                    {
                        return new KeyValuePair<string, string>(item, "");
                    }
                }).ToDictionary();
            foreach (var item in orderDictionary)
            {
                Console.WriteLine(item.Key);
                if (item.Value != "")
                {
                    Console.Write(item.Key);
                    Console.WriteLine($" :{
                        item.Value
                    }");
                }
            }
        }
 
    }
}
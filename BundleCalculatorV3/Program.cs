using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Model;
using BundleCalculatorV3.Service;

namespace BundleCalculatorV3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please input your orders like '10 IMG'");
            Console.WriteLine("Input 'OK' in a new line to complete");
            List<string> orders = new List<string>();
            string oneLine = Console.ReadLine();
            while (oneLine.ToUpper() != "OK")
            {
                orders.Add(oneLine.ToUpper());
                oneLine = Console.ReadLine();
            }

            ClientOrder clientOrder = new ClientOrder();

            foreach (var one in orders)
            {
                string[] strOrders = one.Split(' ');
                if (strOrders.Length < 2)
                    continue;
                int posts = 0;
                int.TryParse(strOrders[0], out posts);
                if (posts > 0)
                {
                    MediaOrder mediaOrder = new MediaOrder(strOrders[1].ToUpper(), posts);
                    clientOrder.AddMediaOrder(mediaOrder);
                }
            }
            InitAllMediaBundleItem.Run();
            FilledClientOrder filledClientOrder = ClientOrderCalculator.CalClientOrder(clientOrder);
            Console.WriteLine("\nThe result is......\n");
            Console.WriteLine(filledClientOrder.GetResutlStr());

            Console.ReadKey();
        }
    }
}

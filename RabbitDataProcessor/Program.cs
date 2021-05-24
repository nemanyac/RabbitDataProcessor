using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitDataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting processor");
            var amqpUrl = args[0];

            var publisher = new MassTransitListener(amqpUrl);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.WriteLine("Done processing");
        }
    }
}

using System;
using System.IO;
using System.Threading;

namespace Resin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            if (!Directory.Exists("/sys/class/gpio/gpio18"))
            {
                Console.WriteLine("...about to open pin 18");
                File.WriteAllText("/sys/class/gpio/export", "18");
            }
            else
            {
                Console.WriteLine("...pin is already open");
            }
 
            Console.WriteLine("...specifying direction of Pin 18 as OUT");
            File.WriteAllText("/sys/class/gpio/gpio18/direction", "out");

            while (true)
            {
                Console.WriteLine("...setting output level to " + 1);
                File.WriteAllText("/sys/class/gpio/gpio18/value", "1");
                Thread.Sleep(1000);
                Console.WriteLine("...setting output level to " + 0);
                File.WriteAllText("/sys/class/gpio/gpio18/value", "0");
                Thread.Sleep(1000);    
            }
            
        }
    }
}

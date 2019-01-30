using StackExchange.Redis;
using System;
using System.Threading;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Publisher";

            var connection = ConnectionMultiplexer.Connect("192.168.20.82:6379,abortConnect=false,syncTimeout=3000");

            var publisher = connection.GetSubscriber();

            for (int i = 0; i < 20; i++)
            {
                var count = publisher.Publish("test", $"Message {i+1}");
                Thread.Sleep(10000);
            }

            Console.ReadLine();
        }
    }
}

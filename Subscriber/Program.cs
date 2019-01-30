using StackExchange.Redis;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Subscriber";

            var connection = ConnectionMultiplexer.Connect("192.168.20.82:6379,abortConnect=false,syncTimeout=3000");

            var subscriber = connection.GetSubscriber();

            subscriber.Subscribe("test", (channel, message) => {
                Console.WriteLine("Got notification: " + message);
            });

            Console.ReadLine();
        }
    }
}

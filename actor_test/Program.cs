using System;
using System.Collections.Generic;
using actor_test.actors;
using Akka.Actor;

namespace actor_test
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var system = ActorSystem.Create("TestSystem");
            
            var actorOne = system.ActorOf(Props.Create<ActorOne>(), "Actor-One");
            var actorTwo = system.ActorOf(Props.Create<ActorTwo>(), "Actor-Two");

            var addMessage = new AddMessage
            {
                Values = new List<int>
                {
                    5, 10, 20
                }
            };
            
            Console.WriteLine($"Actor One: {actorOne}");
            actorOne.Tell(SimpleMessage.Print, ActorRefs.NoSender);
            actorOne.Tell(addMessage, ActorRefs.NoSender);

            Console.WriteLine($"Actor Two: {actorTwo}");
            actorTwo.Tell(SimpleMessage.Print, ActorRefs.NoSender);
            
            Console.ReadLine();
        }
    }
}
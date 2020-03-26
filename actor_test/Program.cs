using System;
using Akka.Actor;

namespace actor_test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var system = ActorSystem.Create("TestSystem");
            
            var actorOne = system.ActorOf(Props.Create<ActorOne>(), "Actor-One");
            
            var actorTwo = system.ActorOf(Props.Create<ActorTwo>(), "Actor-Two");
            
            Console.WriteLine($"Actor One: {actorOne}");
            actorOne.Tell(Messages.PrintReference, ActorRefs.NoSender);

            Console.WriteLine($"Actor Two: {actorTwo}");
            actorTwo.Tell(Messages.PrintReference, ActorRefs.NoSender);
            
            Console.ReadLine();
        }
    }
}
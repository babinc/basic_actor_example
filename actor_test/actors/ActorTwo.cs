using System;
using Akka.Actor;

namespace actor_test
{
    public class ActorTwo : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var messageEnum = Common.Instance.UnboxMessage(message);
            
            switch (messageEnum)
            {
                case Messages.PrintReference:
                    IActorRef secondRef = Context.ActorOf(Props.Empty);
                    Console.WriteLine($"Second Ref: {secondRef}");
                    break;
                case Messages.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
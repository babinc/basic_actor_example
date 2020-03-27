using System;
using Akka.Actor;

namespace actor_test.actors
{
    public class ActorTwo : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            EvaluateComplexMessages(message);

            EvaluateSimpleMessages(message);
        }
        
        private static void EvaluateComplexMessages(object message)
        {
        }

        private static void EvaluateSimpleMessages(object message)
        {
            var simpleMessage = Common.Instance.UnboxMessage(message);
            switch (simpleMessage)
            {
                case SimpleMessage.Print:
                    IActorRef secondRef = Context.ActorOf(Props.Empty);
                    Console.WriteLine($"second ref: {secondRef}");
                    break;
                case SimpleMessage.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
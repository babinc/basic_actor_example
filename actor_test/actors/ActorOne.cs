using System;
using System.Linq;
using Akka.Actor;

namespace actor_test.actors
{
    public class ActorOne : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            EvaluateComplexMessages(message);

            EvaluateSimpleMessages(message);
        }

        private static void EvaluateComplexMessages(object message)
        {
            if (message is AddMessage addMessage)
            {
                var sum = addMessage.Values.Sum();

                Console.WriteLine($"Sum: {sum}");
            }
        }

        private static void EvaluateSimpleMessages(object message)
        {
            var simpleMessage = Common.Instance.UnboxMessage(message);
            switch (simpleMessage)
            {
                case SimpleMessage.Print:
                    var secondRef = Context.ActorOf(Props.Empty);
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
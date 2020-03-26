namespace actor_test
{
    public sealed class Common
    {
        private static Common _instance = null;
        private static readonly object Padlock = new object();

        public Common()
        {
        }

        public Messages UnboxMessage(object message)
        {
            return message is Messages ? (Messages) message : Messages.None;
        }

        public static Common Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Common();
                    }
                    return _instance;
                }
            }
        }
    }
}
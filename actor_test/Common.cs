namespace actor_test
{
    public sealed class Common
    {
        #region field
        private static Common _instance = null;
        private static readonly object Padlock = new object();
        #endregion
        
        #region Properties
        #endregion

        #region Constructor
        public Common()
        {
        }
        #endregion

        #region methods
        public SimpleMessage UnboxMessage(object message)
        {
            return message is SimpleMessage ? (SimpleMessage) message : SimpleMessage.None;
        }
        #endregion

        #region static methods
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
        #endregion
    }
}
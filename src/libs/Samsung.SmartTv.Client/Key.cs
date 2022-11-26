using Samsung.SmartTv.Client.Text;

namespace Samsung.SmartTv.Client
{
    /// <summary>
    /// Remote control key.
    /// </summary>
    public class Key
    {
        public static readonly Key Power = new Key(SmartTvClientConstants.Keys.Power);
        public static readonly Key Home = new Key(SmartTvClientConstants.Keys.Home);
        public static readonly Key Menu = new Key(SmartTvClientConstants.Keys.Menu);
        public static readonly Key Source = new Key(SmartTvClientConstants.Keys.Source);
        public static readonly Key Guide = new Key(SmartTvClientConstants.Keys.Guide);
        public static readonly Key Tools = new Key(SmartTvClientConstants.Keys.Tools);
        public static readonly Key Info = new Key(SmartTvClientConstants.Keys.Info);
        public static readonly Key Up = new Key(SmartTvClientConstants.Keys.Up);
        public static readonly Key Down = new Key(SmartTvClientConstants.Keys.Down);
        public static readonly Key Left = new Key(SmartTvClientConstants.Keys.Left);
        public static readonly Key Right = new Key(SmartTvClientConstants.Keys.Right);
        public static readonly Key Enter = new Key(SmartTvClientConstants.Keys.Enter);
        public static readonly Key Return = new Key(SmartTvClientConstants.Keys.Return);
        public static readonly Key ChannelList = new Key(SmartTvClientConstants.Keys.ChannelList);
        public static readonly Key ChannelUp = new Key(SmartTvClientConstants.Keys.ChannelUp);
        public static readonly Key ChannelDown = new Key(SmartTvClientConstants.Keys.ChannelDown);
        public static readonly Key VolumeUp = new Key(SmartTvClientConstants.Keys.VolumeUp);
        public static readonly Key VolumeDown = new Key(SmartTvClientConstants.Keys.VolumeDown);
        public static readonly Key Mute = new Key(SmartTvClientConstants.Keys.Mute);
        public static readonly Key Red = new Key(SmartTvClientConstants.Keys.Red);
        public static readonly Key Green = new Key(SmartTvClientConstants.Keys.Green);
        public static readonly Key Yellow = new Key(SmartTvClientConstants.Keys.Yellow);
        public static readonly Key Blue = new Key(SmartTvClientConstants.Keys.Blue);

        /// <summary>
        /// Creates channel key.
        /// </summary>
        /// <param name="number">Channel number.</param>
        /// <returns>Channel numeric key.</returns>
        public static Key GetChannelNumericKey(ushort number) => new Key(SmartTvClientConstants.Keys.CustomKeyPrefix + number);

        public string Value { get; }

        internal Key(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new StringNullOrEmptyException(nameof(value));

            Value = value;
        }

        public static implicit operator string(Key k) => k.Value;

        public override string ToString() => Value;
    }
}
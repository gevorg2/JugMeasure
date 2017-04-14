namespace JugMeasure.Core
{
    public struct Capacity
    {
        public Capacity(ushort v)
        {
            this.Value = v;
        }

        public ushort Value { get; }

        public static bool operator <(Capacity x, Capacity y)
        {
            return x.Value < y.Value;
        }

        public static bool operator >(Capacity x, Capacity y)
        {
            return x.Value > y.Value;
        }

        public static Capacity operator -(Capacity x, Capacity y)
        {
            if (x < y)
                return new Capacity(0);
            return new Capacity((ushort) (x.Value - y.Value));
        }

        public static Capacity operator +(Capacity x, Capacity y)
        {
            return new Capacity((ushort)(x.Value + y.Value));
        }

        public static bool operator ==(Capacity x, Capacity y)
        {
            return x.Value == y.Value;
        }

        public static bool operator !=(Capacity x, Capacity y)
        {
            return !(x == y);
        }
    }
}
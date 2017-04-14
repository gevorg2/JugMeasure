namespace JugMeasure.Core
{
    public struct Capacity
    {
        public Capacity(uint v)
        {
            this.Value = v;
        }

        public uint Value { get; }

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
            return new Capacity((uint) (x.Value - y.Value));
        }

        public static Capacity operator +(Capacity x, Capacity y)
        {
            return new Capacity((uint)(x.Value + y.Value));
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
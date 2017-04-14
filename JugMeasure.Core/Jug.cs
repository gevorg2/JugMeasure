using System;
using System.Collections.Generic;
using System.Text;

namespace JugMeasure.Core
{
    public struct Jug
    {
        public Jug(ushort capasity, string name) : this(new Capacity(capasity), name)
        {
        }
        public Jug(Capacity capasity, string name)
        {
            this.Capacity = capasity;
            this.Name = name;
            this.FilledCapacity = new Capacity(0);
        }
        public string Name { get; private set; } //identifier 
        public Capacity Capacity { get; }
        public Capacity FilledCapacity { get; private set; }

        public Capacity FreeCapacity => Capacity - FilledCapacity;

        public bool IsEmpty => FilledCapacity.Value == 0;
        public bool IsFull => Capacity == FilledCapacity;

        public void Fill()
        {
            FilledCapacity = Capacity;
        }

        public void Fill(Capacity capacity)
        {
            FilledCapacity += capacity;
            if (FilledCapacity > Capacity)
                FilledCapacity = Capacity;
        }

        public void Empty()
        {
            FilledCapacity = new Capacity(0);
        }

        public void Empty(Capacity capacity)
        {
            FilledCapacity -= capacity;
        }
        
    }
}

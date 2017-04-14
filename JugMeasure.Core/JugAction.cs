using System;
using System.Net.Sockets;

namespace JugMeasure.Core
{
    public class JugAction
    {
        public JugAction(Jug? from, Jug? to)
        {
            if(from == null && to == null)
                throw new ArgumentNullException();
            From = @from;
            To = @to;
        }

        public Jug? From { get; set; }
        public Jug? To { get; set; }

        public override string ToString()
        {
            return $"{From.Value.Name}{To.Value.Name}";
        }

        public JugAction Perform()
        {
            if (From == null)
            {
                var t = To.Value;
                t.Fill();
                return new JugAction(null, t);
            }
            if (To == null)
            {
                var f = From.Value;
                f.Empty();
                return new JugAction(f, null);
            }
            var from = From.Value;
            var to = To.Value;
            var capToFill = from.FilledCapacity;
            from.Empty(to.FreeCapacity);
            to.Fill(capToFill);
            return new JugAction(from, to);
        }
    }
}
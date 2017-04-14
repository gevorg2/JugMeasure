using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace JugMeasure.Core
{
    public class JugMeasureService : IJugMeasureService
    {
        public MeasureReslut ReverseMeasure(Jug jug1, Jug jug2, Capacity amount)
        {
            return Measure(jug2, jug1, amount);
        }
        public MeasureReslut Measure(Jug jug1, Jug jug2, Capacity amount)
        {
            var repeatCount = 0;
            List<JugAction> jugActions = new List<JugAction>();
            while (jug1.FilledCapacity != amount && jug2.FilledCapacity != amount)
            {
                JugAction action = null;
                if (jug1.IsEmpty)
                    action = new JugAction(null, jug1);
                else if (jug2.IsFull)
                    action = new JugAction(jug2, null);
                else
                    action = new JugAction(jug1, jug2);

                if (jug1.IsFull && jug2.IsEmpty)
                    repeatCount++;
                if (repeatCount >= 2)
                    return null;
                jugActions.Add(action);
                var pAction = action.Perform();
                if (pAction.From != null)
                {
                    if (pAction.From.Value.Name == jug1.Name)
                        jug1 = pAction.From.Value;
                    else
                        jug2 = pAction.From.Value;
                }
                if (pAction.To != null)
                {
                    if (pAction.To.Value.Name == jug1.Name)
                        jug1 = pAction.To.Value;
                    else
                        jug2 = pAction.To.Value;
                }
            }
            return new MeasureReslut(jugActions);
        }

        public async Task<MeasureReslut> MeasureAsync(Jug jug1, Jug jug2, Capacity amount)
        {
            return await Task.Run(() => Measure(jug1, jug2, amount));
        }

        public async Task<MeasureReslut> ReverseMeasureAsync(Jug jug1, Jug jug2, Capacity amount)
        {
            return await Task.Run(() => ReverseMeasure(jug1, jug2, amount));
        }
    }
}

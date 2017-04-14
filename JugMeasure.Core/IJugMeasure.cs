using System.Collections.Generic;

namespace JugMeasure.Core
{
    public interface IJugMeasure
    {
        MeasureReslut Measure(Jug jug1, Jug jug2, Capacity amount);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JugMeasure.Core
{
    public interface IJugMeasureService
    {
        Task<MeasureReslut> MeasureAsync(Jug jug1, Jug jug2, Capacity amount);
        MeasureReslut Measure(Jug jug1, Jug jug2, Capacity amount);
        MeasureReslut ReverseMeasure(Jug jug1, Jug jug2, Capacity amount);
        Task<MeasureReslut> ReverseMeasureAsync(Jug jug1, Jug jug2, Capacity amount);
    }
}
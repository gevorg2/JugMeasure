using System;
using System.Collections.Generic;

namespace JugMeasure.Core
{
    public class MeasureReslut
    {
        public MeasureReslut(List<JugAction> jugActions)
        {
            Actions = jugActions;
        }

        public IList<JugAction> Actions { get; set; }
    }
}
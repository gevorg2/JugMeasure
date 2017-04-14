using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JugMeasure.Api.Models;
using JugMeasure.Core;
using Microsoft.AspNetCore.Mvc;

namespace JugMeasure.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ValidateModel]
    public class JugMeasureController : Controller
    {
        private readonly IJugMeasureService _jugMeasureService;

        public JugMeasureController(IJugMeasureService jugMeasureService)
        {
            _jugMeasureService = jugMeasureService;
        }

        [HttpPost]
        public async Task<IEnumerable<JugActionModel>> Measure([FromBody]JugMeasureModel model)
        {
            var res = await _jugMeasureService.MeasureAsync(new Jug(model.Jug1,model.Jug1Name), new Jug(model.Jug2, model.Jug2Name), new Capacity(model.Amount));
            return res?.Actions?.Select(a => new JugActionModel(){From = a.From?.Name, To = a.To?.Name});
        }

        [HttpPost]
        public async Task<IEnumerable<JugActionModel>> ReverseMeasure([FromBody]JugMeasureModel model)
        {
            var res = await _jugMeasureService.ReverseMeasureAsync(new Jug(model.Jug1, model.Jug1Name), new Jug(model.Jug2, model.Jug2Name), new Capacity(model.Amount));
            return res?.Actions?.Select(a => new JugActionModel() { From = a.From?.Name, To = a.To?.Name });
        }
    }
}

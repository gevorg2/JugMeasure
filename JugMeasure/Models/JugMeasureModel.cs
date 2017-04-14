using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JugMeasure.Api.Models
{
    public class JugMeasureModel
    {
        [Required]
        public uint Jug1 { get; set; }
        [Required]
        public string Jug1Name { get; set; }
        [Required]
        public uint Jug2 { get; set; }
        [Required]
        public string Jug2Name { get; set; }
        [Required]
        public uint Amount { get; set; }
    }
}

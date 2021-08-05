using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoFinalAP2.Models
{
    public class MatchGame
    {
        [Key]
        public int MatchGameId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio, debe llenarlo.")]
        public string Jugador { get; set; }
        public string TimeDisplay { get; set; }
        public string Estilo { get; set; }
        public string Dificultad { get; set; }

        public double Tiempo
        {
            get { return Convert.ToDouble(this.TimeDisplay.Replace("s", "")); }
        }
    }
}

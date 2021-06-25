using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.InputModel
{
    public class RacingInputModel
    {
        internal double Hour;

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do País da corrida deve conter entre 3 e 100 caracteres")]
        public string Country { get; set; }        
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do Cidade da corrida deve conter entre 3 e 100 caracteres")]
        public string City { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Data Inválida")]
        public  int Date { get; set; }

    }
}

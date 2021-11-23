using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "Amount must be greater than 0")]
        public double Value { get; set; }
    }
}

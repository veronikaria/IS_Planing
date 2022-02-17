using Microsoft.AspNetCore.Authorization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPlaning.Models
{
    public class Chart
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Назва")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

    }
}

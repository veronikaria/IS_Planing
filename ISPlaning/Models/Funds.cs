using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPlaning.Models
{
    public class Funds
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва предмету")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Display(Name = "Кошти")]
        [Column(TypeName = "money")]
        public decimal Uah { get; set; }
    }
}

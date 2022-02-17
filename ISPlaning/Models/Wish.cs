using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPlaning.Models
{
    public class Wish
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Назва бажання")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        
        [Display(Name = "Опис бажання")]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        
    }
}

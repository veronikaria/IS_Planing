using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPlaning.Models
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Поле Назва є обовязковим")]
        [Display(Name = "Назва цілі")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Display(Name = "Пріоритетність")]
        public int Priority { get; set; }

        [Display(Name = "Причина")]
        [Column(TypeName = "nvarchar(200)")]
        public string Reason { get; set; }
        
        [Display(Name = "Результат")]
        [Column(TypeName = "nvarchar(200)")]
        public string Result { get; set; }
        
        [Display(Name = "Нагороди")]
        [Column(TypeName = "nvarchar(200)")]
        public string Awards { get; set; }
        
        [Display(Name = "Стан")]
        [Column("State", TypeName = "nvarchar(30)")]
        public StateGoal State { get; set; }
    }
}

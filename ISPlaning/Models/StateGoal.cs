using System.ComponentModel.DataAnnotations;

namespace ISPlaning.Models
{
    public enum StateGoal
    {
        [Display(Name = "Нове")]
        New,
        [Display(Name = "Досягнуте")]
        During,
        [Display(Name = "В процесі")]
        Archived
    }
}

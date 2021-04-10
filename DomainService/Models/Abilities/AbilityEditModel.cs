using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class AbilityEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public MajorType MajorId { get; set; }
        [Required, DisplayName("Имя")]
        public string Name { get; set; }
        [Required, DisplayName("Символ")]
        public AbilityType Type { get; set; }
        [Required, StringLength(6), DisplayName("Цвет")]
        public string Color { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Влияние")]
        public string Influence { get; set; }
    }
}
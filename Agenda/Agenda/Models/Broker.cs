using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Agenda.Models
{
    public partial class Broker
    {
        public Broker()
        {
            Appointments = new HashSet<Appointment>();
        }


        [Key]
        public int IdBroker { get; set; }

        [Required(ErrorMessage = "Nom manquant")]
        [Display(Name = "Nom")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Prénom manquant")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Adresse mail manquante")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse mail")]
        public string Mail { get; set; } = null!;

        [Required(ErrorMessage = "Téléphone manquant")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[0]{1}[1-7]{1}[0-9]{8}", ErrorMessage = "Numéro invalide")]
        [Display(Name = "Téléphone")]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

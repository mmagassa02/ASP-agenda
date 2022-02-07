using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agenda.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Nom manquant")]
        [Display(Name ="Nom")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Prénom manquant")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Adresse mail manquante")]
        [EmailAddress (ErrorMessage ="Le champ Email n'est pas valide")]
        [Display(Name = "Adresse mail")]
        public string Mail { get; set; } = null!;

        [Required(ErrorMessage = "Téléphone manquant")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[0]{1}[1-7]{1}[0-9]{8}", ErrorMessage = "Numéro invalide")]
        [Display(Name = "Téléphone")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Budget manquant")]
        public int Budget { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

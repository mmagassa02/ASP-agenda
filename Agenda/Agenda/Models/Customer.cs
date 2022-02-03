using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Lastname missing")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Firstname missing")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Email missing")]
        public string Mail { get; set; } = null!;


        [Required(ErrorMessage = "Phone number missing")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[0]{1}[1-7]{1}[0-9]{8}", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Budget missing")]
        public int Budget { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

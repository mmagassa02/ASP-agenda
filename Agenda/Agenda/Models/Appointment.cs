using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agenda.Models
{
    public partial class Appointment
    {
        [Key]
        public int IdAppointment { get; set; }

        [Required]
        public DateTime DateHour { get; set; }

        [Required]
        public string Subject { get; set; } = null!;

        public int IdBroker { get; set; }

        public int IdCustomer { get; set; }

        public virtual Broker IdBrokerNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}

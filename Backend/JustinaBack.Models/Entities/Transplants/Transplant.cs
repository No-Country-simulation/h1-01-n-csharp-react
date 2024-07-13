using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Transplants
{
    public class Transplant : BaseEntity<Guid>
    {
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public Urgency Urgency { get; set; }

        public Donor Donor { get; set; }
        public Guid DonorId { get; set; }
        public Recipient Recipient { get; set; }
        public Guid RecipientId { get; set; }
    }

    public enum Urgency
    {
        Immediate,
        Emergency,
        Urgent,
        SemiUrgent,
        NonUrgent,
        Finished
    }
}

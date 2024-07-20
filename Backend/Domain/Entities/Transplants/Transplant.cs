using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transplants
{
    public class Transplant : BaseEntity<int>
    {
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public Urgency Urgency { get; set; }

        public Donor Donor { get; set; }
        public int DonorId { get; set; }
        public Recipient Recipient { get; set; }
        public int RecipientId { get; set; }
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

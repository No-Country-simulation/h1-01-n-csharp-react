using JustinaBack.Models.Entities.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class Lab : BaseEntity<int>
    {
        public DateTime OpensAt { get; set; }
        public DateTime ClosesAt { get; set; }
        public LabType LabType { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public List<Medicine> Medicines { get; set; }
    }

    public enum LabType
    {
        Analysis,
        Preparation
    }
}

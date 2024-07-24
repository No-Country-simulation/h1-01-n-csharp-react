using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Medicine
{
    public class MedicineGetDto
    {
        public int Id { get; set; }
        public int CertificateNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

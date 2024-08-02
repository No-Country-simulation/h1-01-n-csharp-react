using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Document
{
    public class DocumentGetDto
    {
        public int Id { get; set; }
        public string DocSrc { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

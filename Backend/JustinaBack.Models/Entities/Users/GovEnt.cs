using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class GovEnt : BaseEntity<Guid>
    {
        public string ImgSrc { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; }
    }
}

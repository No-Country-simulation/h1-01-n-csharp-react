using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class GovEnt : BaseEntity<int>
    {
        public string ImgSrc { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; }
    }
}

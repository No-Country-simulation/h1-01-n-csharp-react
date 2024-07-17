using JustinaBack.Models.Entities.Users;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JustinaBack.Models.Entities.Medical
{
    public class Specialty : BaseEntity<int>
    {
        public string Type { get; set; }

        public List<Medic> Medics { get; set; }
    }
}

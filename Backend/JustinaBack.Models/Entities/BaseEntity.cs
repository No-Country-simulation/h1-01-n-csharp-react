using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}

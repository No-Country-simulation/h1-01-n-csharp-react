﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class Admin : BaseEntity<Guid>
    {
        public ApplicationUser ApplicationUser { get; set; }
    }
}

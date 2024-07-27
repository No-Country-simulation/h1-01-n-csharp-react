﻿using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IMedicPatientRepository : IGenericRepository<MedicPatient, int>
    {
        Task<MedicPatient> FindRelationship(int medicId, int patientId);
    }
}

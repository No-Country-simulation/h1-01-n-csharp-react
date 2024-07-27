﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IMedicPatientService
    {
        Task<ServiceResponse<bool>> AddRelationshipWithPatient(int medicId, int patientId);
    }
}
using Core.Services.Interfaces;
using DTOs;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MedicPatientService : IMedicPatientService
    {
        private readonly ILogger<MedicPatientService> _logger;
        private readonly IMedicPatientRepository _medicPatientRepository;

        public MedicPatientService(
            ILogger<MedicPatientService> logger,
            IMedicPatientRepository medicPatientRepository)
        {
            _logger = logger;
            _medicPatientRepository = medicPatientRepository;
        }

        public async Task<ServiceResponse<bool>> AddRelationshipWithPatient(int medicId, int patientId)
        {
            return null;
        }
    }
}

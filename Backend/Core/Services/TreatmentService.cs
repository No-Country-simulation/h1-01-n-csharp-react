using Core.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ILogger<TreatmentService> _logger;
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ILogger<TreatmentService> logger, ITreatmentRepository treatmentRepository)
        {
            _logger = logger;
            _treatmentRepository = treatmentRepository;
        }
    }
}

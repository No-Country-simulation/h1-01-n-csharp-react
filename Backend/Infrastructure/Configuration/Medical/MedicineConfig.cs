using Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Medical
{
    public class MedicineConfig : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasData(
                new Medicine { Id = 1, CertificateNumber = 52692, Name = "MEPREDNISONA VARIFARMA", Description = "Comprimido Prednisona 4 Mg" },
                new Medicine { Id = 2, CertificateNumber = 58033, Name = "INMUNOSPORIN", Description = "Solución Oftálmica Ciclosporina 0.1 g %" },
                new Medicine { Id = 3, CertificateNumber = 54912, Name = "PARACETAMOL SCHAFER 500", Description = "Comprimido Paracetamol 500 Mg" },
                new Medicine { Id = 4, CertificateNumber = 55318, Name = "IBUPROFENO TAURO", Description = "Comprimido Ibuprofeno 400 Mg" },
                new Medicine { Id = 5, CertificateNumber = 54155, Name = "FLEXIPLEN", Description = "Comprimido con cubierta entérica. Diclofenaco sódico 75 Mg" },
                new Medicine { Id = 6, CertificateNumber = 52651, Name = "FABAMOX", Description = "Comprimido recubierto. Amoxicilina 500 Mg" },
                new Medicine { Id = 7, CertificateNumber = 54546, Name = "GENOPRAZOL", Description = "Omeprazol 20 Mg" },
                new Medicine { Id = 8, CertificateNumber = 40562, Name = "ENALAPRIL RICHET", Description = "Comprimido. Enalapril Maleato 10 Mg" },
                new Medicine { Id = 9, CertificateNumber = 44390, Name = "PAXON 50", Description = "Losartán Potásico 50 Mg" },
                new Medicine { Id = 10, CertificateNumber = 44497, Name = "STOPALER", Description = "Comprimido Cetirizina Diclorhidrato 10 Mg" }
            );
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configurations
{
    internal class PrestationConiguration : IEntityTypeConfiguration<Prestation>
    {
        public void Configure(EntityTypeBuilder<Prestation> builder)
        {
            builder.HasOne(p => p.prestataire).
                WithMany(p => p.prestations).HasForeignKey(p => p.PrestataireFK);


            builder.HasOne(p => p.client).
                    WithMany(p => p.prestations).HasForeignKey(p => p.ClientFK);
            builder.HasKey(p => new { p.PrestataireFK, p.ClientFK, p.HeureDebut });

        }
    }
}

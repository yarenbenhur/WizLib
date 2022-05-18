using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentDetailConfig : IEntityTypeConfiguration<Fluent_Detail>
    {
        public void Configure(EntityTypeBuilder<Fluent_Detail> modelBuilder)
        {
            //BookDetails
            modelBuilder.HasKey(b => b.Detail_Id);
            modelBuilder.Property(b => b.NumberOfChapters).IsRequired();



        }
    }
}

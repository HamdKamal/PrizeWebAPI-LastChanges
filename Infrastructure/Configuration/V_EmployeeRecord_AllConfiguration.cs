using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class V_EmployeeRecord_AllConfiguration : IEntityTypeConfiguration<VEmployeeRecordAll>
    {
        public void Configure(EntityTypeBuilder<VEmployeeRecordAll> builder)
        {
            builder.HasNoKey();
            builder.ToView("VEmployeeRecordAll", "dbo");
        }
    }

}

﻿using EntityConsoleApp3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //builder.HasKey(a => a.ID)

            //builder.Property(a => a.Name)
            //.IsRequired()
            //.HasMaxLength(50)
            //.IsUnicode(false);

            //builder.Property(a => a.year)
            //    .HasDefaultValue(DateTime.NOW.Year)
            //            //.HasAnnotation("Range",minand maz);
        }
    }
}

﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Instrastructure.Persistence.Configurations
{
    public class ProjectCommentsConfigurations : IEntityTypeConfiguration<ProjectComments>
    {
        public void Configure(EntityTypeBuilder<ProjectComments> builder)
        {
            builder
             .HasKey(p => p.Id);

            builder
              .HasOne(p => p.Project)
              .WithMany(p => p.Comments)
              .HasForeignKey(p => p.IdProject)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(p => p.User)
             .WithMany(u => u.Comments)
             .HasForeignKey(p => p.IdUser)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

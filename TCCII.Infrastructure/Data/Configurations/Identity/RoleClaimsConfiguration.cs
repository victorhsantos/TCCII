﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Core.Entities.Identity;

namespace TCCII.Infrastructure.Data.Configurations.Identity
{
    public class RoleClaimsConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder
                .ToTable("RoleClaim");

            builder
                .HasOne(roleClaim => roleClaim.Role)
                .WithMany(role => role.Claims)
                .HasForeignKey(roleClaim => roleClaim.RoleId);
        }
    }
}

﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NC_H_FISC.Models
{
    public partial class NC_H_FISCContext : DbContext
    {
        public NC_H_FISCContext()
        {
        }

        public NC_H_FISCContext(DbContextOptions<NC_H_FISCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banktab> Banktab { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=NC_H_FISC;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Banktab>(entity =>
            {
                entity.HasKey(e => e.Bankcode);

                entity.ToTable("BANKTAB");

                entity.Property(e => e.Bankcode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("BANKCODE");

                entity.Property(e => e.Bankname)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("BANKNAME");

                entity.Property(e => e.Telno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELNO");

                entity.Property(e => e.Telzone)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TELZONE");

                entity.Property(e => e.Updatedate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEDATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
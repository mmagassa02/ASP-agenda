using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Agenda.Models
{
    public partial class agendaContext : DbContext
    {
        public agendaContext()
        {
        }

        public agendaContext(DbContextOptions<agendaContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Broker> Brokers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=agenda;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("Appointments_PK");

                entity.Property(e => e.IdAppointment).ValueGeneratedNever();

                entity.Property(e => e.DateHour).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasColumnType("text");

                entity.HasOne(d => d.IdBrokerNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdBroker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Appointments_Brokers_FK");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Appointments_Customers0_FK");
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.HasKey(e => e.IdBroker)
                    .HasName("Brokers_PK");

                entity.Property(e => e.IdBroker).ValueGeneratedNever();

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("Customers_PK");

                entity.Property(e => e.IdCustomer).ValueGeneratedNever();

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TekstilCekiHazirlama
{
    /// <summary>
    /// Represents a delivery note document saved in the database.
    /// </summary>
    public class DeliveryNote
    {
        public int Id { get; set; }

        [Required]
        public string DocumentNo { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string ReceiverName { get; set; } = string.Empty;

        public int TotalRoll { get; set; }

        public decimal TotalKg { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<DeliveryNoteItem> Items { get; set; } = new();
    }

    public class DeliveryNoteItem
    {
        public int Id { get; set; }

        public int DeliveryNoteId { get; set; }

        public int LineNo { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int RollCount { get; set; }

        public decimal Kg { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public DeliveryNote? DeliveryNote { get; set; }
    }

    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<DeliveryNote> DeliveryNotes { get; set; } = null!;
        public DbSet<DeliveryNoteItem> DeliveryNoteItems { get; set; } = null!;

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kumas-ceki.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryNote>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DocumentNo).IsRequired();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<DeliveryNoteItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.DeliveryNote)
                      .WithMany(d => d.Items)
                      .HasForeignKey(e => e.DeliveryNoteId)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            });
        }
    }

    public class AppSettings
    {
        public string CompanyName { get; set; } = "Firma Adı";
        public string CompanyAddress { get; set; } = "Firma Adresi";
        public string CompanyPhone { get; set; } = "Telefon";
        public string? LogoPath { get; set; }
    }
}

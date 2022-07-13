using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalReceipts
{
    public class ReceiptsContext : DbContext
    {
        public DbSet<ReceiptRecord> Receipts { get; set; }

        public string DbPath { get; }

        private string connectionString;

        public ReceiptsContext()
        {
            string username = Properties.Settings.Default.DatabaseUsername;
            string password = Properties.Settings.Default.DatabasePassword;
            string address = Properties.Settings.Default.DatabaseIP;
            string port = Properties.Settings.Default.DatabasePort;
            string table = Properties.Settings.Default.DatabaseTable;
            connectionString = $"server={address};port={port};database={table};user={username};password={password}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiptRecord>()
                .HasKey(x => x.Id);
        }
    }

    public class ReceiptRecord
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string? Reference { get; set; }
        public string PaymentType { get; set; }
        public string Signature { get; set; }
        public string? Tenant { get; set; }
    }
}

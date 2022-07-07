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

        public ReceiptsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "receipts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }

    public class ReceiptRecord
    {
        public int Id { get; set; }
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

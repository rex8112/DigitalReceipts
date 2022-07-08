using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalReceipts
{
    public class Receipt
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public string Sign { get; set; }
        public string? Tenant { get; set; }

        public Receipt(decimal amt, DateTime date, string from, string address, string remarks, string? reference, string type, string sign)
        {
            this.Id = 0;
            this.Amount = amt;
            this.Date = date;
            this.From = from;
            this.Address = address;
            this.Remarks = remarks;
            this.Type = type;
            this.Sign = sign;
            this.Reference = reference;
        }

        public Receipt(decimal amt, DateTime date, string from, string address, string remarks, string? reference, string type, string sign, string? tenant) :
            this(amt, date, from, address, remarks, reference, type, sign)
        {
            this.Tenant = tenant;
            if (this.Tenant == "")
                this.Tenant = null;
        }
        public Receipt(ReceiptRecord record) :
            this
            (
                record.Amount,
                record.Date,
                record.From,
                record.Address,
                record.Remarks,
                record.Reference,
                record.PaymentType,
                record.Signature,
                record.Tenant
            )
        {
            this.Id = record.Id;
        }

        public ReceiptRecord GetDatabaseSet()
        {
            ReceiptRecord receiptRecord = new ReceiptRecord
            {
                From = this.From,
                Amount = this.Amount,
                Address = this.Address,
                Remarks = this.Remarks,
                Reference = this.Reference,
                PaymentType = this.Type,
                Signature = this.Sign,
                Tenant = this.Tenant,
                Date = this.Date
            };
            return receiptRecord;
        }
    }
}

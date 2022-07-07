using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalReceipts
{
    public class Receipt
    {
        public decimal Amount;
        public DateTime Date;
        public string From;
        public string Address;
        public string Remarks;
        public string Reference;
        public string Type;
        public string Sign;
        public string? Tenant;

        public Receipt(decimal amt, DateTime date, string from, string address, string remarks, string reference, string type, string sign)
        {
            this.Amount = amt;
            this.Date = date;
            this.From = from;
            this.Address = address;
            this.Remarks = remarks;
            this.Type = type;
            this.Sign = sign;
            this.Reference = reference;
        }

        public Receipt(decimal amt, DateTime date, string from, string address, string remarks, string reference, string type, string sign, string tenant) :
            this(amt, date, from, address, remarks, reference, type, sign)
        {
            this.Tenant = tenant;
            if (this.Tenant == "")
                this.Tenant = null;
        }

        public ReceiptRecord GetDatabaseSet()
        {
            ReceiptRecord receiptRecord = new ReceiptRecord
            {
                From = this.From,
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

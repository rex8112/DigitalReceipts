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
        public string From;
        public string Address;
        public string Remarks;
        public string Type;
        public string Sign;
        public string? Tenant;

        public Receipt(decimal amt, string from, string address, string remarks, string type, string sign)
        {
            this.Amount = amt;
            this.From = from;
            this.Address = address;
            this.Remarks = remarks;
            this.Type = type;
            this.Sign = sign;
        }

        public Receipt(decimal amt, string from, string address, string remarks, string type, string sign, string tenant) :
            this(amt, from, address, remarks, type, sign)
        {
            this.Tenant = tenant;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace kasir.Model
{
    public class Voucher
    {
        public string voucher { get; set; }
        public double potongan { get; set; }

        public Voucher(string voucher, double potongan)
        {
            this.voucher = voucher;
            this.potongan = potongan;
        }
    }
}

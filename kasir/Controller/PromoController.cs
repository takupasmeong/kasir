using System;
using System.Collections.Generic;
using System.Text;
using kasir.Model;

namespace kasir.Controller
{
    class PromoController
    {
        public List<Voucher> diskon;

        public PromoController()
        {
            diskon = new List<Voucher>();
        }

        public void addPromo(Voucher diskon)
        {
            this.diskon.Add(diskon);
        }

        public List<Voucher> getDiskon()
        {
            return this.diskon;
        }
    }
}

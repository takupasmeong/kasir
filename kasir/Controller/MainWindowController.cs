using System;
using System.Collections.Generic;
using System.Text;
using kasir.Model;

namespace kasir.Controller
{
    class MainWindowController
    {
        KeranjangBelanja keranjangBelanja;


        public MainWindowController(KeranjangBelanja keranjangBelanja, Payment payment)
        {
            this.keranjangBelanja = keranjangBelanja;
        }

        public void addItem(Item item)
        {
            this.keranjangBelanja.addItem(item);
        }

        public void removeItem(Item item)
        {
            this.keranjangBelanja.removeItem(item);
        }

        public List<Item> getItems()
        {
            return this.keranjangBelanja.getItems();
        }

        public void addDiskon(Voucher diskon)
        {

            this.keranjangBelanja.addDiskon(diskon);
        }

        public List<Voucher> getDiskon()
        {
            return this.keranjangBelanja.getDiskon();
        }

    }
}

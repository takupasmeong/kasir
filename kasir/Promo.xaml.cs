using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using kasir.Controller;
using kasir.Model;

namespace kasir
{
    /// <summary>
    /// Interaction logic for Promo.xaml
    /// </summary>
    public partial class Promo : Window
    {
        PromoController promoController;
        OnPromoChangedListener promoListener;
        public Promo()
        {
            InitializeComponent();
            promoController = new PromoController();
            listBoxDaftarPromo.ItemsSource = promoController.getDiskon();

            generateContentPromo();
        }
        public void SetOnPromoSelectedListener(OnPromoChangedListener promoListener)
        {
            this.promoListener = promoListener;
        }

        private void generateContentPromo()
        {
            Voucher diskon1 = new Voucher("Promo Awal tahun Diskon 25 % ", 25000);
            Voucher diskon2 = new Voucher("Promo Tebus Murah Diskon 30 % atau maksimal 30.000", 30000);
            Voucher diskon3 = new Voucher("Promo Natal Potongan 10000", 10000);

            promoController.addPromo(diskon1);
            promoController.addPromo(diskon2);
            promoController.addPromo(diskon3);

            listBoxDaftarPromo.Items.Refresh();
        }

        private void onlistBoxDaftarPromoClicked(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Voucher diskon = listbox.SelectedItem as Voucher;
            this.promoListener.OnPromoSelected(diskon);
            this.Close();
        }
    }
    public interface OnPromoChangedListener
    {
        void OnPromoSelected(Voucher diskon);
    }
}

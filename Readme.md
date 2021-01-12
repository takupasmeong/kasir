# Study Case : Cashier
aplikasi kasir cafe sederhana untuk memenuhi tugas UAS. Memiliki fungsi pembelian makanan dan minuman, penggunaan voucher atau promo serta penghitungan total makanan&minuman serta pemotongan harga menggunakan voucher.

## Scope and Functionalities
- User dapat melihat daftar voucher yang ditawarkan
- User dapat memasukkan atau menghapus makanan pilihan ke dalam keranjang
- User dapat melihat subtotal makanan yang terdapat pada keranjang
- User dapat menggunakan salah satu voucher
- User dapat melihat harga total termasuk potongannya

## How Does it works?
1. Penggunaan Teknik <br>
Dengan menggunakan teknik <a href="https://www.tutorialspoint.com/mvc_framework/mvc_framework_introduction.htm">Model-View-Controller (MVC)</a>, terbagi tiga komponen logic yaitu : view, model, dan controller. Hal ini berfungsi untuk memfokuskan satu class hanya memiliki tugas atau mengerjakan satu function saja.<br>
2. Pembagian Tugas<br>
Terdapat dua folder yang memuat dua komponen logic yang berbeda. Pada folder Model berisi class `Item.cs` `Voucher.cs` `KeranjangBelanja.cs` `Payment.cs`. Class Item dan Voucher berfungsi untuk mendeklarasikan variabel, class KeranjangBelanja berfungsi menambah dan menghapus pesanan serta menghitung subtotal dan promo. Kemudian class Payment berisi penghitungan total hasil pengurangan subtotal dan promo. Pada folder Controller berisi class `MainWindowController.cs` `MenuController` `PromoController`. Class-class ini berfungsi mengatur alur program seperti jika button diclick akan memunculkan atau menambahkan item dari folder Model.<br>
3. Alur program<br>
Diawali pada class `Menu.xaml.cs` yang berfungsi menambahkan menu kedalam keranjang menggunakan controller pada class `MenuController.cs` .
```csharp
private void generateContentMenu()
        {
            Item Menu1 = new Item("Coffe Late", 30000);
            Item Menu2 = new Item("Black Tea", 20000);
            Item Menu3 = new Item("Pizza", 75000);
            Item Menu4 = new Item("Milk Shake", 15000);
            Item Menu5 = new Item("Fried Frice Special", 45000);
            Item Menu6 = new Item("Watermelon Juice", 25000);
            Item Menu7 = new Item("Lemon Squash", 30000);

            menuController.addItem(Menu1);
            menuController.addItem(Menu2);
            menuController.addItem(Menu3);
            menuController.addItem(Menu4);
            menuController.addItem(Menu5);
            menuController.addItem(Menu6);
            menuController.addItem(Menu7);

            listMenu.Items.Refresh();
        }
```
Kemudian penggunaan voucher pada class `Promo.xaml.cs` dengan menggunakan controller dari class `PromoController.cs`.
```csharp
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
```
Pada `MainWindow.xaml.cs`, diinisialisasi variabel dari instance class Payment, KeranjangBelanja dan MainWindowController. instance dari class Payment dan KeranjangBelanja akan dikontrol menggunakan instance dari class MainWindowController. Kemudian terdapat itemSource dari listKeranjangBelanja dan listPromo yang berfungsi untuk menampilkan item dan kupon yang telah dipilih.
```csharp
public MainWindow()
        {
            InitializeComponent();
            payment = new Payment(this);
            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);
            controller = new MainWindowController(keranjangBelanja, payment);

            listKeranjangBelanja.ItemsSource = controller.getItems();
            listPromo.ItemsSource = controller.getDiskon();

            initializeView();
        }
```
Terdapat function onPriceUpdated pada `MainWindow.xaml.cs` yang berfungsi untuk menampilkan total hasil perhitungan masing-masing subtotal, promo dan total pada content label.
```csharp
public void onPriceUpdated(double subTotal, double total, double promo)
        {
            labelSubTotal.Content = "Rp " + subTotal;
            labelPromo.Content = "Rp" + (total - subTotal);
            labelTotal.Content = "Rp " + total;
        }
```
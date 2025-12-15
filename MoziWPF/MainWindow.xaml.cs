using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoziWPF
{
    public class Mozi
    {
        public String Cím { get; set; }
        public DateTime Időpont { get; set; }
        public String Terem { get; set; }
        public int Szabadhelyek { get; set; }
        public bool _3D { get; set; }

        public Mozi(string cím, DateTime időpont, string terem, int szabadhelyek, bool _3D)
        {
            Cím = cím;
            Időpont = időpont;
            Terem = terem;
            Szabadhelyek = szabadhelyek;
            this._3D = _3D;
        }
    }
    public partial class MainWindow : Window
    {

        public List<Mozi> mozifilmek = new List<Mozi>();

        public MainWindow()
        {
            InitializeComponent();
            mozifilmek.Add(
                new Mozi("Gyűrük Ura", new DateTime(2025, 12, 15, 19, 30, 0), "1-es terem", 12, true));
            mozifilmek.Add(
                new Mozi("Venom", new DateTime(2025, 12, 15, 20, 25, 0), "2-es terem", 30, false));
            mozifilmek.Add(
                new Mozi("Up", new DateTime(2025, 12, 15, 14, 0, 0), "4-es terem", 10, true));
            mozifilmek.Add(
                new Mozi("Step Up", new DateTime(2025, 12, 15, 19, 50, 0), "3-es terem", 0, false));
            mozifilmek.Add(
                new Mozi("FNAF 2", new DateTime(2025, 12, 15, 23, 0, 0), "1-es terem", 2, true));
            mozifilmek.Add(
                new Mozi("IT", new DateTime(2025, 12, 15, 23, 0, 0), "2-es terem", 2, true));
            dataGrid.ItemsSource = mozifilmek;
        }

        private void adatokbetoltese(object sender, RoutedEventArgs e)
        {

        }

        private void foglalás(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Mozi)
            {
                ((Mozi)dataGrid.SelectedItem).Szabadhelyek
                     = ((Mozi)dataGrid.SelectedItem).Szabadhelyek - 1;
                dataGrid.Items.Refresh();
            }
        }
        private void vanhely(object sender, RoutedEventArgs e)
        {
            List<Mozi> csakholvanhely = new List<Mozi>();
            foreach (var mozi in mozifilmek)
            {
                if (mozi.Szabadhelyek > 0)
                    csakholvanhely.Add(mozi);
            }
            dataGrid.ItemsSource = csakholvanhely;
            dataGrid.Items.Refresh();
        }
        private void legnepszerubb(object sender, RoutedEventArgs e)
        {
            List<Mozi> legnepszeru = new List<Mozi>();
            foreach (var mozi in mozifilmek)
            {
                if (mozi.Szabadhelyek < 10)
                    legnepszeru.Add(mozi);
            }
            dataGrid.ItemsSource = legnepszeru;
            dataGrid.Items.Refresh();
        }
        private void atlaghely(object sender, RoutedEventArgs e)
        {
            int osszesHely = 0;
            int filmekSzama = 0;

            foreach (var mozi in mozifilmek)
            {
                osszesHely += mozi.Szabadhelyek;
                filmekSzama++;
            }

            int atlagosHely = osszesHely / filmekSzama;

            MessageBox.Show($"Átlagos szabad helyek száma: {atlagosHely}");
        }

        private void _3dfilmek(object sender, RoutedEventArgs e)
        {
            List<Mozi> _3dfilmek = new List<Mozi>();
            foreach (var mozi in mozifilmek)
            {
                if (mozi._3D == true)
                    _3dfilmek.Add(mozi);
            }
            dataGrid.ItemsSource = _3dfilmek;
            dataGrid.Items.Refresh();
        }
        private void Kereses(object sender, RoutedEventArgs e)
        {
            string cim = tbCimKereses.Text;
            bool csak3D = cb3D.IsChecked == true;

            List<Mozi> talalatok = new List<Mozi>();

            foreach (var mozi in mozifilmek)
            {
                if (mozi.Cím.Contains(cim) && (!csak3D || mozi._3D))
                {
                    talalatok.Add(mozi);
                }
            }

            dataGrid.ItemsSource = talalatok;
            dataGrid.Items.Refresh();
        }




    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sem_02
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Conductor> Conductores { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Conductores = new ObservableCollection<Conductor>();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Conductores conductores = new Conductores();
            conductores.ConductoresDataGrid.ItemsSource = Conductores;
            conductores.Show();
        }

        public void AgregarConductor(Conductor conductor)
        {
            Conductores.Add(conductor);
        }
    }
}

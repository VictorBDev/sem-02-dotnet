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
using System.Windows.Shapes;

namespace sem_02
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        // Propiedad para almacenar el tipo de documento seleccionado
        public string TipoDocumento { get; set; }
        public ObservableCollection<string> Documentos { get; set; }
        public Registro()
        {
            InitializeComponent();
            DataContext = this; // Establece el contexto de datos para la ventana

            // Inicializa la colección de tipos de documentos
            Documentos = new ObservableCollection<string>
            {
                "DNI",
                "Pasaporte",
                "Carnet de extranjería"
            };

            // Configura la fecha y hora actuales:
            FechaDatePicker.SelectedDate = DateTime.Today;
            HoraTextBox.Text = DateTime.Now.ToString("HH:mm");
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime fecha = FechaDatePicker.SelectedDate ?? DateTime.Today;
                TimeSpan hora;
                if (!TimeSpan.TryParse(HoraTextBox.Text, out hora))
                {
                    throw new Exception("Formato de hora inválido. Use HH:mm.");
                }

                var fechaHora = fecha.Date + hora;

                var conductor = new Conductor
                {
                    TipoDocumento = TipoComboBox.Text,
                    NumeroDocumento = DocumentoTextBox.Text,
                    Placa = PlacaTextBox.Text,
                    NombreConductor = NombreTextBox.Text,
                    ApellidoConductor = ApellidoTextBox.Text,
                    FechaHora = fechaHora,
                    PesoIngreso = decimal.Parse(Peso_de_IngresoTextBox.Text)
                };

                ((MainWindow)Application.Current.MainWindow).AgregarConductor(conductor);

                MessageBox.Show("Conductor guardado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el conductor: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

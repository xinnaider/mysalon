using System;
using System.Collections.Generic;
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
using wpf_sallonnovo.Views;

namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Interação lógica para Nav.xam
    /// </summary>
    public partial class Nav : Page
    {
        private Window _window;

        private Frame _frame;

        public Nav(Frame frame, Window window)
        {
            InitializeComponent();
            _frame = frame;
            _window = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Perfil();
            btInicio.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btServico.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btServico.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            _frame.Content = new Inicio(_frame);
            btInicio.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
        }

        /*private void Bt_Sair_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();
            /* 
             Agendamento Agenda = new Agendamento();
             Agenda.Close();

             Salao Salon = new Salao();
             Salon.Close();
        }*/

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();

        }

        private void btSair_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnServico_Click(object sender, RoutedEventArgs e)
        {
            btInicio.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btServico.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
            CadastroServico Telas = new CadastroServico();
            Telas.ShowDialog();
        }

        private void btAgenda_Click(object sender, RoutedEventArgs e)
        {
            btInicio.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btServico.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
        }
    }
}

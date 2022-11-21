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
using wpf_sallonnovo.Models;
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

        private Cliente _cli = new Cliente();

        public Nav(Frame frame, Window window, Cliente cliente)
        {
            InitializeComponent();
            _frame = frame;
            _cli = cliente;
            _window = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Perfil(_cli);
            btInicio.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btSalao.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btSalao.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            _frame.Content = new Inicio(_frame, _cli);
            btInicio.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();

        }

        private void btSair_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btAgenda_Click(object sender, RoutedEventArgs e)
        {
            btInicio.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btSalao.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
            _frame.Content = new AgendamentoUsuario(_cli);
        }

        private void BtnSalao_Click(object sender, RoutedEventArgs e)
        {
            btInicio.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btPerfil.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            btSalao.Background = new SolidColorBrush(Color.FromRgb(47, 53, 89));
            btAgenda.Background = new SolidColorBrush(Color.FromRgb(154, 143, 200));
            _frame.Content = new GerencimentoSalao(_cli);
        }
    }
}

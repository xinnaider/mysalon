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
using System.Windows.Shapes;
using wpf_sallonnovo.Views.Pages;
using wpf_sallonnovo.Models;

namespace wpf_sallonnovo.Views
{
    /// <summary>
    /// Lógica interna para Agendamento.xaml
    /// </summary>
    public partial class Agendamento : Window
    {
        private Cliente _cli = new Cliente();
        public Agendamento()
        {
            InitializeComponent();
            Loaded += Agendamento_Loaded;
            MessageBox.Show(_cli.Nome);
 
        }
        public Agendamento(Cliente cliente)
        {
            InitializeComponent();
            _cli = cliente;
            CarregarListagem();
            Loaded += Agendamento_Loaded;

        }

        private void Agendamento_Loaded(object sender, RoutedEventArgs e)
        {
            var menu = new Nav(fraPaginas, this, _cli);
            frmNav.Content = menu;
        }
        private void CarregarListagem()
        {
            lblUsuario.Content = _cli.Nome;
        }
    }
}

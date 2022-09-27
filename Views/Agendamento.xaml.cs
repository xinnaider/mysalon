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

namespace wpf_sallonnovo.Views
{
    /// <summary>
    /// Lógica interna para Agendamento.xaml
    /// </summary>
    public partial class Agendamento : Window
    {
        public Agendamento()
        {
            InitializeComponent();
            Loaded += Agendamento_Loaded;
                
        }

        private void Agendamento_Loaded(object sender, RoutedEventArgs e)
        {
            var menu = new Nav(fraPaginas);
            frmNav.Content = menu;
        }
    }
}

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

namespace wpf_sallonnovo.Views.Pages
{
    public partial class CadastroSalao : Page
    {
        public CadastroSalao()
        {
            InitializeComponent();
            Loaded += CadastroSalao_Loaded;
        }

        private void CadastroSalao_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {


        }


        private void Bt_Salvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Cancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

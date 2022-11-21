using System;
using System.Collections;
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
using wpf_sallonnovo.Models;

namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Lógica interna para GerencimentoSalao.xaml
    /// </summary>
    public partial class GerencimentoSalao : Page
    {

        private Cliente _cli = new Cliente();

        public GerencimentoSalao()
        {
            InitializeComponent();
        }
        public GerencimentoSalao(Cliente cliente)
        {
            InitializeComponent();
            Loaded += GerencimentoSalao_Loaded;
            _cli = cliente;
        }


        private void GerencimentoSalao_Loaded(object sender, RoutedEventArgs e)
        {
            var dao = new SalaoDAO();
            var teste = dao.VerificarExiste(_cli.Id);
            if (teste == 0)
            {

            }
            else
            {
                btCriarSalao.Visibility = Visibility.Hidden;
                txtTituloNaoCriou.Visibility = Visibility.Hidden;
            }
        }
    }
}

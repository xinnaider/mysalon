using MaterialDesignThemes.Wpf;
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
        private Frame _frame;

        public GerencimentoSalao()
        {
            InitializeComponent();
            Loaded += GerencimentoSalao_Loaded;
        }
        public GerencimentoSalao(Cliente cliente, Frame frame)
        {
            InitializeComponent();
            Loaded += GerencimentoSalao_Loaded;
            _cli = cliente;
            _frame = frame;

        }


        private void GerencimentoSalao_Loaded(object sender, RoutedEventArgs e)
        {
            var dao = new SalaoDAO();
            var teste = dao.VerificarExiste(_cli.Id);

            if (teste != 0)
            {
                btCriarSalao.Visibility = Visibility.Hidden;
                txtTituloNaoCriou.Visibility = Visibility.Hidden;
                
                
            }
            else
            {
                tbNome.Visibility = Visibility.Hidden;
                btBotaoSalao1.Visibility = Visibility.Hidden;
                btBotaoSalao2.Visibility = Visibility.Hidden;
                btBotaoSalao3.Visibility = Visibility.Hidden;
                btBotaoSalao4.Visibility = Visibility.Hidden;
            }
        }

        private void btCriarSalao_Click(object sender, RoutedEventArgs e)
        {
            var tela = new CadastrarSalao(_cli, _frame);
            tela.ShowDialog();

        }

        private void tbNome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btBotaoSalao1_Click(object sender, RoutedEventArgs e)
        {
            var tela = new CadastroServico(_cli);
            tela.ShowDialog();
        }

        private void btBotaoSalao2_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ListarServico2(_cli);
            tela.ShowDialog();
        }

        private void btBotaoSalao3_Click(object sender, RoutedEventArgs e)
        {
            var tela = new EditarSalao(_cli);
            tela.ShowDialog();
        }

        private void btBotaoSalao4_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new AgendamentoSalao(_cli, _frame);
        }
    }
}

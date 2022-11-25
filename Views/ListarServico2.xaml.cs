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
using wpf_sallonnovo.Models;
using wpf_sallonnovo.Views.Pages;

namespace wpf_sallonnovo.Views
{
    /// <summary>
    /// Lógica interna para ListarServico2.xaml
    /// </summary>
    public partial class ListarServico2 : Window
    {
        private Cliente _cli = new Cliente();
        public ListarServico2(Cliente cliente)
        {
            InitializeComponent();
            Loaded += ListarServico2_Loaded;
            _cli = cliente;
        }

        private void ListarServico2_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var daoSalao = new SalaoDAO();
                var dao = new ServicoDAO();
                List<Servico> servicos = dao.ListEspecifico(daoSalao.RetornarIdSalao(_cli.Id));

                dataGridServico.ItemsSource = servicos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelecionado = dataGridServico.SelectedItem as Servico;

            var resultado = MessageBox.Show($"Deseja realmente remover o serviço '{servicoSelecionado.Name}' ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao2 = new AgendaDAO();
                    dao2.DeleteWithId(servicoSelecionado.Id);
                    var dao = new ServicoDAO();
                    dao.Delete(servicoSelecionado);

                    MessageBox.Show("Registro removido com sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                   

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CarregarListagem();
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelecionado = dataGridServico.SelectedItem as Servico;

            var resultado = MessageBox.Show($"Deseja realmente atualizar os dados do servico '{servicoSelecionado.Name}' ?", "Confirmação de alteração",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                var form = new CadastroServico(servicoSelecionado);
                form.ShowDialog();
            }

            CarregarListagem();
        }

        private void CarregarListagem()
        {
            /*try
            {
                var dao = new ServicoDAO();
                List<Servico> servicos = dao.List();

                dataGridServico.ItemsSource = servicos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            try
            {
                var daoSalao = new SalaoDAO();
                var dao = new ServicoDAO();
                List<Servico> servicos = dao.ListEspecifico(daoSalao.RetornarIdSalao(_cli.Id));

                dataGridServico.ItemsSource = servicos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

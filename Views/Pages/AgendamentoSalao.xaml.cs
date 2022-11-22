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
using wpf_sallonnovo.UserControls;

namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Interação lógica para AgendamentoSalao.xam
    /// </summary>
    public partial class AgendamentoSalao : Page
    {
        private Cliente cli = new Cliente();
        private Salao sal = new Salao();
        public AgendamentoSalao(Cliente cliente)
        {
            InitializeComponent();
            cli = cliente;
            var dao = new SalaoDAO();
            sal = dao.InfoSal(cli.Id);
            Loaded += AgendamentoSalao_Loaded;
        }

        private void AgendamentoSalao_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new AgendaDAO();
                var listaAgenda = dao.ListResolvidoSal(sal.Id);


                foreach (var agenda in listaAgenda)
                {
                    var a = new UserSalaoAgendamento()
                    {
                        NomeCliente = $"{agenda.Cliente}",
                        NomeServico = $"{agenda.Servico}",
                        DataHorario = agenda.dataHorario
                    };

                    listAgenda.Children.Add(a);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();   
        }
    }
    
}

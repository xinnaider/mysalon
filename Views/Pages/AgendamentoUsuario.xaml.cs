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
using wpf_sallonnovo.UserControls;
using wpf_sallonnovo.Models;

namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Interação lógica para AgendamentoUsuario.xam
    /// </summary>
    public partial class AgendamentoUsuario : Page
    {
        private Cliente _cli = new Cliente();
        private Frame _frame;

        public AgendamentoUsuario()
        {
            InitializeComponent();
            Loaded += AgendamentoUsuario_Loaded;
        }
        public AgendamentoUsuario(Cliente cliente, Frame frame)
        {
            InitializeComponent();
            Loaded += AgendamentoUsuario_Loaded;
            _cli = cliente;
            _frame = frame;
        }

        private void AgendamentoUsuario_Loaded(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var dao = new AgendaDAO();
                var listaAgenda = dao.ListResolvido(_cli.Id);

                
                foreach (var agenda in listaAgenda)
                {
                    var a = new UserAgendamento(_cli, _frame)
                    {
                        NomeSalao = $"{agenda.Salao}",
                        NomeServico = $"{agenda.Servico}",
                        DataHorario = agenda.dataHorario,
                    };

                    listAgenda.Children.Add(a);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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

namespace wpf_sallonnovo.UserControls
{
    /// <summary>
    /// Interação lógica para UserSalaoAgendamento.xam
    /// </summary>
    public partial class UserSalaoAgendamento : UserControl
    {
        public string NomeCliente { get; set; }
        public string NomeServico { get; set; }
        public DateTime? DataHorario { get; set; }

        public string Teste { get; set; }

        private Agenda _agenda = new Agenda();
        public UserSalaoAgendamento()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UserSalaoAgendamento_Loaded;
        }

        private void UserSalaoAgendamento_Loaded(object sender, RoutedEventArgs e)
        {
            _agenda.Cliente = NomeCliente;
            _agenda.Servico = NomeServico;
            _agenda.dataHorario = DataHorario;
        }
    }
}

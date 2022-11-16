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
    /// Interação lógica para UserAgendamento.xam
    /// </summary>
    public partial class UserAgendamento : UserControl
    {
        public string NomeSalao { get; set; }
        public string NomeServico { get; set; }
        public DateTime? DataHorario { get; set; }

        private Agenda _agenda = new Agenda();
        internal string aaaaaa;

        public UserAgendamento()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UserAgendamento_Loaded;
        }

        private void UserAgendamento_Loaded(object sender, RoutedEventArgs e)
        {
           _agenda.Salao = NomeSalao;
           _agenda.Servico = NomeServico;
           _agenda.dataHorario = DataHorario;
        }




    }
}

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

namespace wpf_sallonnovo.Views
{
    /// <summary>
    /// Lógica interna para ConfirmacaoAgendamento.xaml
    /// </summary>
    public partial class ConfirmacaoAgendamento : Window
    {
        private Salao _sal = new Salao();
        private Servico _servico = new Servico();
        private Cliente _cli = new Cliente();
        private Agenda _age = new Agenda();
        
        public ConfirmacaoAgendamento(Salao salao, Servico servico, Cliente cliente)
        {
            InitializeComponent();
            _sal = salao;
            _servico = servico;
            _cli = cliente;
            Loaded += ConfirmacaoAgendamento_Loaded;

        }

        private void ConfirmacaoAgendamento_Loaded(object sender, RoutedEventArgs e)
        {
            lblNSalao.Content = _sal.Nome;
            lblNServico.Content = _servico.Name;
            _age.FkCli = _cli.Id;
            _age.FkSal = _sal.Id;
            _age.FkSer = _servico.Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            _age.DataHora = LocaleDatePicker.Text + " " + timePicker.Text;
            MessageBox.Show(_age.DataHora);

            try
            {
                var dao = new AgendaDAO();
                dao.Insert(_age);
                MessageBox.Show("Agendamento Concluido");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
             
        }
            
    }
}

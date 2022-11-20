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
using wpf_sallonnovo.Views;

namespace wpf_sallonnovo.UserControls
{
    /// <summary>
    /// Interação lógica para UserServico.xam
    /// </summary>
    public partial class UserServico : UserControl
    {
        public string Nome {get; set;}
        public float Preco { get; set;}
        public int Cod { get; set; }

        private Servico _servico = new Servico();
        private Frame _frame;
        private Salao _salao = new Salao();
        private Cliente _cli = new Cliente();

        public UserServico(Frame frame ,Salao sal, Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UserServico_Loaded;
            _salao = sal;
            _cli = cliente;
            _frame = frame;
            
        }

        private void UserServico_Loaded(object sender, RoutedEventArgs e)
        {
            _servico.Name = Nome;
            _servico.Valor = Preco;
            _servico.Id = Cod;
        }

        private void btnSelectServico_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ConfirmacaoAgendamento(_salao, _servico, _cli);
            tela.ShowDialog();

        }
    }
}

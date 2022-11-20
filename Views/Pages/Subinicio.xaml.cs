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
using wpf_sallonnovo.Views.Pages;

namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Interação lógica para Subinicio.xam
    /// </summary>
    public partial class Subinicio : Page

    {
        private Salao salao = new Salao();
        private Frame _frame;
        private Cliente _cli = new Cliente();
        public Subinicio(Cliente cliente)
        {
            InitializeComponent();
            _cli = cliente;
            Loaded += Subinicio_Loaded;
        }
        public Subinicio(Frame frame ,Salao _salao, Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = this;
            salao = _salao;
            _cli = cliente;
            CarregarListagem();
            
            Loaded += Subinicio_Loaded;
            _frame = frame;
        }

        private void Subinicio_Loaded(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var dao = new ServicoDAO();
                var listaServicos = dao.ListEspecifico(salao.Id);
                
                foreach (var servicos in listaServicos)
                {
                    var a = new UserServico(_frame, salao, _cli)
                    {
                        Nome = $"{servicos.Name}",
                        Cod = servicos.Id,
                        Preco = servicos.Valor,
                        
                    };

                    listServicos.Children.Add(a);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void CarregarListagem()
        {
            lblNome.Content = Convert.ToString(salao.Nome);
            var end = new EnderecoDAO();
            lblRua.Content = end.BuscarEnd(salao);
        }
    }
}

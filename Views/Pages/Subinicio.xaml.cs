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
        public Subinicio()
        {
            InitializeComponent();
            Loaded += Subinicio_Loaded;
        }
        public Subinicio(Salao _salao)
        {
            InitializeComponent();
            salao = _salao;
            CarregarListagem();
            Loaded += Subinicio_Loaded;
        }

        private void Subinicio_Loaded(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var dao = new ServicoDAO();
                var listaServicos = dao.List();
                
                foreach (var servicos in listaServicos)
                {
                    var a = new UserServico()
                    {
                        Nome = $"{servicos.Name}",
                        Preco = servicos.Valor
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

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
    /// Interação lógica para Inicio.xam
    /// </summary>
    public partial class Inicio : Page
    {
        private Frame _frame;
        private Cliente _cli = new Cliente();
        public Inicio(Frame frame, Cliente cliente)
        {
            InitializeComponent();
            _frame = frame;
            _cli = cliente;
            Loaded += Inicio_Loaded;
        }

        private void Inicio_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new SalaoDAO();
                var listaSalao = dao.List();
                foreach (var salao in listaSalao)
                {
                    var a = new UserInicial(_frame, _cli) { Title = $"{salao.Nome}",  Preco = $"PRECO adicionar", 
                        Cod = $"{salao.Id}", Tel = $"{salao.Telefone}", RSocial = $"{salao.Razao_Social}",
                        Email = $"{salao.Email}", Cnpj = $"{salao.Email}"};

                    listAgenda.Children.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Subinicio(_cli);
        }

    }
}

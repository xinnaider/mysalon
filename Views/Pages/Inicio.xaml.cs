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

namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Interação lógica para Inicio.xam
    /// </summary>
    public partial class Inicio : Page
    {
        private Frame _frame;

        public Inicio(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += Inicio_Loaded;
        }

        private void Inicio_Loaded(object sender, RoutedEventArgs e)
        {

            for(int i = 0; i < 3; i++)
            {
                var a = new UserInicial() { Title = $"ANTONIO {i}", Descricao = $"DESCRICAO {i}", Preco = $"PRECO {i}"};

                listAgenda.Children.Add(a);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Subinicio();
        }
    }
}

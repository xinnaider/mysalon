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
    /// Interação lógica para UserServico.xam
    /// </summary>
    public partial class UserServico : UserControl
    {
        public string Nome {get; set;}
        public float Preco { get; set;}

        public Servico _servico = new Servico();
        public UserServico()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UserServico_Loaded;
        }

        private void UserServico_Loaded(object sender, RoutedEventArgs e)
        {
            _servico.Name = Nome;
            _servico.Valor = Preco;
        }
    }
}

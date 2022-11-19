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
    /// Interação lógica para UserInicial.xam
    /// </summary>
    public partial class UserInicial : UserControl
    {
        public string Title { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }

        public string Cod { get; set; }

        public string Tel { get; set; }

        public string RSocial { get; set; }
        public string Email { get; set; }
        public string FkEnd { get; set; }

        public string Cnpj { get; set; }

        private Salao _salao = new Salao();

        public UserInicial()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UserInicial_Loaded;
            
        }

        private void UserInicial_Loaded(object sender, RoutedEventArgs e)
        {
            _salao.Id = Convert.ToInt32(Cod);
            _salao.Nome = Title;
            _salao.Telefone = Tel;
            _salao.Razao_Social = RSocial;
            _salao.CNPJ = Cnpj;
            _salao.Email = Email;

        }

        private void btnSelectServico_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ID: " + Convert.ToString(_salao.Id) + "; Nome: " +
                _salao.Nome + "; Telefone: " + _salao.Telefone + "; Cnpj: " + _salao.CNPJ
                + "; Razão Social: " + _salao.Razao_Social + "; Email: " + _salao.Email);
            
        }
    }
}

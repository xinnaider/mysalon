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
using wpf_sallonnovo.Views.Pages;

namespace wpf_sallonnovo.UserControls
{
    /// <summary>
    /// Interação lógica para UserInicial.xam
    /// </summary>
    public partial class UserInicial : UserControl
    {
        public string Title { get; set; }

        public string Preco { get; set; }

        public string Cod { get; set; }

        public string Tel { get; set; }
        public string Endereco { get; set; }
        public string RSocial { get; set; }
        public string Email { get; set; }
        public string FkEnd { get; set; }
        public string Img { get; set; }
        public string Cnpj { get; set; }

        private Salao _salao = new Salao();
        private Cliente _cli = new Cliente();
       
        public UserInicial(Frame frame, Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UserInicial_Loaded;
            _frame = frame;
            _cli = cliente;
        }

        private Frame _frame;

        private void UserInicial_Loaded(object sender, RoutedEventArgs e)
        {
            _salao.Id = Convert.ToInt32(Cod);
            _salao.Nome = Title;
            _salao.Telefone = Tel;
            _salao.Razao_Social = RSocial;
            _salao.CNPJ = Cnpj;
            _salao.Email = Email;
            var end = new EnderecoDAO();
            lblEndereco.Content = end.BuscarEnd(_salao);
            var dao = new ServicoDAO();
           // _salao.Imagem = ;
                   
            lblPreco.Content = "A partir de: R$ " + Convert.ToString(dao.MinPreco(_salao)); 
        }

        private void btnSelectServico_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Subinicio(_frame,_salao, _cli);
        }
    }
}

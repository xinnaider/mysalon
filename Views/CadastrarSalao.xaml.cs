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
    /// Lógica interna para CadastrarSalao.xaml
    /// </summary>
    /// dar uma olhadinha em relação ao endereço
    public partial class CadastrarSalao : Window
    {

        private Cliente _cli = new Cliente();
        Salao _salao = new Salao();
        Endereco _end = new Endereco();

        public CadastrarSalao(Cliente cliente)
        {
            InitializeComponent();
            _cli = cliente;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _salao.Nome = txtNSalao.Text;
            _salao.Telefone = txtTelfone.Text;
            _salao.Razao_Social = txtRazaoSocial.Text;
            _salao.CNPJ = txtCNPJ.Text;
            _salao.Email = txtEmail.Text;
            _salao.idUsuario = _cli.Id;

            _end.Estado = cbEstado.Text;
            _end.Cidade = txtCidade.Text;
            _end.Bairro = txtBairro.Text;
            _end.Rua = txtRua.Text;
            _end.Numero =txtNum.Text;
            _end.Cep = txtCEP.Text;
            

            try
            {

                var li = new EnderecoDAO();
                li.Insert(_end);
                var lista = li.List();
                var a = lista.Count();
                _salao.IdEnd = a;
                var dao = new SalaoDAO();
                dao.Insert(_salao);
                MessageBox.Show("Salão Cadastrado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

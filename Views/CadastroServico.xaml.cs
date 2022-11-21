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
    /// Lógica interna para CadastroServico.xaml
    /// </summary>
    public partial class CadastroServico : Window
    {
        private Servico _servico = new Servico();
        private Cliente _cli = new Cliente();
        public CadastroServico(Cliente cliente)
        {
            InitializeComponent();
            _cli = cliente;
        }

        public CadastroServico(Servico servicoSelecionado)
        {
            InitializeComponent();
            Loaded += CadastroServico_Loaded;
            _servico = servicoSelecionado; 
        }

        private void CadastroServico_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeSer.Text = _servico.Name;
            txtValorSer.Text = _servico.Valor.ToString();
            txtTiposSer.Text = _servico.Tipo;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            _servico.Name = txtNomeSer.Text;
            _servico.Valor = float.Parse(txtValorSer.Text);
            _servico.Tipo = txtTiposSer.Text;

            var daoSalao = new SalaoDAO();
            _servico.fkSalao = daoSalao.RetornarIdSalao(_cli.Id);


            var dao = new ServicoDAO();
            try
            {
                if (_servico.Id > 0)
                {
                    dao.Update(_servico);

                    MessageBox.Show("Registro de escola cadastrado com sucesso.");
                }
                else
                {
                    dao.Insert(_servico);

                    MessageBox.Show("Registro de escola cadastrado com sucesso.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

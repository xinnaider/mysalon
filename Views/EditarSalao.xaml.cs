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
    /// Lógica interna para EditarSalao.xaml
    /// </summary>
    public partial class EditarSalao : Window
    {
        private Salao sal = new Salao();
        private Cliente cli = new Cliente();
        public EditarSalao(Cliente cliente)
        {
            InitializeComponent();
            cli = cliente;
            var dao = new SalaoDAO();
            sal = dao.InfoSal(cli.Id);
            Loaded += EditarSalao_Loaded;
            
        }

        

        private void EditarSalao_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtNSalao.Text = sal.Nome;
            txtEmail.Text = sal.Email;  
            txtCNPJ.Text = sal.CNPJ;
            txtRazaoSocial.Text = sal.Razao_Social;
            txtTelfone.Text = sal.Telefone;

        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            sal.Nome = txtNSalao.Text;
             sal.Email = txtEmail.Text ;
            sal.CNPJ = txtCNPJ.Text;
            sal.Razao_Social = txtRazaoSocial.Text;
             sal.Telefone = txtTelfone.Text;

            try
            {
                var dao = new SalaoDAO();
                dao.Update(sal);
                MessageBox.Show("Deu certo man!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); 
            }
        }
    }
}

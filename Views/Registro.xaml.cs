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
using wpf_sallonnovo.Views;

namespace wpf_sallonnovo.Views
{
    /// <summary>
    /// Lógica interna para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private Log _log = new Log();
        private Cliente _cliente = new Cliente();
       
        public Registro()
        {
            InitializeComponent();
        }
        void OnClick1(object sender, RoutedEventArgs e)
        {
            MainWindow telas = new MainWindow();
            this.Close();
            telas.ShowDialog();
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            _cliente.Nome = txtNome.Text;
            _cliente.CPF = txtCPF.Text;
            _cliente.RG = txtRG.Text;
            _cliente.Telefone = txtTelefone.Text;
            _cliente.Email = txtEmail.Text;

            if ((bool)rbMasculino.IsChecked)
                _cliente.Sexo = "Masculino";
            else
            {
                if ((bool)rbFeminino.IsChecked)
                    _cliente.Sexo = "Femenino";
                else _cliente.Sexo = "Prefiro não dizer";
            }

            _log.User = txtEmail.Text;
            _log.Password = passbSenha.Password.ToString(); ;

            try
            {
                var dao = new ClienteDAO();
                dao.Insert(_cliente);
                var idfk = dao.List().Count;
                _log.FkCliente = idfk;
                var log = new LoginDAO();
                log.Insert(_log);
                MessageBox.Show("Registro de cliente cadastrado com sucesso!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtTelefone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

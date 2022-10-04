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
        private Cliente _cliente = new Cliente();
    //    private Login _login = new Login();
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
            if (chcbTermos.IsChecked == true)
            {
                if (passbSenha.Password.ToString() == passbSconfirma.Password.ToString())
                {
                    if ((txtNome.Text == null) | (txtEmail.Text == String.Empty) 
                        | (txtUser.Text == String.Empty) | (passbSenha.Password.ToString() == String.Empty)
                        | (passbSconfirma.Password.ToString() == String.Empty))
                    {

                        MessageBox.Show("Por favor preencha os campos corretamente");
                    }
                    else {
                        string senha = passbSenha.Password.ToString();
                        _cliente.Nome = txtNome.Text;
                        string user = txtUser.Text;

                        _cliente.Email = txtEmail.Text;
                        try
                        {
                            var dao = new ClienteDAO();
                            dao.Insert(_cliente);
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                else { MessageBox.Show("Senha não corresponde"); }
                
            }
            else
            {
                MessageBox.Show("Aceite os termos para concluir o registro!");
            }
        }
    }
}

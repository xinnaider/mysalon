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
using wpf_sallonnovo.Views;
using wpf_sallonnovo.Models;
using wpf_sallonnovo.Views.Pages;

namespace wpf_sallonnovo
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()

        {
            InitializeComponent();
        }
        void OnClick2(object sender, RoutedEventArgs e)
        {
            Registro Telas = new Registro();
            this.Close();
            Telas.ShowDialog();
        }




        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {

            string usuario = txtUsuario.Text;
            string senha = passbSenha.Password.ToString();

            usuario = "user";
            senha = "senha";

            if (Login.Loginn(usuario, senha))
            {
                //var cliente = new ClienteDAO().GetByUsuario(usuario, senha);
                Agendamento main = new Agendamento();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

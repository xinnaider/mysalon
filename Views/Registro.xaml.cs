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
            Loaded += Registro_Loaded;
        }

        public Registro(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            
            Loaded += Registro_Loaded;
        }

        void OnClick1(object sender, RoutedEventArgs e)
        {
            MainWindow telas = new MainWindow();
            this.Close();
            telas.ShowDialog();
        }

        private void Registro_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
            

        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaCliente = dao.List();

                dataGridCliente.ItemsSource = listaCliente;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            int i = dataGridCliente.Items.Count;
            i = i + 1;
           
            _log.FkCliente = i;


        }

        private void dataGridCliente_SelectionChanged(object sender, SelectedCellsChangedEventArgs e) { }
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
            _log.Password = passbSenha.Password;

            try
            {
                var dao = new ClienteDAO();

                
                dao.Insert(_cliente);
                MessageBox.Show("Registro de cliente cadastrado com sucesso!");
                var log = new LoginDAO();
                log.Insert(_log);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}

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

            txtNome.Text = _cliente.Nome;
            txtCPF.Text = _cliente.CPF;
            txtRG.Text = _cliente.RG;
            txtTelefone.Text = _cliente.Telefone;
            txtEmail.Text = _cliente.Email;

            if (_cliente.Sexo == "Masculino")
            {
                rbMasculino.IsChecked = true;
            }
            else
            {
                if (_cliente.Sexo == "Femenino")
                {
                    rbFeminino.IsChecked = true;
                }
                else rbNDizer.IsChecked = true;
            }

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

            try
            {
                var dao = new ClienteDAO();

                if (_cliente.Id > 0)
                {
                    dao.Update(_cliente);
                    MessageBox.Show("Registro de cliente atualizado com sucesso!");
                }
                else
                {
                    dao.Insert(_cliente);
                    MessageBox.Show("Registro de cliente cadastrado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}

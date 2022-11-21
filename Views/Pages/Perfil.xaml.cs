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
namespace wpf_sallonnovo.Views.Pages
{
    /// <summary>
    /// Interação lógica para Perfil.xam
    /// </summary>
    public partial class Perfil : Page
    {
        private Cliente _cli = new Cliente();

        public Perfil()
        {
            InitializeComponent();
            Loaded += Perfil_Loaded;
        }
        public Perfil(Cliente cliente)
        {
            InitializeComponent();
            _cli = cliente;
            Loaded += Perfil_Loaded;
        }
        

        private void Perfil_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cli.Nome;
            txtCPF.Text = _cli.CPF;
            txtRG.Text = _cli.RG;
            txtTelefone.Text = _cli.Telefone;
        }
        private void Bt_Salvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.IsReadOnly == true)
            {
                Bt_Salvar.Content = "Salvar";
                bt_Cancelar.Visibility = Visibility.Visible;

                txtNome.IsReadOnly = false;
                txtCPF.IsReadOnly = false;
                txtRG.IsReadOnly = false;
                txtTelefone.IsReadOnly = false;
                rbFeminino.IsEnabled = true;
                rbMasculino.IsEnabled = true;
                rbNDizer.IsEnabled = true;

            }
            else
            {
                Bt_Salvar.Content = "Editar";
                bt_Cancelar.Visibility = Visibility.Hidden;

                txtNome.IsReadOnly = true;
                txtCPF.IsReadOnly = true;
                txtRG.IsReadOnly = true;
                txtTelefone.IsReadOnly = true;
                rbFeminino.IsEnabled = false;
                rbMasculino.IsEnabled = false;
                rbNDizer.IsEnabled = false;
            }

        }

        private void bt_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Bt_Salvar.Content = "Editar";
            bt_Cancelar.Visibility = Visibility.Hidden;

            txtNome.IsReadOnly = true;
            txtCPF.IsReadOnly = true;
            txtRG.IsReadOnly = true;
            txtTelefone.IsReadOnly = true;
            rbFeminino.IsEnabled = false;
            rbMasculino.IsEnabled = false;
            rbNDizer.IsEnabled = false;
        }
    }
}

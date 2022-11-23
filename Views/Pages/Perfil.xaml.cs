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
            if (_cli.Sexo != "masculino")
            {
                if(_cli.Sexo != "feminino") { rbFeminino.IsChecked = true; }
                else { rbNDizer.IsChecked = true; }
            } else { rbMasculino.IsChecked = true; }
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

                _cli.Nome = txtNome.Text;
                _cli.CPF = txtCPF.Text;
                _cli.RG = txtRG.Text;
                _cli.Telefone = txtTelefone.Text;
                if ((bool)rbMasculino.IsChecked)
                    _cli.Sexo = "masculino";
                else
                {
                    if ((bool)rbFeminino.IsChecked)
                        _cli.Sexo = "femenino";
                    else _cli.Sexo = "prefiro nao dizer";
                }

                try
                {
                    var dao = new ClienteDAO();
                    dao.Update(_cli);
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //var tela = new Agendamento(_cli);
                //tela.lblUsuario.Content = _cli.Nome;

                
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

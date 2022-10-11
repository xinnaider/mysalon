﻿using System;
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
      // private Login _login = new Login();
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
            
        }
    }
}

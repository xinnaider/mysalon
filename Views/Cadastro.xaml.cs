using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wpf_sallon.Views;

namespace wpf_sallon.Views
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        void OnClick1(object sender, RoutedEventArgs e)
        {
            MainWindow telas = new MainWindow();
            this.Close();
            telas.ShowDialog();
        }
    }
}

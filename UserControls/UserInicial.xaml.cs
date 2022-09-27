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

namespace wpf_sallonnovo.UserControls
{
    /// <summary>
    /// Interação lógica para UserInicial.xam
    /// </summary>
    public partial class UserInicial : UserControl
    {
        public string Title { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }

        public UserInicial()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

    }
}

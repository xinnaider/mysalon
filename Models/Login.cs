using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public Cliente Cliente { get; set; }
        private static Login _instance;

        private Login() { }

        public static Login GetInstance()
        {
            if (_instance == null)
                _instance = new Login();

            return _instance;
        }

        public static bool Loginn(string usuario, string senha)
        {
            var user = new LoginDAO().GetByUsuario(usuario, senha);

            if (user != null)
                return true;

            return false;
        }

        public static int GetFuncionarioId()
        {
            return _instance.Cliente.Id;
        }
    }
}

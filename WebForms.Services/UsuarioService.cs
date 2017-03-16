using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.Services
{
    public interface IUsuarioService
    {
        string RetornarMensagem();
    }
    public class UsuarioService : IUsuarioService
    {
        public string RetornarMensagem()
        {
            return "Hello";
        }
    }
}

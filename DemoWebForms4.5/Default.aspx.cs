using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Services;

namespace DemoWebForms4._5
{
    public partial class _Default : Page
    {
        IUsuarioService _usuarioService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

     
        public  string GetNome()
        {
            var u =  _usuarioService.RetornarMensagem();
            return u;
        }
    }
}
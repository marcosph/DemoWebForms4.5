using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Services;

namespace WebApiWebForms
{
    public partial class _Default : Page
    {
        [Dependency]
        public IUsuarioService _userRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var r = _userRepository.RetornarMensagem();
        }
    }
}
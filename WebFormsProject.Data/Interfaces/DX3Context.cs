using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormsProject.Data
{
    partial class DX3Context
    {
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}

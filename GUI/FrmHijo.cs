using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmHijo : Form
    {
        public FrmHijo()
        {
            InitializeComponent();
        }

        private void FrmHijo_Load(object sender, EventArgs e)
        {
            var padre = this.Owner;
            User usuario =(User) padre.Tag;
            this.Text = usuario.Nombre;
        }
    }
}

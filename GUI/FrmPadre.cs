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
    public partial class FrmPadre : Form
    {
        //public string Tipo { get; set; }
        
        public FrmPadre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usuario = new User(1, "johnp");
            this.Tag = usuario;
            FrmHijo f = new FrmHijo();

            f.Owner = this;
            f.ShowDialog();
        }
    }
    public class User
    {
        public User(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
       
    }
}

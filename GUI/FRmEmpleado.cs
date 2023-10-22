using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class FRmEmpleado : Form
    {
        
        private EmpleadoService empleadoService = new EmpleadoService();
        int fila;
        public FRmEmpleado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Empleado empleado = new Empleado(txtid.Text, txtNombre.Text,txtsalario.Text, cbestado.Text);

            Guardar(empleado);
            CargarGrilla(empleadoService.Consultar());


            
            
           

        }
        void Guardar(Empleado empleado)
        {
            var msg = empleadoService.Guardar(empleado);
            MessageBox.Show(msg);

        }

        private void FRmMunicipio_Load(object sender, EventArgs e)
        {
            CargarDptos();
            CargarMunicipios();
            CargarGrilla(empleadoService.Consultar());
        }

        void CargarGrilla(List<Empleado> lista)
        {
            grillaMunicipios.Rows.Clear();
            
            foreach (var item in lista)
            {
                grillaMunicipios.Rows.Add(item.Empleadoid, item.Empleadonombre, item.Empleadosalario, item.Empleadoestado);
                
            }

        }
        void CargarMunicipios()
        {
            lstEmpleados.DataSource = empleadoService.Consultar();
            lstEmpleados.ValueMember = "CodigoMunicipio";
            lstEmpleados.DisplayMember = "NombreMunicipio";
        }
        void CargarDptos()
        {
            cbestado.DataSource = empleadoService.Consultar();
            cbestado.ValueMember = "CodigoDpto";
            cbestado.DisplayMember= "NombreDpto";
        }

        private void grillaMunicipios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           fila= e.RowIndex;
            string codigo= grillaMunicipios.Rows[fila].Cells[0].Value.ToString();
            Buscar(codigo);
            
            tabControl1.SelectTab(0);
        }
        void Buscar(string id)
        {
            var municipio = empleadoService.BuscarId(id);
            Ver(municipio);
        }
        void Ver(Empleado empleado)
        {
            if (empleado != null)
            {
                txtid.Text = empleado.Empleadoid;
                txtNombre.Text = empleado.Empleadonombre;
                txtsalario.Text = empleado.Empleadosalario;
                cbestado.Text = empleado.Empleadoestado;

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void lstMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text=lstEmpleados.SelectedIndex.ToString();

            string codigo = lstEmpleados.SelectedValue.ToString();
            Buscar(codigo);
           
        }

        //private void txtFiltro_TextChanged(object sender, EventArgs e)
        //{
        //    var filtro= txtFiltro.Text;

        //    var lista = empleadoService.BuscarX(filtro);
        //    CargarGrilla(lista);

        //}

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void verDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string codigo = grillaMunicipios.Rows[fila].Cells[0].Value.ToString();
            Buscar(codigo);
            
            tabControl1.SelectTab(0);
        }

        private void grillaMunicipios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila=e.RowIndex;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

            
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Solo se admiten letras");
                txtNombre.Text.Remove(txtNombre.Text.Length - 1);
            }
           

        }

        private void cbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbestado.Text == "ACTIVO")
            {
                cbestado.Text = "ACTIVO";
            }
            else
            {
                cbestado.Text = "INACTIVO";
            }

            

            

           

        }
    }
}

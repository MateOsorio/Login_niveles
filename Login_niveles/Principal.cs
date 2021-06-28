using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_niveles
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //admin
            if(Login.area.Trim() == "A001")
            {
                btnAlmacen.Enabled = true;
                btnCompras.Enabled = true;
                btnVentas.Enabled = true;

                lblCargo.Text = "Administrador";
            }
            //ventas
            else if (Login.area == "A002")
            {
                btnAlmacen.Enabled = false;
                btnCompras.Enabled = false;
                btnVentas.Enabled = true;

                lblCargo.Text = "Ventas";
            }
            //Compras
            else if (Login.area == "A003")
            {
                btnAlmacen.Enabled = false;
                btnCompras.Enabled = true;
                btnVentas.Enabled = false;

                lblCargo.Text = "Compras";
            }

            lblNombre.Text = Login.usuario_nombre;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yy");
            lblHora.Text = DateTime.Now.ToString("hh-mm-ss tt");
        }
    }
}

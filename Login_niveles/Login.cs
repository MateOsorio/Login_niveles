using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace Login_niveles
{
    public partial class Login : Form
    {
        E_Users objeuser = new E_Users();
        N_Users objnuser = new N_Users();
        Principal frm1 = new Principal();

        public static string usuario_nombre;
        public static string area;

        public Login()
        {
            InitializeComponent();
        }

        void logueo()
        {
            DataTable dt = new DataTable();
            objeuser.usuario = txtUsuario.Text;
            objeuser.clave = txtContrasena.Text;

            dt = objnuser.N_User(objeuser);

            if (dt.Rows.Count >0)
            {
                MessageBox.Show("bienvenido al sistema" + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][1].ToString();
                area = dt.Rows[0][0].ToString();

                frm1.ShowDialog();

                Login login = new Login();
                //login.ShowDialog();

                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new Principal());

                txtUsuario.Clear();
                txtContrasena.Clear();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos" + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            logueo();
        }
    }
}

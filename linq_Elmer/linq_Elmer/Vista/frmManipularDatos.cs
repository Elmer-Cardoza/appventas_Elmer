using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using linq_Elmer.Model;

namespace linq_Elmer
{
    public partial class manipularDatos : Form
    {
        public manipularDatos()
        {
            InitializeComponent();
        }
        public void mostrar()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                dtvUsuarios.DataSource = db.usuarios.ToList();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void manipularDatos_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void txtUsu_Enter(object sender, EventArgs e)
        {
            if (txtUsu.Text == "USUARIO")
            {
                txtUsu.Clear();

            }
            txtUsu.ForeColor = Color.DeepSkyBlue;
        }

        private void txtUsu_Leave(object sender, EventArgs e)
        {
            if (txtUsu.Text == "")
            {
                txtUsu.Text = "USUARIO";

            }
            txtUsu.ForeColor = Color.White;
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Clear();
                txtpass.UseSystemPasswordChar = true;
            }
            txtpass.ForeColor = Color.DeepSkyBlue;
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.UseSystemPasswordChar = false;
            }
            txtpass.ForeColor = Color.White;
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                usuarios user = new usuarios();
                String identificaion = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                int identificaionc = int.Parse(identificaion);
                user = db.usuarios.Where(verificarId => verificarId.Id_usuario == identificaionc).First();

                user.Usuario = txtUsu.Text;
                user.Contraseña = txtpass.Text;

                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Datos guardados correctamente..\nPulse aceptar para continuar");
            mostrar();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogueo f1 = new frmLogueo();
            f1.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Usuarios usu = new Usuarios();
            usu.Show();
            this.Hide();
        }

        private void dtvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String usuario = dtvUsuarios.CurrentRow.Cells[1].Value.ToString();
            String contraseña = dtvUsuarios.CurrentRow.Cells[2].Value.ToString();



            txtUsu.Text = usuario;
            txtpass.Text = contraseña;
        }
    }
}

using linq_Elmer.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace linq_Elmer
{
    public partial class registrar : Form
    {
        public registrar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtUsu_Enter(object sender, EventArgs e)
        {
            if (txtUsu.Text == "NUEVO USUARIO")
            {
                txtUsu.Clear();

            }
            txtUsu.ForeColor = Color.DeepSkyBlue;
            panel1.BackColor = Color.DeepSkyBlue;
        }

        private void txtUsu_Leave(object sender, EventArgs e)
        {
            if (txtUsu.Text == "")
            {
                txtUsu.Text = "NUEVO USUARIO";

            }
            txtUsu.ForeColor = Color.White;
            panel1.BackColor = Color.White;
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "NUEVA CONTRASEÑA")
            {
                txtpass.Clear();
                txtpass.UseSystemPasswordChar = true;
            }
            txtpass.ForeColor = Color.DeepSkyBlue;
            panel2.BackColor = Color.DeepSkyBlue;
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "NUEVA CONTRASEÑA";
                txtpass.UseSystemPasswordChar = false;
            }
            txtpass.ForeColor = Color.White;
            panel2.BackColor = Color.White;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db=new sistema_ventasEntities()) 
            {
                usuarios user = new usuarios();

                user.Usuario = txtUsu.Text;
                user.Contraseña = txtpass.Text;

                db.usuarios.Add(user);
                db.SaveChanges();
            }MessageBox.Show("Datos guardados correctamente...\nPulce aceptar para continuar");
            frmLogueo f1 = new frmLogueo();
            f1.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogueo f1 = new frmLogueo();
            f1.Show();
            this.Hide();
        }

        private void registrar_Load(object sender, EventArgs e)
        {

        }
    }
}

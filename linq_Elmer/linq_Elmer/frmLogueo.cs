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
using linq_Elmer.Vista;

namespace linq_Elmer
{
    public partial class frmLogueo : Form
    {
        public frmLogueo()
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
            if (txtUsu.Text=="USUARIO") {
                txtUsu.Clear();
                
            }txtUsu.ForeColor = Color.DeepSkyBlue;
            panel1.BackColor = Color.DeepSkyBlue;
            pictureBox4.Image = Properties.Resources.usuario__3_;
        }

        private void txtUsu_Leave(object sender, EventArgs e)
        {
            if (txtUsu.Text == "")
            {
                txtUsu.Text = "USUARIO";

            }
            txtUsu.ForeColor = Color.White;
            panel1.BackColor = Color.White;
            pictureBox4.Image = Properties.Resources.usuario;
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text=="CONTRASEÑA")
            {
                txtpass.Clear();
                txtpass.UseSystemPasswordChar = true;
            }txtpass.ForeColor = Color.DeepSkyBlue;
            panel2.BackColor = Color.DeepSkyBlue;
            pictureBox5.Image = Properties.Resources.candado__1_;
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.UseSystemPasswordChar = false;
            }
            txtpass.ForeColor = Color.White;
            panel2.BackColor = Color.White;
            pictureBox5.Image = Properties.Resources.candado;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db=new sistema_ventasEntities())
            {
                var listar = from usuaio in db.usuarios
                             where usuaio.Usuario == txtUsu.Text
                             && usuaio.Contraseña == txtpass.Text
                             select usuaio;
                if (listar.Count()>0)
                {
                    MessageBox.Show("Datos correctos...\nBienvenid@: "+txtUsu.Text+"\nPulse aceptar para continuar");
                    frmMenu men = new frmMenu();
                    men.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsu_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registrar reg = new registrar();
            reg.Show();
            this.Hide();
        }

        
    }
}

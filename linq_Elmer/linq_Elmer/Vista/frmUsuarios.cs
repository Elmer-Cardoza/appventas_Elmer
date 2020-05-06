using linq_Elmer.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace linq_Elmer
{
    public partial class Usuarios : Form
    {
        public Usuarios()
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

        private void Usuarios_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado= MessageBox.Show("¿Desea eliminar los datos de forma permanente?\nEsta opcion no es reversible.", "¡Eliminar datos!", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (resultado==DialogResult.OK)
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    usuarios user = new usuarios();
                    String obtener = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                    user = db.usuarios.Find(int.Parse(obtener));
                    db.usuarios.Remove(user);
                    db.SaveChanges();
                }
                mostrar();
            }
            
        }

       

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogueo f1 = new frmLogueo();
            f1.Show();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            manipularDatos man = new manipularDatos();
            man.Show();
            this.Hide();
        }

        private void dtvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

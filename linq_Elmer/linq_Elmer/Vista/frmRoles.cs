using linq_Elmer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linq_Elmer.Vista
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db=new sistema_ventasEntities())
            {
                var innertabla = from usua in db.usuarios
                                 from rolesusua in db.roles_usuarios
                                 where usua.Id_usuario == rolesusua.id_Rol_Usuario
                                 select new
                                 {
                                     Id = usua.Id_usuario,
                                     Usu = usua.Usuario,
                                     Tipo_rol = rolesusua.tipo_rol
                                 };
                dtvInner.DataSource = innertabla.ToList();
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid(); //solo en el primero load de la pagina
            }

        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        private UsuarioLogic _logic; 
        public UsuarioLogic Logic   //prop para tener 100pre disp la logica de negocio de Usuario en este formulario web (segun pdf del lab)
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic(); //usamos el construc x defecto
                }
                return _logic;
            }
        }
        public void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
            
        }

        private Usuario UsuarioActual { get; set; }
        private int SelectedID
        {
            get
            {
                if(this.ViewState["SelectedID"]!= null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
        private void LoadForm (int id) 
        {
            this.UsuarioActual = this.Logic.GetOne(id);
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombreUsuario.Text = this.UsuarioActual.NombreUsuario;


        }

        protected void lnkbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }
        private void LoadEntity(Usuario usu) //mapearAdatos
        {
            usu.Nombre = this.txtNombre.Text;
            usu.Apellido = this.txtApellido.Text;
            usu.Email = this.txtEmail.Text;
            usu.NombreUsuario = this.txtNombreUsuario.Text;
            usu.Clave = this.txtClave.Text;
            usu.Habilitado = this.chkHabilitado.Checked;
        }
        private void SaveEntity(Usuario usu) //save
        {
            this.Logic.Save(usu);
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.UsuarioActual = new Usuario();
                    this.UsuarioActual.ID = this.SelectedID;
                    this.UsuarioActual.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.UsuarioActual);
                    this.SaveEntity(this.UsuarioActual);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.UsuarioActual = new Usuario();
                    this.LoadEntity(this.UsuarioActual);
                    this.SaveEntity(this.UsuarioActual);
                    this.LoadGrid();
                    break;
                default:
                    break;

            }
            this.formPanel.Visible = false;
        }
        private void EnableForm (bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtNombreUsuario.Enabled = enable;
            this.txtClave.Enabled = enable;
            this.lblClave.Visible = enable;
            this.txtConfirmarClave.Visible = enable;
            this.lblConfirmarClave.Visible = enable;

        }

        protected void lnkbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        private void DeleteEntity(int id) //Delete/eliminar usuario
        {
            this.Logic.Delete(id);  
        }
        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.chkHabilitado.Checked = false;
            this.txtNombreUsuario.Text = string.Empty;
        }

        protected void lnkbtnNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Usuarios.aspx");
           
        }
    }
}
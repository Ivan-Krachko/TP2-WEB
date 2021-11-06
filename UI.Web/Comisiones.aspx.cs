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
    public partial class Comisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid(); //solo en el primero load de la pagina
                this.LoadDropDownList();
                
            }
        }
        ComisionLogic _comLogic;
        private ComisionLogic ComLogic
        {
            get
            {
                if (_comLogic == null)
                {
                    _comLogic = new ComisionLogic();
                }
                return _comLogic;
            }
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode //la prop se almacena/guarda en el viewstate (dentro del viewState) de la pagina xq va a ser necesario mantenerla almacenada/gardada entre postbacks.
        {                           //para no perder el estado del form entre postbacks(por eso guardamos la prop y su valor en el viewstate.)
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }
        
        private void LoadGrid()
        {
            this.gridView.DataSource = this.ComLogic.GetAll();
            this.gridView.DataBind();
        }
        private Comision ComActual { get; set; }
        private void LoadDropDownList()
        {
            PlanLogic pl = new PlanLogic();
            this.ddlPlan.DataSource = pl.GetAll();
            this.ddlPlan.DataTextField = "DescPlan";
            this.ddlPlan.DataValueField = "ID";
            this.ddlPlan.DataBind();//termina de enlazar (en sí enlaza) el origen de datos al control.
        }
        private int SelectedID //prop q almacena/contiéne el id de la com seleccionada actualmente
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
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
        private bool IsComisionActualSelected
        {
            get
            {
                return (this.SelectedID != 0); //retorna true si esto se cumple
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue; //aca obtiene el valor de la id (de esa fila/comision/row)con el SelectedValue , ya que ésta prop guarda la clave de datos (la key) que previamente seteamos que es la ID (por cada row/fila).Osea seteamos la prop SelectedID con ese valor.
        }
        private void LoadForm(int id) //completa los controles del form (los carga) en base a una comision
        {
            this.ComActual = this.ComLogic.GetOne(id);//obtenemos la instancia de comision correspondiente a esa id con getOne y la asignamos a la propiedad ComActual.
            this.txtDescCom.Text = this.ComActual.DescComision;
            this.txtAnioEsp.Text = Convert.ToString(this.ComActual.AnioEspecialidad); //lo convierto a string. xq AnioEspecialidad es int
            this.ddlPlan.SelectedValue = this.ComActual.IdPlan.ToString(); 
        }

        protected void lnkbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsComisionActualSelected)
            {
                this.EnableForm(true); //para habilitar los controles del form
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID); //aca completamos (segun q com venga) el formulario para poder editar la instancia de Comision, se carga en el form la com que hallamos seleccionado su fila en la grilla.
            }
        }
        private void LoadComision(Comision com) //cargar la comision con los datos que desamos (que son los que estamos ingresando en los campos del form)
        {
            com.DescComision = this.txtDescCom.Text;
            com.AnioEspecialidad =Convert.ToInt32(this.txtAnioEsp.Text);
            com.IdPlan = Convert.ToInt32(this.ddlPlan.SelectedValue); //le asignamos el value (en este caso es el id del plan elegido) del elemento seleccionado de la ddl.
        }
        private void SaveComision(Comision com)
        {
            this.ComLogic.Save(com);
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteComision(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.ComActual = new Comision();
                    this.ComActual.ID = this.SelectedID; //para que esta nueva instancia de comision que creamos tenga la misma id que la com que en realidad estamos editando (y q obviamente continuara con la misma id). Entonces la id se mantiene igual, no cambia.
                    this.ComActual.State = BusinessEntity.States.Modified;
                    this.LoadComision(this.ComActual);
                    this.SaveComision(this.ComActual);
                    this.LoadGrid(); //para recargar la grilla.
                    break;
                case FormModes.Alta:
                    this.ComActual = new Comision();
                    this.LoadComision(this.ComActual);
                    this.SaveComision(this.ComActual);
                    this.LoadGrid(); //para recargar/refrescar la grilla
                    break;
                default:
                    break;

            }
            this.formPanel.Visible = false;
        
        }
        private void EnableForm(bool enable)
        {
            this.txtAnioEsp.Enabled = enable;
            this.txtDescCom.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        protected void lnkbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsComisionActualSelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        private void DeleteComision(int id)
        {
            this.ComLogic.Delete(id);//le paso al metodo Delete la id recibida como parametro para poder eliminar la com correspondiente a esa id,
        }

        protected void lnkbtnNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true; //volvemos visible el form asi podemos cargarlo con datos
            this.FormMode = FormModes.Alta;
            this.ClearForm(); //metodo para limpiar controles en caso que tengan cosas escritas o seleccionadas, para dejarlos en blanco/por defecto
            this.EnableForm(true); //para habilitar los controles del form en el caso que previamente esten deshabilitados xq se realizo una eliminacion/delete con anterioridad.
        }

        private void ClearForm()
        {
            this.txtAnioEsp.Text = string.Empty;
            this.txtDescCom.Text = string.Empty;
            //para el ddl no hace falta, elegimos/seleccionamos otro y listo
        }

        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Comisiones.aspx");
        }
    }
}
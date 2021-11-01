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
    public partial class Materias : System.Web.UI.Page
    {
        MateriaLogic _materiaData;
        private MateriaLogic MateriaData
        {
            get
            {
                if(_materiaData == null)
                {
                    _materiaData = new MateriaLogic();
                }
                return _materiaData;
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
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Materia Materia { get; set; }

        private int SelectedID
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

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            this.dgvMaterias.DataSource = this.MateriaData.GetAll();
            dgvMaterias.DataBind();
            PlanLogic pl = new PlanLogic();
            ddlPlan.DataSource = pl.GetAll();
            ddlPlan.DataTextField = "DescPlan";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataBind();
        }

        protected void dgvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvMaterias.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Materia = this.MateriaData.GetOne(id);
            this.txtDescripcion.Text = this.Materia.DescMateria;
            this.txtHssemanales.Text = this.Materia.HSSemanales.ToString();
            this.txtHstotales.Text = this.Materia.HSTotales.ToString();
            this.ddlPlan.SelectedValue = this.Materia.IDPlan.ToString();
        }

        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(SelectedID);
            }
        }

        private void LoadMaterias(Materia materia)
        {
            materia.DescMateria = this.txtDescripcion.Text;
            materia.HSSemanales = int.Parse(this.txtHssemanales.Text);
            materia.HSTotales = int.Parse(this.txtHstotales.Text);
            materia.IDPlan = int.Parse(ddlPlan.SelectedValue);
        }

        private void SaveMaterias(Materia materia)
        {
            this.MateriaData.Save(materia);
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {

            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteMaterias(SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Materia = new Materia();
                    this.Materia.ID = this.SelectedID;
                    this.Materia.State = BusinessEntity.States.Modified;
                    this.LoadMaterias(this.Materia);
                    this.SaveMaterias(this.Materia);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Materia = new Materia();
                    this.LoadMaterias(this.Materia);
                    this.SaveMaterias(this.Materia);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm (bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.txtHssemanales.Enabled = enable;
            this.txtHstotales.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteMaterias(int id)
        {
            this.MateriaData.Delete(id);
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtHssemanales.Text = string.Empty;
            this.txtHstotales.Text = string.Empty;
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Materias.aspx");
        }
    }
}
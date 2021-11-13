using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Curso : System.Web.UI.Page
    {
        CursoLogic _CursoData;

        private CursoLogic CursoData
        {
            get
            {
                if (_CursoData == null)
                {
                    _CursoData = new CursoLogic();
                }
                return _CursoData;
            }
        }

        private Business.Entities.Curso CursoActual { get; set; }

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
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            if (Session["tipoPersona"].ToString() == "Admin")
            {
                dgvCurso.DataSource = CursoData.GetAll();
                dgvCurso.DataBind();
                MateriaLogic ml = new MateriaLogic();
                ComisionLogic cl = new ComisionLogic();

                ddlIDmateria.DataSource = ml.GetAll();
                ddlIDmateria.DataTextField = "DescMateria";
                ddlIDmateria.DataValueField = "ID";
                ddlIDmateria.DataBind();

                ddlIDcomision.DataSource = cl.GetAll();
                ddlIDcomision.DataTextField = "DescComision";
                ddlIDcomision.DataValueField = "ID";
                ddlIDcomision.DataBind();
            }
            else
            {
                lbtnNuevo.Visible = false;
                lbtnEditar.Visible = false;
                lbtnEliminar.Visible = false;
                lbtnInforme.Visible = false;
                dgvCurso.DataSource = CursoData.GetAll();
                dgvCurso.DataBind();
            }
            
        }

        protected void dgvCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvCurso.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.CursoActual = this.CursoData.GetOne(id);
            ddlIDmateria.SelectedValue = CursoActual.IDMateria.ToString();
            ddlIDcomision.SelectedValue = CursoActual.IDComision.ToString();
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
        }

        private void EnableForm(bool enable)
        {
            ddlIDmateria.Enabled = enable;
            ddlIDcomision.Enabled = enable;
            txtAnioCalendario.Enabled = enable;
            txtCupo.Enabled = enable;
        }

        private void LoadCursos(Business.Entities.Curso curso)
        {
            curso.IDMateria = int.Parse(ddlIDmateria.SelectedValue);
            curso.IDComision = int.Parse(ddlIDcomision.SelectedValue);
            curso.AnioCalendario = int.Parse(txtAnioCalendario.Text);
            curso.Cupo = int.Parse(txtCupo.Text);
        }

        private void SaveCursos(Business.Entities.Curso curso)
        {
            this.CursoData.Save(curso);
        }

        private void DeleteCurso(int id)
        {
            List<Business.Entities.DocenteCurso> DocentesCursos = CursoData.BuscaDocentesCurso(id);
            if (DocentesCursos.Count != 0)
            {
                Page.Response.Write("Debe eliminar la relacion que existe entre los profesores y este curso");
            }
            else
            {
                this.CursoData.Delete(id);
            }
        }

        private void ClearForm()
        {
            txtAnioCalendario.Text = string.Empty;
            txtCupo.Text = string.Empty;
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

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lbtnInforme_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Reportes/reportesCursos");
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteCurso(SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.CursoActual = new Business.Entities.Curso();
                    this.CursoActual.ID = this.SelectedID;
                    this.CursoActual.State = BusinessEntity.States.Modified;
                    this.LoadCursos(this.CursoActual);
                    this.SaveCursos(this.CursoActual);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.CursoActual = new Business.Entities.Curso();
                    this.LoadCursos(this.CursoActual);
                    this.SaveCursos(this.CursoActual);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Curso.aspx");
        }
    }
}
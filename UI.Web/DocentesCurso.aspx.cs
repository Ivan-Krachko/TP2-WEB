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
    public partial class DocentesCurso : System.Web.UI.Page
    {
        DocenteCursoLogic _docenteCursoData;

        private DocenteCursoLogic DocenteCursoData
        {
            get
            {
                if (_docenteCursoData == null)
                {
                    _docenteCursoData = new DocenteCursoLogic();
                }
                return _docenteCursoData;
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

        private DocenteCurso DocenteCurso { get; set; }

        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
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
                ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        private void LoadGrid()
        {
            if (Session["tipoPersona"].ToString() == "Admin")
            {
                dgvDocentesCursos.DataSource = DocenteCursoData.GetAll();
                dgvDocentesCursos.DataBind();

                PersonaLogic profes = new PersonaLogic();
                ddlDocente.DataSource = profes.RecuperarPorfesores();
                ddlDocente.DataTextField = "Apellido";
                ddlDocente.DataValueField = "ID";
                ddlDocente.DataBind();

                MateriaLogic materia = new MateriaLogic();
                ddlMateria.DataSource = materia.GetAll();
                ddlMateria.DataTextField = "DescMateria";
                ddlMateria.DataValueField = "ID";
                ddlMateria.DataBind();

                ComisionLogic comision = new ComisionLogic();
                ddlComision.DataSource = comision.GetAll();
                ddlComision.DataTextField = "DescComision";
                ddlComision.DataValueField = "ID";
                ddlComision.DataBind();

                ddlCargo.DataSource = Enum.GetValues(typeof(DocenteCurso.cargos));
                ddlCargo.DataBind();
            }
            else
            {
                lbtnEditar.Visible = false;
                lbtnNuevo.Visible = false;
                lbtnEliminar.Visible = false;
                lbtnInforme.Visible = false;
                lbtnAceptar.Visible = false;
                lbtnCancelar.Visible = false;
            }
        }

        protected void dgvDocentesCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvDocentesCursos.SelectedValue;
        }

        private void LoadForm(int id)
        {
            DocenteCurso = this.DocenteCursoData.GetOne(id);
            ddlDocente.SelectedValue = DocenteCurso.IDDocente.ToString();

            CursoLogic cursoData = new CursoLogic();
            Business.Entities.Curso curso = cursoData.GetOne(DocenteCurso.IDCurso);

            ddlMateria.SelectedValue = curso.IDMateria.ToString();
            ddlComision.SelectedValue = curso.IDComision.ToString();

            ddlCargo.SelectedValue = DocenteCurso.Cargo.ToString();
        }

        
        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void LoadDocenteCurso(DocenteCurso dc)
        {
            dc.IDDocente = int.Parse(ddlDocente.SelectedValue);

            int materia = int.Parse(ddlMateria.SelectedValue);
            int comision = int.Parse(ddlComision.SelectedValue);

            Business.Entities.Curso curso = DocenteCursoData.BuscarCurso(materia, comision);

            dc.IDCurso = curso.ID;


            if (this.ddlCargo.SelectedValue == DocenteCurso.cargos.Profesor.ToString())
            {
                dc.Cargo = DocenteCurso.cargos.Profesor;
            }
            else
            {
                dc.Cargo = DocenteCurso.cargos.Auxiliar;
            }

        }

        private void SaveDocenteCurso(DocenteCurso dc)
        {
            DocenteCursoData.Save(dc);
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
                    this.DocenteCurso = new DocenteCurso();
                    this.DocenteCurso.ID = this.SelectedID;
                    this.DocenteCurso.State = BusinessEntity.States.Modified;
                    this.LoadDocenteCurso(this.DocenteCurso);
                    this.SaveDocenteCurso(this.DocenteCurso);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.DocenteCurso = new DocenteCurso();
                    this.LoadDocenteCurso(this.DocenteCurso);
                    this.SaveDocenteCurso(this.DocenteCurso);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.ddlDocente.Enabled = enable;
            this.ddlMateria.Enabled = enable;
            this.ddlComision.Enabled = enable;
            this.ddlCargo.Enabled = enable;
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
            this.DocenteCursoData.Delete(id);
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("DocentesCurso.aspx");
        }

        protected void lbtnInforme_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Reportes/reportesDocentesCursos.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {

        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> DocentesCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * from docentes_cursos", sqlConn);
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                while (drDocenteCurso.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (Business.Entities.DocenteCurso.cargos)drDocenteCurso["cargo"];
                    DocentesCursos.Add(dc);
                }
                drDocenteCurso.Close();
            }
            catch (Exception ex)
            {
                Exception exepcionManejada = new Exception("Error al recuperar la lista de docentes_cursos", ex);
                throw exepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return DocentesCursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("Select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDocentesCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCurso = cmdDocentesCursos.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (Business.Entities.DocenteCurso.cargos)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la tabla docentes_cursos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }

        protected void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_docente=@id_docente, id_curso=@id_curso, cargo=@cargo where id_dictado=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de la tabla docentes_cursos", e);
                throw er;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                //abrimos la conexión
                this.OpenConnection();

                //creamos la sentencia sql y asignamos un valor al parámetro
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la fila de docentes_cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docentecurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into docentes_cursos(id_docente,id_curso,cargo) " +
                "Values(@id_docente,@id_curso,@cargo)", sqlConn);
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docentecurso.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docentecurso.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docentecurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear al docente y curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }

        public Curso BuscarCurso(int idMateria, int idComision)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscarCurso = new SqlCommand(
                    "select * from cursos " +
                    "where id_materia = @idMateria and " +
                    "id_comision=@idComision;", sqlConn);
                cmdBuscarCurso.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                cmdBuscarCurso.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                SqlDataReader drCurso = cmdBuscarCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.Cupo = (int)drCurso["cupo"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error, no se encontraron cursos para esa comision y materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return curso;
        }

        public Curso BuscarComisiones(int idMateria, int idComision)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscarCurso = new SqlCommand(
                    "select * from cursos where id_materia = @idMateria and id_comision=@idComision;", sqlConn);
                cmdBuscarCurso.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                cmdBuscarCurso.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                SqlDataReader drCurso = cmdBuscarCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.Cupo = (int)drCurso["cupo"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error, no se encontraron cursos para esa comision y materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return curso;
        }
    }
}

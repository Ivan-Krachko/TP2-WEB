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

    public class Alumnos_InscripcionesAdapter : Adapter
    {
        private static List<Alumnos_Inscripciones> _Alumnos_Inscripciones;

        private static List<Alumnos_Inscripciones> Alumnos_Inscripciones
        {
            get
            {
                if (_Alumnos_Inscripciones == null)
                {
                    _Alumnos_Inscripciones = new List<Business.Entities.Alumnos_Inscripciones>();
                    Business.Entities.Alumnos_Inscripciones al_insc;
                    al_insc = new Business.Entities.Alumnos_Inscripciones();
                    al_insc.Id_inscripcion = 1;
                    al_insc.Id_alumno = 1;
                    al_insc.Id_curso = 1;
                    al_insc.Condicion = "Aprobado";
                    al_insc.Nota = 9;
                    al_insc.State = Business.Entities.BusinessEntity.States.Unmodified;
                    _Alumnos_Inscripciones.Add(al_insc);

                    al_insc = new Business.Entities.Alumnos_Inscripciones();
                    al_insc.Id_inscripcion = 2;
                    al_insc.Id_alumno = 2;
                    al_insc.Id_curso = 2;
                    al_insc.Condicion = "Reprobado";
                    al_insc.Nota = 2;
                    al_insc.State = Business.Entities.BusinessEntity.States.Unmodified;
                    _Alumnos_Inscripciones.Add(al_insc);
                }
                return _Alumnos_Inscripciones;
            }
        }

        public List<Alumnos_Inscripciones> GetAll()
        {
            List<Alumnos_Inscripciones> alumnos_inscripciones = new List<Alumnos_Inscripciones>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos_Inscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                SqlDataReader drAlumnos_Inscripciones = cmdAlumnos_Inscripciones.ExecuteReader();
                while (drAlumnos_Inscripciones.Read())
                {
                    Alumnos_Inscripciones al_insc = new Alumnos_Inscripciones();
                    al_insc.Id_inscripcion = (int)drAlumnos_Inscripciones["id_inscripcion"];
                    al_insc.Id_alumno = (int)drAlumnos_Inscripciones["id_alumno"];
                    al_insc.Id_curso = (int)drAlumnos_Inscripciones["id_curso"];
                    al_insc.Condicion = (string)drAlumnos_Inscripciones["condicion"];
                    al_insc.Nota = (int)drAlumnos_Inscripciones["nota"];
                    alumnos_inscripciones.Add(al_insc);
                }
                drAlumnos_Inscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos_inscripciones;
        }

        public Alumnos_Inscripciones GetOne(int ID)
        {
            Alumnos_Inscripciones al_insc = new Alumnos_Inscripciones();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos_Inscripciones = new SqlCommand("Select * from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdAlumnos_Inscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos_Inscripciones = cmdAlumnos_Inscripciones.ExecuteReader();
                if (drAlumnos_Inscripciones.Read())
                {
                    al_insc.Id_inscripcion = (int)drAlumnos_Inscripciones["id_inscripcion"];
                    al_insc.Id_alumno = (int)drAlumnos_Inscripciones["id_alumno"];
                    al_insc.Id_curso = (int)drAlumnos_Inscripciones["id_curso"];
                    al_insc.Condicion = (string)drAlumnos_Inscripciones["condicion"];
                    al_insc.Nota = (int)drAlumnos_Inscripciones["nota"];
                }
                drAlumnos_Inscripciones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripciones de alumnos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return al_insc;
        }
        protected void Update(Alumnos_Inscripciones alumnos_inscripciones)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, id_curso = @id_curso, condicion = @condicion, nota = @nota  where id_inscripcion=@id_inscripcion", sqlConn);
                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = alumnos_inscripciones.Id_inscripcion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnos_inscripciones.Id_alumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnos_inscripciones.Id_curso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnos_inscripciones.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnos_inscripciones.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de la inscripción del alumno", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id_inscripcion", sqlConn);
                cmdDelete.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripción del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Alumnos_Inscripciones alumnos_inscripciones)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota) " +
                "Values(@id_alumno, @id_curso, @condicion, @nota)", sqlConn);
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnos_inscripciones.Id_alumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnos_inscripciones.Id_curso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnos_inscripciones.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnos_inscripciones.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Alumnos_Inscripciones alumnos_inscripciones)
        {
            if (alumnos_inscripciones.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnos_inscripciones.Id_inscripcion);
            }
            else if (alumnos_inscripciones.State == BusinessEntity.States.New)
            {
                this.Insert(alumnos_inscripciones);
            }
            else if (alumnos_inscripciones.State == BusinessEntity.States.Modified)
            {
                this.Update(alumnos_inscripciones);
            }
            alumnos_inscripciones.State = BusinessEntity.States.Unmodified;
        }
    }
}

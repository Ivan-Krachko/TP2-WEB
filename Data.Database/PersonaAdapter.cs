using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn); //como param del nuevo command pasamos el objConeccion y el command.text
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Fecha_nac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Tipo_persona = (Business.Entities.Persona.Tipo_personas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return personas;
        }
        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("Select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader(); //creo una nueva instancia de dataReader llamada "drPersonas" y le asigno cmdPersonas.ExecuteReader().
                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Fecha_nac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Tipo_persona = (Business.Entities.Persona.Tipo_personas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la Persona", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }
        protected void Update(Persona perso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre=@nombre, apellido=@apellido,direccion=@direccion,email=@email," +
                    "telefono=@telefono,fecha_nac=@fecha_nac,legajo=@legajo,tipo_persona=@tipo_persona,id_plan=@id_plan " +
                    "where id_persona=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = perso.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = perso.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = perso.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = perso.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = perso.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = perso.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = perso.Fecha_nac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = perso.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = perso.Tipo_persona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = perso.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de Personas", e);
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
                SqlCommand cmdDelete =
                new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID; //creo y agrego a la coleccion de parametros, un parametro "@id" int, con su "value": ID.
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona pers)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into personas(nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) " +
                "Values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)", sqlConn);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = pers.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = pers.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = pers.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = pers.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = pers.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = pers.Fecha_nac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = pers.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = pers.Tipo_persona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = pers.IDPlan;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona perso)
        {
            if (perso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(perso.ID);
            }
            else if (perso.State == BusinessEntity.States.New)
            {
                this.Insert(perso);
            }
            else if (perso.State == BusinessEntity.States.Modified)
            {
                this.Update(perso);
            }
            perso.State = BusinessEntity.States.Unmodified;
        }

        public List<Persona> RecuperarProfesores()
        {
            List<Persona> profes = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "select * from personas where tipo_persona = 2", sqlConn); //como param del nuevo command pasamos el objConeccion y el command.text
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona profesor = new Persona();
                    profesor.ID = (int)drPersonas["id_persona"];
                    profesor.Nombre = (string)drPersonas["nombre"];
                    profesor.Apellido = (string)drPersonas["apellido"];
                    profesor.Direccion = (string)drPersonas["direccion"];
                    profesor.Email = (string)drPersonas["email"];
                    profesor.Telefono = (string)drPersonas["telefono"];
                    profesor.Fecha_nac = (DateTime)drPersonas["fecha_nac"];
                    profesor.Legajo = (int)drPersonas["legajo"];
                    profesor.Tipo_persona = (Business.Entities.Persona.Tipo_personas)drPersonas["tipo_persona"];
                    profesor.IDPlan = (int)drPersonas["id_plan"];
                    profes.Add(profesor);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }

            return profes;
        }

    }
}

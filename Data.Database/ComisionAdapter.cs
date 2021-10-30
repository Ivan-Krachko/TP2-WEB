using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Comision> _Comisiones;

        private static List<Comision> Comisiones
        {
            get
            {
                if (_Comisiones == null)
                {
                    _Comisiones = new List<Business.Entities.Comision>();
                    Business.Entities.Comision com;
                    com = new Business.Entities.Comision();
                    com.ID = 1;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 1;
                    com.DescComision = "comision de max 40 alumnos";
                    _Comisiones.Add(com);

                    com = new Business.Entities.Comision();
                    com.ID = 2;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 2;
                    com.DescComision = "comision de max 35 alumnos";
                    _Comisiones.Add(com);

                    com = new Business.Entities.Comision();
                    com.ID = 3;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 3;
                    com.DescComision = "comision de max 50 alumnos";
                    _Comisiones.Add(com);

                }
                return _Comisiones;
            }
        }
        #endregion

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(com);

                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from comisiones where id_comision = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdUsuarios.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }
        protected void Update(Comision comi)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad, id_plan=@id_plan where id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comi.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comi.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comi.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comi.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al recuperar los datos de Comisiones", e);
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
                new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision comi)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into comisiones(desc_comision,anio_especialidad,id_plan) " +
                "Values(@desc_comision,@anio_especialidad,@id_plan)", sqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comi.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comi.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comi.IdPlan;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comi)
        {
            if (comi.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comi.ID);
            }
            else if (comi.State == BusinessEntity.States.New)
            {
                this.Insert(comi);
            }
            else if (comi.State == BusinessEntity.States.Modified)
            {
                this.Update(comi);
            }
            comi.State = BusinessEntity.States.Unmodified;
        }
    }
}

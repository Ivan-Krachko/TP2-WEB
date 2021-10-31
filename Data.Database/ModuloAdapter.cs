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
    public class ModuloAdapter : Adapter
    {

        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader drModulos = cmdModulos.ExecuteReader();
                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulos["id_modulo"];
                    mod.DescModulo = (string)drModulos["desc_modulo"];
                    mod.Ejecuta = (string)drModulos["ejecuta"];
                    modulos.Add(mod);
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }

        public Modulo GetOne(int ID)
        {
            Modulo mod = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("Select * from modulos where id_modulo = @id", sqlConn);
                cmdModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();
                if (drModulos.Read())
                {
                    mod.ID = (int)drModulos["id_modulo"];
                    mod.DescModulo = (string)drModulos["desc_modulo"];
                    mod.Ejecuta = (string)drModulos["ejecuta"];
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del modulo", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mod;
        }
        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos SET desc_modulo=@desc_modulo, ejecuta=@ejecuta where id_modulo=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.DescModulo;
                cmdSave.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = modulo.Ejecuta;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos del modulo", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete modulos where id_modulo=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into modulos(desc_modulo,ejecuta) " +
                "Values(@desc_modulo,@ejecuta)", sqlConn);
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.DescModulo;
                cmdSave.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = modulo.Ejecuta;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.New)
            {
                this.Insert(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                this.Update(modulo);
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
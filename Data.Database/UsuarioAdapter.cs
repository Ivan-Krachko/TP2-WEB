using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from usuarios where id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email where id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al recuperar los datos de usuario", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email) " +
                "Values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email) ", sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        public Business.Entities.Persona BuscarPersona(int idUsuario)
        {
            Persona pers = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscaPersona = new SqlCommand(
                    "select p.id_persona,p.nombre,p.apellido,direccion,p.email,telefono,fecha_nac,legajo,tipo_persona,id_plan from usuarios u " +
                    "inner join personas p on p.id_persona=u.id_persona " +
                    "where id_usuario= @id", sqlConn);
                cmdBuscaPersona.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drPersona = cmdBuscaPersona.ExecuteReader();
                if (drPersona.Read())
                {
                    pers.ID = (int)drPersona["id_persona"];
                    pers.Nombre = (string)drPersona["nombre"];
                    pers.Apellido = (string)drPersona["apellido"];
                    pers.Direccion = (string)drPersona["direccion"];
                    pers.Email = (string)drPersona["email"];
                    pers.Telefono = (string)drPersona["telefono"];
                    pers.Fecha_nac = (DateTime)drPersona["fecha_nac"];
                    pers.Legajo = (int)drPersona["legajo"];
                    pers.TipoPersona = (Business.Entities.Persona.tipoPersonas)drPersona["tipo_persona"];
                    pers.IDPlan = (int)drPersona["id_plan"];
                }
                drPersona.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return pers;
        }

        public void ActualizarPersona(string nombreUsuario, string apellidoUsuario, string email, int idPersona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre=@nombre, apellido=@apellido, email=@email " +
                    "where id_persona=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = idPersona;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombreUsuario;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = apellidoUsuario;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de usuario", e);
                throw er;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public Persona BuscaPersonaxNombApeEm(string nombre, string apellido, string mail)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBusca = new SqlCommand(
                    "select * from personas " +
                    "where nombre=@nombre and " +
                    "apellido = @apellido and " +
                    "email=@email; ", sqlConn);
                cmdBusca.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                cmdBusca.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = apellido;
                cmdBusca.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = mail;
                SqlDataReader drPersona = cmdBusca.ExecuteReader();
                if (drPersona.Read())
                {
                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Email = (string)drPersona["email"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.Fecha_nac = (DateTime)drPersona["fecha_nac"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.TipoPersona = (Business.Entities.Persona.tipoPersonas)drPersona["tipo_persona"];
                    per.IDPlan = (int)drPersona["id_plan"];
                }
                drPersona.Close();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al encontrar la persona", e);
                throw er;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void CargarIDPersona(string nombreUser, string apellidoUser, string emailUser, int idPersona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdCargaID = new SqlCommand(
                    "Update usuarios set id_persona=@idPersona " +
                    "where nombre=@nombre and apellido=@apellido and email=@email;", sqlConn);
                cmdCargaID.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                cmdCargaID.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombreUser;
                cmdCargaID.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = apellidoUser;
                cmdCargaID.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = emailUser;
                cmdCargaID.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar la id persona de usuario", e);
                throw er;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }

}

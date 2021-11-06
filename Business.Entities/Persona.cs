using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _email;
        private string _telefono;
        private DateTime _fecha_nac;
        private int _legajo;
        private tipoPersonas _tipoPersona;

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }
        public DateTime Fecha_nac
        {
            get
            {
                return _fecha_nac;
            }
            set
            {
                _fecha_nac = value;
            }
        }

        public int Legajo
        {
            get
            {
                return _legajo;
            }
            set
            {
                _legajo = value;
            }
        }
        public tipoPersonas TipoPersona
        {
            get
            {
                return _tipoPersona;
            }
            set
            {
                _tipoPersona = value;
            }
        }
        public int IDPlan { get; set; }
        public enum tipoPersonas
        {
            Admin = 1,
            Docente = 2,
            Alumno = 3
        }
    }
}

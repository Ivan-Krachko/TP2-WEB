﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Business.Logic.UsuarioLogic ul = new Business.Logic.UsuarioLogic();
            List<Business.Entities.Usuario> users = ul.GetAll();

            Business.Entities.Usuario usuario = new Business.Entities.Usuario();
            bool encuentra = false;

            foreach (Business.Entities.Usuario user in users)
            {
                if (user.NombreUsuario == txtUsuario.Text)
                {
                    encuentra = true;
                    usuario = user;
                }
            }

            if (encuentra == true)
            {
                if (usuario.Clave == txtContraseña.Text)
                {
                    Page.Response.Redirect("Default.aspx");
                }
                else
                {
                    Page.Response.Write("Usuario y/o contraseña incorrecto/s");
                }
            }
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrecto/s");
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
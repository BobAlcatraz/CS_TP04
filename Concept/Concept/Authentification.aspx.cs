﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class Authentification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void connection_click(object sender, EventArgs e)
        {
            if (this.UtilisateurIdentif())
            {
                Utilisateur u = (Utilisateur)this.Session["Utilisateur"];
                if (u.Type.Id == 'A')
                    this.Response.Redirect("Gestion.aspx");
                else if (u.Type.Id == 'G')
                {
                    this.Response.Redirect("SuiviDesCommandes.aspx");
                }
                else
                    this.Response.Redirect("Default.aspx");
            }
        }

        private bool UtilisateurIdentif()
        {
            bool trouve = false;
            if (BDGestion.Instance.Authentifier(this.tb_email.Text,this.tb_motDePasse.Text) != null)
            {
                this.Session["Utilisateur"] = BDGestion.Instance.Authentifier(this.tb_email.Text, this.tb_motDePasse.Text);
                trouve = true;
            } 
            return trouve;
        }

        protected void création_click(object sender, EventArgs e)
        {
            // vide
        }
    }
}
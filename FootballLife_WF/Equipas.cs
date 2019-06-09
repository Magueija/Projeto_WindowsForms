﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FootballLife_WF
{
    public partial class Equipas : Form
    {
        public Equipas()
        {
            InitializeComponent();
        }

        private void Equipas_Load(object sender, EventArgs e)
        {
            Seniores();
            Juniores();
            Juvenis();
            Iniciados();
            Infantis();
            Benjamins();
            Traquinas();
            Petizes();
        }

        private void Seniores()
        {
            flowpanel_Seniores.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 1) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();
                    Users(IDTreinador, NomeTreinador);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 1) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Users(string ID, string Nome)
        {
            Panel panel = new Panel();
            panel.Width = 260;
            panel.Height = 50;
            panel.Anchor = AnchorStyles.Top;
            panel.BackColor = Color.White;
            panel.Visible = true;
            panel.Name = "Panel" + ID;
            panel.Margin = new Padding(5, 5, 0, 0);
            flowpanel_Seniores.Controls.Add(panel);

            PictureBox Pb = new PictureBox();
            Pb.Location = new Point(5, 5);
            Pb.Width = 40;
            Pb.Height = 40;
            Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Visible = true;
            panel.Controls.Add(Pb);

            Label lblUser = new Label();
            lblUser.Location = new Point(50, 15);
            lblUser.Text = Nome;
            lblUser.ForeColor = Color.Firebrick;
            lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblUser.Visible = true;
            lblUser.Width = 200;
            lblUser.Tag = ID;
            panel.Controls.Add(lblUser);
        }

        private void Juniores()
        {
            flowpanel_Juniores.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 2) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 2) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Juvenis()
        {
            flowpanel_Juvenis.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 3) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 3) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Iniciados()
        {
            flowpanel_Iniciados.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 4) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 4) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }


        private void Infantis()
        {
            flowpanel_Infantis.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 5) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 5) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Benjamins()
        {
            flowpanel_Benjamins.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 6) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 6) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Traquinas()
        {
            flowpanel_Traquinas.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 7) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 7) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Petizes()
        {
            flowpanel_Petizes.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 8) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 8) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        //==============================================================================================

        private void Img_Menu_Click(object sender, EventArgs e)
        {
            if(panel_Menu.Visible == true && btn_Menu.Visible == true)
            {
                panel_Menu.Visible = false;
                btn_Menu.Visible = false;
            }
            else
            {
                panel_Menu.Visible = true;
                btn_Menu.Visible = true;
            }
        }

//==============================================================================================

      

//==============================================================================================
        private void Btn_Home_Click(object sender, EventArgs e)
        {
            PaginaInicial PgInicio = new PaginaInicial();
            this.Hide();
            PgInicio.ShowDialog();
            this.Dispose();
        }

        private void Btn_Jogos_Click(object sender, EventArgs e)
        {
            Jogos Jogo = new Jogos();
            this.Hide();
            Jogo.ShowDialog();
            this.Dispose();
        }

        private void Btn_Estadio_Click(object sender, EventArgs e)
        {
            Estadio Estadio = new Estadio();
            this.Hide();
            Estadio.ShowDialog();
            this.Dispose();
        }

        private void PesquisaSeniores()
        {
            flowpanel_Seniores.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 1) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 1) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Seniores.Controls.Count == 0)
                {
                    lbl1.Visible = true;
                }
                else
                {
                    lbl1.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaJuniores()
        {
            flowpanel_Juniores.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 2) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 2) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Juniores.Controls.Count == 0)
                {
                    lbl2.Visible = true;
                }
                else
                {
                    lbl2.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaJuvenis()
        {
            flowpanel_Juvenis.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 3) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 3) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Juvenis.Controls.Count == 0)
                {
                    lbl3.Visible = true;
                }
                else
                {
                    lbl3.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaIniciados()
        {
            flowpanel_Iniciados.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 4) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 4) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Iniciados.Controls.Count == 0)
                {
                    lbl4.Visible = true;
                }
                else
                {
                    lbl4.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaInfantis()
        {
            flowpanel_Infantis.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 5) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 5) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Infantis.Controls.Count == 0)
                {
                    lbl5.Visible = true;
                }
                else
                {
                    lbl5.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaBenjamins()
        {
            flowpanel_Benjamins.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 6) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 6) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Benjamins.Controls.Count == 0)
                {
                    lbl6.Visible = true;
                }
                else
                {
                    lbl6.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaTraquinas()
        {
            flowpanel_Traquinas.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 7) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 7) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Traquinas.Controls.Count == 0)
                {
                    lbl7.Visible = true;
                }
                else
                {
                    lbl7.Visible = false;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void PesquisaPetizes()
        {
            flowpanel_Petizes.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDTreinador = "";
            string NomeTreinador = "";

            string IDAtleta = "";
            string NomeAtleta = "";

            try
            {
                //TREINADORES
                SqlDataReader dr;
                string Query = ("SELECT IDTreinador, Nome FROM dbo.TblTreinador WHERE(Apagado = 0) AND(FK_IDEscalao = 8) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    IDTreinador = dr["IDTreinador"].ToString();
                    NomeTreinador = dr["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDTreinador;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoTreinador;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeTreinador;
                    lblUser.ForeColor = Color.Firebrick;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDTreinador;
                    panel.Controls.Add(lblUser);
                }
                dr.Close();


                //ATLETAS
                SqlDataReader drAtleta;
                string QueryAtleta = ("SELECT IDAtleta, Nome, Lesao FROM dbo.TblAtleta WHERE(Apagado = 0) AND(FK_IDEscalao = 8) AND(Nome COLLATE Latin1_General_CI_AI LIKE '%" + tb_Pesquisar.Text + "%' COLLATE Latin1_General_CI_AI) ORDER BY Nome");
                SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                drAtleta = CommandAtleta.ExecuteReader();

                while (drAtleta.Read())
                {
                    IDAtleta = drAtleta["IDAtleta"].ToString();
                    NomeAtleta = drAtleta["Nome"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 260;
                    panel.Height = 50;
                    panel.Anchor = AnchorStyles.Top;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDAtleta;
                    panel.Margin = new Padding(5, 5, 0, 0);
                    flowpanel_Seniores.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(5, 5);
                    Pb.Width = 40;
                    Pb.Height = 40;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAtleta;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 15);
                    lblUser.Text = NomeAtleta;
                    lblUser.Font = new Font("Berlin Sans FB ", 9, FontStyle.Bold);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    lblUser.Width = 200;
                    lblUser.Tag = IDAtleta;
                    panel.Controls.Add(lblUser);
                }
                drAtleta.Close();

                if (flowpanel_Petizes.Controls.Count == 0)
                {
                    lbl8.Visible = true;
                }
                else
                {
                    lbl8.Visible = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            con.Close();
        }

        private void Btn_DeletePesquisa_Click(object sender, EventArgs e)
        {
            tb_Pesquisar.Text = "";

            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;

            Seniores();
            Juniores();
            Juvenis();
            Iniciados();
            Infantis();
            Benjamins();
            Traquinas();
            Petizes();
        }


        private void Btn_Lupa_Click(object sender, EventArgs e)
        {
            if (tb_Pesquisar.Text != "")
            {
                PesquisaSeniores();
                PesquisaJuniores();
                PesquisaJuvenis();
                PesquisaIniciados();
                PesquisaInfantis();
                PesquisaBenjamins();
                PesquisaTraquinas();
                PesquisaPetizes();
            }
        }

        private void Tb_Pesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tb_Pesquisar.Text != "")
                {
                    PesquisaSeniores();
                    PesquisaJuniores();
                    PesquisaJuvenis();
                    PesquisaIniciados();
                    PesquisaInfantis();
                    PesquisaBenjamins();
                    PesquisaTraquinas();
                    PesquisaPetizes();
                }
            }
        }
    }
}


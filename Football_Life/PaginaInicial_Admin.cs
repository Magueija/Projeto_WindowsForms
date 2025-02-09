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
    public partial class PaginaInicial_Admin : Form
    {
        public PaginaInicial_Admin()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            InitializeComponent();
        }

        private void PaginaInicial_Admin_Load(object sender, EventArgs e)
        {
            Discussoes();
        }


        //==============================================================================================


        private void NovaDiscussao_Hover()
        {
            lbl_NovaDiscussao.Font = new Font("Berlin Sans FB Demi", 10, FontStyle.Underline);
        }

        private void Lbl_Novadiscussao_MouseHover(object sender, EventArgs e)
        {
            NovaDiscussao_Hover();
        }

        private void Img_NovaDiscussao_MouseHover(object sender, EventArgs e)
        {
            NovaDiscussao_Hover();
        }

        private void Btn_NovaDiscussao_MouseHover(object sender, EventArgs e)
        {
            NovaDiscussao_Hover();
        }

        //============

        private void NovaDiscussao_Leave()
        {
            lbl_NovaDiscussao.Font = new Font("Berlin Sans FB Demi", 10, FontStyle.Regular);
        }

        private void Lbl_Novadiscussao_MouseLeave(object sender, EventArgs e)
        {
            NovaDiscussao_Leave();
        }
        private void Img_NovaDiscussao_MouseLeave(object sender, EventArgs e)
        {
            NovaDiscussao_Leave();
        }
        private void Btn_NovaDiscussao_MouseLeave(object sender, EventArgs e)
        {
            NovaDiscussao_Leave();
        }

        //==============================================================================================

        int i = 2;
        private void Discussoes()
        {
            flowpanel_Discussoes.Controls.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string IDDiscussao = "";
            string NomeDiscussao = "";
            string Descricao = "";
            string NomeAdmin = "";
            string IDAdmin = "";

            try{
                SqlDataReader dr;
                string Query = ("SELECT TOP (" + i + ") dbo.TblDiscussao.IDDiscussao, dbo.TblDiscussao.NomeDiscussao, dbo.TblDiscussao.Descricao, dbo.TblAdministrador.IDAdministrador, dbo.TblAdministrador.Nome FROM dbo.TblDiscussao INNER JOIN dbo.TblAdministrador ON dbo.TblDiscussao.FK_IDAdministrador = dbo.TblAdministrador.IDAdministrador WHERE dbo.TblAdministrador.Apagado = 0 AND dbo.TblDiscussao.Apagado = 0 ORDER BY dbo.TblDiscussao.IDDiscussao DESC");
                SqlCommand Command = new SqlCommand(Query, con);
                dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    IDDiscussao = dr["IDDiscussao"].ToString();
                    NomeDiscussao = dr["NomeDiscussao"].ToString();
                    Descricao = dr["Descricao"].ToString();
                    NomeAdmin = dr["Nome"].ToString();

                    IDAdmin = dr["IDAdministrador"].ToString();

                    Panel panel = new Panel();
                    panel.Width = 800;
                    panel.Height = 250;
                    panel.Margin = new Padding(5, 5, 5, 0);
                    panel.Anchor = AnchorStyles.Top;
                    panel.BorderStyle = BorderStyle.Fixed3D;
                    panel.BackColor = Color.White;
                    panel.Visible = true;
                    panel.Name = "Panel" + IDDiscussao;
                    flowpanel_Discussoes.Controls.Add(panel);

                    PictureBox Pb = new PictureBox();
                    Pb.Location = new Point(10, 10);
                    Pb.Width = 30;
                    Pb.Height = 30;
                    Pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    Pb.Image = FootballLife_WF.Properties.Resources.LogoAdmin;
                    Pb.SizeMode = PictureBoxSizeMode.Zoom;
                    Pb.Visible = true;
                    panel.Controls.Add(Pb);

                    Label lblUser = new Label();
                    lblUser.Location = new Point(50, 18);
                    lblUser.Width = 250;
                    lblUser.Text = NomeAdmin;
                    lblUser.Font = new Font("Berlin Sans FB", 10, FontStyle.Regular);
                    lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblUser.Visible = true;
                    panel.Controls.Add(lblUser);

                    Label lblTitulo = new Label();
                    lblTitulo.Location = new Point(15, 70);
                    lblTitulo.Width = 765;
                    lblTitulo.Text = NomeDiscussao;
                    lblTitulo.Font = new Font("Berlin Sans FB Demi", 13, FontStyle.Regular);
                    lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lblTitulo.Visible = true;
                    panel.Controls.Add(lblTitulo);

                    TextBox Tb = new TextBox();
                    Tb.Location = new Point(17, 100);
                    Tb.Width = 763;
                    Tb.Height = 120;
                    Tb.Text = Descricao;
                    Tb.Multiline = true;
                    Tb.ReadOnly = true;
                    Tb.Enabled = false;
                    Tb.Font = new Font("Arial", 12, FontStyle.Regular);
                    Tb.Anchor = AnchorStyles.Top;
                    Tb.Visible = true;
                    panel.Controls.Add(Tb);


                    PictureBox PbDelete = new PictureBox();
                    PbDelete.Location = new Point(760, 10);
                    PbDelete.Width = 15;
                    PbDelete.Height = 20;
                    PbDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    PbDelete.Image = FootballLife_WF.Properties.Resources.Delete;
                    PbDelete.SizeMode = PictureBoxSizeMode.Zoom;
                    PbDelete.Cursor = Cursors.Hand;
                    PbDelete.Visible = false;
                    PbDelete.Tag = IDDiscussao;
                    PbDelete.Name = "Btn_Discussao";

                    PbDelete.Click += Btn_DeleteDiscussao_Click;
                    panel.Controls.Add(PbDelete);

                    if (Program.CurrentIDUser == Convert.ToInt32(IDAdmin))
                    {
                        PbDelete.Visible = true;
                    }

                }
                dr.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void Btn_DeleteDiscussao_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Tem a certeza que pretente eliminar esta discussão?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
                con.Open();

                string IDDiscussao = "";

                try
                {
                    string Query = "UPDATE TblDiscussao SET Apagado = 1 WHERE IDDiscussao = @IDDiscussao";

                    PictureBox PbDELETE = (PictureBox)sender;
                    IDDiscussao = PbDELETE.Tag.ToString();
                    SqlCommand Command = new SqlCommand(Query, con);
                    Command.Parameters.AddWithValue("@IDDiscussao", IDDiscussao);
                    Command.ExecuteNonQuery();

                    MessageBox.Show($"Discussão Apagada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                foreach (Control c in flowpanel_Discussoes.Controls)
                {
                    if (c.Name == "Panel" + IDDiscussao)
                    {
                        flowpanel_Discussoes.Controls.Remove(c);
                    }
                }
            }
        }


        //==============================================================================================


        //Side Menu
        private void Img_Menu_Click(object sender, EventArgs e)
        {
            if (panel_Menu.Visible == true)
            {
                panel_Menu.Visible = false;
            }
            else
            {
                panel_Menu.Visible = true;
            }
        }


        //==============================================================================================


        private void Btn_NovaDiscussao_Click(object sender, EventArgs e)
        {
            NovaDiscussão PgInicio = new NovaDiscussão();
            PgInicio.ShowDialog();

            Discussoes();
        }

        
        //Side Menu Buttons click
        private void Btn_Jogos_Click(object sender, EventArgs e)
        {
            Jogos jgs = new Jogos();
            this.Hide();
            jgs.ShowDialog();
            this.Dispose();
        }

        private void Btn_Equipas_Click(object sender, EventArgs e)
        {
            Equipas Equipas = new Equipas();
            this.Hide();
            Equipas.ShowDialog();
            this.Dispose();
        }

        private void Btn_Estadio_Click(object sender, EventArgs e)
        {
            Estadio Estadio = new Estadio();
            this.Hide();
            Estadio.ShowDialog();
            this.Dispose();
        }

        private void Btn_Historia_Click(object sender, EventArgs e)
        {
            Historia hist = new Historia();
            this.Hide();
            hist.ShowDialog();
            this.Dispose();
        }
       
        private void Btn_Financiamento_Click(object sender, EventArgs e)
        {
            Financiamento financas = new Financiamento();
            this.Hide();
            financas.ShowDialog();
            this.Dispose();
        }

        private void Btn_Inventario_Click(object sender, EventArgs e)
        {
            Inventario Inv = new Inventario();
            this.Hide();
            Inv.ShowDialog();
            this.Dispose();
        }
       
        private void Btn_Utilizadores_Click(object sender, EventArgs e)
        {
            Utilizadores Users = new Utilizadores();
            this.Hide();
            Users.ShowDialog();
            this.Dispose();
        }


        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Program.CurrentFuncaoUser = "";
            Program.CurrentIDUser = 0;
            Program.CurrentIDEscalao = 0;

            PaginaInicial PgInicio = new PaginaInicial();
            this.Hide();
            PgInicio.ShowDialog();
            this.Dispose();
        }

        private void AddMore2Discussoes_Click(object sender, EventArgs e)
        {
            i += 2;

            Discussoes();
        }
    }
}


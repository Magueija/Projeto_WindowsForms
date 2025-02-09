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
using System.Media;

namespace FootballLife_WF
{
    public partial class Add_LucroDespesa : Form
    {
        string LucroDespesa = "";

        public Add_LucroDespesa(string Nome)
        {
            InitializeComponent();
            this.Text = "Adicionar " + Nome;
            lbl_Titulo.Text = "Adicionar " + Nome;
            LucroDespesa = Nome;
            if(Nome == "Despesa")
            {
                rb_Utilizadores.Visible = false;
                rb_Outros.Visible = false;

                panel_Outros.Visible = true;
                panel_Utilizador.Visible = false;
            }
        }

        private void Add_LucroDespesa_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            try
            {
                //COMBOBOX SOCIOS
                SqlCommand scSocio = new SqlCommand("SELECT DISTINCT dbo.TblSocio.IDSocio, dbo.TblSocio.Nome FROM dbo.TblSocio INNER JOIN dbo.TblCotaSocio ON dbo.TblSocio.IDSocio = dbo.TblCotaSocio.FK_IDSocio WHERE(dbo.TblSocio.Apagado = 0) AND(dbo.TblCotaSocio.Pago = 0)", con);
                SqlDataReader drSocio;

                drSocio = scSocio.ExecuteReader();
                DataTable dtSocio = new DataTable();
                dtSocio.Columns.Add("IDSocio", typeof(string));
                dtSocio.Columns.Add("Nome", typeof(string));
                dtSocio.Load(drSocio);

                cb_UNomeSocio.ValueMember = "IDSocio";
                cb_UNomeSocio.DisplayMember = "Nome";
                cb_UNomeSocio.DataSource = dtSocio;


                //COMBOBOX ATLETAS
                SqlCommand scAtleta = new SqlCommand("SELECT DISTINCT dbo.TblAtleta.IDAtleta, dbo.TblAtleta.Nome FROM dbo.TblAtleta INNER JOIN dbo.TblCotaAtleta ON dbo.TblAtleta.IDAtleta = dbo.TblCotaAtleta.FK_IDAtleta WHERE(dbo.TblAtleta.Apagado = 0) AND(dbo.TblCotaAtleta.Pago = 0)", con);
                SqlDataReader drAtleta;

                drAtleta = scAtleta.ExecuteReader();
                DataTable dtAtleta = new DataTable();
                dtAtleta.Columns.Add("IDAtleta", typeof(string));
                dtAtleta.Columns.Add("Nome", typeof(string));
                dtAtleta.Load(drAtleta);

                cb_UNomeAtleta.ValueMember = "IDAtleta";
                cb_UNomeAtleta.DisplayMember = "Nome";
                cb_UNomeAtleta.DataSource = dtAtleta;

                if (dtSocio.Rows.Count == 0 && dtAtleta.Rows.Count == 0)
                {
                    panel_Utilizador.Visible = false;
                    panel_Outros.Visible = true;

                    rb_Outros.Checked = true;
                    rb_Utilizadores.Checked = false;
                    rb_Utilizadores.Enabled = false;
                }
                else if (dtSocio.Rows.Count != 0 && dtAtleta.Rows.Count == 0)
                {
                    cb_UFuncao.SelectedIndex = 1;
                    cb_UFuncao.Enabled = false;
                }
                else if (dtSocio.Rows.Count == 0 && dtAtleta.Rows.Count != 0)
                {
                    cb_UFuncao.SelectedIndex = 0;
                    cb_UFuncao.Enabled = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        //====================================================================


        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_Utilizadores.Checked == true)
            {
                panel_Outros.Visible = false;
                panel_Utilizador.Visible = true;
            }
            else if (rb_Outros.Checked == true)
            {
                panel_Outros.Visible = true;
                panel_Utilizador.Visible = false;
            }
        }


        private void Cb_UFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_UFuncao.SelectedItem.ToString() == "Atleta")
            {
                cb_UNomeAtleta.Visible = true;
                cb_UNomeSocio.Visible = false;
            }
            else if (cb_UFuncao.SelectedItem.ToString() == "Sócio")
            {
                cb_UNomeAtleta.Visible = false;
                cb_UNomeSocio.Visible = true;
            }
        }


        //=====================================================================


        //Gravar
        private void Btn_GravarOutros_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string Query = "";

            if (tb_ONome.Text == "" || tb_OMontante.Text == "")
            {
                MessageBox.Show("Campos obrigatórios não preenchidos!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    double tb_txt;
                    if (!double.TryParse(tb_OMontante.Text.ToString(), out tb_txt))
                    {
                        MessageBox.Show("Campos numéricos com valores inválidos!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Query = "INSERT INTO dbo.Tbl" + LucroDespesa + "s (Nome, Valor, Descricao, FK_IDClube) VALUES (@Nome, @Valor, @Descricao, @IDClube)";

                    SqlCommand CommandINSERT = new SqlCommand(Query, con);
                    CommandINSERT.Parameters.AddWithValue("@Nome", tb_ONome.Text);
                    CommandINSERT.Parameters.AddWithValue("@Valor", tb_txt);
                    CommandINSERT.Parameters.AddWithValue("@Descricao", tb_ODescricao.Text);
                    CommandINSERT.Parameters.AddWithValue("@IDClube", "1");
                    CommandINSERT.ExecuteNonQuery();


                    double saldo = 0;
                    SqlDataReader dr2;
                    string Query2 = ("SELECT Saldo FROM dbo.TblClube WHERE IDClube = 1");
                    SqlCommand Command2 = new SqlCommand(Query2, con);
                    dr2 = Command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        saldo = Convert.ToDouble(dr2["Saldo"]);
                    }
                    dr2.Close();

                    
                    double novoSaldo = saldo;

                    if (LucroDespesa == "Lucro")
                    {
                        novoSaldo = saldo + tb_txt;
                    }
                    else if(LucroDespesa == "Despesa")
                    {
                        novoSaldo = saldo - tb_txt;
                    }

                    string Querysaldo = "UPDATE TblClube SET Saldo = @NovoSaldo WHERE IDClube = 1";
                    SqlCommand Commandsaldo = new SqlCommand(Querysaldo, con);
                    Commandsaldo.Parameters.AddWithValue("@NovoSaldo", Math.Round(novoSaldo, 2));
                    Commandsaldo.ExecuteNonQuery();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                this.Dispose();
            }
            
        }

        private void Btn_GravarUtilizador_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            con.Open();

            string QueryLucro = "";
            string QueryCota = "";

            string IDLucro = "";

            if(cb_UFuncao.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Campos obrigatórios não preenchidos!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Nome = "";
                    string Valor = "";
                    string IDMes = "";
                    string Mes = "";

                    if(cb_UFuncao.SelectedItem.ToString() == "Atleta")
                    {
                        //SELECIONA O NOME DO ATLETA PARA INSERIR NA TABELA LUCROS
                        SqlDataReader drAtleta;
                        string QueryAtleta = ("SELECT Nome FROM dbo.TblAtleta WHERE IDAtleta = " + cb_UNomeAtleta.SelectedValue);
                        SqlCommand CommandAtleta = new SqlCommand(QueryAtleta, con);
                        drAtleta = CommandAtleta.ExecuteReader();
                        while (drAtleta.Read())
                        {
                            Nome = drAtleta["Nome"].ToString();
                        }
                        drAtleta.Close();


                        //SELECIONA O MES A PAGAR (O MAIS ANTIGO)
                        SqlDataReader drMes;
                        string QueryMes = ("SELECT dbo.TblMes.IDMes, dbo.TblMes.Mes FROM dbo.TblMes RIGHT OUTER JOIN dbo.TblCotaAtleta ON dbo.TblMes.IDMes = dbo.TblCotaAtleta.FK_IDMes WHERE " +
                            "dbo.TblCotaAtleta.Pago = 0 AND dbo.TblCotaAtleta.FK_IDAtleta = " + cb_UNomeAtleta.SelectedValue);
                        SqlCommand CommandMes = new SqlCommand(QueryMes, con);
                        drMes = CommandMes.ExecuteReader();

                        if (drMes.Read())
                        {
                            IDMes = drMes["IDMes"].ToString();
                            Mes = drMes["Mes"].ToString();
                        }

                        drMes.Close();


                        //SELECIONA O VALOR DA COTA DO ATLETA
                        SqlDataReader drValor;
                        string QueryValor = ("SELECT Valor FROM dbo.TblValorCota WHERE (IDValorCota = 1)");
                        SqlCommand CommandValor = new SqlCommand(QueryValor, con);
                        drValor = CommandValor.ExecuteReader();
                        while (drValor.Read())
                        {
                            Valor = drValor["Valor"].ToString();
                        }
                        drValor.Close();


                        QueryLucro = "INSERT INTO dbo.TblLucros (Nome, Valor, Descricao, FK_IDClube) VALUES (@Nome, @Valor, @Descricao, @IDClube)";

                        SqlCommand CommandLucro = new SqlCommand(QueryLucro, con);
                        CommandLucro.Parameters.AddWithValue("@Nome", Nome + " - " + Mes);
                        CommandLucro.Parameters.AddWithValue("@Valor", Valor);
                        CommandLucro.Parameters.AddWithValue("@Descricao", tb_UDescricao.Text);
                        CommandLucro.Parameters.AddWithValue("@IDClube", "1");
                        CommandLucro.ExecuteNonQuery();


                        SqlDataReader dr;
                        string Query = ("SELECT MAX(IDLucro) AS MaxLucro FROM dbo.TblLucros");
                        SqlCommand Command = new SqlCommand(Query, con);
                        dr = Command.ExecuteReader();
                        while (dr.Read())
                        {
                            IDLucro = dr["MaxLucro"].ToString();
                        }
                        dr.Close();


                        QueryCota = "UPDATE dbo.TblCotaAtleta SET Pago = 1, FK_IDValorCota = @IDValorCota, FK_IDLucro = @IDLucro WHERE FK_IDMes = @IDMes AND FK_IDAtleta = @IDAtleta";

                        SqlCommand CommandCota = new SqlCommand(QueryCota, con);
                        CommandCota.Parameters.AddWithValue("@IDValorCota", "1");
                        CommandCota.Parameters.AddWithValue("@IDLucro", IDLucro);
                        CommandCota.Parameters.AddWithValue("@IDMes", IDMes);
                        CommandCota.Parameters.AddWithValue("@IDAtleta", cb_UNomeAtleta.SelectedValue.ToString());
                        CommandCota.ExecuteNonQuery();
                    
                    }
                    else if (cb_UFuncao.SelectedItem.ToString() == "Sócio")
                    {
                        //SELECIONA O NOME DO Socio PARA INSERIR NA TABELA LUCROS
                        SqlDataReader drSocio;
                        string QuerySocio = ("SELECT Nome FROM dbo.TblSocio WHERE IDSocio = " + Program.CurrentIDUser);
                        SqlCommand CommandSocio = new SqlCommand(QuerySocio, con);
                        drSocio = CommandSocio.ExecuteReader();
                        while (drSocio.Read())
                        {
                            Nome = drSocio["Nome"].ToString();
                        }
                        drSocio.Close();


                        //SELECIONA O MES A PAGAR (O MAIS ANTIGO)
                        SqlDataReader drMes;
                        string QueryMes = ("SELECT dbo.TblMes.IDMes, dbo.TblMes.Mes FROM dbo.TblMes RIGHT OUTER JOIN dbo.TblCotaSocio ON dbo.TblMes.IDMes = dbo.TblCotaSocio.FK_IDMes WHERE " +
                            "dbo.TblCotaSocio.Pago = 0 AND dbo.TblCotaSocio.FK_IDSocio = " + Program.CurrentIDUser);
                        SqlCommand CommandMes = new SqlCommand(QueryMes, con);
                        drMes = CommandMes.ExecuteReader();

                        if (drMes.Read())
                        {
                            IDMes = drMes["IDMes"].ToString();
                            Mes = drMes["Mes"].ToString();
                        }

                        drMes.Close();


                        //SELECIONA O VALOR DA COTA DO Socio
                        SqlDataReader drValor;
                        string QueryValor = ("SELECT Valor FROM dbo.TblValorCota WHERE(IDValorCota = 2)");
                        SqlCommand CommandValor = new SqlCommand(QueryValor, con);
                        drValor = CommandValor.ExecuteReader();
                        while (drValor.Read())
                        {
                            Valor = drValor["Valor"].ToString();
                        }
                        drValor.Close();


                        QueryLucro = "INSERT INTO dbo.TblLucros (Nome, Valor, Descricao, FK_IDClube) VALUES (@Nome, @Valor, @Descricao, @IDClube)";

                        SqlCommand CommandLucro = new SqlCommand(QueryLucro, con);
                        CommandLucro.Parameters.AddWithValue("@Nome", Nome + " - " + Mes);
                        CommandLucro.Parameters.AddWithValue("@Valor", Valor);
                        CommandLucro.Parameters.AddWithValue("@Descricao", tb_UDescricao.Text);
                        CommandLucro.Parameters.AddWithValue("@IDClube", "1");
                        CommandLucro.ExecuteNonQuery();


                        SqlDataReader dr;
                        string Query = ("SELECT MAX(IDLucro) AS MaxLucro FROM dbo.TblLucros");
                        SqlCommand Command = new SqlCommand(Query, con);
                        dr = Command.ExecuteReader();
                        while (dr.Read())
                        {
                            IDLucro = dr["MaxLucro"].ToString();
                        }
                        dr.Close();


                        QueryCota = "UPDATE dbo.TblCotaSocio SET Pago = 1, FK_IDValorCota = @IDValorCota, FK_IDLucro = @IDLucro WHERE FK_IDMes = @IDMes AND FK_IDSocio = @IDSocio";

                        SqlCommand CommandCota = new SqlCommand(QueryCota, con);
                        CommandCota.Parameters.AddWithValue("@IDValorCota", "2");
                        CommandCota.Parameters.AddWithValue("@IDLucro", IDLucro);
                        CommandCota.Parameters.AddWithValue("@IDMes", IDMes);
                        CommandCota.Parameters.AddWithValue("@IDSocio", cb_UNomeSocio.SelectedValue.ToString());
                        CommandCota.ExecuteNonQuery();
                    }

                    double saldo = 0;
                    SqlDataReader dr2;
                    string Query2 = ("SELECT Saldo FROM dbo.TblClube WHERE IDClube = 1");
                    SqlCommand Command2 = new SqlCommand(Query2, con);
                    dr2 = Command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        saldo = Convert.ToDouble(dr2["Saldo"]);
                    }
                    dr2.Close();

                    double novoSaldo = saldo + Convert.ToDouble(Valor);

                    string Querysaldo = "UPDATE TblClube SET Saldo = @NovoSaldo WHERE IDClube = 1";
                    SqlCommand Commandsaldo = new SqlCommand(Querysaldo, con);
                    Commandsaldo.Parameters.AddWithValue("@NovoSaldo", Math.Round(novoSaldo, 2));
                    Commandsaldo.ExecuteNonQuery();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                this.Dispose();
            }
        }

        private void Tb_OMontante_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Decimal))
            {
                e.SuppressKeyPress = true;

                int posicaoCursor = tb_OMontante.SelectionStart;
                tb_OMontante.Text = tb_OMontante.Text.Insert(posicaoCursor, ",");
                tb_OMontante.SelectionStart = posicaoCursor + 1;
            }
            else
            {
                bool naoNumero = false;

                // é um número do topo do teclado
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    // é um numero do teclado numerico
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        // teclas autorizadas
                        if (
                            (e.KeyCode != Keys.Back) &&
                            (e.KeyCode != Keys.Left) &&
                            (e.KeyCode != Keys.Right) &&
                            (e.KeyCode != Keys.Home) &&
                            (e.KeyCode != Keys.End) &&
                            (e.KeyCode != Keys.OemPeriod) &&
                            (e.KeyCode != Keys.Oemcomma)
                           )
                        {
                            naoNumero = true;
                        }
                    }
                }

                if (Control.ModifierKeys != Keys.None)
                {
                    naoNumero = true;
                }

                if (naoNumero)
                {
                    e.SuppressKeyPress = true;

                    SystemSounds.Beep.Play();
                }
            }
        }
    }
}

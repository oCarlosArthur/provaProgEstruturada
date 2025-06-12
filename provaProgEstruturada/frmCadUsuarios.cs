using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace provaProgEstruturada
{
    public partial class frmCadUsuarios : Form
    {
        string usuarioLogado;
        List<string[]> usuarios = new List<string[]>();
        string caminho = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\usuarios.csv";
        public frmCadUsuarios(string usuarioLogado)
        {
            InitializeComponent();
            this.usuarioLogado = usuarioLogado;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            foreach (string[] u in usuarios)
            {
                if (u[0] == nome)
                {
                    MessageBox.Show("Usuário já existe.", "Erro ao adicionar!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            usuarios.Add(new string[] { nome, senha });
            SalvarUsuarios();
            AtualizarLista();
        }

        private void frmCadUsuarios_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
            AtualizarLista();

            if (usuarioLogado != "ADMIN")
            {
                // Faz sumir os botões adicionar e excluir, e a lista usuário também
                btnAdicionar.Enabled = false;
                btnExcluir.Enabled = false;
                listUsuarios.Enabled = false;

                // Mostra só o próprio nome no campo
                txtUsuario.Text = usuarioLogado;
                txtUsuario.Enabled = false;

                // Preenche a senha atual do usuário 
                foreach (var u in usuarios)
                {
                    if (u[0] == usuarioLogado)
                    {
                        txtSenha.Text = u[1];
                        break;
                    }
                }
            }
        }

        private void CarregarUsuarios()
        {
            usuarios.Clear();
            if (File.Exists(caminho))
            {
                string[] linhas = File.ReadAllLines(caminho);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(';');
                    if (partes.Length == 2)
                    {
                        usuarios.Add(new string[] { partes[0], partes[1] });
                    }
                }
            }
        }

        private void SalvarUsuarios()
        {
            List<string> linhas = new List<string>();
            foreach (string[] u in usuarios)
            {
                linhas.Add(u[0] + ";" + u[1]);
            }
            File.WriteAllLines(caminho, linhas);
        }

        private void AtualizarLista()
        {
            listUsuarios.Items.Clear();
            foreach (string[] u in usuarios)
            {
                listUsuarios.Items.Add(u[0] + " - " + u[1]);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text;
            string senha = txtSenha.Text;

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i][0] == nome)
                {
                    if (usuarioLogado != "ADMIN" && usuarioLogado != nome)
                    {
                        MessageBox.Show("Você só pode alterar sua própria senha.", "Erro ao atualizar senha!",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    usuarios[i][1] = senha;
                    break;
                }
            }

            SalvarUsuarios();
            AtualizarLista();
            MessageBox.Show("Senha atualizada com sucesso!", "sucesso ao atualizar senha!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (listUsuarios.SelectedItem == null) return;

            string selecionado = listUsuarios.SelectedItem.ToString();
            string nome = selecionado.Split('-')[0].Trim();

            if (nome == "ADMIN")
            {
                MessageBox.Show("Não pode excluir o ADMIN.");
                return;
            }

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i][0] == nome)
                {
                    usuarios.RemoveAt(i);
                    SalvarUsuarios();
                    AtualizarLista();
                    return;
                }
            }
        }

        private void listUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUsuarios.SelectedItem == null) return;

            string selecionado = listUsuarios.SelectedItem.ToString();
            string nome = selecionado.Split('-')[0].Trim();

            foreach (string[] u in usuarios)
            {
                if (u[0] == nome)
                {
                    txtUsuario.Text = u[0];
                    txtSenha.Text = u[1];
                    break;
                }
            }
        }
    }
}

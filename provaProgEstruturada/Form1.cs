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
    public partial class frmLogin : Form
    {
        string usuariosCsv = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\usuarios.csv";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (usuario == "ADMIN" && senha == "123")
            {
                frmPrincipal telaPrinc = new frmPrincipal();

                MessageBox.Show("Bem-vindo administrador!", "Login realizado!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                telaPrinc.ShowDialog();
            }
            else if (ValidarUsuarioCSV(usuario, senha))
            {
                frmPrincipal telaPrinc = new frmPrincipal();

                MessageBox.Show("Bem-vindo usuário!", "Login realizado!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                telaPrinc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Login falhou!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarUsuarioCSV(string usuario, string senha)
        {
            if (!File.Exists(usuariosCsv))
                return false;

            var linhas = File.ReadAllLines(usuariosCsv);
            foreach (var linha in linhas)
            {
                var partes = linha.Split(';');
                if (partes.Length >= 2 && partes[0] == usuario && partes[1] == senha)
                    return true;
            }

            return false;
        }

    }
}

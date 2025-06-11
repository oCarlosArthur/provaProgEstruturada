using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace provaProgEstruturada
{
    public partial class frmPrincipal : Form
    {
        string usuarioLogado;
        public frmPrincipal(string usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
        }

        private void btnCadUsuarios_Click(object sender, EventArgs e)
        {
            if (usuarioLogado != "ADMIN")
            {
                MessageBox.Show("Você poderá alterar somente sua senha!!", "Falha, perfil não autorizado!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCadUsuarios telaCadUsuarios = new frmCadUsuarios(usuarioLogado);
                telaCadUsuarios.ShowDialog();

            }
            else
            {
                frmCadUsuarios telaCadUsuarios = new frmCadUsuarios(usuarioLogado);
                telaCadUsuarios.ShowDialog();
            }
        }

        private void btnCadClientes_Click(object sender, EventArgs e)
        {
            frmCadClientes telaCadClientes = new frmCadClientes();
            telaCadClientes.ShowDialog();
        }

        private void btnCadProdutos_Click(object sender, EventArgs e)
        {
            frmCadProdutos telaCadProdutos = new frmCadProdutos();
            telaCadProdutos.ShowDialog();
        }

        private void btnCadPedidos_Click(object sender, EventArgs e)
        {
            frmCadPedidos telaCadPedidos = new frmCadPedidos();
            telaCadPedidos.ShowDialog();
        }

        private void btnConsultarPedidos_Click(object sender, EventArgs e)
        {
            frmConsultaPedidos telaConsultaPedido = new frmConsultaPedidos();
            telaConsultaPedido.ShowDialog();
        }
    }
}

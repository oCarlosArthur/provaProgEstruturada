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
    public partial class frmCadPedidos : Form
    {
        List<string[]> clientes = new List<string[]>();
        List<string[]> produtos = new List<string[]>();
        List<string[]> itensTemporarios = new List<string[]>();

        string caminhoClientes = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\clientes.csv";
        string caminhoProdutos = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\produtos.csv";
        string caminhoPedidos = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\pedidos.csv";
        string caminhoItens = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\itenspedido.csv";

        public frmCadPedidos()
        {
            InitializeComponent();
        }

        private void CarregarClientes()
        {
            clientes.Clear();
            if (File.Exists(caminhoClientes))
            {
                foreach (string linha in File.ReadAllLines(caminhoClientes))
                {
                    var partes = linha.Split(',');
                    if (partes.Length >= 2)
                        clientes.Add(partes);
                }
            }
        }

        private void CarregarProdutos()
        {
            produtos.Clear();
            cmbProduto.Items.Clear();
            if (File.Exists(caminhoProdutos))
            {
                foreach (string linha in File.ReadAllLines(caminhoProdutos))
                {
                    var partes = linha.Split(',');
                    if (partes.Length >= 3)
                    {
                        produtos.Add(partes);
                        cmbProduto.Items.Add(partes[0] + " - " + partes[1]); // código - nome
                    }
                }
            }
        }

        private void frmCadPedidos_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text.Trim();
            lblNomeCliente.Text = "";
            foreach (var c in clientes)
            {
                if (c[0] == cpf)
                {
                    lblNomeCliente.Text = c[1]; // nome
                    return;
                }
            }
            MessageBox.Show("Cliente não encontrado.", "Erro!",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

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

        private void frmCadPedidos_Load(object sender, EventArgs e)
        {

        }
    }
}

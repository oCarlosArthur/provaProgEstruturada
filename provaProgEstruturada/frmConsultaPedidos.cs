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
    public partial class frmConsultaPedidos : Form
    {
        string caminhoClientes = @"C:\Users\Usuario\Desktop\Faculdade\provaProgEstruturada\arquivosCsv\clientes.csv";
        string caminhoPedidos = @"C:\Users\Usuario\Desktop\Faculdade\provaProgEstruturada\arquivosCsv\pedidos.csv";
        string caminhoItens = @"C:\Users\Usuario\Desktop\Faculdade\provaProgEstruturada\arquivosCsv\itenspedido.csv";
        string caminhoProdutos = @"C:\Users\Usuario\Desktop\Faculdade\provaProgEstruturada\arquivosCsv\produtos.csv";
       
        List<string[]> produtos = new List<string[]>();
      
        public frmConsultaPedidos()
        {
            InitializeComponent();
        }

        private void frmConsultaPedidos_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listVPedidos.Items.Clear();
            listVItens.Items.Clear();
            lblTotal.Text = "Total: R$ 0,00";
            lblNomeCliente.Text = "";

            string cpf = txtCPF.Text.Trim();

            // Buscar nome do cliente
            if (File.Exists(caminhoClientes))
            {
                foreach (var linha in File.ReadAllLines(caminhoClientes))
                {
                    var partes = linha.Split(',');
                    if (partes[0] == cpf)
                    {
                        lblNomeCliente.Text = partes[1];
                        break;
                    }
                }
            }

            if (lblNomeCliente.Text == "")
            {
                MessageBox.Show("Cliente não encontrado.", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar pedidos
            if (File.Exists(caminhoPedidos))
            {
                foreach (var linha in File.ReadAllLines(caminhoPedidos))
                {
                    var partes = linha.Split(',');
                    if (partes.Length >= 3 && partes[1] == cpf)
                    {
                        listVPedidos.Items.Add(partes[0]); // Código do pedido
                    }
                }
            }

            if (listVPedidos.Items.Count == 0)
            {
                MessageBox.Show("Nenhum pedido encontrado para este CPF.","Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

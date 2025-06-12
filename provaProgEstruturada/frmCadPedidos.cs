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

        private void LimparTudo()
        {
            txtCPF.Text = "";
            lblNomeCliente.Text = "";
            txtCodPedido.Text = "";
            txtQuantidade.Text = "";
            cmbProduto.SelectedIndex = -1;
            listItens.Items.Clear();
            lblTotal.Text = "Total: R$ 0,00";
            itensTemporarios.Clear();
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

        private void AtualizarTotal()
        {
            double total = 0;
            foreach (var item in itensTemporarios)
            {
                string cod = item[0];
                int qtd = Convert.ToInt32(item[1]);
                foreach (var p in produtos)
                {
                    if (p[0] == cod)
                    {
                        total += Convert.ToDouble(p[2]) * qtd;
                        break;
                    }
                }
            }
            lblTotal.Text = "Total: R$ " + total.ToString("0.00");
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedIndex < 0 || txtQuantidade.Text == "")
                return;

            string codProduto = cmbProduto.SelectedItem.ToString().Split('-')[0].Trim();
            string quantidade = txtQuantidade.Text.Trim();
            string nome = "";
            string preco = "0";

            // Verifica se o produto já está na lista
            foreach (ListViewItem prodItem in listItens.Items)
            {
                if (prodItem.Text == codProduto)
                {
                    MessageBox.Show("Este produto já foi adicionado ao pedido.", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Busca o nome e preço do produto
            foreach (var p in produtos)
            {
                if (p[0] == codProduto)
                {
                    nome = p[1];
                    preco = p[2];
                    break;
                }
            }

            double totalItem = Convert.ToDouble(preco) * Convert.ToInt32(quantidade);

            // Adiciona o item no ListView com colunas
            ListViewItem novoItem = new ListViewItem(codProduto);     // Código
            novoItem.SubItems.Add(nome);                              // Nome
            novoItem.SubItems.Add(quantidade);                        // Quantidade
            novoItem.SubItems.Add(preco);                             // Preço
            novoItem.SubItems.Add(totalItem.ToString("0.00"));        // Subtotal

            listItens.Items.Add(novoItem);

            // Adiciona à lista temporária para salvar depois
            itensTemporarios.Add(new string[] { codProduto, quantidade });

            AtualizarTotal();
        }

        private void btnSalvarPedido_Click(object sender, EventArgs e)
        {
            string codPedido = txtCodPedido.Text.Trim();
            string cpf = txtCPF.Text.Trim();

            if (codPedido == "" || cpf == "")
            {
                MessageBox.Show("Informe o código do pedido e o CPF do cliente.","Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o código do pedido já existe
            if (File.Exists(caminhoPedidos))
            {
                var linhasPedidos = File.ReadAllLines(caminhoPedidos);
                foreach (var linha in linhasPedidos)
                {
                    if (linha.StartsWith(codPedido + ","))
                    {
                        MessageBox.Show("Já existe um pedido com este código. Use outro.", "Aviso!", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            double total = 0;
            foreach (var item in itensTemporarios)
            {
                foreach (var p in produtos)
                {
                    if (p[0] == item[0])
                    {
                        total += Convert.ToDouble(p[2]) * Convert.ToInt32(item[1]);
                        break;
                    }
                }
            }

            // Salva o pedido
            File.AppendAllText(caminhoPedidos, codPedido + "," + cpf + "," + total.ToString("0.00") + Environment.NewLine);

            // Salva os itens do pedido
            foreach (var item in itensTemporarios)
            {
                File.AppendAllText(caminhoItens, codPedido + "," + item[0] + "," + item[1] + Environment.NewLine);
            }

            MessageBox.Show("Pedido salvo com sucesso.");
            LimparTudo();
        }

    }
}

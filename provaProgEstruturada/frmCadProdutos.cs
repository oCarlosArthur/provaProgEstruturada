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
    public partial class frmCadProdutos : Form
    {
        string caminhoProdutos = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\produtos.csv";
        List<string[]> produtos = new List<string[]>();

        private void CarregarProdutos()
        {
            produtos.Clear();
            if (File.Exists(caminhoProdutos))
            {
                string[] linhas = File.ReadAllLines(caminhoProdutos);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(',');
                    if (partes.Length == 4)
                    {
                        produtos.Add(partes);
                    }
                }
            }
        }

        private void AtualizarLista()
        {
            listProdutos.Items.Clear();
            foreach (string[] p in produtos)
            {
                listProdutos.Items.Add(p[0] + " - " + p[1]); // mostra: código - nome
            }
        }

        public frmCadProdutos()
        {
            InitializeComponent();
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {

        }
    }
}

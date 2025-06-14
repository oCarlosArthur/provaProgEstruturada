﻿using System;
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

        private void SalvarProdutos()
        {
            List<string> linhas = new List<string>();
            foreach (string[] p in produtos)
            {
                linhas.Add(p[0] + "," + p[1] + "," + p[2] + "," + p[3]);
            }
            File.WriteAllLines(caminhoProdutos, linhas);
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtPreco.Text = "";
            txtDescricao.Text = "";
        }

        public frmCadProdutos()
        {
            InitializeComponent();
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            AtualizarLista();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string cod = txtCodigo.Text.Trim();
            string nome = txtNome.Text.Trim();
            string preco = txtPreco.Text.Trim();
            string desc = txtDescricao.Text.Trim();

            if (cod == "" || nome == "" || preco == "") return;

            // impede duplicado
            foreach (string[] p in produtos)
            {
                if (p[0] == cod)
                {
                    MessageBox.Show("Código já existe.", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            produtos.Add(new string[] { cod, nome, preco, desc });
            SalvarProdutos();
            AtualizarLista();
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string cod = txtCodigo.Text.Trim();
            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i][0] == cod)
                {
                    produtos[i][1] = txtNome.Text.Trim();
                    produtos[i][2] = txtPreco.Text.Trim();
                    produtos[i][3] = txtDescricao.Text.Trim();
                    SalvarProdutos();
                    AtualizarLista();
                    LimparCampos();
                    return;
                }
            }
            MessageBox.Show("Produto não encontrado.", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string cod = txtCodigo.Text.Trim();
            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i][0] == cod)
                {
                    produtos.RemoveAt(i);
                    SalvarProdutos();
                    AtualizarLista();
                    LimparCampos();
                    return;
                }
            }
            MessageBox.Show("Produto não encontrado.", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProdutos.SelectedIndex >= 0)
            {
                string cod = listProdutos.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (string[] p in produtos)
                {
                    if (p[0] == cod)
                    {
                        txtCodigo.Text = p[0];
                        txtNome.Text = p[1];
                        txtPreco.Text = p[2];
                        txtDescricao.Text = p[3];
                        break;
                    }
                }
            }
        }

    }
}

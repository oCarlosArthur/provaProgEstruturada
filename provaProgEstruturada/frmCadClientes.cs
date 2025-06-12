using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace provaProgEstruturada
{
    public partial class frmCadClientes : Form
    {
        private static readonly HttpClient client = new HttpClient();

        string caminhoClientes = "C:\\Users\\Usuario\\Desktop\\Faculdade\\provaProgEstruturada\\arquivosCsv\\clientes.csv";
        List<string[]> clientes = new List<string[]>();

        private void CarregarClientes()
        {
            clientes.Clear();
            if (File.Exists(caminhoClientes))
            {
                string[] linhas = File.ReadAllLines(caminhoClientes);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(';');
                    if (partes.Length == 11)
                    {
                        clientes.Add(partes);
                    }
                }
            }
        }

        private void AtualizarLista()
        {
            listClientes.Items.Clear();
            foreach (string[] c in clientes)
            {
                listClientes.Items.Add(c[0] + " - " + c[1]); // CPF - Nome
            }
        }

        private void SalvarClientes()
        {
            List<string> linhas = new List<string>();
            foreach (var c in clientes)
            {
                linhas.Add(string.Join(";", c));
            }
            File.WriteAllLines(caminhoClientes, linhas);
        }

        private void LimparCampos()
        {
            txtCPF.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtCEP.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtTelefone.Text = "";
            txtWhatsApp.Text = "";
        }

        public frmCadClientes()
        {
            InitializeComponent();
        }

        private async Task BuscarCEPAsync(string cep)
        {
            try
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                string logradouro = GetJsonValue(responseBody, "logradouro");
                string bairro = GetJsonValue(responseBody, "bairro");
                string cidade = GetJsonValue(responseBody, "localidade");
                string estado = GetJsonValue(responseBody, "uf");

                txtLogradouro.Text = logradouro;
                txtBairro.Text = bairro;
                txtCidade.Text = cidade;
                txtEstado.Text = estado;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erro ao buscar o CEP: " + ex.Message);
            }
        }

        private string GetJsonValue(string json, string key)
        {
            string procura = $"\"{key}\":";
            int start = json.IndexOf(procura);
            if (start == -1) return "";

            start += procura.Length;
            while (json[start] == ' ' || json[start] == '\"') start++;

            int end = start;
            while (end < json.Length && json[end] != '\"' && json[end] != ',') end++;

            return json.Substring(start, end - start).Replace("\"", "").Trim();
        }

        private async void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim().Replace("-", "");

            if (cep.Length == 8)
            {
                await BuscarCEPAsync(cep);
            }
            else
            {
                MessageBox.Show("Digite um CEP válido com 8 dígitos.", "Erro formato inválido!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCadClientes_Load(object sender, EventArgs e)
        {
            CarregarClientes();
            AtualizarLista();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text.Trim();
            foreach (var c in clientes)
            {
                if (c[0] == cpf)
                {
                    MessageBox.Show("CPF já cadastrado.", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string[] novo = {cpf,
                txtNome.Text.Trim(),
                txtEmail.Text.Trim(),
                txtCEP.Text.Trim(),
                txtLogradouro.Text.Trim(),
                txtNumero.Text.Trim(),
                txtBairro.Text.Trim(),
                txtCidade.Text.Trim(),
                txtEstado.Text.Trim(),
                txtTelefone.Text.Trim(),
                txtWhatsApp.Text.Trim()};

            clientes.Add(novo);
            SalvarClientes();
            AtualizarLista();
            LimparCampos();
        }
    }
}

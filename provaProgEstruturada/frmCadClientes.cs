using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public frmCadClientes()
        {
            InitializeComponent();
        }

        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {

        }
    }
}

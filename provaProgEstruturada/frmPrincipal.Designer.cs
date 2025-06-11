namespace provaProgEstruturada
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadClientes = new System.Windows.Forms.Button();
            this.btnCadProdutos = new System.Windows.Forms.Button();
            this.btnCadPedidos = new System.Windows.Forms.Button();
            this.btnCadUsuarios = new System.Windows.Forms.Button();
            this.btnConsultarPedidos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escolha uma das opções";
            // 
            // btnCadClientes
            // 
            this.btnCadClientes.Location = new System.Drawing.Point(35, 56);
            this.btnCadClientes.Name = "btnCadClientes";
            this.btnCadClientes.Size = new System.Drawing.Size(123, 23);
            this.btnCadClientes.TabIndex = 1;
            this.btnCadClientes.Text = "Cadastro de Clientes";
            this.btnCadClientes.UseVisualStyleBackColor = true;
            this.btnCadClientes.Click += new System.EventHandler(this.btnCadClientes_Click);
            // 
            // btnCadProdutos
            // 
            this.btnCadProdutos.Location = new System.Drawing.Point(35, 85);
            this.btnCadProdutos.Name = "btnCadProdutos";
            this.btnCadProdutos.Size = new System.Drawing.Size(123, 23);
            this.btnCadProdutos.TabIndex = 2;
            this.btnCadProdutos.Text = "Cadastro de Produtos";
            this.btnCadProdutos.UseVisualStyleBackColor = true;
            this.btnCadProdutos.Click += new System.EventHandler(this.btnCadProdutos_Click);
            // 
            // btnCadPedidos
            // 
            this.btnCadPedidos.Location = new System.Drawing.Point(35, 114);
            this.btnCadPedidos.Name = "btnCadPedidos";
            this.btnCadPedidos.Size = new System.Drawing.Size(123, 23);
            this.btnCadPedidos.TabIndex = 3;
            this.btnCadPedidos.Text = "Cadastro de Pedidos";
            this.btnCadPedidos.UseVisualStyleBackColor = true;
            this.btnCadPedidos.Click += new System.EventHandler(this.btnCadPedidos_Click);
            // 
            // btnCadUsuarios
            // 
            this.btnCadUsuarios.Location = new System.Drawing.Point(35, 143);
            this.btnCadUsuarios.Name = "btnCadUsuarios";
            this.btnCadUsuarios.Size = new System.Drawing.Size(123, 23);
            this.btnCadUsuarios.TabIndex = 4;
            this.btnCadUsuarios.Text = "Cadastro de Usuários";
            this.btnCadUsuarios.UseVisualStyleBackColor = true;
            this.btnCadUsuarios.Click += new System.EventHandler(this.btnCadUsuarios_Click);
            // 
            // btnConsultarPedidos
            // 
            this.btnConsultarPedidos.Location = new System.Drawing.Point(35, 172);
            this.btnConsultarPedidos.Name = "btnConsultarPedidos";
            this.btnConsultarPedidos.Size = new System.Drawing.Size(123, 23);
            this.btnConsultarPedidos.TabIndex = 5;
            this.btnConsultarPedidos.Text = "Consultar Pedidos";
            this.btnConsultarPedidos.UseVisualStyleBackColor = true;
            this.btnConsultarPedidos.Click += new System.EventHandler(this.btnConsultarPedidos_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 223);
            this.Controls.Add(this.btnConsultarPedidos);
            this.Controls.Add(this.btnCadUsuarios);
            this.Controls.Add(this.btnCadPedidos);
            this.Controls.Add(this.btnCadProdutos);
            this.Controls.Add(this.btnCadClientes);
            this.Controls.Add(this.label1);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadClientes;
        private System.Windows.Forms.Button btnCadProdutos;
        private System.Windows.Forms.Button btnCadPedidos;
        private System.Windows.Forms.Button btnCadUsuarios;
        private System.Windows.Forms.Button btnConsultarPedidos;
    }
}
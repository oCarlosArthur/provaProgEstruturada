namespace provaProgEstruturada
{
    partial class frmConsultaPedidos
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.listVItens = new System.Windows.Forms.ListView();
            this.listVPedidos = new System.Windows.Forms.ListView();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(179, 49);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 23);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(344, 292);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total: ";
            // 
            // listVItens
            // 
            this.listVItens.HideSelection = false;
            this.listVItens.Location = new System.Drawing.Point(347, 35);
            this.listVItens.Name = "listVItens";
            this.listVItens.Size = new System.Drawing.Size(426, 254);
            this.listVItens.TabIndex = 11;
            this.listVItens.UseCompatibleStateImageBehavior = false;
            // 
            // listVPedidos
            // 
            this.listVPedidos.HideSelection = false;
            this.listVPedidos.Location = new System.Drawing.Point(24, 105);
            this.listVPedidos.Name = "listVPedidos";
            this.listVPedidos.Size = new System.Drawing.Size(294, 184);
            this.listVPedidos.TabIndex = 10;
            this.listVPedidos.UseCompatibleStateImageBehavior = false;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(24, 52);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 9;
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Location = new System.Drawing.Point(21, 89);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(85, 13);
            this.lblNomeCliente.TabIndex = 8;
            this.lblNomeCliente.Text = "Nome do Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "CPF";
            // 
            // frmConsultaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 330);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.listVItens);
            this.Controls.Add(this.listVPedidos);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.label1);
            this.Name = "frmConsultaPedidos";
            this.Text = "frmConsultaPedidos";
            this.Load += new System.EventHandler(this.frmConsultaPedidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListView listVItens;
        private System.Windows.Forms.ListView listVPedidos;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Label label1;
    }
}
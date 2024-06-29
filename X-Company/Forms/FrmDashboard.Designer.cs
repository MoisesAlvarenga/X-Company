

namespace XCompany
{
    partial class frmDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            col_cliente = new ColumnHeader();
            col_dataVenda = new ColumnHeader();
            col_totalItens = new ColumnHeader();
            listViewSale = new ListView();
            col_valorTotal = new ColumnHeader();
            btnMakeSale = new Button();
            menuStripDashboard = new MenuStrip();
            toolStripMenuItemProduct = new ToolStripMenuItem();
            toolStripMenuItemCustomers = new ToolStripMenuItem();
            menuStripDashboard.SuspendLayout();
            SuspendLayout();
            // 
            // col_cliente
            // 
            col_cliente.Text = "Cliente";
            col_cliente.Width = 150;
            // 
            // col_dataVenda
            // 
            col_dataVenda.Text = "Data da Venda";
            col_dataVenda.Width = 150;
            // 
            // col_totalItens
            // 
            col_totalItens.Text = "Total Itens";
            col_totalItens.Width = 100;
            // 
            // listViewSale
            // 
            listViewSale.Columns.AddRange(new ColumnHeader[] { col_cliente, col_dataVenda, col_totalItens, col_valorTotal });
            listViewSale.Location = new Point(144, 54);
            listViewSale.Name = "listViewSale";
            listViewSale.Size = new Size(507, 370);
            listViewSale.TabIndex = 2;
            listViewSale.UseCompatibleStateImageBehavior = false;
            listViewSale.View = View.Details;
            // 
            // col_valorTotal
            // 
            col_valorTotal.Text = "Valor Total";
            col_valorTotal.Width = 100;
            // 
            // btnMakeSale
            // 
            btnMakeSale.Location = new Point(144, 27);
            btnMakeSale.Name = "btnMakeSale";
            btnMakeSale.Size = new Size(117, 23);
            btnMakeSale.TabIndex = 3;
            btnMakeSale.Text = "&Efetuar venda (F3)";
            btnMakeSale.UseVisualStyleBackColor = true;
            btnMakeSale.Click += btnMakeSale_Click;
            // 
            // menuStripDashboard
            // 
            menuStripDashboard.Items.AddRange(new ToolStripItem[] { toolStripMenuItemProduct, toolStripMenuItemCustomers });
            menuStripDashboard.Location = new Point(0, 0);
            menuStripDashboard.Name = "menuStripDashboard";
            menuStripDashboard.Size = new Size(800, 24);
            menuStripDashboard.TabIndex = 4;
            menuStripDashboard.Text = "menuStrip1";
            // 
            // toolStripMenuItemProduct
            // 
            toolStripMenuItemProduct.Name = "toolStripMenuItemProduct";
            toolStripMenuItemProduct.Size = new Size(90, 20);
            toolStripMenuItemProduct.Text = "&Produtos (F1)";
            toolStripMenuItemProduct.Click += toolStripMenuItemProducts_Click;
            // 
            // toolStripMenuItemCustomers
            // 
            toolStripMenuItemCustomers.Name = "toolStripMenuItemCustomers";
            toolStripMenuItemCustomers.Size = new Size(84, 20);
            toolStripMenuItemCustomers.Text = "&Clientes (F2)";
            toolStripMenuItemCustomers.Click += toolStripMenuItemCustomers_Click;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMakeSale);
            Controls.Add(listViewSale);
            Controls.Add(menuStripDashboard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MainMenuStrip = menuStripDashboard;
            MaximizeBox = false;
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += frmDashboard_Load;
            KeyDown += saleForm_KeyDown;
            menuStripDashboard.ResumeLayout(false);
            menuStripDashboard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColumnHeader col_cliente;
        private ColumnHeader col_dataVenda;
        private ColumnHeader col_totalItens;
        private ListView listViewSale;
        private Button btnMakeSale;
        private ColumnHeader col_valorTotal;
        private MenuStrip menuStripDashboard;
        private ToolStripMenuItem toolStripMenuItemProduct;
        private ToolStripMenuItem toolStripMenuItemCustomers;
    }
}

namespace XCompany
{
    partial class FrmSale
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
            comboBoxProduct = new ComboBox();
            comboBoxCustomer = new ComboBox();
            numericUpDownAmount = new NumericUpDown();
            buttonAddProduct = new Button();
            listViewProductsToSale = new ListView();
            productHeader = new ColumnHeader();
            descriptionHeader = new ColumnHeader();
            priceHeader = new ColumnHeader();
            amountHeader = new ColumnHeader();
            textBoxTotal = new TextBox();
            labelTotal = new Label();
            textBoxPrice = new TextBox();
            textBoxDescription = new TextBox();
            btnRemoveProduct = new Button();
            labelCustomer = new Label();
            labelProduct = new Label();
            labelAmount = new Label();
            labelPrice = new Label();
            labelDescription = new Label();
            buttonMakeSale = new Button();
            textBoxStockStock = new TextBox();
            labelStockStock = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            SuspendLayout();
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(30, 95);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(121, 23);
            comboBoxProduct.TabIndex = 1;
            comboBoxProduct.SelectedIndexChanged += comboBoxProduct_SelectedIndexChanged;
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(30, 39);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(206, 23);
            comboBoxCustomer.TabIndex = 0;
            // 
            // numericUpDownAmount
            // 
            numericUpDownAmount.Location = new Point(157, 96);
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(79, 23);
            numericUpDownAmount.TabIndex = 2;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(30, 224);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(206, 23);
            buttonAddProduct.TabIndex = 3;
            buttonAddProduct.Text = "&Adicionar Produto (F1)";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += btnAddProduct_Click;
            // 
            // listViewProductsToSale
            // 
            listViewProductsToSale.Columns.AddRange(new ColumnHeader[] { productHeader, descriptionHeader, priceHeader, amountHeader });
            listViewProductsToSale.Location = new Point(291, 39);
            listViewProductsToSale.Name = "listViewProductsToSale";
            listViewProductsToSale.Size = new Size(348, 355);
            listViewProductsToSale.TabIndex = 13;
            listViewProductsToSale.TabStop = false;
            listViewProductsToSale.UseCompatibleStateImageBehavior = false;
            listViewProductsToSale.View = View.Details;
            // 
            // productHeader
            // 
            productHeader.Text = "Produto";
            productHeader.Width = 100;
            // 
            // descriptionHeader
            // 
            descriptionHeader.Text = "Descrição";
            descriptionHeader.Width = 100;
            // 
            // priceHeader
            // 
            priceHeader.Text = "Valor";
            // 
            // amountHeader
            // 
            amountHeader.Text = "Quantidade";
            amountHeader.Width = 100;
            // 
            // textBoxTotal
            // 
            textBoxTotal.Location = new Point(539, 400);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(100, 23);
            textBoxTotal.TabIndex = 11;
            textBoxTotal.TabStop = false;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(501, 404);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(32, 15);
            labelTotal.TabIndex = 6;
            labelTotal.Text = "Total";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(30, 142);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.ReadOnly = true;
            textBoxPrice.Size = new Size(96, 23);
            textBoxPrice.TabIndex = 3;
            textBoxPrice.TabStop = false;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(30, 195);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Size = new Size(206, 23);
            textBoxDescription.TabIndex = 4;
            textBoxDescription.TabStop = false;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.BackColor = Color.FromArgb(255, 128, 128);
            btnRemoveProduct.Location = new Point(291, 400);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(142, 23);
            btnRemoveProduct.TabIndex = 10;
            btnRemoveProduct.TabStop = false;
            btnRemoveProduct.Text = "&Remover Produto (F2)";
            btnRemoveProduct.UseVisualStyleBackColor = false;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Location = new Point(30, 21);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(44, 15);
            labelCustomer.TabIndex = 11;
            labelCustomer.Text = "Cliente";
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(30, 77);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(50, 15);
            labelProduct.TabIndex = 12;
            labelProduct.Text = "Produto";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(157, 78);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(69, 15);
            labelAmount.TabIndex = 13;
            labelAmount.Text = "Quantidade";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(30, 124);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(40, 15);
            labelPrice.TabIndex = 14;
            labelPrice.Text = "Preço:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(32, 177);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(58, 15);
            labelDescription.TabIndex = 15;
            labelDescription.Text = "Descrição";
            // 
            // buttonMakeSale
            // 
            buttonMakeSale.BackColor = Color.FromArgb(128, 255, 128);
            buttonMakeSale.Location = new Point(30, 268);
            buttonMakeSale.Name = "buttonMakeSale";
            buttonMakeSale.Size = new Size(206, 51);
            buttonMakeSale.TabIndex = 4;
            buttonMakeSale.Text = "Efetuar Venda (F4)";
            buttonMakeSale.UseVisualStyleBackColor = false;
            buttonMakeSale.Click += btnRemoveProduct_Click;
            // 
            // textBoxStockStock
            // 
            textBoxStockStock.Location = new Point(132, 142);
            textBoxStockStock.Name = "textBoxStockStock";
            textBoxStockStock.ReadOnly = true;
            textBoxStockStock.Size = new Size(104, 23);
            textBoxStockStock.TabIndex = 16;
            textBoxStockStock.TabStop = false;
            // 
            // labelStockStock
            // 
            labelStockStock.AutoSize = true;
            labelStockStock.Location = new Point(132, 124);
            labelStockStock.Name = "labelStockStock";
            labelStockStock.Size = new Size(49, 15);
            labelStockStock.TabIndex = 17;
            labelStockStock.Text = "Estoque";
            // 
            // FrmSale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelStockStock);
            Controls.Add(textBoxStockStock);
            Controls.Add(buttonMakeSale);
            Controls.Add(labelDescription);
            Controls.Add(labelPrice);
            Controls.Add(labelAmount);
            Controls.Add(labelProduct);
            Controls.Add(labelCustomer);
            Controls.Add(btnRemoveProduct);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxPrice);
            Controls.Add(labelTotal);
            Controls.Add(textBoxTotal);
            Controls.Add(listViewProductsToSale);
            Controls.Add(buttonAddProduct);
            Controls.Add(numericUpDownAmount);
            Controls.Add(comboBoxCustomer);
            Controls.Add(comboBoxProduct);
            KeyPreview = true;
            Name = "FrmSale";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SaleForm";
            Load += FrmSale_Load;
            KeyDown += SaleForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxProduct;
        private ComboBox comboBoxCustomer;
        private NumericUpDown numericUpDownAmount;
        private Button buttonAddProduct;
        private ListView listViewProductsToSale;
        private TextBox textBoxTotal;
        private ColumnHeader productHeader;
        private ColumnHeader descriptionHeader;
        private ColumnHeader priceHeader;
        private Label labelTotal;
        private ColumnHeader amountHeader;
        private TextBox textBoxPrice;
        private TextBox textBoxDescription;
        private Button btnRemoveProduct;
        private Label labelCustomer;
        private Label labelProduct;
        private Label labelAmount;
        private Label labelPrice;
        private Label labelDescription;
        private Button buttonMakeSale;
        private TextBox textBoxStockStock;
        private Label labelStockStock;
    }
}
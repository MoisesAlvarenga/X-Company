namespace XCompany
{
    partial class ProductForms
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
            descriptionTextBox = new TextBox();
            nameTextBox = new TextBox();
            labelName = new Label();
            DescriptionLabel = new Label();
            stockLabel = new Label();
            priceLabel = new Label();
            btnSaveProduct = new Button();
            priceUpDown = new NumericUpDown();
            stockUpDown2 = new NumericUpDown();
            comboBoxProduct = new ComboBox();
            produtoLabel = new Label();
            btnDeleteProduct = new Button();
            btnNewProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)priceUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stockUpDown2).BeginInit();
            SuspendLayout();
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(317, 103);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(262, 23);
            descriptionTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(195, 103);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 2;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(195, 85);
            labelName.Name = "labelName";
            labelName.Size = new Size(40, 15);
            labelName.TabIndex = 4;
            labelName.Text = "Nome";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(317, 85);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 5;
            DescriptionLabel.Text = "Description";
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(317, 144);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(49, 15);
            stockLabel.TabIndex = 6;
            stockLabel.Text = "Estoque";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(198, 144);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(37, 15);
            priceLabel.TabIndex = 7;
            priceLabel.Text = "Preço";
            // 
            // btnSaveProduct
            // 
            btnSaveProduct.Location = new Point(198, 191);
            btnSaveProduct.Name = "btnSaveProduct";
            btnSaveProduct.Size = new Size(75, 23);
            btnSaveProduct.TabIndex = 6;
            btnSaveProduct.Text = "&Salvar (F4)";
            btnSaveProduct.UseVisualStyleBackColor = true;
            btnSaveProduct.Click += btnSaveProduct_Click;
            // 
            // priceUpDown
            // 
            priceUpDown.DecimalPlaces = 2;
            priceUpDown.Location = new Point(198, 162);
            priceUpDown.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            priceUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            priceUpDown.Name = "priceUpDown";
            priceUpDown.Size = new Size(100, 23);
            priceUpDown.TabIndex = 4;
            priceUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // stockUpDown2
            // 
            stockUpDown2.Location = new Point(317, 162);
            stockUpDown2.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            stockUpDown2.Name = "stockUpDown2";
            stockUpDown2.Size = new Size(100, 23);
            stockUpDown2.TabIndex = 5;
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(28, 103);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(121, 23);
            comboBoxProduct.TabIndex = 1;
            comboBoxProduct.SelectedIndexChanged += comboBoxProduct_SelectedIndexChanged;
            // 
            // produtoLabel
            // 
            produtoLabel.AutoSize = true;
            produtoLabel.Location = new Point(28, 85);
            produtoLabel.Name = "produtoLabel";
            produtoLabel.Size = new Size(50, 15);
            produtoLabel.TabIndex = 12;
            produtoLabel.Text = "Produto";
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(317, 191);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(75, 23);
            btnDeleteProduct.TabIndex = 7;
            btnDeleteProduct.Text = "&Deletar (F2)";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnNewProduct
            // 
            btnNewProduct.Location = new Point(28, 37);
            btnNewProduct.Name = "btnNewProduct";
            btnNewProduct.Size = new Size(75, 23);
            btnNewProduct.TabIndex = 0;
            btnNewProduct.Text = "&Novo (F1)";
            btnNewProduct.UseVisualStyleBackColor = true;
            btnNewProduct.Click += btnNewProduct_Click;
            // 
            // ProductForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 378);
            Controls.Add(btnNewProduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(produtoLabel);
            Controls.Add(comboBoxProduct);
            Controls.Add(stockUpDown2);
            Controls.Add(priceUpDown);
            Controls.Add(btnSaveProduct);
            Controls.Add(priceLabel);
            Controls.Add(stockLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(labelName);
            Controls.Add(nameTextBox);
            Controls.Add(descriptionTextBox);
            Name = "ProductForms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produtos";
            Load += ProductForms_Load;
            ((System.ComponentModel.ISupportInitialize)priceUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)stockUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox descriptionTextBox;
        private TextBox nameTextBox;
        private Label labelName;
        private Label DescriptionLabel;
        private Label stockLabel;
        private Label priceLabel;
        private Button btnSaveProduct;
        private NumericUpDown priceUpDown;
        private NumericUpDown stockUpDown2;
        private ComboBox comboBoxProduct;
        private Label produtoLabel;
        private Button btnDeleteProduct;
        private Button btnNewProduct;
    }
}
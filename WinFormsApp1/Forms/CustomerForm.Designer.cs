namespace XCompany
{
    partial class CustomerForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSaveCustomer = new Button();
            addressTextBox = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPhone = new TextBox();
            textBoxName = new TextBox();
            comboBoxCustomers = new ComboBox();
            clientLabel = new Label();
            btnDeleteCustomer = new Button();
            btnNewCustomer = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 73);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 73);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 124);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 124);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 3;
            label4.Text = "Endereço";
            // 
            // btnSaveCustomer
            // 
            btnSaveCustomer.Location = new Point(258, 199);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.Size = new Size(75, 23);
            btnSaveCustomer.TabIndex = 6;
            btnSaveCustomer.Text = "&Salvar (F4)";
            btnSaveCustomer.UseVisualStyleBackColor = true;
            btnSaveCustomer.Click += btnSaveCustomer_Click;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(387, 142);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(100, 23);
            addressTextBox.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(387, 91);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 23);
            textBoxEmail.TabIndex = 3;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(258, 142);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(100, 23);
            textBoxPhone.TabIndex = 4;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(258, 91);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // comboBoxCustomers
            // 
            comboBoxCustomers.FormattingEnabled = true;
            comboBoxCustomers.Location = new Point(12, 91);
            comboBoxCustomers.Name = "comboBoxCustomers";
            comboBoxCustomers.Size = new Size(121, 23);
            comboBoxCustomers.Sorted = true;
            comboBoxCustomers.TabIndex = 1;
            comboBoxCustomers.SelectedIndexChanged += comboBoxCustomers_SelectedIndexChanged;
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(12, 73);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(44, 15);
            clientLabel.TabIndex = 10;
            clientLabel.Text = "Cliente";
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(387, 199);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(75, 23);
            btnDeleteCustomer.TabIndex = 7;
            btnDeleteCustomer.Text = "&Deletar (F2)";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Visible = true;
            btnDeleteCustomer.Click += deletebutton_Click;
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Location = new Point(12, 34);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(121, 23);
            btnNewCustomer.TabIndex = 0;
            btnNewCustomer.Text = "&Novo Cliente (F1)";
            btnNewCustomer.UseVisualStyleBackColor = true;
            btnNewCustomer.Click += btnNewCustomer_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 378);
            Controls.Add(btnNewCustomer);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(clientLabel);
            Controls.Add(comboBoxCustomers);
            Controls.Add(textBoxName);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxEmail);
            Controls.Add(addressTextBox);
            Controls.Add(btnSaveCustomer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            Load += CustomerForm_Load;
            KeyDown += CustomerForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSaveCustomer;
        private TextBox addressTextBox;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private TextBox textBoxName;
        private ComboBox comboBoxCustomers;
        private Label clientLabel;
        private Button btnDeleteCustomer;
        private Button btnNewCustomer;
    }
}
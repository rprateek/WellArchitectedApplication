
namespace PetShop
{
    partial class frmCustomer
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
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dgCustomerList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCustType = new System.Windows.Forms.ComboBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtBillDate = new System.Windows.Forms.DateTimePicker();
            this.ddChooseDAL = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdUOW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(153, 181);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 0;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(244, 181);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 1;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(375, 181);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(475, 181);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // dgCustomerList
            // 
            this.dgCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomerList.Location = new System.Drawing.Point(57, 210);
            this.dgCustomerList.Name = "dgCustomerList";
            this.dgCustomerList.RowTemplate.Height = 25;
            this.dgCustomerList.Size = new System.Drawing.Size(694, 211);
            this.dgCustomerList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bill Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(445, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bill Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address";
            // 
            // cboCustType
            // 
            this.cboCustType.FormattingEnabled = true;
            this.cboCustType.Items.AddRange(new object[] {
            "Visitor",
            "Customer"});
            this.cboCustType.Location = new System.Drawing.Point(155, 52);
            this.cboCustType.Name = "cboCustType";
            this.cboCustType.Size = new System.Drawing.Size(121, 23);
            this.cboCustType.TabIndex = 11;
            this.cboCustType.SelectedIndexChanged += new System.EventHandler(this.cboCustType_SelectedIndexChanged);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(155, 90);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(199, 23);
            this.txtFullName.TabIndex = 12;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(156, 128);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(199, 23);
            this.txtPhoneNo.TabIndex = 13;
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Location = new System.Drawing.Point(521, 57);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(159, 23);
            this.txtBillAmount.TabIndex = 14;
            this.txtBillAmount.Text = "0";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(521, 123);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(230, 23);
            this.txtAddress.TabIndex = 15;
            // 
            // dtBillDate
            // 
            this.dtBillDate.Location = new System.Drawing.Point(521, 89);
            this.dtBillDate.Name = "dtBillDate";
            this.dtBillDate.Size = new System.Drawing.Size(200, 23);
            this.dtBillDate.TabIndex = 16;
            // 
            // ddChooseDAL
            // 
            this.ddChooseDAL.FormattingEnabled = true;
            this.ddChooseDAL.Items.AddRange(new object[] {
            "ADO.Net",
            "Entity Framework"});
            this.ddChooseDAL.Location = new System.Drawing.Point(57, 181);
            this.ddChooseDAL.Name = "ddChooseDAL";
            this.ddChooseDAL.Size = new System.Drawing.Size(85, 23);
            this.ddChooseDAL.TabIndex = 17;
            this.ddChooseDAL.SelectedIndexChanged += new System.EventHandler(this.ddChooseDAL_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Choose DAL";
            // 
            // cmdUOW
            // 
            this.cmdUOW.Location = new System.Drawing.Point(628, 163);
            this.cmdUOW.Name = "cmdUOW";
            this.cmdUOW.Size = new System.Drawing.Size(123, 40);
            this.cmdUOW.TabIndex = 19;
            this.cmdUOW.Text = "Use UOW";
            this.cmdUOW.UseVisualStyleBackColor = true;
            this.cmdUOW.Click += new System.EventHandler(this.cmdUOW_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdUOW);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ddChooseDAL);
            this.Controls.Add(this.dtBillDate);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.cboCustType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCustomerList);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Name = "frmCustomer";
            this.Text = "Customer Management";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.DataGridView dgCustomerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCustType;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker dtBillDate;
        private System.Windows.Forms.ComboBox ddChooseDAL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdUOW;
    }
}


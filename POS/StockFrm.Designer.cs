namespace POS
{
    partial class StockFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.DGVStocks1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.DRPStockIn = new System.Windows.Forms.DateTimePicker();
            this.DGVStocks2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_reorder_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_code1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_desc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_category1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_unit_price1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_qty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStocks1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStocks2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Code:";
            // 
            // txtProductCode
            // 
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Enabled = false;
            this.txtProductCode.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(183, 45);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(283, 27);
            this.txtProductCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(164, 28);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(283, 27);
            this.txtQty.TabIndex = 4;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Stock in Date:";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(183, 84);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(283, 27);
            this.txtDescription.TabIndex = 9;
            // 
            // DGVStocks1
            // 
            this.DGVStocks1.AllowUserToAddRows = false;
            this.DGVStocks1.AllowUserToDeleteRows = false;
            this.DGVStocks1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStocks1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVStocks1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStocks1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_id,
            this.prod_code,
            this.prod_desc,
            this.prod_category,
            this.prod_unit_price,
            this.prod_reorder_level,
            this.prod_qty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVStocks1.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStocks1.Location = new System.Drawing.Point(562, 165);
            this.DGVStocks1.Name = "DGVStocks1";
            this.DGVStocks1.ReadOnly = true;
            this.DGVStocks1.RowHeadersWidth = 51;
            this.DGVStocks1.RowTemplate.Height = 24;
            this.DGVStocks1.Size = new System.Drawing.Size(450, 351);
            this.DGVStocks1.TabIndex = 10;
            this.DGVStocks1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStocks1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddStock);
            this.groupBox1.Controls.Add(this.DRPStockIn);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 437);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STOCK INFORMATION";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtQty);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(17, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 73);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Add Quantity:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(183, 163);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(283, 27);
            this.txtPrice.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Price:";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(174, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 42);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Enabled = false;
            this.txtCategory.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(183, 124);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(283, 27);
            this.txtCategory.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(337, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 42);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Category:";
            // 
            // btnAddStock
            // 
            this.btnAddStock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddStock.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.Location = new System.Drawing.Point(25, 363);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(129, 42);
            this.btnAddStock.TabIndex = 13;
            this.btnAddStock.Text = "ADD STOCK";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // DRPStockIn
            // 
            this.DRPStockIn.CalendarFont = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DRPStockIn.Enabled = false;
            this.DRPStockIn.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DRPStockIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DRPStockIn.Location = new System.Drawing.Point(183, 203);
            this.DRPStockIn.Name = "DRPStockIn";
            this.DRPStockIn.Size = new System.Drawing.Size(283, 27);
            this.DRPStockIn.TabIndex = 10;
            // 
            // DGVStocks2
            // 
            this.DGVStocks2.AllowUserToAddRows = false;
            this.DGVStocks2.AllowUserToDeleteRows = false;
            this.DGVStocks2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStocks2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVStocks2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStocks2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_id1,
            this.prod_code1,
            this.prod_desc1,
            this.prod_category1,
            this.prod_unit_price1,
            this.prod_qty1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVStocks2.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVStocks2.Location = new System.Drawing.Point(1041, 165);
            this.DGVStocks2.Name = "DGVStocks2";
            this.DGVStocks2.ReadOnly = true;
            this.DGVStocks2.RowHeadersWidth = 51;
            this.DGVStocks2.RowTemplate.Height = 24;
            this.DGVStocks2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVStocks2.Size = new System.Drawing.Size(450, 351);
            this.DGVStocks2.TabIndex = 12;
            this.DGVStocks2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStocks2_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Blue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1525, 31);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(61, 27);
            this.logoutToolStripMenuItem.Text = "Back";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(562, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(929, 77);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "Search:";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(88, 27);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(818, 27);
            this.textBox4.TabIndex = 0;
            // 
            // prod_id
            // 
            this.prod_id.DataPropertyName = "prod_id";
            this.prod_id.HeaderText = "PRODUCT ID";
            this.prod_id.MinimumWidth = 6;
            this.prod_id.Name = "prod_id";
            this.prod_id.ReadOnly = true;
            this.prod_id.Visible = false;
            this.prod_id.Width = 125;
            // 
            // prod_code
            // 
            this.prod_code.DataPropertyName = "prod_code";
            this.prod_code.HeaderText = "CODE";
            this.prod_code.MinimumWidth = 6;
            this.prod_code.Name = "prod_code";
            this.prod_code.ReadOnly = true;
            this.prod_code.Width = 125;
            // 
            // prod_desc
            // 
            this.prod_desc.DataPropertyName = "prod_desc";
            this.prod_desc.HeaderText = "DESCRIPTION";
            this.prod_desc.MinimumWidth = 6;
            this.prod_desc.Name = "prod_desc";
            this.prod_desc.ReadOnly = true;
            this.prod_desc.Width = 125;
            // 
            // prod_category
            // 
            this.prod_category.DataPropertyName = "prod_category";
            this.prod_category.HeaderText = "CATEGORY";
            this.prod_category.MinimumWidth = 6;
            this.prod_category.Name = "prod_category";
            this.prod_category.ReadOnly = true;
            this.prod_category.Width = 125;
            // 
            // prod_unit_price
            // 
            this.prod_unit_price.DataPropertyName = "prod_unit_price";
            this.prod_unit_price.HeaderText = "UNIT PRICE";
            this.prod_unit_price.MinimumWidth = 6;
            this.prod_unit_price.Name = "prod_unit_price";
            this.prod_unit_price.ReadOnly = true;
            this.prod_unit_price.Width = 125;
            // 
            // prod_reorder_level
            // 
            this.prod_reorder_level.DataPropertyName = "prod_reorder_level";
            this.prod_reorder_level.HeaderText = "REODER-LEVEL";
            this.prod_reorder_level.MinimumWidth = 6;
            this.prod_reorder_level.Name = "prod_reorder_level";
            this.prod_reorder_level.ReadOnly = true;
            this.prod_reorder_level.Width = 125;
            // 
            // prod_qty
            // 
            this.prod_qty.DataPropertyName = "prod_qty";
            this.prod_qty.HeaderText = "QUANTITY";
            this.prod_qty.MinimumWidth = 6;
            this.prod_qty.Name = "prod_qty";
            this.prod_qty.ReadOnly = true;
            this.prod_qty.Width = 125;
            // 
            // prod_id1
            // 
            this.prod_id1.DataPropertyName = "prod_id";
            this.prod_id1.HeaderText = "PRODUCT ID";
            this.prod_id1.MinimumWidth = 6;
            this.prod_id1.Name = "prod_id1";
            this.prod_id1.ReadOnly = true;
            this.prod_id1.Visible = false;
            this.prod_id1.Width = 125;
            // 
            // prod_code1
            // 
            this.prod_code1.DataPropertyName = "prod_code";
            this.prod_code1.HeaderText = "PRODUCT CODE";
            this.prod_code1.MinimumWidth = 6;
            this.prod_code1.Name = "prod_code1";
            this.prod_code1.ReadOnly = true;
            this.prod_code1.Width = 125;
            // 
            // prod_desc1
            // 
            this.prod_desc1.DataPropertyName = "prod_desc";
            this.prod_desc1.HeaderText = "DESCRIPTION";
            this.prod_desc1.MinimumWidth = 6;
            this.prod_desc1.Name = "prod_desc1";
            this.prod_desc1.ReadOnly = true;
            this.prod_desc1.Width = 125;
            // 
            // prod_category1
            // 
            this.prod_category1.DataPropertyName = "prod_category";
            this.prod_category1.HeaderText = "CATEGORY";
            this.prod_category1.MinimumWidth = 6;
            this.prod_category1.Name = "prod_category1";
            this.prod_category1.ReadOnly = true;
            this.prod_category1.Width = 125;
            // 
            // prod_unit_price1
            // 
            this.prod_unit_price1.DataPropertyName = "prod_unit_price";
            this.prod_unit_price1.HeaderText = "UNIT PRICE";
            this.prod_unit_price1.MinimumWidth = 6;
            this.prod_unit_price1.Name = "prod_unit_price1";
            this.prod_unit_price1.ReadOnly = true;
            this.prod_unit_price1.Width = 125;
            // 
            // prod_qty1
            // 
            this.prod_qty1.DataPropertyName = "prod_qty";
            this.prod_qty1.HeaderText = "QUANTITY";
            this.prod_qty1.MinimumWidth = 6;
            this.prod_qty1.Name = "prod_qty1";
            this.prod_qty1.ReadOnly = true;
            this.prod_qty1.Width = 125;
            // 
            // StockFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1525, 528);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DGVStocks2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVStocks1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockFrm";
            this.Load += new System.EventHandler(this.StockFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStocks1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStocks2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DataGridView DGVStocks1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DRPStockIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DGVStocks2;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_reorder_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_code1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_desc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_category1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_unit_price1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_qty1;
    }
}
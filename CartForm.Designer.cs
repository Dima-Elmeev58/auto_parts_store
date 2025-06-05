namespace AutoStoreParts
{
    partial class CartForm
    {
        public System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartForm));
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AllowUserToAddRows = false;
            this.dataGridViewCart.AllowUserToDeleteRows = false;
            this.dataGridViewCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(16, 15);
            this.dataGridViewCart.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCart.MultiSelect = false;
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCart.Size = new System.Drawing.Size(747, 369);
            this.dataGridViewCart.TabIndex = 0;
            this.dataGridViewCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellContentClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotal.Location = new System.Drawing.Point(16, 400);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(168, 25);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Общая сумма: ";
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBuy.Location = new System.Drawing.Point(543, 394);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(220, 37);
            this.btnBuy.TabIndex = 2;
            this.btnBuy.Text = "Оформить заказ";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(543, 443);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(220, 37);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Вернуться в каталог";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveItem.Location = new System.Drawing.Point(16, 443);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(220, 37);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Удалить товар";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(779, 494);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridViewCart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корзина покупок";
            this.Load += new System.EventHandler(this.CartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewCart;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnBuy;
        public System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.Button btnRemoveItem;
    }
}
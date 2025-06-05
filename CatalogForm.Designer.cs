namespace AutoStoreParts
{
    partial class CatalogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogForm));
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentClick);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddToCart.Location = new System.Drawing.Point(400, 390);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(200, 40);
            this.btnAddToCart.TabIndex = 1;
            this.btnAddToCart.Text = "Добавить в корзину";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // numericQuantity
            // 
            this.numericQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericQuantity.Location = new System.Drawing.Point(300, 400);
            this.numericQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numericQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(80, 26);
            this.numericQuantity.TabIndex = 2;
            this.numericQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericQuantity.ValueChanged += new System.EventHandler(this.numericQuantity_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(178, 402);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество:";
            // 
            // btnViewCart
            // 
            this.btnViewCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewCart.Location = new System.Drawing.Point(620, 390);
            this.btnViewCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewCart.Name = "btnViewCart";
            this.btnViewCart.Size = new System.Drawing.Size(160, 40);
            this.btnViewCart.TabIndex = 4;
            this.btnViewCart.Text = "Перейти в корзину";
            this.btnViewCart.UseVisualStyleBackColor = true;
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericQuantity);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dataGridViewProducts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог товаров";
            this.Load += new System.EventHandler(this.CatalogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewProducts;
        public System.Windows.Forms.Button btnAddToCart;
        public System.Windows.Forms.NumericUpDown numericQuantity;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnViewCart;
    }
}
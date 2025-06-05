using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AutoStoreParts
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            lblTables = new Label();
            cmbTables = new ComboBox();
            dataGridView = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lblTables
            // 
            lblTables.AutoSize = true;
            lblTables.Location = new Point(27, 31);
            lblTables.Margin = new Padding(4, 0, 4, 0);
            lblTables.Name = "lblTables";
            lblTables.Size = new Size(71, 20);
            lblTables.TabIndex = 0;
            lblTables.Text = "Таблицы";
            // 
            // cmbTables
            // 
            cmbTables.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new Point(107, 26);
            cmbTables.Margin = new Padding(4, 5, 4, 5);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new Size(199, 28);
            cmbTables.TabIndex = 1;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(27, 77);
            dataGridView.Margin = new Padding(4, 5, 4, 5);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(800, 462);
            dataGridView.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 554);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(133, 46);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(187, 554);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(133, 46);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(347, 554);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 46);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(693, 554);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(133, 46);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 615);
            Controls.Add(btnLogout);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView);
            Controls.Add(cmbTables);
            Controls.Add(lblTables);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(869, 650);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель администратора";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        public System.Windows.Forms.Label lblTables;
        public System.Windows.Forms.ComboBox cmbTables;
        public System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnLogout;
    }
}
namespace BeautySalonApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewManager = new System.Windows.Forms.DataGridView();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonFired = new System.Windows.Forms.Button();
            this.buttonWorking = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManager
            // 
            this.dataGridViewManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManager.Location = new System.Drawing.Point(3, 462);
            this.dataGridViewManager.Name = "dataGridViewManager";
            this.dataGridViewManager.RowHeadersWidth = 82;
            this.dataGridViewManager.RowTemplate.Height = 33;
            this.dataGridViewManager.Size = new System.Drawing.Size(2048, 575);
            this.dataGridViewManager.TabIndex = 0;
            this.dataGridViewManager.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManager_CellContentClick);
            this.dataGridViewManager.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManager_CellEndEdit);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(26, 23);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(331, 78);
            this.buttonShow.TabIndex = 1;
            this.buttonShow.Text = "Показать всех";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(26, 378);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(331, 78);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(754, 268);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(331, 78);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonFired
            // 
            this.buttonFired.Location = new System.Drawing.Point(26, 143);
            this.buttonFired.Name = "buttonFired";
            this.buttonFired.Size = new System.Drawing.Size(331, 78);
            this.buttonFired.TabIndex = 4;
            this.buttonFired.Text = "Уволенные";
            this.buttonFired.UseVisualStyleBackColor = true;
            this.buttonFired.Click += new System.EventHandler(this.buttonFired_Click);
            // 
            // buttonWorking
            // 
            this.buttonWorking.Location = new System.Drawing.Point(26, 268);
            this.buttonWorking.Name = "buttonWorking";
            this.buttonWorking.Size = new System.Drawing.Size(331, 78);
            this.buttonWorking.TabIndex = 5;
            this.buttonWorking.Text = "Работающие";
            this.buttonWorking.UseVisualStyleBackColor = true;
            this.buttonWorking.Click += new System.EventHandler(this.buttonWorking_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(772, 167);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(285, 73);
            this.textBoxSearch.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2120, 1229);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonWorking);
            this.Controls.Add(this.buttonFired);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.dataGridViewManager);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManager;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonFired;
        private System.Windows.Forms.Button buttonWorking;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}


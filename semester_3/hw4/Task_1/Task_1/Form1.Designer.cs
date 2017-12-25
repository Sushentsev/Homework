namespace Task_1
{
    partial class MyPaintForm
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
            this.area = new System.Windows.Forms.Panel();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(12, 61);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(719, 351);
            this.area.TabIndex = 0;
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(12, 12);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(54, 20);
            this.undoButton.TabIndex = 1;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.OnUndoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(12, 35);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(54, 20);
            this.redoButton.TabIndex = 2;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.OnRedoButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(72, 12);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(91, 20);
            this.drawButton.TabIndex = 3;
            this.drawButton.Text = "Draw line";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.OnDrawButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(169, 12);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(91, 20);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select line";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.OnSelectButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(266, 12);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(91, 20);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove line";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.OnRemoveButton_Click);
            // 
            // MyPaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 424);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.redoButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.area);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MyPaintForm";
            this.Text = "MyPaint";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel area;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button removeButton;
    }
}


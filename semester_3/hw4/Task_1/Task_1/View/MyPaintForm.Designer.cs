using System.Drawing;

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
            this.DrawingArea = new System.Windows.Forms.Panel();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.RemoveLineButton = new System.Windows.Forms.Button();
            this.DrawRadioButton = new System.Windows.Forms.RadioButton();
            this.SelectRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // DrawingArea
            // 
            this.DrawingArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingArea.Location = new System.Drawing.Point(12, 38);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(719, 374);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDrawingArea_Paint);
            this.DrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDrawingArea_MouseDown);
            this.DrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrawingArea_MouseMove);
            this.DrawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnDrawingArea_MouseUp);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(12, 12);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(54, 20);
            this.UndoButton.TabIndex = 1;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.OnUndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(72, 12);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(54, 20);
            this.RedoButton.TabIndex = 2;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.OnRedoButton_Click);
            // 
            // RemoveLineButton
            // 
            this.RemoveLineButton.Location = new System.Drawing.Point(132, 12);
            this.RemoveLineButton.Name = "RemoveLineButton";
            this.RemoveLineButton.Size = new System.Drawing.Size(91, 20);
            this.RemoveLineButton.TabIndex = 5;
            this.RemoveLineButton.Text = "Remove line";
            this.RemoveLineButton.UseVisualStyleBackColor = true;
            this.RemoveLineButton.Click += new System.EventHandler(this.OnRemoveButton_Click);
            // 
            // DrawRadioButton
            // 
            this.DrawRadioButton.AutoSize = true;
            this.DrawRadioButton.Checked = true;
            this.DrawRadioButton.Location = new System.Drawing.Point(229, 14);
            this.DrawRadioButton.Name = "DrawRadioButton";
            this.DrawRadioButton.Size = new System.Drawing.Size(50, 17);
            this.DrawRadioButton.TabIndex = 6;
            this.DrawRadioButton.TabStop = true;
            this.DrawRadioButton.Text = "Draw";
            this.DrawRadioButton.UseVisualStyleBackColor = true;
            this.DrawRadioButton.Click += new System.EventHandler(this.DrawRadioButton_Click);
            // 
            // SelectRadioButton
            // 
            this.SelectRadioButton.AutoSize = true;
            this.SelectRadioButton.Location = new System.Drawing.Point(285, 14);
            this.SelectRadioButton.Name = "SelectRadioButton";
            this.SelectRadioButton.Size = new System.Drawing.Size(55, 17);
            this.SelectRadioButton.TabIndex = 7;
            this.SelectRadioButton.Text = "Select";
            this.SelectRadioButton.UseVisualStyleBackColor = true;
            // 
            // MyPaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 424);
            this.Controls.Add(this.SelectRadioButton);
            this.Controls.Add(this.DrawRadioButton);
            this.Controls.Add(this.RemoveLineButton);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.DrawingArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MyPaintForm";
            this.Text = "MyPaint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DrawingArea;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button RemoveLineButton;
        private System.Windows.Forms.RadioButton DrawRadioButton;
        private System.Windows.Forms.RadioButton SelectRadioButton;
    }
}


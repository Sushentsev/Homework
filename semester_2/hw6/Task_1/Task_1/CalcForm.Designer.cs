namespace Task_1
{
    partial class Calc
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
            this.clearButton = new System.Windows.Forms.Button();
            this.inputField = new System.Windows.Forms.TextBox();
            this.changeSignButton = new System.Windows.Forms.Button();
            this.getPercentButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.digitNineButton = new System.Windows.Forms.Button();
            this.digitEightButton = new System.Windows.Forms.Button();
            this.digitSevenButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.digitThreeButton = new System.Windows.Forms.Button();
            this.digitTwoButton = new System.Windows.Forms.Button();
            this.digitOneButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.digitSixButton = new System.Windows.Forms.Button();
            this.digitFiveButton = new System.Windows.Forms.Button();
            this.digitFourButton = new System.Windows.Forms.Button();
            this.pointButton = new System.Windows.Forms.Button();
            this.digitZeroButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(12, 47);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(50, 50);
            this.clearButton.TabIndex = 0;
            this.clearButton.Text = "AC";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputField.Location = new System.Drawing.Point(12, 12);
            this.inputField.Name = "inputField";
            this.inputField.ReadOnly = true;
            this.inputField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.inputField.Size = new System.Drawing.Size(218, 29);
            this.inputField.TabIndex = 1;
            // 
            // changeSignButton
            // 
            this.changeSignButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.changeSignButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeSignButton.Location = new System.Drawing.Point(68, 47);
            this.changeSignButton.Name = "changeSignButton";
            this.changeSignButton.Size = new System.Drawing.Size(50, 50);
            this.changeSignButton.TabIndex = 2;
            this.changeSignButton.Text = "+/-";
            this.changeSignButton.UseVisualStyleBackColor = true;
            // 
            // getPercentButton
            // 
            this.getPercentButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.getPercentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getPercentButton.Location = new System.Drawing.Point(124, 47);
            this.getPercentButton.Name = "getPercentButton";
            this.getPercentButton.Size = new System.Drawing.Size(50, 50);
            this.getPercentButton.TabIndex = 3;
            this.getPercentButton.Text = "%";
            this.getPercentButton.UseVisualStyleBackColor = true;
            // 
            // divideButton
            // 
            this.divideButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.divideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.divideButton.Location = new System.Drawing.Point(180, 47);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(50, 50);
            this.divideButton.TabIndex = 4;
            this.divideButton.Text = "÷";
            this.divideButton.UseVisualStyleBackColor = true;
            // 
            // multiplyButton
            // 
            this.multiplyButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.multiplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiplyButton.Location = new System.Drawing.Point(180, 103);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(50, 50);
            this.multiplyButton.TabIndex = 8;
            this.multiplyButton.Text = "×";
            this.multiplyButton.UseVisualStyleBackColor = true;
            // 
            // digitNineButton
            // 
            this.digitNineButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitNineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitNineButton.Location = new System.Drawing.Point(124, 103);
            this.digitNineButton.Name = "digitNineButton";
            this.digitNineButton.Size = new System.Drawing.Size(50, 50);
            this.digitNineButton.TabIndex = 7;
            this.digitNineButton.Text = "9";
            this.digitNineButton.UseVisualStyleBackColor = true;
            this.digitNineButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // digitEightButton
            // 
            this.digitEightButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitEightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitEightButton.Location = new System.Drawing.Point(68, 103);
            this.digitEightButton.Name = "digitEightButton";
            this.digitEightButton.Size = new System.Drawing.Size(50, 50);
            this.digitEightButton.TabIndex = 6;
            this.digitEightButton.Text = "8";
            this.digitEightButton.UseVisualStyleBackColor = true;
            this.digitEightButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // digitSevenButton
            // 
            this.digitSevenButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitSevenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitSevenButton.Location = new System.Drawing.Point(12, 103);
            this.digitSevenButton.Name = "digitSevenButton";
            this.digitSevenButton.Size = new System.Drawing.Size(50, 50);
            this.digitSevenButton.TabIndex = 5;
            this.digitSevenButton.Text = "7";
            this.digitSevenButton.UseVisualStyleBackColor = true;
            this.digitSevenButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // plusButton
            // 
            this.plusButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.plusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusButton.Location = new System.Drawing.Point(180, 215);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(50, 50);
            this.plusButton.TabIndex = 16;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            // 
            // digitThreeButton
            // 
            this.digitThreeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitThreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitThreeButton.Location = new System.Drawing.Point(124, 215);
            this.digitThreeButton.Name = "digitThreeButton";
            this.digitThreeButton.Size = new System.Drawing.Size(50, 50);
            this.digitThreeButton.TabIndex = 15;
            this.digitThreeButton.Text = "3";
            this.digitThreeButton.UseVisualStyleBackColor = true;
            this.digitThreeButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // digitTwoButton
            // 
            this.digitTwoButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitTwoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitTwoButton.Location = new System.Drawing.Point(68, 215);
            this.digitTwoButton.Name = "digitTwoButton";
            this.digitTwoButton.Size = new System.Drawing.Size(50, 50);
            this.digitTwoButton.TabIndex = 14;
            this.digitTwoButton.Text = "2";
            this.digitTwoButton.UseVisualStyleBackColor = true;
            this.digitTwoButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // digitOneButton
            // 
            this.digitOneButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitOneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitOneButton.Location = new System.Drawing.Point(12, 215);
            this.digitOneButton.Name = "digitOneButton";
            this.digitOneButton.Size = new System.Drawing.Size(50, 50);
            this.digitOneButton.TabIndex = 13;
            this.digitOneButton.Text = "1";
            this.digitOneButton.UseVisualStyleBackColor = true;
            this.digitOneButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // minusButton
            // 
            this.minusButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusButton.Location = new System.Drawing.Point(180, 159);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(50, 50);
            this.minusButton.TabIndex = 12;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            // 
            // digitSixButton
            // 
            this.digitSixButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitSixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitSixButton.Location = new System.Drawing.Point(124, 159);
            this.digitSixButton.Name = "digitSixButton";
            this.digitSixButton.Size = new System.Drawing.Size(50, 50);
            this.digitSixButton.TabIndex = 11;
            this.digitSixButton.Text = "6";
            this.digitSixButton.UseVisualStyleBackColor = true;
            this.digitSixButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // digitFiveButton
            // 
            this.digitFiveButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitFiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitFiveButton.Location = new System.Drawing.Point(68, 159);
            this.digitFiveButton.Name = "digitFiveButton";
            this.digitFiveButton.Size = new System.Drawing.Size(50, 50);
            this.digitFiveButton.TabIndex = 10;
            this.digitFiveButton.Text = "5";
            this.digitFiveButton.UseVisualStyleBackColor = true;
            this.digitFiveButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // digitFourButton
            // 
            this.digitFourButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitFourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitFourButton.Location = new System.Drawing.Point(12, 159);
            this.digitFourButton.Name = "digitFourButton";
            this.digitFourButton.Size = new System.Drawing.Size(50, 50);
            this.digitFourButton.TabIndex = 9;
            this.digitFourButton.Text = "4";
            this.digitFourButton.UseVisualStyleBackColor = true;
            this.digitFourButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // pointButton
            // 
            this.pointButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.pointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointButton.Location = new System.Drawing.Point(124, 268);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(50, 50);
            this.pointButton.TabIndex = 17;
            this.pointButton.Text = ",";
            this.pointButton.UseVisualStyleBackColor = true;
            // 
            // digitZeroButton
            // 
            this.digitZeroButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitZeroButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.digitZeroButton.Location = new System.Drawing.Point(12, 268);
            this.digitZeroButton.Name = "digitZeroButton";
            this.digitZeroButton.Size = new System.Drawing.Size(106, 50);
            this.digitZeroButton.TabIndex = 18;
            this.digitZeroButton.Text = "0";
            this.digitZeroButton.UseVisualStyleBackColor = true;
            this.digitZeroButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // resultButton
            // 
            this.resultButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.resultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultButton.Location = new System.Drawing.Point(180, 268);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(50, 50);
            this.resultButton.TabIndex = 19;
            this.resultButton.Text = "=";
            this.resultButton.UseVisualStyleBackColor = true;
            // 
            // Calc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(241, 325);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.digitZeroButton);
            this.Controls.Add(this.pointButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.digitThreeButton);
            this.Controls.Add(this.digitTwoButton);
            this.Controls.Add(this.digitOneButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.digitSixButton);
            this.Controls.Add(this.digitFiveButton);
            this.Controls.Add(this.digitFourButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.digitNineButton);
            this.Controls.Add(this.digitEightButton);
            this.Controls.Add(this.digitSevenButton);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.getPercentButton);
            this.Controls.Add(this.changeSignButton);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.clearButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Calc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Button changeSignButton;
        private System.Windows.Forms.Button getPercentButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button digitNineButton;
        private System.Windows.Forms.Button digitEightButton;
        private System.Windows.Forms.Button digitSevenButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button digitThreeButton;
        private System.Windows.Forms.Button digitTwoButton;
        private System.Windows.Forms.Button digitOneButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button digitSixButton;
        private System.Windows.Forms.Button digitFiveButton;
        private System.Windows.Forms.Button digitFourButton;
        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.Button digitZeroButton;
        private System.Windows.Forms.Button resultButton;
    }
}


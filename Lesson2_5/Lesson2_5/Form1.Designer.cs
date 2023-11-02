namespace Lesson2_5
{
    partial class Calculator
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
            ButtonSum = new Button();
            ButtonSub = new Button();
            ButtonMylt = new Button();
            ButtonDivide = new Button();
            ButtonCancel = new Button();
            ButtonReset = new Button();
            Result = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // ButtonSum
            // 
            ButtonSum.Location = new Point(243, 57);
            ButtonSum.Name = "ButtonSum";
            ButtonSum.Size = new Size(94, 29);
            ButtonSum.TabIndex = 0;
            ButtonSum.Text = "Сложить";
            ButtonSum.UseVisualStyleBackColor = true;
            ButtonSum.Click += ButtonSum_Click;
            // 
            // ButtonSub
            // 
            ButtonSub.Location = new Point(243, 131);
            ButtonSub.Name = "ButtonSub";
            ButtonSub.Size = new Size(94, 29);
            ButtonSub.TabIndex = 1;
            ButtonSub.Text = "Вычесть";
            ButtonSub.UseVisualStyleBackColor = true;
            ButtonSub.Click += ButtonSub_Click;
            // 
            // ButtonMylt
            // 
            ButtonMylt.Location = new Point(243, 200);
            ButtonMylt.Name = "ButtonMylt";
            ButtonMylt.Size = new Size(94, 29);
            ButtonMylt.TabIndex = 2;
            ButtonMylt.Text = "Умножить";
            ButtonMylt.UseVisualStyleBackColor = true;
            ButtonMylt.Click += ButtonMylt_Click;
            // 
            // ButtonDivide
            // 
            ButtonDivide.Location = new Point(243, 275);
            ButtonDivide.Name = "ButtonDivide";
            ButtonDivide.Size = new Size(94, 29);
            ButtonDivide.TabIndex = 3;
            ButtonDivide.Text = "Делить";
            ButtonDivide.UseVisualStyleBackColor = true;
            ButtonDivide.Click += ButtonDivide_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(213, 378);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(155, 29);
            ButtonCancel.TabIndex = 4;
            ButtonCancel.Text = "Отмена действия";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // ButtonReset
            // 
            ButtonReset.Location = new Point(694, 409);
            ButtonReset.Name = "ButtonReset";
            ButtonReset.Size = new Size(94, 29);
            ButtonReset.TabIndex = 5;
            ButtonReset.Text = "Сброс";
            ButtonReset.UseVisualStyleBackColor = true;
            ButtonReset.Click += ButtonReset_Click;
            // 
            // Result
            // 
            Result.AutoSize = true;
            Result.Location = new Point(457, 62);
            Result.Name = "Result";
            Result.Size = new Size(64, 20);
            Result.TabIndex = 6;
            Result.Text = "Result: 0";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 34);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 8;
            label1.Text = "Введите число";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 34);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 9;
            label2.Text = "Выберите операцию";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(457, 34);
            label3.Name = "label3";
            label3.Size = new Size(146, 20);
            label3.TabIndex = 10;
            label3.Text = "Получите результат";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(457, 250);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 11;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(Result);
            Controls.Add(ButtonReset);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonDivide);
            Controls.Add(ButtonMylt);
            Controls.Add(ButtonSub);
            Controls.Add(ButtonSum);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonSum;
        private Button ButtonSub;
        private Button ButtonMylt;
        private Button ButtonDivide;
        private Button ButtonCancel;
        private Button ButtonReset;
        private Label Result;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
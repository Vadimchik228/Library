
namespace WindowsFormsApp6
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
            this.TotalNumber = new System.Windows.Forms.Label();
            this.NumberIssuedOnHand = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TotalNumber
            // 
            this.TotalNumber.AutoSize = true;
            this.TotalNumber.Location = new System.Drawing.Point(576, 9);
            this.TotalNumber.Name = "TotalNumber";
            this.TotalNumber.Size = new System.Drawing.Size(36, 13);
            this.TotalNumber.TabIndex = 0;
            this.TotalNumber.Text = "label1";
            this.TotalNumber.Visible = false;
            // 
            // NumberIssuedOnHand
            // 
            this.NumberIssuedOnHand.AutoSize = true;
            this.NumberIssuedOnHand.Location = new System.Drawing.Point(576, 37);
            this.NumberIssuedOnHand.Name = "NumberIssuedOnHand";
            this.NumberIssuedOnHand.Size = new System.Drawing.Size(38, 13);
            this.NumberIssuedOnHand.TabIndex = 1;
            this.NumberIssuedOnHand.Text = "label2";
            this.NumberIssuedOnHand.Visible = false;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Wheat;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(727, 345);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(89, 30);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Fall;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 375);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NumberIssuedOnHand);
            this.Controls.Add(this.TotalNumber);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PersonControl player;
        private System.Windows.Forms.Label TotalNumber;
        private System.Windows.Forms.Label NumberIssuedOnHand;
        private System.Windows.Forms.Button StartButton;
    }
}


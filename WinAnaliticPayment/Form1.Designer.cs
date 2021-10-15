
namespace WinAnaliticPayment
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
            this.btnFindStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFindStart
            // 
            this.btnFindStart.Location = new System.Drawing.Point(136, 61);
            this.btnFindStart.Name = "btnFindStart";
            this.btnFindStart.Size = new System.Drawing.Size(75, 23);
            this.btnFindStart.TabIndex = 0;
            this.btnFindStart.Text = "button1";
            this.btnFindStart.UseVisualStyleBackColor = true;
            this.btnFindStart.Click += new System.EventHandler(this.btnFindStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFindStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindStart;
    }
}


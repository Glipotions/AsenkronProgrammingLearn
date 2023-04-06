namespace TaskThreadApp
{
    partial class Form1
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
            btnBaslat = new Button();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            btnSayac = new Button();
            SuspendLayout();
            // 
            // btnBaslat
            // 
            btnBaslat.Location = new Point(37, 36);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(75, 23);
            btnBaslat.TabIndex = 0;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(37, 100);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(703, 23);
            progressBar1.TabIndex = 1;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(37, 173);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(703, 23);
            progressBar2.TabIndex = 2;
            // 
            // btnSayac
            // 
            btnSayac.Location = new Point(145, 36);
            btnSayac.Name = "btnSayac";
            btnSayac.Size = new Size(75, 23);
            btnSayac.TabIndex = 3;
            btnSayac.Text = "Sayaç";
            btnSayac.UseVisualStyleBackColor = true;
            btnSayac.Click += btnSayac_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSayac);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(btnBaslat);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBaslat;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Button btnSayac;
    }
}
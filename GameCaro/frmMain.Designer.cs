namespace GameCaro
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHaiNguoiChoi = new System.Windows.Forms.Button();
            this.btnChoiVoiMay = new System.Windows.Forms.Button();
            this.btnHuongDan = new System.Windows.Forms.Button();
            this.btnDanhOnline = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHaiNguoiChoi
            // 
            this.btnHaiNguoiChoi.BackColor = System.Drawing.Color.Red;
            this.btnHaiNguoiChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHaiNguoiChoi.ForeColor = System.Drawing.Color.White;
            this.btnHaiNguoiChoi.Location = new System.Drawing.Point(57, 31);
            this.btnHaiNguoiChoi.Name = "btnHaiNguoiChoi";
            this.btnHaiNguoiChoi.Size = new System.Drawing.Size(346, 81);
            this.btnHaiNguoiChoi.TabIndex = 0;
            this.btnHaiNguoiChoi.Text = "Người chơi với người";
            this.btnHaiNguoiChoi.UseVisualStyleBackColor = false;
            this.btnHaiNguoiChoi.Click += new System.EventHandler(this.btnHaiNguoiChoi_Click);
            // 
            // 
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.BackColor = System.Drawing.Color.Red;
            this.btnHuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuongDan.ForeColor = System.Drawing.Color.White;
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Size = new System.Drawing.Size(346, 81);
            this.btnHuongDan.TabIndex = 0;
            this.btnHuongDan.Text = "Hướng dẫn";
            this.btnHuongDan.UseVisualStyleBackColor = false;
            this.btnHuongDan.Click += new System.EventHandler(this.btnHuongDan_Click);
            // 
            // btnDanhOnline
            // 
            this.btnDanhOnline.BackColor = System.Drawing.Color.Red;
            this.btnDanhOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhOnline.ForeColor = System.Drawing.Color.White;
            this.btnDanhOnline.Location = new System.Drawing.Point(57, 234);
            this.btnDanhOnline.Name = "btnDanhOnline";
            this.btnDanhOnline.Size = new System.Drawing.Size(346, 75);
            this.btnDanhOnline.TabIndex = 0;
            this.btnDanhOnline.Text = "Đánh online";
            this.btnDanhOnline.UseVisualStyleBackColor = false;
            this.btnDanhOnline.Click += new System.EventHandler(this.btnDanhOnline_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(346, 81);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuongDan);
            this.Controls.Add(this.btnHaiNguoiChoi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Caro";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHaiNguoiChoi;
        private System.Windows.Forms.Button btnHuongDan;
        private System.Windows.Forms.Button btnThoat;
    }
}


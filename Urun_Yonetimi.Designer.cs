namespace ETicaret
{
    partial class Urun_Yonetimi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_urun_sil = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_urun_ekle = new System.Windows.Forms.Button();
            this.txt_adet = new System.Windows.Forms.NumericUpDown();
            this.txt_fiyat = new System.Windows.Forms.NumericUpDown();
            this.txt_aciklama = new System.Windows.Forms.RichTextBox();
            this.txt_kategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 709);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_urun_sil);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(17, 530);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 156);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ürün Sil";
            // 
            // btn_urun_sil
            // 
            this.btn_urun_sil.BackColor = System.Drawing.Color.IndianRed;
            this.btn_urun_sil.Location = new System.Drawing.Point(42, 90);
            this.btn_urun_sil.Name = "btn_urun_sil";
            this.btn_urun_sil.Size = new System.Drawing.Size(595, 47);
            this.btn_urun_sil.TabIndex = 7;
            this.btn_urun_sil.Text = "Ürün Sil";
            this.btn_urun_sil.UseVisualStyleBackColor = false;
            this.btn_urun_sil.Click += new System.EventHandler(this.btn_urun_sil_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(324, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Seçilen Ürün: (Listeden Bir Ürün Seçin)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürünler Listesi:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 57);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(680, 452);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tan;
            this.button1.Location = new System.Drawing.Point(43, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(486, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ürün Güncelle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(747, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 709);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.btn_urun_ekle);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txt_adet);
            this.groupBox3.Controls.Add(this.txt_fiyat);
            this.groupBox3.Controls.Add(this.txt_aciklama);
            this.groupBox3.Controls.Add(this.txt_kategory);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(17, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(565, 661);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ürün Ekleme / Güncelleme";
            // 
            // btn_urun_ekle
            // 
            this.btn_urun_ekle.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_urun_ekle.Location = new System.Drawing.Point(43, 527);
            this.btn_urun_ekle.Name = "btn_urun_ekle";
            this.btn_urun_ekle.Size = new System.Drawing.Size(487, 47);
            this.btn_urun_ekle.TabIndex = 6;
            this.btn_urun_ekle.Text = "Ürün Ekle";
            this.btn_urun_ekle.UseVisualStyleBackColor = false;
            this.btn_urun_ekle.Click += new System.EventHandler(this.btn_urun_ekle_Click);
            // 
            // txt_adet
            // 
            this.txt_adet.Location = new System.Drawing.Point(208, 360);
            this.txt_adet.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txt_adet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_adet.Name = "txt_adet";
            this.txt_adet.Size = new System.Drawing.Size(320, 26);
            this.txt_adet.TabIndex = 4;
            this.txt_adet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_adet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txt_fiyat
            // 
            this.txt_fiyat.Location = new System.Drawing.Point(208, 257);
            this.txt_fiyat.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txt_fiyat.Name = "txt_fiyat";
            this.txt_fiyat.Size = new System.Drawing.Size(320, 26);
            this.txt_fiyat.TabIndex = 4;
            this.txt_fiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(209, 140);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Size = new System.Drawing.Size(319, 93);
            this.txt_aciklama.TabIndex = 3;
            this.txt_aciklama.Text = "";
            // 
            // txt_kategory
            // 
            this.txt_kategory.FormattingEnabled = true;
            this.txt_kategory.Location = new System.Drawing.Point(208, 307);
            this.txt_kategory.Name = "txt_kategory";
            this.txt_kategory.Size = new System.Drawing.Size(321, 28);
            this.txt_kategory.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.ForeColor = System.Drawing.Color.Brown;
            this.label10.Location = new System.Drawing.Point(204, 413);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(313, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "(Yalnızca Web Sitesinden Eklenebilir.)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(66, 413);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ürün Görseli:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Adet:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kategori:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fiyatı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ürün Açıklaması:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ürün Adı:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(209, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(321, 28);
            this.comboBox1.TabIndex = 7;
            // 
            // Urun_Yonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1372, 738);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Urun_Yonetimi";
            this.Text = "Ürün ve Stok Yönetimi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fiyat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown txt_fiyat;
        private System.Windows.Forms.RichTextBox txt_aciklama;
        private System.Windows.Forms.ComboBox txt_kategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txt_adet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_urun_ekle;
        private System.Windows.Forms.Button btn_urun_sil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
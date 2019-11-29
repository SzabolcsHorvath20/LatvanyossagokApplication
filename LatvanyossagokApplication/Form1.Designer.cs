namespace LatvanyossagokApplication
{
    partial class Form1
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
            this.varos_nev = new System.Windows.Forms.TextBox();
            this.varos_lakossag = new System.Windows.Forms.NumericUpDown();
            this.varos_beszuras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.latvanyossag_nev = new System.Windows.Forms.TextBox();
            this.latvanyossag_ar = new System.Windows.Forms.NumericUpDown();
            this.latvanyossag_hozzaad = new System.Windows.Forms.Button();
            this.latvanyossag_leiras = new System.Windows.Forms.TextBox();
            this.latvanyossag_varos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.varos_lakossag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.latvanyossag_ar)).BeginInit();
            this.SuspendLayout();
            // 
            // varos_nev
            // 
            this.varos_nev.Location = new System.Drawing.Point(100, 12);
            this.varos_nev.Name = "varos_nev";
            this.varos_nev.Size = new System.Drawing.Size(100, 20);
            this.varos_nev.TabIndex = 0;
            // 
            // varos_lakossag
            // 
            this.varos_lakossag.Location = new System.Drawing.Point(100, 40);
            this.varos_lakossag.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.varos_lakossag.Name = "varos_lakossag";
            this.varos_lakossag.Size = new System.Drawing.Size(100, 20);
            this.varos_lakossag.TabIndex = 1;
            // 
            // varos_beszuras
            // 
            this.varos_beszuras.Location = new System.Drawing.Point(100, 66);
            this.varos_beszuras.Name = "varos_beszuras";
            this.varos_beszuras.Size = new System.Drawing.Size(100, 23);
            this.varos_beszuras.TabIndex = 2;
            this.varos_beszuras.Text = "Hozzáad";
            this.varos_beszuras.UseVisualStyleBackColor = true;
            this.varos_beszuras.Click += new System.EventHandler(this.varos_beszuras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Város neve:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Város lakossága:";
            // 
            // latvanyossag_nev
            // 
            this.latvanyossag_nev.Location = new System.Drawing.Point(333, 12);
            this.latvanyossag_nev.Name = "latvanyossag_nev";
            this.latvanyossag_nev.Size = new System.Drawing.Size(121, 20);
            this.latvanyossag_nev.TabIndex = 5;
            // 
            // latvanyossag_ar
            // 
            this.latvanyossag_ar.Location = new System.Drawing.Point(333, 69);
            this.latvanyossag_ar.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.latvanyossag_ar.Name = "latvanyossag_ar";
            this.latvanyossag_ar.Size = new System.Drawing.Size(121, 20);
            this.latvanyossag_ar.TabIndex = 6;
            // 
            // latvanyossag_hozzaad
            // 
            this.latvanyossag_hozzaad.Location = new System.Drawing.Point(333, 123);
            this.latvanyossag_hozzaad.Name = "latvanyossag_hozzaad";
            this.latvanyossag_hozzaad.Size = new System.Drawing.Size(121, 23);
            this.latvanyossag_hozzaad.TabIndex = 7;
            this.latvanyossag_hozzaad.Text = "Hozzáad";
            this.latvanyossag_hozzaad.UseVisualStyleBackColor = true;
            // 
            // latvanyossag_leiras
            // 
            this.latvanyossag_leiras.Location = new System.Drawing.Point(333, 40);
            this.latvanyossag_leiras.Name = "latvanyossag_leiras";
            this.latvanyossag_leiras.Size = new System.Drawing.Size(121, 20);
            this.latvanyossag_leiras.TabIndex = 8;
            // 
            // latvanyossag_varos
            // 
            this.latvanyossag_varos.FormattingEnabled = true;
            this.latvanyossag_varos.Location = new System.Drawing.Point(333, 96);
            this.latvanyossag_varos.Name = "latvanyossag_varos";
            this.latvanyossag_varos.Size = new System.Drawing.Size(121, 21);
            this.latvanyossag_varos.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Látványosság neve:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Leírása:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ára:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Megtalálható:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.latvanyossag_varos);
            this.Controls.Add(this.latvanyossag_leiras);
            this.Controls.Add(this.latvanyossag_hozzaad);
            this.Controls.Add(this.latvanyossag_ar);
            this.Controls.Add(this.latvanyossag_nev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.varos_beszuras);
            this.Controls.Add(this.varos_lakossag);
            this.Controls.Add(this.varos_nev);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.varos_lakossag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.latvanyossag_ar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox varos_nev;
        private System.Windows.Forms.NumericUpDown varos_lakossag;
        private System.Windows.Forms.Button varos_beszuras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox latvanyossag_nev;
        private System.Windows.Forms.NumericUpDown latvanyossag_ar;
        private System.Windows.Forms.Button latvanyossag_hozzaad;
        private System.Windows.Forms.TextBox latvanyossag_leiras;
        private System.Windows.Forms.ComboBox latvanyossag_varos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}


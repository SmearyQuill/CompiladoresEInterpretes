namespace CompiladoresInterpretes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbExprecion = new System.Windows.Forms.TextBox();
            this.bPostfija = new System.Windows.Forms.Button();
            this.tbPostfija = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_CreaAFN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbExprecion
            // 
            this.tbExprecion.Location = new System.Drawing.Point(12, 106);
            this.tbExprecion.Name = "tbExprecion";
            this.tbExprecion.Size = new System.Drawing.Size(266, 20);
            this.tbExprecion.TabIndex = 0;
            // 
            // bPostfija
            // 
            this.bPostfija.Location = new System.Drawing.Point(170, 141);
            this.bPostfija.Name = "bPostfija";
            this.bPostfija.Size = new System.Drawing.Size(108, 23);
            this.bPostfija.TabIndex = 1;
            this.bPostfija.Text = "Convertir a Postfija";
            this.bPostfija.UseVisualStyleBackColor = true;
            this.bPostfija.Click += new System.EventHandler(this.bPostfija_Click);
            // 
            // tbPostfija
            // 
            this.tbPostfija.Location = new System.Drawing.Point(12, 186);
            this.tbPostfija.Name = "tbPostfija";
            this.tbPostfija.Size = new System.Drawing.Size(266, 20);
            this.tbPostfija.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Exprecion Regular:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Postfija:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compiladores e Interpretes A - Equipo Electro-Tamales \r\nFlores Aguilar Gael Ricar" +
    "do\r\nMarcado De Luna Guillermo Daniel";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(297, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Edo";
            this.Column1.Name = "Column1";
            // 
            // bt_CreaAFN
            // 
            this.bt_CreaAFN.Location = new System.Drawing.Point(170, 212);
            this.bt_CreaAFN.Name = "bt_CreaAFN";
            this.bt_CreaAFN.Size = new System.Drawing.Size(108, 23);
            this.bt_CreaAFN.TabIndex = 8;
            this.bt_CreaAFN.Text = "Construir AFN";
            this.bt_CreaAFN.UseVisualStyleBackColor = true;
            this.bt_CreaAFN.Click += new System.EventHandler(this.bt_CreaAFN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 404);
            this.Controls.Add(this.bt_CreaAFN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPostfija);
            this.Controls.Add(this.bPostfija);
            this.Controls.Add(this.tbExprecion);
            this.Name = "Form1";
            this.Text = "ProyectoCompiladres";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExprecion;
        private System.Windows.Forms.Button bPostfija;
        private System.Windows.Forms.TextBox tbPostfija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button bt_CreaAFN;
    }
}


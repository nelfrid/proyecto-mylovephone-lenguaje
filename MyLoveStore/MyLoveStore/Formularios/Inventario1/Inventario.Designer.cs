namespace MyLoveStore.Formularios.Inventario1
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblIndicacion = new System.Windows.Forms.Label();
            this.cbTipoSeleccionEliminacion = new System.Windows.Forms.ComboBox();
            this.lblIndicacion2 = new System.Windows.Forms.Label();
            this.tbSeleccion = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.textoError = new System.Windows.Forms.Label();
            this.btnVolverInterfazPrincipal = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1513, 118);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(15, -49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 223);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombreProducto,
            this.colValor});
            this.dataGridView1.Location = new System.Drawing.Point(15, 142);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(908, 486);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCodigo.DataPropertyName = "idProducto";
            this.colCodigo.HeaderText = "ID";
            this.colCodigo.MinimumWidth = 6;
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colNombreProducto
            // 
            this.colNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreProducto.DataPropertyName = "nombreProducto";
            this.colNombreProducto.FillWeight = 200F;
            this.colNombreProducto.HeaderText = "NOMBRE DEL PRODUCTO";
            this.colNombreProducto.MinimumWidth = 6;
            this.colNombreProducto.Name = "colNombreProducto";
            this.colNombreProducto.ReadOnly = true;
            // 
            // colValor
            // 
            this.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValor.DataPropertyName = "valor";
            this.colValor.HeaderText = "CANTIDAD";
            this.colValor.MinimumWidth = 6;
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(963, 517);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 50);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(963, 156);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(160, 50);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblIndicacion
            // 
            this.lblIndicacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicacion.Location = new System.Drawing.Point(957, 311);
            this.lblIndicacion.Name = "lblIndicacion";
            this.lblIndicacion.Size = new System.Drawing.Size(256, 59);
            this.lblIndicacion.TabIndex = 7;
            this.lblIndicacion.Text = "Selecciona el tipo de producto:";
            this.lblIndicacion.Visible = false;
            // 
            // cbTipoSeleccionEliminacion
            // 
            this.cbTipoSeleccionEliminacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbTipoSeleccionEliminacion.FormattingEnabled = true;
            this.cbTipoSeleccionEliminacion.Items.AddRange(new object[] {
            "ID",
            "NOMBRE"});
            this.cbTipoSeleccionEliminacion.Location = new System.Drawing.Point(962, 402);
            this.cbTipoSeleccionEliminacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoSeleccionEliminacion.Name = "cbTipoSeleccionEliminacion";
            this.cbTipoSeleccionEliminacion.Size = new System.Drawing.Size(249, 33);
            this.cbTipoSeleccionEliminacion.TabIndex = 8;
            this.cbTipoSeleccionEliminacion.Visible = false;
            // 
            // lblIndicacion2
            // 
            this.lblIndicacion2.AutoSize = true;
            this.lblIndicacion2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicacion2.Location = new System.Drawing.Point(957, 225);
            this.lblIndicacion2.Name = "lblIndicacion2";
            this.lblIndicacion2.Size = new System.Drawing.Size(73, 28);
            this.lblIndicacion2.TabIndex = 9;
            this.lblIndicacion2.Text = "Escriba";
            this.lblIndicacion2.Visible = false;
            // 
            // tbSeleccion
            // 
            this.tbSeleccion.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeleccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSeleccion.Location = new System.Drawing.Point(963, 265);
            this.tbSeleccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSeleccion.Name = "tbSeleccion";
            this.tbSeleccion.Size = new System.Drawing.Size(251, 27);
            this.tbSeleccion.TabIndex = 10;
            this.tbSeleccion.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Black;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.Location = new System.Drawing.Point(16, 646);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(160, 50);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // textoError
            // 
            this.textoError.AutoSize = true;
            this.textoError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textoError.ForeColor = System.Drawing.Color.Red;
            this.textoError.Location = new System.Drawing.Point(958, 455);
            this.textoError.Name = "textoError";
            this.textoError.Size = new System.Drawing.Size(317, 20);
            this.textoError.TabIndex = 12;
            this.textoError.Text = "Intentelo de nuevo. Se debe elegir una opcion.";
            this.textoError.Visible = false;
            // 
            // btnVolverInterfazPrincipal
            // 
            this.btnVolverInterfazPrincipal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnVolverInterfazPrincipal.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverInterfazPrincipal.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVolverInterfazPrincipal.Location = new System.Drawing.Point(963, 646);
            this.btnVolverInterfazPrincipal.Name = "btnVolverInterfazPrincipal";
            this.btnVolverInterfazPrincipal.Size = new System.Drawing.Size(398, 50);
            this.btnVolverInterfazPrincipal.TabIndex = 13;
            this.btnVolverInterfazPrincipal.Text = "Volver al menú principal";
            this.btnVolverInterfazPrincipal.UseVisualStyleBackColor = false;
            this.btnVolverInterfazPrincipal.Click += new System.EventHandler(this.btnVolverInterfazPrincipal_Click);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1380, 750);
            this.Controls.Add(this.btnVolverInterfazPrincipal);
            this.Controls.Add(this.textoError);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.tbSeleccion);
            this.Controls.Add(this.lblIndicacion2);
            this.Controls.Add(this.cbTipoSeleccionEliminacion);
            this.Controls.Add(this.lblIndicacion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Inventario";
            this.Text = "Inventario | MyLovePhone";
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblIndicacion;
        private System.Windows.Forms.ComboBox cbTipoSeleccionEliminacion;
        private System.Windows.Forms.Label lblIndicacion2;
        private System.Windows.Forms.TextBox tbSeleccion;
        private System.Windows.Forms.Label textoError;
        private System.Windows.Forms.Button btnVolverInterfazPrincipal;
    }
}
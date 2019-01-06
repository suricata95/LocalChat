namespace LocalChat
{
    partial class TestUDP
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
            this.gbServidor = new System.Windows.Forms.GroupBox();
            this.txtSIP = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSPuerto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCIP = new System.Windows.Forms.TextBox();
            this.txtCPuerto = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtConversacion = new System.Windows.Forms.TextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gbServidor.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbServidor
            // 
            this.gbServidor.Controls.Add(this.txtSIP);
            this.gbServidor.Controls.Add(this.btnIniciar);
            this.gbServidor.Controls.Add(this.label2);
            this.gbServidor.Controls.Add(this.txtSPuerto);
            this.gbServidor.Controls.Add(this.label1);
            this.gbServidor.Location = new System.Drawing.Point(12, 12);
            this.gbServidor.Name = "gbServidor";
            this.gbServidor.Size = new System.Drawing.Size(553, 100);
            this.gbServidor.TabIndex = 0;
            this.gbServidor.TabStop = false;
            this.gbServidor.Text = "Servidor";
            // 
            // txtSIP
            // 
            this.txtSIP.Location = new System.Drawing.Point(57, 40);
            this.txtSIP.Name = "txtSIP";
            this.txtSIP.Size = new System.Drawing.Size(124, 22);
            this.txtSIP.TabIndex = 3;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(447, 40);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(85, 23);
            this.btnIniciar.TabIndex = 10;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Puerto";
            // 
            // txtSPuerto
            // 
            this.txtSPuerto.Location = new System.Drawing.Point(301, 41);
            this.txtSPuerto.Name = "txtSPuerto";
            this.txtSPuerto.Size = new System.Drawing.Size(100, 22);
            this.txtSPuerto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.label4);
            this.gbCliente.Controls.Add(this.btnConectar);
            this.gbCliente.Controls.Add(this.label3);
            this.gbCliente.Controls.Add(this.txtCIP);
            this.gbCliente.Controls.Add(this.txtCPuerto);
            this.gbCliente.Location = new System.Drawing.Point(12, 118);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(553, 100);
            this.gbCliente.TabIndex = 1;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Puerto";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(447, 44);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(85, 23);
            this.btnConectar.TabIndex = 11;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "IP";
            // 
            // txtCIP
            // 
            this.txtCIP.Location = new System.Drawing.Point(57, 44);
            this.txtCIP.Name = "txtCIP";
            this.txtCIP.Size = new System.Drawing.Size(124, 22);
            this.txtCIP.TabIndex = 8;
            // 
            // txtCPuerto
            // 
            this.txtCPuerto.Location = new System.Drawing.Point(301, 44);
            this.txtCPuerto.Name = "txtCPuerto";
            this.txtCPuerto.Size = new System.Drawing.Size(100, 22);
            this.txtCPuerto.TabIndex = 7;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(490, 487);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtConversacion
            // 
            this.txtConversacion.Location = new System.Drawing.Point(12, 224);
            this.txtConversacion.Multiline = true;
            this.txtConversacion.Name = "txtConversacion";
            this.txtConversacion.Size = new System.Drawing.Size(553, 230);
            this.txtConversacion.TabIndex = 6;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(12, 488);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(472, 22);
            this.txtMensaje.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // TestUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 538);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.txtConversacion);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbServidor);
            this.MaximumSize = new System.Drawing.Size(594, 585);
            this.MinimumSize = new System.Drawing.Size(594, 585);
            this.Name = "TestUDP";
            this.Text = "LocalChat";
            this.gbServidor.ResumeLayout(false);
            this.gbServidor.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServidor;
        private System.Windows.Forms.TextBox txtSIP;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSPuerto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCIP;
        private System.Windows.Forms.TextBox txtCPuerto;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtConversacion;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}


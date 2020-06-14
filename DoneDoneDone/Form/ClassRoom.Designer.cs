namespace DoneDoneDone
{
    partial class FormClassRoom
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
            this.dgvClassroom = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassroom)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClassroom
            // 
            this.dgvClassroom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassroom.Location = new System.Drawing.Point(130, 60);
            this.dgvClassroom.Name = "dgvClassroom";
            this.dgvClassroom.Size = new System.Drawing.Size(611, 163);
            this.dgvClassroom.TabIndex = 0;
            // 
            // FormClassRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvClassroom);
            this.Name = "FormClassRoom";
            this.Text = "ClassRoom";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassroom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClassroom;
    }
}
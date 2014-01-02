namespace OOD2_interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_and = new System.Windows.Forms.Button();
            this.button_or = new System.Windows.Forms.Button();
            this.button_not = new System.Windows.Forms.Button();
            this.button_source = new System.Windows.Forms.Button();
            this.button_lamp = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_connect);
            this.splitContainer1.Panel1.Controls.Add(this.button_lamp);
            this.splitContainer1.Panel1.Controls.Add(this.button_source);
            this.splitContainer1.Panel1.Controls.Add(this.button_not);
            this.splitContainer1.Panel1.Controls.Add(this.button_or);
            this.splitContainer1.Panel1.Controls.Add(this.button_and);
            this.splitContainer1.Size = new System.Drawing.Size(762, 564);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_and
            // 
            this.button_and.Image = ((System.Drawing.Image)(resources.GetObject("button_and.Image")));
            this.button_and.Location = new System.Drawing.Point(12, 110);
            this.button_and.Name = "button_and";
            this.button_and.Size = new System.Drawing.Size(108, 71);
            this.button_and.TabIndex = 0;
            this.button_and.UseVisualStyleBackColor = true;
            // 
            // button_or
            // 
            this.button_or.Image = ((System.Drawing.Image)(resources.GetObject("button_or.Image")));
            this.button_or.Location = new System.Drawing.Point(126, 110);
            this.button_or.Name = "button_or";
            this.button_or.Size = new System.Drawing.Size(108, 71);
            this.button_or.TabIndex = 1;
            this.button_or.UseVisualStyleBackColor = true;
            // 
            // button_not
            // 
            this.button_not.Image = ((System.Drawing.Image)(resources.GetObject("button_not.Image")));
            this.button_not.Location = new System.Drawing.Point(12, 199);
            this.button_not.Name = "button_not";
            this.button_not.Size = new System.Drawing.Size(108, 71);
            this.button_not.TabIndex = 2;
            this.button_not.UseVisualStyleBackColor = true;
            // 
            // button_source
            // 
            this.button_source.Image = ((System.Drawing.Image)(resources.GetObject("button_source.Image")));
            this.button_source.Location = new System.Drawing.Point(126, 199);
            this.button_source.Name = "button_source";
            this.button_source.Size = new System.Drawing.Size(108, 71);
            this.button_source.TabIndex = 3;
            this.button_source.UseVisualStyleBackColor = true;
            // 
            // button_lamp
            // 
            this.button_lamp.Image = ((System.Drawing.Image)(resources.GetObject("button_lamp.Image")));
            this.button_lamp.Location = new System.Drawing.Point(12, 289);
            this.button_lamp.Name = "button_lamp";
            this.button_lamp.Size = new System.Drawing.Size(108, 71);
            this.button_lamp.TabIndex = 4;
            this.button_lamp.UseVisualStyleBackColor = true;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(126, 289);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(108, 71);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "CONNECT";
            this.button_connect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 564);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_lamp;
        private System.Windows.Forms.Button button_source;
        private System.Windows.Forms.Button button_not;
        private System.Windows.Forms.Button button_or;
        private System.Windows.Forms.Button button_and;

    }
}


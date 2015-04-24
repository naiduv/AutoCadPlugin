namespace AutocadAddin
{
    partial class DrawForm
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.InnerBtn = new System.Windows.Forms.Button();
            this.MiddleBtn = new System.Windows.Forms.Button();
            this.OuterBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InnerBtn
            // 
            this.InnerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InnerBtn.Location = new System.Drawing.Point(12, 12);
            this.InnerBtn.Name = "InnerBtn";
            this.InnerBtn.Size = new System.Drawing.Size(75, 23);
            this.InnerBtn.TabIndex = 0;
            this.InnerBtn.Text = "Inner";
            this.InnerBtn.UseVisualStyleBackColor = true;
            this.InnerBtn.Click += new System.EventHandler(this.InnerBtn_Click);
            // 
            // MiddleBtn
            // 
            this.MiddleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiddleBtn.Location = new System.Drawing.Point(93, 12);
            this.MiddleBtn.Name = "MiddleBtn";
            this.MiddleBtn.Size = new System.Drawing.Size(75, 23);
            this.MiddleBtn.TabIndex = 1;
            this.MiddleBtn.Text = "Middle";
            this.MiddleBtn.UseVisualStyleBackColor = true;
            this.MiddleBtn.Click += new System.EventHandler(this.MiddleBtn_Click);
            // 
            // OuterBtn
            // 
            this.OuterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OuterBtn.Location = new System.Drawing.Point(174, 12);
            this.OuterBtn.Name = "OuterBtn";
            this.OuterBtn.Size = new System.Drawing.Size(75, 23);
            this.OuterBtn.TabIndex = 2;
            this.OuterBtn.Text = "Outer";
            this.OuterBtn.UseVisualStyleBackColor = true;
            this.OuterBtn.Click += new System.EventHandler(this.OuterBtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(93, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Generate";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 93);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.OuterBtn);
            this.Controls.Add(this.MiddleBtn);
            this.Controls.Add(this.InnerBtn);
            this.Name = "DrawForm";
            this.Text = "Circle Colors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button InnerBtn;
        private System.Windows.Forms.Button MiddleBtn;
        private System.Windows.Forms.Button OuterBtn;
        private System.Windows.Forms.Button button4;

    }
}
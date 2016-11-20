namespace WindowsForm
{
    partial class MainForm
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
            this.jsonTreeView = new Alex75.JsonViewer.WindowsForm.JsonTreeView();
            this.loadJsonButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // jsonTreeView
            // 
            this.jsonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTreeView.Location = new System.Drawing.Point(0, 0);
            this.jsonTreeView.Name = "jsonTreeView";
            this.jsonTreeView.Size = new System.Drawing.Size(282, 253);
            this.jsonTreeView.TabIndex = 0;
            // 
            // loadJsonButton
            // 
            this.loadJsonButton.Location = new System.Drawing.Point(3, 3);
            this.loadJsonButton.Name = "loadJsonButton";
            this.loadJsonButton.Size = new System.Drawing.Size(110, 23);
            this.loadJsonButton.TabIndex = 1;
            this.loadJsonButton.Text = "Load JSON";
            this.loadJsonButton.UseVisualStyleBackColor = true;
            this.loadJsonButton.Click += new System.EventHandler(this.loadJsonButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topPanel.Controls.Add(this.loadJsonButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(282, 29);
            this.topPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.jsonTreeView);
            this.Name = "MainForm";
            this.Text = "Example";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alex75.JsonViewer.WindowsForm.JsonTreeView jsonTreeView;
        private System.Windows.Forms.Button loadJsonButton;
        private System.Windows.Forms.Panel topPanel;
    }
}


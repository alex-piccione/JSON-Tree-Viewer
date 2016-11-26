using Alex75.JsonViewer.WindowsForm;

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
            this.components = new System.ComponentModel.Container();
            this.loadJsonButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.jsonTreeView = new Alex75.JsonViewer.WindowsForm.JsonTreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadJsonButton
            // 
            this.loadJsonButton.Location = new System.Drawing.Point(3, 3);
            this.loadJsonButton.Name = "loadJsonButton";
            this.loadJsonButton.Size = new System.Drawing.Size(110, 46);
            this.loadJsonButton.TabIndex = 1;
            this.loadJsonButton.Text = "Load JSON";
            this.loadJsonButton.UseVisualStyleBackColor = true;
            this.loadJsonButton.Click += new System.EventHandler(this.loadJsonButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.loadJsonButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(482, 54);
            this.topPanel.TabIndex = 2;
            // 
            // jsonTreeView
            // 
            this.jsonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTreeView.ImageIndex = 0;
            this.jsonTreeView.Location = new System.Drawing.Point(0, 0);
            this.jsonTreeView.Name = "jsonTreeView";
            this.jsonTreeView.SelectedImageIndex = 0;
            this.jsonTreeView.Size = new System.Drawing.Size(482, 399);
            this.jsonTreeView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.jsonTreeView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 399);
            this.panel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topPanel);
            this.Name = "MainForm";
            this.Text = "Example";
            this.topPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JsonTreeView jsonTreeView;
        private System.Windows.Forms.Button loadJsonButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panel1;
    }
}


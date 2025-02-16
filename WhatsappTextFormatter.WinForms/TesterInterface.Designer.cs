﻿namespace WhatsappTextFormatter.WinForms
{
    partial class TesterInterface
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbUnformattedText = new System.Windows.Forms.Label();
            this.lbText = new System.Windows.Forms.Label();
            this.lbFormatInfo = new System.Windows.Forms.Label();
            this.btFormat = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.rtbUnformattedText = new System.Windows.Forms.RichTextBox();
            this.rtbFormatInfo = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbUnformattedText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbText, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbFormatInfo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btFormat, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.rtbText, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.rtbUnformattedText, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtbFormatInfo, 3, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 449);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbUnformattedText
            // 
            this.lbUnformattedText.AutoSize = true;
            this.lbUnformattedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnformattedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnformattedText.Location = new System.Drawing.Point(23, 24);
            this.lbUnformattedText.Margin = new System.Windows.Forms.Padding(3);
            this.lbUnformattedText.Name = "lbUnformattedText";
            this.lbUnformattedText.Size = new System.Drawing.Size(154, 42);
            this.lbUnformattedText.TabIndex = 1;
            this.lbUnformattedText.Text = "Unformatted Text";
            this.lbUnformattedText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.Location = new System.Drawing.Point(23, 80);
            this.lbText.Margin = new System.Windows.Forms.Padding(3);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(154, 42);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "Text";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFormatInfo
            // 
            this.lbFormatInfo.AutoSize = true;
            this.lbFormatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFormatInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFormatInfo.Location = new System.Drawing.Point(23, 136);
            this.lbFormatInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lbFormatInfo.Name = "lbFormatInfo";
            this.lbFormatInfo.Size = new System.Drawing.Size(154, 242);
            this.lbFormatInfo.TabIndex = 1;
            this.lbFormatInfo.Text = "Format Info";
            this.lbFormatInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btFormat
            // 
            this.btFormat.AutoSize = true;
            this.btFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFormat.Location = new System.Drawing.Point(191, 392);
            this.btFormat.Name = "btFormat";
            this.btFormat.Size = new System.Drawing.Size(886, 33);
            this.btFormat.TabIndex = 3;
            this.btFormat.Text = "Format";
            this.btFormat.UseVisualStyleBackColor = true;
            // 
            // rtbText
            // 
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbText.Location = new System.Drawing.Point(191, 80);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(886, 42);
            this.rtbText.TabIndex = 1;
            this.rtbText.Text = "";
            // 
            // rtbUnformattedText
            // 
            this.rtbUnformattedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbUnformattedText.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbUnformattedText.Location = new System.Drawing.Point(191, 24);
            this.rtbUnformattedText.Name = "rtbUnformattedText";
            this.rtbUnformattedText.Size = new System.Drawing.Size(886, 42);
            this.rtbUnformattedText.TabIndex = 0;
            this.rtbUnformattedText.Text = "";
            // 
            // rtbFormatInfo
            // 
            this.rtbFormatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFormatInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbFormatInfo.Location = new System.Drawing.Point(191, 136);
            this.rtbFormatInfo.Name = "rtbFormatInfo";
            this.rtbFormatInfo.ReadOnly = true;
            this.rtbFormatInfo.Size = new System.Drawing.Size(886, 242);
            this.rtbFormatInfo.TabIndex = 2;
            this.rtbFormatInfo.Text = "";
            // 
            // TesterInterface
            // 
            this.AcceptButton = this.btFormat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 449);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(400, 302);
            this.Name = "TesterInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Whatsapp Text Formatter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbUnformattedText;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label lbFormatInfo;
        private System.Windows.Forms.Button btFormat;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.RichTextBox rtbUnformattedText;
        private System.Windows.Forms.RichTextBox rtbFormatInfo;
    }
}


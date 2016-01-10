namespace UI
{
    partial class QAControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._questiontextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._nextbutton = new System.Windows.Forms.Button();
            this._prevbutton = new System.Windows.Forms.Button();
            this._answerRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._submitBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.46342F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.53658F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._questiontextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this._answerRichTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2449F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.16035F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.82799F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.65789F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.868421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.34211F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 327);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUESTION :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _questiontextBox
            // 
            this._questiontextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._questiontextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._questiontextBox.Location = new System.Drawing.Point(126, 36);
            this._questiontextBox.Multiline = true;
            this._questiontextBox.Name = "_questiontextBox";
            this._questiontextBox.ReadOnly = true;
            this._questiontextBox.Size = new System.Drawing.Size(512, 35);
            this._questiontextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "ANSWER :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this._nextbutton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this._prevbutton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(111, 209);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(459, 59);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // _nextbutton
            // 
            this._nextbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._nextbutton.Location = new System.Drawing.Point(292, 10);
            this._nextbutton.Name = "_nextbutton";
            this._nextbutton.Size = new System.Drawing.Size(104, 38);
            this._nextbutton.TabIndex = 0;
            this._nextbutton.Text = "NEXT";
            this._nextbutton.UseVisualStyleBackColor = true;
            this._nextbutton.Click += new System.EventHandler(this.onGoToNextQuestion);
            // 
            // _prevbutton
            // 
            this._prevbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._prevbutton.Location = new System.Drawing.Point(60, 10);
            this._prevbutton.Name = "_prevbutton";
            this._prevbutton.Size = new System.Drawing.Size(108, 38);
            this._prevbutton.TabIndex = 1;
            this._prevbutton.Text = "PREV";
            this._prevbutton.UseVisualStyleBackColor = true;
            this._prevbutton.Click += new System.EventHandler(this.onGoToPreviousQuestion);
            // 
            // _answerRichTextBox
            // 
            this._answerRichTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._answerRichTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._answerRichTextBox.Location = new System.Drawing.Point(152, 112);
            this._answerRichTextBox.Name = "_answerRichTextBox";
            this._answerRichTextBox.Size = new System.Drawing.Size(459, 64);
            this._answerRichTextBox.TabIndex = 0;
            this._answerRichTextBox.Text = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this._submitBtn, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(111, 275);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(542, 49);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // _submitBtn
            // 
            this._submitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._submitBtn.Location = new System.Drawing.Point(183, 3);
            this._submitBtn.Name = "_submitBtn";
            this._submitBtn.Size = new System.Drawing.Size(174, 43);
            this._submitBtn.TabIndex = 0;
            this._submitBtn.Text = "SUBMIT";
            this._submitBtn.UseVisualStyleBackColor = true;
            this._submitBtn.Click += new System.EventHandler(this.onSubmitExercise);
            // 
            // QAControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QAControl";
            this.Size = new System.Drawing.Size(656, 327);
            this.Load += new System.EventHandler(this.onLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _questiontextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox _answerRichTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button _nextbutton;
        private System.Windows.Forms.Button _prevbutton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button _submitBtn;

    }
}

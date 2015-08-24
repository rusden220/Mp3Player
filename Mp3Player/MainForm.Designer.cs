namespace Mp3Player
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonPlayPause = new System.Windows.Forms.Button();
			this.listViewMusicCollection = new System.Windows.Forms.ListView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPlayPause
			// 
			this.buttonPlayPause.Location = new System.Drawing.Point(12, 12);
			this.buttonPlayPause.Name = "buttonPlayPause";
			this.buttonPlayPause.Size = new System.Drawing.Size(75, 23);
			this.buttonPlayPause.TabIndex = 0;
			this.buttonPlayPause.Text = "Start";
			this.buttonPlayPause.UseVisualStyleBackColor = true;
			this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
			// 
			// listViewMusicCollection
			// 
			this.listViewMusicCollection.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewMusicCollection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewMusicCollection.Location = new System.Drawing.Point(0, 0);
			this.listViewMusicCollection.Name = "listViewMusicCollection";
			this.listViewMusicCollection.Size = new System.Drawing.Size(327, 308);
			this.listViewMusicCollection.TabIndex = 1;
			this.listViewMusicCollection.UseCompatibleStateImageBehavior = false;
			this.listViewMusicCollection.DoubleClick += new System.EventHandler(this.listViewMusicCollection_DoubleClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlayPause);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listViewMusicCollection);
			this.splitContainer1.Size = new System.Drawing.Size(496, 308);
			this.splitContainer1.SplitterDistance = 165;
			this.splitContainer1.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 308);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonPlayPause;
		private System.Windows.Forms.ListView listViewMusicCollection;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}


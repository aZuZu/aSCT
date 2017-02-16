/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 28.5.2016.
 * Time: 23:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace aSCT
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.dajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.otvotiSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.spremiSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.izađiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pomoćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kakoKoristitiProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iReciMiNeštoOProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog_Select_Set = new System.Windows.Forms.FolderBrowserDialog();
			this.listBox_Files = new System.Windows.Forms.ListBox();
			this.listBox_File_Object_List = new System.Windows.Forms.ListBox();
			this.label_Path = new System.Windows.Forms.Label();
			this.label_Info = new System.Windows.Forms.Label();
			this.treeView_KORG_Set = new System.Windows.Forms.TreeView();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.dajToolStripMenuItem,
									this.pomoćToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(747, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip_Main_Menu";
			// 
			// dajToolStripMenuItem
			// 
			this.dajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.otvotiSetToolStripMenuItem,
									this.spremiSetToolStripMenuItem,
									this.izađiToolStripMenuItem});
			this.dajToolStripMenuItem.Name = "dajToolStripMenuItem";
			this.dajToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.dajToolStripMenuItem.Text = "Daj ...";
			// 
			// otvotiSetToolStripMenuItem
			// 
			this.otvotiSetToolStripMenuItem.Name = "otvotiSetToolStripMenuItem";
			this.otvotiSetToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.otvotiSetToolStripMenuItem.Text = "otvori set...";
			this.otvotiSetToolStripMenuItem.Click += new System.EventHandler(this.OtvoriSetToolStripMenuItemClick);
			// 
			// spremiSetToolStripMenuItem
			// 
			this.spremiSetToolStripMenuItem.Name = "spremiSetToolStripMenuItem";
			this.spremiSetToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.spremiSetToolStripMenuItem.Text = "spremi set...";
			// 
			// izađiToolStripMenuItem
			// 
			this.izađiToolStripMenuItem.Name = "izađiToolStripMenuItem";
			this.izađiToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.izađiToolStripMenuItem.Text = "izađi";
			// 
			// pomoćToolStripMenuItem
			// 
			this.pomoćToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.kakoKoristitiProgramToolStripMenuItem,
									this.iReciMiNeštoOProgramuToolStripMenuItem});
			this.pomoćToolStripMenuItem.Name = "pomoćToolStripMenuItem";
			this.pomoćToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.pomoćToolStripMenuItem.Text = "Pomozi mi ...";
			// 
			// kakoKoristitiProgramToolStripMenuItem
			// 
			this.kakoKoristitiProgramToolStripMenuItem.Name = "kakoKoristitiProgramToolStripMenuItem";
			this.kakoKoristitiProgramToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.kakoKoristitiProgramToolStripMenuItem.Text = "kako koristiti program ...";
			// 
			// iReciMiNeštoOProgramuToolStripMenuItem
			// 
			this.iReciMiNeštoOProgramuToolStripMenuItem.Name = "iReciMiNeštoOProgramuToolStripMenuItem";
			this.iReciMiNeštoOProgramuToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.iReciMiNeštoOProgramuToolStripMenuItem.Text = "i reci mi nešto o programu";
			// 
			// listBox_Files
			// 
			this.listBox_Files.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBox_Files.FormattingEnabled = true;
			this.listBox_Files.ItemHeight = 16;
			this.listBox_Files.Location = new System.Drawing.Point(223, 58);
			this.listBox_Files.Name = "listBox_Files";
			this.listBox_Files.Size = new System.Drawing.Size(236, 180);
			this.listBox_Files.TabIndex = 2;
			this.listBox_Files.DoubleClick += new System.EventHandler(this.ListBox_FilesDoubleClick);
			// 
			// listBox_File_Object_List
			// 
			this.listBox_File_Object_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBox_File_Object_List.FormattingEnabled = true;
			this.listBox_File_Object_List.ItemHeight = 16;
			this.listBox_File_Object_List.Location = new System.Drawing.Point(465, 58);
			this.listBox_File_Object_List.Name = "listBox_File_Object_List";
			this.listBox_File_Object_List.Size = new System.Drawing.Size(236, 180);
			this.listBox_File_Object_List.TabIndex = 3;
			// 
			// label_Path
			// 
			this.label_Path.AutoSize = true;
			this.label_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_Path.Location = new System.Drawing.Point(12, 241);
			this.label_Path.Name = "label_Path";
			this.label_Path.Size = new System.Drawing.Size(2, 15);
			this.label_Path.TabIndex = 4;
			// 
			// label_Info
			// 
			this.label_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label_Info.Location = new System.Drawing.Point(0, 552);
			this.label_Info.Name = "label_Info";
			this.label_Info.Size = new System.Drawing.Size(444, 17);
			this.label_Info.TabIndex = 6;
			// 
			// treeView_KORG_Set
			// 
			this.treeView_KORG_Set.Location = new System.Drawing.Point(12, 58);
			this.treeView_KORG_Set.Name = "treeView_KORG_Set";
			this.treeView_KORG_Set.Size = new System.Drawing.Size(205, 180);
			this.treeView_KORG_Set.TabIndex = 7;
			this.treeView_KORG_Set.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_KORG_SetNodeMouseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 568);
			this.Controls.Add(this.treeView_KORG_Set);
			this.Controls.Add(this.label_Info);
			this.Controls.Add(this.label_Path);
			this.Controls.Add(this.listBox_File_Object_List);
			this.Controls.Add(this.listBox_Files);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "aZuZu KORG PA1X Tool, v1.02.3. (c) aZuZu. 2016.";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TreeView treeView_KORG_Set;
		private System.Windows.Forms.Label label_Info;
		private System.Windows.Forms.Label label_Path;
		private System.Windows.Forms.ListBox listBox_File_Object_List;
		private System.Windows.Forms.ListBox listBox_Files;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Select_Set;
		private System.Windows.Forms.ToolStripMenuItem iReciMiNeštoOProgramuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kakoKoristitiProgramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pomoćToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem izađiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem spremiSetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem otvotiSetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dajToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		

	}
}

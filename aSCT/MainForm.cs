/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 28.5.2016.
 * Time: 23:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace aSCT
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public static KORG_PA1X KORG = new KORG_PA1X();
    	public string KORG_Set_Path = string.Empty;
    	
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public static void Map_Folder(DirectoryInfo DI, TreeNodeCollection TNC)
		{
			TreeNode Current_Node = TNC.Add(DI.Name);
			Current_Node.Tag = DI.FullName;
			foreach(DirectoryInfo SubFolder in DI.GetDirectories())
			{
				if (SubFolder.Exists)
				{
					Map_Folder(SubFolder, Current_Node.Nodes);
				}
			}
		}
        void OtvoriSetToolStripMenuItemClick(object sender, EventArgs e)
		{
			folderBrowserDialog_Select_Set.ShowDialog();
			string Selected_Folder = folderBrowserDialog_Select_Set.SelectedPath;
			if (Selected_Folder != string.Empty)
			{
				treeView_KORG_Set.Nodes.Clear();
				DirectoryInfo Start_Folder = new DirectoryInfo(Selected_Folder);
				Map_Folder(Start_Folder, treeView_KORG_Set.Nodes);
			}
			for (int idx = 0; idx < treeView_KORG_Set.Nodes.Count; idx++)
			{
				Directory.CreateDirectory(KORG_PA1X.Program_Project_Folder + "\\" + treeView_KORG_Set.Nodes[idx].FullPath);
			}
		}
		void ListBox_FilesDoubleClick(object sender, EventArgs e)
		{
			KORG.KORG_Get_Data(treeView_KORG_Set.SelectedNode.Tag.ToString() + "\\" + listBox_Files.SelectedItem.ToString(), treeView_KORG_Set.SelectedNode.FullPath);
			listBox_File_Object_List.Items.Clear();
			foreach ( string Object_Item in KORG_PA1X.Menu_Items)
			{
				listBox_File_Object_List.Items.Add(Object_Item.Split('_')[2]);
			}
		}
		void TreeView_KORG_SetNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if ( e.Node.Level >= 0 )
			{
				listBox_Files.Items.Clear();
				
				foreach (string File in Directory.GetFiles(e.Node.Tag.ToString() ))
				{
					listBox_Files.Items.Add(Path.GetFileName(File));
				}
				label_Path.Text = e.Node.Tag.ToString();
			}

		}
	}
}

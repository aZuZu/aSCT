/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 29.5.2016.
 * Time: 0:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace aSCT
{
	/// <summary>
	/// Description of KORG_PA1X.
	/// </summary>
	public class KORG_PA1X
	{
		public static string Program_Folder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
		public static string Program_Project_Folder = Program_Folder + "\\Project";

		public static string GLOBAL = Program_Project_Folder + "\\GLOBAL";
		public static string MULTISMP = Program_Project_Folder + "\\MULTISMP";
		public static string PAD = Program_Project_Folder + "\\PAD";
		public static string PCM = Program_Project_Folder + "\\PCM";
		public static string PERFORM = Program_Project_Folder + "\\PERFORM";
		public static string SONGBOOK = Program_Project_Folder + "\\SONGBOOK\\SONGDB.SBD";
		public static string SOUND = Program_Project_Folder + "\\SOUND";
		public static string STYLE = Program_Project_Folder + "\\STYLE";
		
		public static string[] Project_Folders = new string[8] { 
															GLOBAL,
															MULTISMP,
															PAD,
															PCM,
															PERFORM,
															SONGBOOK,
															SOUND,
															STYLE
		}; 		
		private static byte[] KORG_File = new byte[] { 0 };
		private static byte[] KORG_Script = new byte[] { 0 };
		private static byte[] KORG_Object_List = new byte[] { 0 };
		
		public static List<string> Menu_Items = new List<string>();
		public static string Valid_FileName( string In_String )
		{
            foreach (char BadChar in Path.GetInvalidFileNameChars())
            {
            	In_String = In_String.Replace(BadChar, ' ').Trim();
            }            
            return In_String;			
		}
		public static string ByteToHex(byte[] In_Bytes)
		{
			return BitConverter.ToString(In_Bytes).Replace("-", string.Empty);
		}
		public static byte[] HexToByte(string In_String)
		{
			byte[] Bytes = new byte[In_String.Length / 2];
			for (int index = 0; index < Bytes.Length; index++)
			{
				Bytes[index] = byte.Parse(In_String.Substring(index * 2, 2).ToString(), NumberStyles.HexNumber);
			}
			return Bytes;
		}
		public static byte[] String2ByteArray( string In_String )
		{
			Encoding ASCII = new ASCIIEncoding();
			return ASCII.GetBytes(In_String);
		}
		public static string ByteArray2String( byte[] In_Bytes )
		{
			Encoding ASCII = new ASCIIEncoding();
			return ASCII.GetString(In_Bytes);
		}
		public static int ByteIndexOf(byte[] Where, byte[] What, int Start)
		{
			bool matched = false;
			for (int index = Start; index <= Where.Length - What.Length; ++index)
			{
				matched = true;
				for (int subIndex = 0; subIndex < What.Length; ++subIndex)
				{
					if (What[subIndex] != Where[index + subIndex])
					{
						matched = false;
						break;
					}
				}
				if (matched)
				{
					return index;
				}
			}
			return -1;
		}
		private static int ByteArray2Integer(byte[] In_Bytes, bool Endianness )
		{
			byte[] Tmp = In_Bytes;
			switch (In_Bytes.Length )
			{
				case 2:
				{
					if ( Endianness )
					{
						Tmp = new byte[2];
						Tmp[0] = In_Bytes[1];
						Tmp[1] = In_Bytes[0];
					}
					return BitConverter.ToInt16(Tmp, 0);
				}
				case 4:
				{
					if ( Endianness )
					{
						Tmp = new byte[4];
						Tmp[0] = In_Bytes[3];
						Tmp[1] = In_Bytes[2];
						Tmp[2] = In_Bytes[1];
						Tmp[3] = In_Bytes[0];
					}
					return BitConverter.ToInt32(Tmp, 0);
				}
			}
			return -1;
		}
		public static void Parse_Object_List(byte[] In_RAW_Data, string Where, string KORG_File)
		{
			TextWriter tw_m = new StreamWriter(Where + "\\" + Path.GetFileNameWithoutExtension(KORG_File) + "_Object_List.lst");
			string[] Menu_Parts = new string[2];
			string Menu_Item = string.Empty;
			byte[] Menu_Chunk = new byte[24];
			int Type = -1;
			int Bank = -1;
			int Index = -1;
			string FileName = string.Empty;
			Menu_Items.Clear();
			for ( int idx = 0; idx < In_RAW_Data.Length; idx += 24 )
			{
				Menu_Chunk = In_RAW_Data.Skip(idx).Take(24).ToArray();
				FileName = Valid_FileName(ByteArray2String(Menu_Chunk.ToArray().Skip(0).Take(18).ToArray()).Trim(new char[] { '\0' }));
				Type = Convert.ToInt16(Menu_Chunk[18]);
				Index = Convert.ToInt16(Menu_Chunk[20]);
                Bank = Convert.ToInt16(Menu_Chunk[22]);
				Menu_Item = Type.ToString().PadLeft(3, '0') + "_" + Bank.ToString().PadLeft(3, '0') + "_" + Valid_FileName(FileName) + "." + Index.ToString().PadLeft(3, '0');
				if (!Menu_Items.Contains(Menu_Item))
				{
					Menu_Items.Add(Menu_Item);
				}
			}
			foreach ( string MItem in Menu_Items.ToArray() )
			{
				tw_m.WriteLine(MItem);
			}
			tw_m.Close();
		}		
		public void KORG_Get_Data(string KORG_File, string KORG_SET_Name)
		{
			byte[] KORG_MFile = File.ReadAllBytes(KORG_File);
			Directory.CreateDirectory(Program_Project_Folder + "\\" + KORG_SET_Name + "\\" + Path.GetFileName(KORG_File));
			string Where = Program_Project_Folder + "\\" + KORG_SET_Name + "\\" + Path.GetFileName(KORG_File);
			List<int> Offsets = new List<int>();
			int Offset = -1;
			int Script_Begin = ByteIndexOf(KORG_MFile, String2ByteArray("KBEG"), 0) + 4;
			int Script_End = ByteIndexOf(KORG_MFile, String2ByteArray("KEND"), 0);
			KORG_Script = KORG_MFile.ToArray().Skip(Script_Begin).Take(Script_End - Script_Begin).ToArray();
			int Part_Size = -1;
			int Object_List_Size = -1;
			int Object_Item = -1;
			byte[] Buffer0 = new byte[] { 0 };
			byte[] Buffer1 = new byte[] { 0 };
			byte[] Buffer2 = new byte[] { 0 };
                        byte[] Buffer3 = new byte[] { 0 };
			string FileName = string.Empty;
			BinaryReader br = new BinaryReader(File.OpenRead(KORG_File), Encoding.ASCII);
			for( int idx = 0; idx < KORG_Script.Length; idx += 4)
			{
				Offset = ByteArray2Integer(KORG_Script.ToArray().Skip(idx).Take(4).ToArray(), true);
				Offsets.Add(Offset);
			}
			br.BaseStream.Seek(Offsets[0], SeekOrigin.Begin);
			Buffer0 = br.ReadBytes(8);
			Object_List_Size = ByteArray2Integer(Buffer0.ToArray().Skip(4).Take(4).ToArray(), true);
			Buffer0 = br.ReadBytes(Object_List_Size);
			for( int Part = 1; Part < Offsets.Count; Part++ )
			{	
				br.BaseStream.Seek(Offsets[Part], SeekOrigin.Begin);
				Buffer1 = br.ReadBytes(8);
				Part_Size = ByteArray2Integer(Buffer1.ToArray().Skip(4).Take(4).ToArray(), true);
				Buffer2 = br.ReadBytes(Part_Size);
				Parse_Object_List(Buffer0, Where, KORG_File);
				Object_Item += 1;
				FileName = Menu_Items[Object_Item].Split('|')[0];
				BinaryWriter bw_i = new BinaryWriter(File.OpenWrite(Where + "\\" + FileName));
				bw_i.Write(Buffer1);
				bw_i.Write(Buffer2);
				bw_i.Close();
			}
		}
	}
}

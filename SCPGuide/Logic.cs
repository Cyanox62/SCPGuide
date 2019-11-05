using System.Collections.Generic;
using System.IO;

namespace SCPGuide
{
	partial class EventHandler
	{
		private static Dictionary<string, string> info = new Dictionary<string, string>();

		private static string infoList = string.Empty;

		public static void LoadInfo()
		{
			info.Clear();
			infoList = string.Empty;
			FileInfo[] files = new DirectoryInfo(Plugin.configLocation).GetFiles("*.txt");
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo file = files[i];
				string infoName = file.Name.Replace(".txt", "").ToLower();
				info.Add(infoName, File.ReadAllText(file.FullName));
				infoList += $"{infoName}{(i != files.Length - 1 ? "\n" : "")}";
			}
		}
	}
}

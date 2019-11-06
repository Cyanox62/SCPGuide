using Smod2.API;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SCPGuide
{
	partial class EventHandler
	{
		private static Dictionary<string, string> info = new Dictionary<string, string>();

		private static string infoList = string.Empty;

		// Configs
		private int lineSplitNum;

		private void LoadConfigs()
		{
			lineSplitNum = instance.GetConfigInt("scpg_message_split_size");
		}

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

		private string TrySplitMessage(Player player, string input, string responseHeader)
		{
			List<string> lines = input.Split(new string[] { "\n" }, System.StringSplitOptions.None).ToList();
			if (lines.Count >= lineSplitNum)
			{
				int part = 1;
				while (lines.Count >= lineSplitNum)
				{
					string temp = string.Empty;
					for (int i = 0; i < lineSplitNum - 1; i++)
					{
						temp += $"{lines[0]}{(i != lineSplitNum - 2 ? "\n" : "")}";
						lines.RemoveAt(0);
					}
					player.SendConsoleMessage($"{responseHeader} [Page {part}]:\n{temp}", "red");
					part++;
				}
				string remain = string.Empty;
				for (int i = 0; i < lines.Count; i++)
				{
					remain += $"{lines[i]}{(i != lines.Count - 1 ? "\n" : "")}";
				}
				return $"{responseHeader} [Page {part}]:\n{remain}";
			}
			else
			{
				return $"{responseHeader}:\n{input}";
			}
		}
	}
}

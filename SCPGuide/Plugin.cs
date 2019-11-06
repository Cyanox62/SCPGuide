using Smod2.Attributes;
using System.IO;

namespace SCPGuide
{
	[PluginDetails(
	author = "Cyanox",
	name = "SCPGuide",
	description = "Allows users to retrieve prewritten information on plugins.",
	id = "cyan.scpg",
	version = "1.0.0",
	SmodMajor = 3,
	SmodMinor = 0,
	SmodRevision = 0
	)]
	public class Plugin : Smod2.Plugin
	{
		public static string configLocation = FileManager.GetAppFolder() + "SCPGuide";

		public override void OnDisable() { }

		public override void OnEnable()
		{
			if (!Directory.Exists(configLocation)) Directory.CreateDirectory(configLocation);
		}

		public override void Register()
		{
			AddEventHandlers(new EventHandler(this));
			AddConfig(new Smod2.Config.ConfigSetting("scpg_message_split_size", 8, true, "If a message contains more than this number of lines it will be split into two messages"));
			AddCommands(new[] { "scpgreload", "scpgr" }, new ReloadCommand());
		}
	}
}

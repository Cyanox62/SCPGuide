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
			AddEventHandlers(new EventHandler());
			AddCommands(new[] { "scpgrefresh", "scpgr" }, new RefreshCommand());
		}
	}
}

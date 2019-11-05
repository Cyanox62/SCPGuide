using Smod2.Commands;

namespace SCPGuide
{
	class ReloadCommand : ICommandHandler
	{
		public string GetCommandDescription()
		{
			return "Reloads the info documents.";
		}

		public string GetUsage()
		{
			return "SCPGRELOAD / SCPGR";
		}

		public string[] OnCall(ICommandSender sender, string[] args)
		{
			EventHandler.LoadInfo();
			return new[] { "Info reloaded." };
		}
	}
}

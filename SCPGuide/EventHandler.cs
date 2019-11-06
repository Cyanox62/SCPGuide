using Smod2.Events;
using Smod2.EventHandlers;
using System.Linq;
using System.Collections.Generic;

namespace SCPGuide
{
	partial class EventHandler : IEventHandlerWaitingForPlayers, IEventHandlerCallCommand
	{
		private Plugin instance;

		public EventHandler(Plugin plugin) => instance = plugin;

		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
		{
			LoadConfigs();
			LoadInfo();
		}

		public void OnCallCommand(PlayerCallCommandEvent ev)
		{
			string[] split = ev.Command.Split(' ');
			if (split[0].ToLower() == "info")
			{
				if (split.Length < 2)
				{
					ev.ReturnMessage = TrySplitMessage(ev.Player, infoList, "Available Infos");
				}
				else if (info.ContainsKey(split[1]))
				{
					ev.ReturnMessage = TrySplitMessage(ev.Player, info[split[1]], $"Info for {split[1]}");
				}
				else
				{
					ev.ReturnMessage = "Invalid info requested, type .info for a list of infos.";
				}
			}
		}
	}
}

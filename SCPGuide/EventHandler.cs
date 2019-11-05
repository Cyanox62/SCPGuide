using Smod2.Events;
using Smod2.EventHandlers;

namespace SCPGuide
{
	partial class EventHandler : IEventHandlerWaitingForPlayers, IEventHandlerCallCommand
	{
		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
		{
			LoadInfo();
		}

		public void OnCallCommand(PlayerCallCommandEvent ev)
		{
			string[] split = ev.Command.Split(' ');
			if (split[0].ToLower() == "info")
			{
				if (split.Length < 2)
				{
					ev.ReturnMessage = $"Available infos:\n{infoList}";// list infos
				}
				else if (info.ContainsKey(split[1]))
				{
					ev.ReturnMessage = $"Info for {split[1]}:\n{info[split[1]]}";
				}
				else
				{
					ev.ReturnMessage = "Invalid info requested, type .info for a list of infos.";
				}
			}
		}
	}
}

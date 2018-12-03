using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SSMS.Hubs
{
  public class DbHub : Hub
  {
    public async Task JoinGroups(string[] groups)
    {
      foreach (var group in groups)
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
    }
    public async Task LeaveGroups(string[] groups)
    {
      foreach (var group in groups)
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
    }
  }
}
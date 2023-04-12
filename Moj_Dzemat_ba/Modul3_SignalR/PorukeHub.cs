using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Example.Modul3_SignalR
{
    public class PorukeHub:Hub
    {
        public async Task ProslijediPoruku(string p)
        {
            await Clients.Others.SendAsync("PosaljiPoruku", p);
        }
    }
}

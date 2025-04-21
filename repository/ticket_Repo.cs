using Library.DataAccess;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class ticket_Repo
    {
        public AppDbContext context = new AppDbContext();
        public async Task<List<Ticket>> GetTicket()
        {
            return (context.Tickets.ToList());
        }
        public async Task<int> PostNewTicket(Ticket ticket)
        {
            var NewTicket = new Ticket()
            {
                IdTicket= ticket.IdTicket,
                IdBook=ticket.IdBook,
                IdUser=ticket.IdUser,
                DataGet=ticket.DataGet,
                DataPost=ticket.DataPost,
                TicketNum=ticket.TicketNum,
            };
            await context.Tickets.AddAsync(NewTicket);
            await context.SaveChangesAsync();
            return ticket.IdTicket;
        }
        public async Task<int> UpdateTicket(Ticket ticket,int Idticket)
        {
            var updateTicket = context.Tickets.Find(Idticket);
            if (updateTicket is null)
            {
                return 0;
            }
            updateTicket.IdTicket = ticket.IdTicket;
            updateTicket.IdBook = ticket.IdBook;
            updateTicket.IdUser = ticket.IdUser;
            updateTicket.DataGet = ticket.DataGet;
            updateTicket.DataPost = ticket.DataPost;
            updateTicket.TicketNum = ticket.TicketNum;
            context.SaveChanges();
            return (Idticket);
        }
        public async Task<int> DeleteTicket(int IdTicket) { await context.Tickets.Where(x => x.IdTicket == IdTicket).ExecuteDeleteAsync(); return (IdTicket); }
    }
}

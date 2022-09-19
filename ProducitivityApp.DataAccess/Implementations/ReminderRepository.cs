using Microsoft.EntityFrameworkCore;
using ProducitivityApp.DataAccess.Interfaces;
using ProductivityApp.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace ProducitivityApp.DataAccess.Implementations
{
    public class ReminderRepository : IReminderRepository
    {

        private readonly ProductivityAppDbContext _dbContext;


        public ReminderRepository(ProductivityAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Reminder entity)
        {
            _dbContext.Reminders.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Reminder entity)
        {
            _dbContext.Reminders.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Reminder>> GetAll()
        {
            return await _dbContext.Reminders
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Reminder> GetById(int id)
        {
            return await _dbContext.Reminders
                .Include(x => x.User)
                .SingleOrDefaultAsync(s => s.ReminderId == id);
        }

        public async Task Update(Reminder entity)
        {
            _dbContext.Reminders.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

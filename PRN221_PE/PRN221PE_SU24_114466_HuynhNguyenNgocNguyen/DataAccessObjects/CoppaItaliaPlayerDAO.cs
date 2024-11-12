using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CoppaItaliaPlayerDAO
    {
        private readonly CoppaItalia2024DbContext _context;
        private static CoppaItaliaPlayerDAO instance = null;

        private CoppaItaliaPlayerDAO()
        {
            _context = new CoppaItalia2024DbContext();
        }
        public static CoppaItaliaPlayerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new CoppaItaliaPlayerDAO();
                }
                return instance;
            }
        }
        public async Task<List<CoppaItaliaPlayer>> GetList()
        {
            return await _context.CoppaItaliaPlayers.Include(x => x.CoppaItaliaClub).ToListAsync();
        }
        public class CoppaItaliaPlayerResponse
        {
            public List<CoppaItaliaPlayer> CoppaItaliaPlayers { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }
        public async Task<CoppaItaliaPlayerResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.CoppaItaliaPlayers.Include(x => x.CoppaItaliaClub).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.InternationalCareer.ToLower().Contains(searchTerm.ToLower()) || x.Birthday.ToString().Contains(searchTerm.ToLower()));
            }

            int count = await query.CountAsync(); //11
            int totalPages = (int)Math.Ceiling(count / (double)pageSize); //3

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new CoppaItaliaPlayerResponse
            {
                CoppaItaliaPlayers = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }
        public async Task<CoppaItaliaPlayer> GetCoppaItaliaPlayerById(string id)
        {
            return await _context.CoppaItaliaPlayers.Include(x => x.CoppaItaliaClub).FirstOrDefaultAsync(m => m.CoppaItaliaPlayerId == id);
        }

        public async Task AddPlayer(CoppaItaliaPlayer coppaItaliaPlayer)
        {
            try
            {
                var existingPlayer = await GetCoppaItaliaPlayerById(coppaItaliaPlayer.CoppaItaliaPlayerId);
                if (existingPlayer != null)
                {
                    throw new Exception("Art already exists");
                }
                _context.CoppaItaliaPlayers.Add(coppaItaliaPlayer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdatePlayer(CoppaItaliaPlayer coppaItaliaPlayer)
        {
            try
            {
                var existingPlayer = await GetCoppaItaliaPlayerById(coppaItaliaPlayer.CoppaItaliaPlayerId);
                if (existingPlayer == null)
                {
                    throw new Exception("Does not exist");
                }

                existingPlayer.FullName = coppaItaliaPlayer.FullName;
                existingPlayer.Position = coppaItaliaPlayer.Position;
                existingPlayer.Birthday = coppaItaliaPlayer.Birthday;
                existingPlayer.InternationalCareer = coppaItaliaPlayer.InternationalCareer;
                existingPlayer.StyleOfPlay = coppaItaliaPlayer.StyleOfPlay;

                var coppaItaliaClub = await _context.CoppaItaliaClubs.FirstOrDefaultAsync(s => s.CoppaItaliaClubId == coppaItaliaPlayer.CoppaItaliaClubId);
                if (coppaItaliaClub == null)
                {
                    throw new Exception("CoppaItaliaClub does not exist");
                }
                existingPlayer.CoppaItaliaClubId = coppaItaliaPlayer.CoppaItaliaClubId;

                _context.CoppaItaliaPlayers.Update(existingPlayer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeletePlayer(string id)
        {
            try
            {
                var existPlayer = _context.CoppaItaliaPlayers.FirstOrDefault(m => m.CoppaItaliaPlayerId == id);
                if (existPlayer == null)
                {
                    throw new Exception("Art not found");
                }
                _context.CoppaItaliaPlayers.Remove(existPlayer);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<CoppaItaliaClub>> GetCoppaItaliaClubs()
        {
            return await _context.CoppaItaliaClubs.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Pagination<T>
    {

        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public IList<T>? Result { get; set; }
        public Pagination(int totalPage, int currentPage, IList<T>? src)
        {
            TotalPage = totalPage;
            CurrentPage = currentPage;
            Result = src;
        }

        public static async Task<Pagination<T>> Create(IQueryable<T> datas, int currentPage, int pageSize, int totalItems)
        {
            var items = await datas.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>((int)Math.Ceiling(totalItems / (double)pageSize), currentPage, items);
        }
    }
}

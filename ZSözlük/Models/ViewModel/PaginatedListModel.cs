using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Models.ViewModel
{
    public class PaginatedListModel<T>: List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedListModel(IEnumerable<T> items, int count, int pageIndex, int pageSize) //list --> IEnumerable olarak değişti..
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageIndex);
            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static async Task<PaginatedListModel<T>> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count();   //CountAsync();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(); //ToListAsync();
            return new PaginatedListModel<T>(items, count, pageIndex, pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Comments.Application.Models.Shared
{
    public class PagedList<T>
    {
        public IEnumerable<T> Data { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set;  }
        public int PageSize { get; set; }
        
        public PagedList(IEnumerable<T> data, int totalCount, int currentPage, int pageSize)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;

            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    
        public static PagedList<T> ToPagedModel(IEnumerable<T> data, int totalCount, int currentPage, int pageSize)
        {
            var res = data
                .Skip(pageSize * (currentPage - 1))
                .Take(pageSize);
        
            return new PagedList<T>(res, totalCount, currentPage, pageSize);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection.Infrastructure
{
    public class PaginatedList<T> : List<T>
    {
        private readonly int _pageIndex;
        private readonly int _pageSize;
        private readonly int _totalCount;
        private readonly int _totalPages;

        public PaginatedList(IQueryable<T> source, int pageIndex = 0, int pageSize = 12)
        {
            _pageIndex = pageIndex;
            _pageSize = pageSize;
            _totalCount = source.Count();
            _totalPages = (int)Math.Ceiling(_totalCount / (double)_pageSize);

            AddRange(source.Skip(_pageIndex * _pageSize).Take(_pageSize));
        }

        public bool HasPreviousPage()
        {
            return _pageIndex > 0;
        }

        public bool HasNextPage()
        {
            return (_pageIndex + 1 < _totalPages);
        }

        public int TotalPages()
        {
            return _totalPages;
        }
    }
}

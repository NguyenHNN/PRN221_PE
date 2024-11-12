namespace OilPaintingArt_LeXuanPhuoc.Utils
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        
        public PaginatedList(List<T> items, int pageIndex, int totalPage)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            this.AddRange(items);
        }

        public static PaginatedList<T> Paginate(IEnumerable<T> sources, int pageIndex, int pageSize)
        {
            int totalPage = (int)Math.Ceiling(sources.Count() / (double)pageSize);

            if (pageIndex < 0 || pageIndex > totalPage) pageIndex = 1;


            var items = sources.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedList<T>(items, pageIndex, totalPage);
        }
    }
}

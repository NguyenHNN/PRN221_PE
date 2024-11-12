namespace Euro2024DB_LeXuanPhuoc.Pages
{
    public class PagingHelper<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public PagingHelper(List<T> items, int pageIndex, int totalPage)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            this.AddRange(items);
        }

        public static PagingHelper<T> Paging(IEnumerable<T> sources, int pageIndex, int pageSize)
        {
            int totalPage = (int)Math.Ceiling(sources.Count() / (double)pageSize);

            if (pageIndex < 0 || pageIndex > totalPage) pageIndex = 1;


            var items = sources.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagingHelper<T>(items, pageIndex, totalPage);
        }
    }
}

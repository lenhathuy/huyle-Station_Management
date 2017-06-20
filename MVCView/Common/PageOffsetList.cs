using System.Collections.Generic;
using System.ComponentModel;

namespace MVCView.Common
{
    public class PageOffsetList : IListSource
    {
        public bool ContainsListCollection
        {
            get;
            protected set;
        }

        private int _totalRecords = 0;
        private int _pageSize = 0;

        public PageOffsetList(int pageSize, int total)
        {
            _totalRecords = total;
            this._pageSize = pageSize;
        }
        public System.Collections.IList GetList()
        {
            // Return a list of page offsets based on "totalRecords" and "pageSize"   
            var pageOffsets = new List<int>();
            for (int offset = 0; offset <= _totalRecords; offset = offset + _pageSize)
            {
                pageOffsets.Add(offset);
            }
            return pageOffsets;
        }
    }
}

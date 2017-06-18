using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCModal
{
    class Region
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private String tenKV;

        public String TenKV
        {
            get { return tenKV; }
            set { tenKV = value; }
        }
        private int order;

        public int Order
        {
            get { return order; }
            set { order = value; }
        }




    }
}

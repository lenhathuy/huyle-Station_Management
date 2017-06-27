using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCView.ViewModel
{
    public class DeviceViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Serial { get; set; }


        public DateTime ReceiptDate { get; set; }

        public DateTime SetupDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

    }
}

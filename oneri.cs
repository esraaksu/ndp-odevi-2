using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kütüphane
{
    class oneri
    {

        //ayın kitabı ve yılın kitabı gibi önerileri göstermek için oluşturulan class
        public string sıra { get; set; }

        public string kitap { get; set; }

        public string yazar { get; set; }

        public string yayınevi { get; set; }

        public string sayfa { get; set; }

        public string sıragetir()
        {
            return sıra;
        }

    }
}

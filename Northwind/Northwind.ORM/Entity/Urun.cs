using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ORM.Entity
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal BirimFİyati { get; set; }
        public short HedefStokDuzeyi { get; set; }
        public int KategoriID { get; set; }
        public int TedarikciID { get; set; }
        public string BirimdekiMiktar { get; set; }
        public short YeniSatis { get; set; }
        public short EnAzYenidenSatisMikatari { get; set; }
        public bool Sonlandi { get; set; }
    }
}

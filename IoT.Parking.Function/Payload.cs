using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Parking.Function
{

    public class Rootobject
    {
        public Deveui_Uplink DevEUI_uplink { get; set; }
    }

    public class Deveui_Uplink
    {
        public DateTime Time { get; set; }
        public string DevEUI { get; set; }
        public string FPort { get; set; }
        public string FCntUp { get; set; }
        public string ADRbit { get; set; }
        public string MType { get; set; }
        public string FCntDn { get; set; }
        public string payload_hex { get; set; }
        public string mic_hex { get; set; }
        public string Lrcid { get; set; }
        public string LrrRSSI { get; set; }
        public string LrrSNR { get; set; }
        public string SpFact { get; set; }
        public string SubBand { get; set; }
        public string Channel { get; set; }
        public string DevLrrCnt { get; set; }
        public string Lrrid { get; set; }
        public string LrrLAT { get; set; }
        public string LrrLON { get; set; }
        public Lrrs Lrrs { get; set; }
        public string CustomerID { get; set; }
        public Customerdata CustomerData { get; set; }
        public string ModelCfg { get; set; }
        public string AppSKey { get; set; }
    }

    public class Lrrs
    {
        public Lrr[] Lrr { get; set; }
    }

    public class Lrr
    {
        public string Lrrid { get; set; }
        public string Chain { get; set; }
        public string LrrRSSI { get; set; }
        public string LrrSNR { get; set; }
        public string LrrESP { get; set; }
    }

    public class Customerdata
    {
        public Alr alr { get; set; }
    }

    public class Alr
    {
        public string pro { get; set; }
        public string ver { get; set; }
    }

}

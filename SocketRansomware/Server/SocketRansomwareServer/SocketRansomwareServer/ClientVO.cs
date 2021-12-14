using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketRansomwareServer
{
    class ClientVO
    {
        private String mac;
        private String ip;
        private String infectionTime;
        private bool isPayment;

        public void setMac(String mac)
        {
            this.mac = mac;
        }

        public String getMac() { return this.mac; }

        public void setIp(String ip) { this.ip = ip; }
        public String getIp() { return this.ip; }
        public void setInfectionTime(String infectionTime) { this.infectionTime = infectionTime; }
        public String getInfectionTime() { return this.infectionTime; }
        public void setIsPayment(bool isPayment) { this.isPayment = isPayment; }
        public bool getIsPayment() { return this.isPayment; }
    }
}

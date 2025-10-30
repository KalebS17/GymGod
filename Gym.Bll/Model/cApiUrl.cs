using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Bll.Model
{
    public class cApiUrl
    {

        private String WebApiUrl = "http://localhost:7149/";

        public string getWebApiUrl()
        {
            return WebApiUrl;
        }
    }
}

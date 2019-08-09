using System;
using System.Collections.Generic;
using System.Text;

namespace FurniturefFOB
{
    [Serializable]
     public class parameter
    {
         public string parmName { get; set; }
         public string parmValue { get; set; }
       public parameter(string name,string value)
        {
            this.parmName = name;
            this.parmValue = value;
        }
        public parameter()
        {
            this.parmName = "";
            this.parmValue = "";
        }


    }
}

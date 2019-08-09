using System;

namespace FurniturefFOB
{
    [Serializable]
    public class Parameter
    {
        public string name { get; set; }
        public string value { get; set; }
        public Parameter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter()
        {
            this.name = "";
            this.value = "";
        }


    }
}

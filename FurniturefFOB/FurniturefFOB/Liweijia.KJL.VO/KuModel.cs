using System.Collections.Generic;

namespace FurniturefFOB
{
    public class KuModel
    {
        public int orderType { get; set; }
        public string holeGroup { get; set; }//组件单独出孔的标志
        public int modelTypeId { get; set; }
        public string obsBrandGoodId { get; set; }
        public string modelName { get; set; }
        public string modelNumber { get; set; }
        public string modelAvailable { get; set; }
        public string customCode { get; set; }
        public string obsModelAccountId { get; set; }
        public bool needQuotation { get; set; }
        public bool displayInCostList { get; set; }
        public string textureName { get; set; }
        public string textureBrandGoodCode { get; set; }
        public bool textureAvailable { get; set; }
        public string obsTextureAccountId { get; set; }
        public List<Parameter> parameters { get; set; }
        public Position absPosition { get; set; }//计算孔位的坐标
        public Position ImosPosition { get; set; }//imos插入的坐标
        public Rotation absRotation { get; set; }
        public string id { get; set; }
        public string parentId { get; set; }
        public Caul caulModel { get; set; }
        public int LevelSeq { get; set; }
        public string newCode { get; set; }
        public Position boxPostion { get; set; }
        public string holeStart { get; set; }
        public double holeFx { get; set; }

        public bool isDoor()
        {
            bool rst = false;
            foreach (Parameter p in this.parameters)
            {
                if (p.name == "KMFX")
                {
                    rst = false;
                    return rst;
                }
            }
            return rst;
        }
    }
}

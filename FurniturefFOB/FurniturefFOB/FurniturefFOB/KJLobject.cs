using System;
using System.Collections.Generic;
using System.Text;

namespace FurniturefFOB
{
  public class KJLobject
    {
        public int OrderType { get; set; }
        public string HoleGroup { get; set; }//组件单独出孔的标志
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
        public List<parameter> parameters { get; set; }
        public absPostion absP { get; set; }
        public absRotation absR { get; set; }
        public string id { get; set; }
        public string parentid { get; set; }
        public CaulModel caulModel { get; set; }
        public int LevelSeq { get; set; }
        public string newCode { get; set; }
        public absPostion boxPostion { get; set; }
        public string holeStart { get; set; }
        public double holeFx { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace FurniturefFOB
{
  public  class DALServicer
    {
        public static bool InsertBoard(string code,string cname,string Fx,string hole)
        {
            string sql = "insert into boardinfo(code,cname,boardFX,hole)";
                   sql = sql + "values (@code,@cname,@boardFX,@hole)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@code",OleDbType.VarChar,50,code));
            parameters.Add(new OleDbParameter("@cname", OleDbType.VarChar, 50, cname));
            parameters.Add(new OleDbParameter("@boardFX", OleDbType.VarChar, 50, Fx));
            parameters.Add(new OleDbParameter("@hole", OleDbType.VarChar, 50 ,hole));
           int i= OleHeper.ExecuteSql(sql, parameters.ToArray());
            if(i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateBoard(string code, string cname, string Fx, string hole,int id)
        {
            string sql = "update boardinfo set code={0},cname={1},boardFX={2},hole={3}";
            sql = sql + " where id={4}";
            int i = OleHeper.ExecuteSql(string.Format(sql,"'"+code+ "'",
                "'"+cname+"'", "'"+Fx+"'", "'"+hole+"'", id));
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteBoard(int id)
        {
            string sql = "delete boardinfo ";
            sql = sql + " where id=@id";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@id", id));
            int i = OleHeper.ExecuteSql(sql, parameters.ToArray());
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DataSet getBoard(string codeName)
        {
            string sql = "select * from boardinfo ";
                if(codeName.Trim().Length>0)
            {
                sql=sql+" where code like '*" 
                    +codeName+ "*' + or code like '*" +codeName + "*'";
            }
            return OleHeper.Query(sql);
        }
    }   
}

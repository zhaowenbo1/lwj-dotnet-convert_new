using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace FurniturefFOB
{
    public class ApplicationInitbs
    {
        public string GetNetDateTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = (WebResponse)request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                { if (h == "Date") { datetime = headerCollection[h]; } }
                return datetime;
            }
            catch (Exception) { return datetime; }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }
        //public  string Encryption(string express)
        //{
        //    CspParameters param = new CspParameters();
        //    param.KeyContainerName = "oa_erp_wuzhujiaozhu";
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
        //    {
        //        byte[] plaindata = Encoding.Default.GetBytes(express);
        //        byte[] encryptdata = rsa.Encrypt(plaindata, false);
        //        return Convert.ToBase64String(encryptdata);
        //    }
        //}

        public string Decrypt(string ciphertext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "oa_erp_wuzhujiaozhu";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
        }
        public int Applicatbs()
        {
            DateTime date1 = DateTime.Now;
            string filename = System.IO.Directory.GetCurrentDirectory() + "\\licenses";
            //File.WriteAllText(filename, Encryption1(date1.AddDays(15).ToString(), new Random()));
            DateTime date2 = DateTime.Parse(Decrypt1(File.ReadAllText(filename, System.Text.Encoding.UTF8)));
            File.ReadAllText(filename);
            TimeSpan ts = date2 - date1;
            return ts.Days;
        }
        static public string Encryption1(string str, Random R)
        {
            string md1, md2, pwd = "";
            string[] str_t = new string[255];
            int l1, l2;
            for (int i = 0; i < str.Length; i++)
            {
                l1 = R.Next(0, 256);
                md1 = l1.ToString("X");
                if (md1.Length == 1) { md1 = "0" + md1; }

                str_t[i] = str.Substring(i, 1);
                System.Text.ASCIIEncoding AsciiEncoding = new System.Text.ASCIIEncoding();
                l2 = (int)AsciiEncoding.GetBytes(str_t[i])[0];
                md2 = (l1 ^ l2).ToString("X");
                if (md2.Length == 1) { md2 = "0" + md2; }
                pwd = pwd + md1 + md2;
            }
            return pwd;
        }

        static public string Decrypt1(string str)
        {
            string pwd = "";
            int xl;
            if (str.Length % 4 == 0)
            {
                xl = str.Length / 4;
                string md1, md2;
                int l1, l2;
                for (int i = 0; i < xl; i++)
                {
                    md1 = str.Substring(i * 4, 2);
                    md2 = str.Substring(i * 4 + 2, 2);
                    l1 = int.Parse(md1, System.Globalization.NumberStyles.AllowHexSpecifier);
                    l2 = int.Parse(md2, System.Globalization.NumberStyles.AllowHexSpecifier);
                    System.Text.ASCIIEncoding AsciiEncoding = new System.Text.ASCIIEncoding();
                    byte[] byteArray = new byte[] { (byte)(l1 ^ l2) };
                    md1 = AsciiEncoding.GetString(byteArray);
                    pwd = pwd + md1;
                }
            }
            return pwd;
        }
    }
}

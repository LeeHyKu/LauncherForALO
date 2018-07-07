using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Alfhr
{
    class Mojang
    {
        public static String ID;
        public static String PW;
        public static String UUID;
        public static String AT;
        public static String Name;
        public static int Errorcode;
        public static Boolean Login(String Id,String Pw)
        {
            Errorcode = 0;
            String ReqRes;
            Boolean result = false;
            try
            {
                var req = WebRequest.Create("https://authserver.mojang.com/authenticate");
                req.Proxy = null;
                req.Method = "POST";
                req.ContentType = "application/json";
                
                String PostString = "{ \"agent\" : { \"name\" : \"Minecraft\" , \"version\" : 1 }, \"username\" : \"" + Id + "\", \"password\" : \"" + Pw + "\", \"clientToken\" : \"\"}";
                byte[] reqData = Encoding.UTF8.GetBytes(PostString);
                req.ContentLength = reqData.Length;
                using (Stream reqStream = req.GetRequestStream())
                    reqStream.Write(reqData, 0, reqData.Length);

                using (WebResponse res = req.GetResponse())
                using (Stream resSteam = res.GetResponseStream())
                using (StreamReader sr = new StreamReader(resSteam))
                    ReqRes = sr.ReadToEnd();

                dynamic ResData = JObject.Parse(ReqRes);

                String error = ResData.error;
                if(error != null)
                {
                    if(error.Equals("Method Not Allowed"))
                    {
                        Errorcode = 3;
                        return result;
                    } else if (
                        error.Equals("IllegalArgumentException")|
                        error.Equals("ForbiddenOperationException")
                        )
                    {
                        Errorcode = 4;
                        return result;
                    }
                    else
                    {
                        Errorcode = 2;
                        return result;
                    }
                }

                result = true;
                ID = Id;
                PW = Pw;
                AT = ResData.accessToken;
                UUID = ResData.selectedProfile.id;
                Name = ResData.selectedProfile.name;
                return result;

            }
            catch(Exception)
            {
                Errorcode = 1;
                return false;
            }
        }
    }
}

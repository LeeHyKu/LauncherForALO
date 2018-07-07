using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public static async Task<Boolean> Login(String Id, String Pw)
        {
            Errorcode = 0;
            String ReqRes;
            Boolean result = false;
            try
            {
                String uri = "https://authserver.mojang.com/authenticate";
                String PostString = "{ \"agent\" : { \"name\" : \"Minecraft\" , \"version\" : 1 }, \"username\" : \"" + Id + "\", \"password\" : \"" + Pw + "\", \"clientToken\" : \"\"}";

                var req = new HttpClient();
                var content = new StringContent( PostString, Encoding.UTF8, "application/json");
                var reponse = await req.PostAsync(uri, content);
                reponse.EnsureSuccessStatusCode();
                ReqRes = await reponse.Content.ReadAsStringAsync();

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

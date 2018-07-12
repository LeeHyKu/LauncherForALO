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
        public static String Password;
        public static String UUID;
        public static String AccessToken;
        public static String Name;
        public static int Errorcode;
        public static String Error;
        public static async Task<Boolean> Login(String Id, String Pw)
        {
            Errorcode = 0;
            Error = "";
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

                
                if(!(String.IsNullOrEmpty(ResData.error)))
                {
                    String error = ResData.error;
                    Errorcode = 3;
                    Error = error;
                    return false;
                }

                result = true;
                ID = Id;
                Password = Pw;
                AccessToken = ResData.accessToken;
                UUID = ResData.selectedProfile.id;
                Name = ResData.selectedProfile.name;
                return result;

            }
            catch(IOException)
            {
                Errorcode = 1;
                return false;
            }
            catch (Exception)
            {
                Errorcode = 2;
                return false;
            }
        }
    }
}

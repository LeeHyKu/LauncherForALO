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

        public static String InvaildToken;

        public static Task SaveDataAsync()
        {
            return Task.Run(() => SaveData());
        }
        /*public static Task<int> LoadDataAsync()
        {
            return Task.Run(() => LoadData());
        }*/
        private static void SaveData()
        {
            String JsonString =
                "{" +
                    "\"UserData\" : {" +
                        $"\"Name\" : \"{Name}\"," +
                        $"\"ID\" : \"{ID}\"," +
                        $"\"Password\" : \"{Password}\"" +
                    "}," +
                    $"\"UUID\" : \"{UUID}\"," +
                    $"\"AccessToken\" : \"{AccessToken}\"" +
                "}";
            File.WriteAllText("USER.info", JsonString);
        }
        public static async Task<int> LoadDataAsync()
        {
            /*
             * 1:엑세스토큰이 유효한 경우
             * 2:엑세스토큰이 유효하지 않지만 아이디와 비번이 있는경우
             * 3:모두 없는 경우
             */
            int result = 3;
            String JsonString;

            try
            {
                JsonString = File.ReadAllText("USER.info");
            }
            catch (Exception)
            {
                result = 3;
                return result;
            }

            if (!String.IsNullOrEmpty(JsonString))
            {
                dynamic Data = JObject.Parse(JsonString);
                String Token = Data.AccessToken;
                if (await CheckToken(Token))
                {
                    result = 1;
                    try
                    {
                        Name = Data.UserData.Name;
                        ID = Data.UserData.ID;
                        Password = Data.UserData.Password;
                        UUID = Data.UUID;
                        AccessToken = Data.AccessToken;
                    }
                    catch (Exception)
                    {
                        result = 3;
                        return result;
                    }
                }
                else
                {
                    result = 2;
                    try
                    {
                        Name = Data.UserData.Name;
                        ID = Data.UserData.ID;
                        Password = Data.UserData.Password;
                        UUID = Data.UUID;
                        InvaildToken = Data.AccessToken;
                    }
                    catch (Exception)
                    {
                        result = 3;
                        return result;
                    }
                }
            }
            return result;
        }
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
                var content = new StringContent(PostString, Encoding.UTF8, "application/json");
                var reponse = await req.PostAsync(uri, content);
				if(reponse.IsSuccessStatusCode)
				{
					ReqRes = await reponse.Content.ReadAsStringAsync();
					dynamic ResData = JObject.Parse(ReqRes);
					result = true;
					ID = Id;
					Password = Pw;
					AccessToken = ResData.accessToken;
					UUID = ResData.selectedProfile.id;
					Name = ResData.selectedProfile.name;
				}
				else 
				{
					Errorcode = 3;
					Error = "LoginError";
					result = false;
				}
                return result;

            }
            catch(IOException e)
            {
                Errorcode = 1;
				Error = e.Message;
                return false;
            }
            catch (Exception e)
            {
                Errorcode = 2;
				Error = e.Message;
                return false;
            }
        }
        public static async Task<Boolean> CheckToken(String Token)
        {
            bool result = false;
            try
            {
                String uri = "https://authserver.mojang.com/validate";
                String PostString = "{\"accessToken\" : \"" + AccessToken + "\",\"clientToken\" : \"\"}";

                var req = new HttpClient();
                var content = new StringContent(PostString, Encoding.UTF8, "application/json");
                var reponse = await req.PostAsync(uri, content);
                if (reponse.StatusCode.Equals(HttpStatusCode.NoContent))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;

            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public static async Task<Boolean> Refresh()
        {
            String ReqRes;
            Boolean result = false;
            try
            {
                String uri = "https://authserver.mojang.com/refresh";
                String PostString = "{ \"accessToken\" : \"" + InvaildToken + "\", \"clientToken\" : \"\", \"selectedProfile\" : { \"id\" : \""+ UUID + "\",\"name\" : \""+ Name +"\" } }";

                var req = new HttpClient();
                var content = new StringContent(PostString, Encoding.UTF8, "application/json");
                var reponse = await req.PostAsync(uri, content);
                if (reponse.IsSuccessStatusCode)
                {
                    ReqRes = await reponse.Content.ReadAsStringAsync();
                    dynamic ResData = JObject.Parse(ReqRes);
                    result = true;
                    AccessToken = ResData.accessToken;
                    UUID = ResData.selectedProfile.id;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

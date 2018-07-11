using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Alfhr.Control
{
    class Mincraft
    {
        //private static String ClientPath = "C:\\asdf\\DATA";
        private static String Command = $"-server -d64 -da -dsa -Xrs -Xms768M -Xmx2G -XX:NewSize=768M -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -XX:+DisableExplicitGC -Djava.library.path=%appdata%\\.minecraft\\versions\\1.12.2\\1.12.2-natives-59894925878961 -cp %appdata%\\.minecraft\\libraries\\com\\mojang\\netty\\1.6\\netty-1.6.jar;%appdata%\\.minecraft\\libraries\\oshi-project\\oshi-core\\1.1\\oshi-core-1.1.jar;%appdata%\\.minecraft\\libraries\\net\\java\\dev\\jna\\jna\\3.4.0\\jna-3.4.0.jar;%appdata%\\.minecraft\\libraries\\net\\java\\dev\\jna\\platform\\3.4.0\\platform-3.4.0.jar;%appdata%\\.minecraft\\libraries\\com\\ibm\\icu\\icu4j-core-mojang\\51.2\\icu4j-core-mojang-51.2.jar;%appdata%\\.minecraft\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\4.6\\jopt-simple-4.6.jar;%appdata%\\.minecraft\\libraries\\com\\paulscode\\codecjorbis\\20101023\\codecjorbis-20101023.jar;%appdata%\\.minecraft\\libraries\\com\\paulscode\\codecwav\\20101023\\codecwav-20101023.jar;%appdata%\\.minecraft\\libraries\\com\\paulscode\\libraryjavasound\\20101123\\libraryjavasound-20101123.jar;%appdata%\\.minecraft\\libraries\\com\\paulscode\\librarylwjglopenal\\20100824\\librarylwjglopenal-20100824.jar;%appdata%\\.minecraft\\libraries\\com\\paulscode\\soundsystem\\20120107\\soundsystem-20120107.jar;%appdata%\\.minecraft\\libraries\\io\\netty\\netty-all\\4.0.23.Final\\netty-all-4.0.23.Final.jar;%appdata%\\.minecraft\\libraries\\com\\google\\guava\\guava\\17.0\\guava-17.0.jar;%appdata%\\.minecraft\\libraries\\org\\apache\\commons\\commons-lang3\\3.3.2\\commons-lang3-3.3.2.jar;%appdata%\\.minecraft\\libraries\\commons-io\\commons-io\\2.4\\commons-io-2.4.jar;%appdata%\\.minecraft\\libraries\\commons-codec\\commons-codec\\1.9\\commons-codec-1.9.jar;%appdata%\\.minecraft\\libraries\\net\\java\\jinput\\jinput\\2.0.5\\jinput-2.0.5.jar;%appdata%\\.minecraft\\libraries\\net\\java\\jutils\\jutils\\1.0.0\\jutils-1.0.0.jar;%appdata%\\.minecraft\\libraries\\com\\google\\code\\gson\\gson\\2.2.4\\gson-2.2.4.jar;%appdata%\\.minecraft\\libraries\\com\\mojang\\authlib\\1.5.22\\authlib-1.5.22.jar;%appdata%\\.minecraft\\libraries\\com\\mojang\\realms\\1.9.3\\realms-1.9.3.jar;%appdata%\\.minecraft\\libraries\\org\\apache\\commons\\commons-compress\\1.8.1\\commons-compress-1.8.1.jar;%appdata%\\.minecraft\\libraries\\org\\apache\\httpcomponents\\httpclient\\4.3.3\\httpclient-4.3.3.jar;%appdata%\\.minecraft\\libraries\\commons-logging\\commons-logging\\1.1.3\\commons-logging-1.1.3.jar;%appdata%\\.minecraft\\libraries\\org\\apache\\httpcomponents\\httpcore\\4.3.2\\httpcore-4.3.2.jar;%appdata%\\.minecraft\\libraries\\it\\unimi\\dsi\\fastutil\\7.0.12_mojang\\fastutil-7.0.12_mojang.jar;%appdata%\\.minecraft\\libraries\\org\\apache\\logging\\log4j\\log4j-api\\2.0-beta9\\log4j-api-2.0-beta9.jar;%appdata%\\.minecraft\\libraries\\org\\apache\\logging\\log4j\\log4j-core\\2.0-beta9\\log4j-core-2.0-beta9.jar;%appdata%\\.minecraft\\libraries\\org\\lwjgl\\lwjgl\\lwjgl\\2.9.4-nightly-20150209\\lwjgl-2.9.4-nightly-20150209.jar;%appdata%\\.minecraft\\libraries\\org\\lwjgl\\lwjgl\\lwjgl_util\\2.9.4-nightly-20150209\\lwjgl_util-2.9.4-nightly-20150209.jar;%appdata%\\.minecraft\\versions\\1.12.2\\1.12.2.jar net.minecraft.launchwrapper.Launch --username {Mojang.Name} --version 1.12.2 --gameDir %appdata%\\.minecraft --assetsDir %appdata%\\.minecraft\assets --assetIndex 1.12 --uuid {Mojang.UUID} --accessToken {Mojang.AccessToken} --userType legacy --versionType release --nativeLauncherVersion 307 --server ALO.f4m.kr";

        public static Task LaunchAsync()
        {
            return Task.Run(() => Launch());
        }

        public static Task UpdateAsync()
        {
            return Task.Run(() => Update());
        }

        public static Task<bool> ChackLastestVersionAsync()
        {
            return Task.Run(() => LastestChackVersion());
        }

        private static void Launch()
        {
            if (!LastestChackVersion())
            {
                Update();
            }

            ProcessStartInfo Launch = new ProcessStartInfo
            {
                FileName = "C:\\Program Files\\Java\\jre1.8.0_171\\bin\\java.exe",
                Arguments = $"{Command}",
                RedirectStandardOutput = false,
                UseShellExecute = true
            };
            Process.Start(Launch);
        }

        private static void Update()
        {

        }

        private static bool LastestChackVersion()
        {
            return true;
        }
    }
}

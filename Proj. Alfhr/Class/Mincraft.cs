using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Proj.Alfhr.Control
{
    class Mincraft
    {
        //수정 예정
        private static String ClientPath = "DATA";
        private static String ServerPath = "ALO.f4m.kr";
        private static String Command = $"-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump -Xms1024m -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn512M -Djava.library.path={ClientPath}\\natives -cp {ClientPath}\\libraries\\net\\minecraftforge\\forge\\1.12.2-14.23.3.2655\\forge-1.12.2-14.23.3.2655.jar;{ClientPath}\\libraries\\net\\minecraft\\launchwrapper\\1.12\\launchwrapper-1.12.jar;{ClientPath}\\libraries\\org\\ow2\\asm\\asm-all\\5.2\\asm-all-5.2.jar;{ClientPath}\\libraries\\jline\\jline\\2.13\\jline-2.13.jar;{ClientPath}\\libraries\\com\\typesafe\\akka\\akka-actor_2.11\\2.3.3\\akka-actor_2.11-2.3.3.jar;{ClientPath}\\libraries\\com\\typesafe\\config\\1.2.1\\config-1.2.1.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-actors-migration_2.11\\1.1.0\\scala-actors-migration_2.11-1.1.0.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-compiler\\2.11.1\\scala-compiler-2.11.1.jar;{ClientPath}\\libraries\\org\\scala-lang\\plugins\\scala-continuations-library_2.11\\1.0.2\\scala-continuations-library_2.11-1.0.2.jar;{ClientPath}\\libraries\\org\\scala-lang\\plugins\\scala-continuations-plugin_2.11.1\\1.0.2\\scala-continuations-plugin_2.11.1-1.0.2.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-library\\2.11.1\\scala-library-2.11.1.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-parser-combinators_2.11\\1.0.1\\scala-parser-combinators_2.11-1.0.1.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-reflect\\2.11.1\\scala-reflect-2.11.1.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-swing_2.11\\1.0.1\\scala-swing_2.11-1.0.1.jar;{ClientPath}\\libraries\\org\\scala-lang\\scala-xml_2.11\\1.0.2\\scala-xml_2.11-1.0.2.jar;{ClientPath}\\libraries\\lzma\\lzma\\0.0.1\\lzma-0.0.1.jar;{ClientPath}\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\5.0.3\\jopt-simple-5.0.3.jar;{ClientPath}\\libraries\\java3d\\vecmath\\1.5.2\\vecmath-1.5.2.jar;{ClientPath}\\libraries\\net\\sf\\trove4j\\trove4j\\3.0.3\\trove4j-3.0.3.jar;{ClientPath}\\libraries\\net\\minecraftforge\\MercuriusUpdater\\1.12.2\\MercuriusUpdater-1.12.2.jar;{ClientPath}\\libraries\\com\\mojang\\patchy\\1.1\\patchy-1.1.jar;{ClientPath}\\libraries\\oshi-project\\oshi-core\\1.1\\oshi-core-1.1.jar;{ClientPath}\\libraries\\net\\java\\dev\\jna\\jna\\4.4.0\\jna-4.4.0.jar;{ClientPath}\\libraries\\net\\java\\dev\\jna\\platform\\3.4.0\\platform-3.4.0.jar;{ClientPath}\\libraries\\com\\ibm\\icu\\icu4j-core-mojang\\51.2\\icu4j-core-mojang-51.2.jar;{ClientPath}\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\5.0.3\\jopt-simple-5.0.3.jar;{ClientPath}\\libraries\\com\\paulscode\\codecjorbis\\20101023\\codecjorbis-20101023.jar;{ClientPath}\\libraries\\com\\paulscode\\codecwav\\20101023\\codecwav-20101023.jar;{ClientPath}\\libraries\\com\\paulscode\\libraryjavasound\\20101123\\libraryjavasound-20101123.jar;{ClientPath}\\libraries\\com\\paulscode\\librarylwjglopenal\\20100824\\librarylwjglopenal-20100824.jar;{ClientPath}\\libraries\\com\\paulscode\\soundsystem\\20120107\\soundsystem-20120107.jar;{ClientPath}\\libraries\\io\\netty\\netty-all\\4.1.9.Final\\netty-all-4.1.9.Final.jar;{ClientPath}\\libraries\\com\\google\\guava\\guava\\21.0\\guava-21.0.jar;{ClientPath}\\libraries\\org\\apache\\commons\\commons-lang3\\3.5\\commons-lang3-3.5.jar;{ClientPath}\\libraries\\commons-io\\commons-io\\2.5\\commons-io-2.5.jar;{ClientPath}\\libraries\\commons-codec\\commons-codec\\1.10\\commons-codec-1.10.jar;{ClientPath}\\libraries\\net\\java\\jinput\\jinput\\2.0.5\\jinput-2.0.5.jar;{ClientPath}\\libraries\\net\\java\\jutils\\jutils\\1.0.0\\jutils-1.0.0.jar;{ClientPath}\\libraries\\com\\google\\code\\gson\\gson\\2.8.0\\gson-2.8.0.jar;{ClientPath}\\libraries\\com\\mojang\\authlib\\1.5.25\\authlib-1.5.25.jar;{ClientPath}\\libraries\\com\\mojang\\realms\\1.10.17\\realms-1.10.17.jar;{ClientPath}\\libraries\\org\\apache\\commons\\commons-compress\\1.8.1\\commons-compress-1.8.1.jar;{ClientPath}\\libraries\\org\\apache\\httpcomponents\\httpclient\\4.3.3\\httpclient-4.3.3.jar;{ClientPath}\\libraries\\commons-logging\\commons-logging\\1.1.3\\commons-logging-1.1.3.jar;{ClientPath}\\libraries\\org\\apache\\httpcomponents\\httpcore\\4.3.2\\httpcore-4.3.2.jar;{ClientPath}\\libraries\\it\\unimi\\dsi\\fastutil\\7.1.0\\fastutil-7.1.0.jar;{ClientPath}\\libraries\\org\\apache\\logging\\log4j\\log4j-api\\2.8.1\\log4j-api-2.8.1.jar;{ClientPath}\\libraries\\org\\apache\\logging\\log4j\\log4j-core\\2.8.1\\log4j-core-2.8.1.jar;{ClientPath}\\libraries\\org\\lwjgl\\lwjgl\\lwjgl\\2.9.4-nightly-20150209\\lwjgl-2.9.4-nightly-20150209.jar;{ClientPath}\\libraries\\org\\lwjgl\\lwjgl\\lwjgl_util\\2.9.4-nightly-20150209\\lwjgl_util-2.9.4-nightly-20150209.jar;{ClientPath}\\libraries\\com\\mojang\\text2speech\\1.10.3\\text2speech-1.10.3.jar;{ClientPath}\\versions\\1.12.2\\1.12.2.jar net.minecraft.launchwrapper.Launch --username {Mojang.Name} --version 1.12.2 --gameDir \"\"{ClientPath}\"\" --assetsDir \"\"{ClientPath}\\assets\"\" --assetIndex 1.12 --uuid {Mojang.UUID} --accessToken {Mojang.AccessToken} --userProperties {{}} --userType Mojang --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker --versionType Forge --nativeLauncherVersion 307 --server {ServerPath}";

		private static Label DownloadStatusLabel;

        public static Task LaunchAsync(Label StatusLabel)
        {
            return Task.Run(() => Launch(StatusLabel));
        }

        /*public static Task UpdateAsync(Label StatusLabel)
        {
            return Task.Run(() => UpdateAsync(StatusLabel));
        }*/

        public static Task<bool> ChackLastestVersionAsync()
        {
            return Task.Run(() => ChackLastestVersion());
        }

        private static void Launch(Label StatusLabel)
        {
            StatusLabel.Dispatcher.Invoke(new Action(() => { StatusLabel.Content = "실행중..."; }));
			ProcessStartInfo Launch = new ProcessStartInfo
            {
                FileName = $"{ClientPath}\\runtime\\bin\\java.exe",
                Arguments = $"{Command}",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Minimized
            };
            Process.Start(Launch);
        }

        public static async Task UpdateAsync(Label StatusLabel)
        {
			DownloadStatusLabel = StatusLabel;
			StatusLabel.Dispatcher.Invoke(new Action(() => { StatusLabel.Content = "설치중..."; }));
			String TempFilePath = Path.GetTempFileName();
            var request = new WebClient();
            request.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            await request.DownloadFileTaskAsync(new Uri(""), TempFilePath);
            try
            {
                Directory.Delete(ClientPath,true);
                Directory.CreateDirectory(ClientPath);
            }
            catch (Exception)
            {
            }
            StatusLabel.Dispatcher.Invoke(new Action(() => { StatusLabel.Content = "압축을 푸는중..."; }));
            ZipFile.ExtractToDirectory(TempFilePath, ClientPath);
            File.Delete(TempFilePath);
        }

		private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
		{
			DownloadStatusLabel.Dispatcher.Invoke(new Action(() => { DownloadStatusLabel.Content = $" {e.BytesReceived}바이트 받음,총 {e.TotalBytesToReceive}바이트,{e.ProgressPercentage}% 완료"; }));
		}

		private static bool ChackLastestVersion()
        {
            if (!Directory.Exists(ClientPath))
            {
                return false;
            }
            if (!File.Exists($"{ClientPath}\\Vers.ion"))
            {
                return false;
            }
            String TempFilePath = Path.GetTempFileName();
            var request = new WebClient();
            request.DownloadFile("", TempFilePath);
            String nowVersion = File.ReadAllText("DATA\\Vers.ion");
            String lastVersion = File.ReadAllText(TempFilePath);
            File.Delete(TempFilePath);
            if (!nowVersion.Equals(lastVersion))
            {
                return false;
            }
            return true;
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

namespace UnityHttp.Editor
{
    public static class UpgradeNetCore
    {
        private static Dictionary<string, string> Packages = new Dictionary<string, string>()
        {
            {"Microsoft.NETCore.UniversalWindowsPlatform", "5.4.2"}
        };

        [PostProcessBuild(2)]
        public static void InstallPackages(BuildTarget target, string pathToBuild)
        {
            if (target != BuildTarget.WSAPlayer)
            {
                return;
            }

            var nugetJsons = Directory.GetFiles(pathToBuild, "project.json", SearchOption.AllDirectories);
            foreach (var file in nugetJsons)
            {
                string json = File.ReadAllText(file);
                var jsonObj = (JObject) JsonConvert.DeserializeObject(json);
                var deps = (JObject) jsonObj["dependencies"];

                foreach (var package in Packages)
                {
                    deps[package.Key] = package.Value;
                }

                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(file, output);
            }
        }
    }
}
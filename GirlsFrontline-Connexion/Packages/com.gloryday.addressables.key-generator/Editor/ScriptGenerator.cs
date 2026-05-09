#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GloryDay.Addressables
{
    public static class ScriptGenerator
    {
        private static readonly StringBuilder Builder = new StringBuilder();

        public static void Generate(AddressableAssetMetadata metadata)
        {
            var data = SettingsPopUpWindow.ReadUserDataFromDisk();

            // If the directory does not exist on the path, create it.
            var path = $"{Application.dataPath}/{data.Path}/{data.ClassName}.cs";
            if (Directory.Exists(data.Path) == false)
            {
                Directory.CreateDirectory(data.Path);
            }

            var set = new HashSet<string>(metadata.Groups.Values.SelectMany(group => group.Keys));

            Builder.Append("using System.Collections.Generic;\n\n");
            Builder.Append($"namespace {data.Namespace}\n");
            Builder.Append("{\n");
            Builder.Append($"\tpublic static class {data.ClassName}\n");
            Builder.Append("\t{\n");

            metadata.Addresses.Sort();

            var count = metadata.Addresses.Count;
            for (var i = 0; i < count; i++)
            {
                var address = metadata.Addresses[i];
                Builder.Append($"\t\tpublic const string {ToFieldName(address)} = \"{address}\";\n");
            }
            Builder.Append("\t\t\n");

            Builder.Append("\t\tpublic static Dictionary<string, Dictionary<string, HashSet<string>>> Groups = new ()\n");
            Builder.Append("\t\t{\n");

            foreach (var group in metadata.Groups.OrderBy(group => group.Key))
            {
                Builder.Append("\t\t\t{\n");
                Builder.Append($"\t\t\t\t\"{group.Key}\",\n");
                Builder.Append("\t\t\t\tnew Dictionary<string, HashSet<string>>()\n");
                Builder.Append("\t\t\t\t{\n");

                foreach (var label in set.Where(label => metadata.Groups[group.Key].ContainsKey(label) == false).OrderBy(label => label))
                {
                    Builder.Append($"\t\t\t\t\t{{ \"{label}\", new HashSet<string> {{ }} }},\n");
                }

                foreach (var item in metadata.Groups[group.Key].OrderBy(item => item.Key))
                {
                    var value = string.Join(",", item.Value.Select(i => $"\"{i}\""));
                    Builder.Append($"\t\t\t\t\t{{ \"{item.Key}\", new HashSet<string> {{ {value} }} }},\n");
                }

                Builder.Append("\t\t\t\t}\n");
                Builder.Append("\t\t\t},\n");
            }

            Builder.Append("\t\t};\n\n");

            Builder.Append("\t\t#region NESTED STRUCTURE API\n\n");

            Builder.Append("\t\tpublic struct Group\n");
            Builder.Append("\t\t{\n");

            foreach (var key in metadata.Groups.Keys.OrderBy(key => key))
            {
                Builder.Append($"\t\t\tpublic const string {key.Replace(" ", "_")} = \"{key}\";\n");
            }

            Builder.Append("\t\t}\n\n");

            Builder.Append("\t\tpublic struct Label\n");
            Builder.Append("\t\t{\n");

            foreach (var key in set.OrderBy(key => key))
            {
                Builder.Append($"\t\t\tpublic const string {key.Replace("/", "_")} = \"{key}\";\n");
            }

            Builder.Append("\t\t}\n\n");

            Builder.Append("\t\t#endregion\n");

            Builder.Append("\t}\n");
            Builder.Append("}");

            var contents = Builder.ToString();
            File.WriteAllText(path, contents);

            Builder.Clear();
        }

        public static string ToFieldName(string path)
        {
            var extension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension) == false)
            {
                extension = char.ToUpper(extension[1]) + extension.Substring(2);
            }

            var name = Path.ChangeExtension(path, null);
            name = Regex.Replace(name, @"[^\w]", "_");
            name = Regex.Replace(name, "_+", "_");
            name = name.Trim('_');

            if (char.IsDigit(name[0]))
            {
                name = "_" + name;
            }

            return name + "_" + extension;
        }
    }
}

#endif

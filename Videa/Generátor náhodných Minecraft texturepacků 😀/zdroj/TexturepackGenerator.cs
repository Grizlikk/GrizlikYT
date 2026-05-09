using Minecraft_random_texturepacks.custom_windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Controls;

namespace Minecraft_random_texturepacks
{
    public struct FolderWithTexturesInArchive
    {
        public string Name { get; set; }
        public uint NumberOfTextures { get; set; }
        public FolderWithTexturesInArchive(string name, uint numberOfEntries)
        {
            Name = name;
            NumberOfTextures = numberOfEntries;
        }
    }
    internal class TexturepackGenerator
    {
        private const string ICON_NAME = "pack.png";
        private const string MCMETA_FILE_NAME = "pack.mcmeta";
        private const string TEXTURES_PATH = "assets/minecraft/textures";
        private readonly Uri PACK_FORMATS_URI = new Uri("https://cdn.jsdelivr.net/npm/pack-format");
        public readonly FileInfo SourceFile;

        private ZipArchive sourceArchive;
        private Stream sourceArchiveStream;

        private Task<string> getPackFormatTask;

        public TexturepackGenerator(FileInfo sourceFile, bool loadToMemory = true)
        {
            SourceFile = sourceFile;

            if (loadToMemory)
            {
                sourceArchiveStream = new MemoryStream(File.ReadAllBytes(SourceFile.FullName));
            }
            else
            {
                sourceArchiveStream = new FileStream(SourceFile.FullName, FileMode.Open);
            }

            sourceArchive = new ZipArchive(sourceArchiveStream, ZipArchiveMode.Read);
            getPackFormatTask = GetPackFormatAsync();
        }

        public List<FolderWithTexturesInArchive> GetFoldersWithTextures()
        {
            Dictionary<string, uint> foldersInTextures = new Dictionary<string, uint>();
            var alternateLookup = foldersInTextures.GetAlternateLookup<ReadOnlySpan<char>>();

            foreach (ZipArchiveEntry entry in sourceArchive.Entries)
            {
                ReadOnlySpan<char> entryName = entry.FullName;

                if (!(entryName.StartsWith(TEXTURES_PATH) && entryName.EndsWith(".png"))) continue;

                ReadOnlySpan<char> folderName = entryName.Slice(TEXTURES_PATH.Length + 1, entryName.Slice(TEXTURES_PATH.Length + 1).IndexOf('/'));

                if (!alternateLookup.ContainsKey(folderName))
                {
                    alternateLookup.TryAdd(folderName, 1);
                }
                else
                {
                    alternateLookup[folderName]++;
                }
            }

            return foldersInTextures.Select(x => new FolderWithTexturesInArchive(x.Key, x.Value)).ToList();
        }

        private List<ZipArchiveEntry>[] GetTexturesToRandomize(string[] foldersWithTexturesToRandomize)
        {
            List<ZipArchiveEntry>[] texturesToRandomize = Enumerable.Range(0, foldersWithTexturesToRandomize.Length).Select(_ => new List<ZipArchiveEntry>()).ToArray();

            foreach (ZipArchiveEntry entry in sourceArchive.Entries)
            {
                if (!(entry.FullName.StartsWith(TEXTURES_PATH, StringComparison.Ordinal) && entry.FullName.EndsWith(".png", StringComparison.Ordinal))) continue;

                for (int i = 0; i < foldersWithTexturesToRandomize.Length; i++)
                {
                    if (entry.FullName.IndexOf(foldersWithTexturesToRandomize[i], TEXTURES_PATH.Length + 1, foldersWithTexturesToRandomize[i].Length, StringComparison.Ordinal) > -1)
                    {
                        texturesToRandomize[i].Add(entry);
                    }
                }
            }

            return texturesToRandomize;
        }

        private (ZipArchiveEntry source, string target)[] RandomizeFileNames(ZipArchiveEntry[] files, byte randomizationPercentage)
        {
            Random random = new Random();

            random.Shuffle(files);

            string[] newFileNames = new string[(long)files.Length * randomizationPercentage / 100];
            if (newFileNames.Length <= 1) return Array.Empty<(ZipArchiveEntry, string)>();

            for (int i = 0; i < newFileNames.Length; i++)
            {
                newFileNames[i] = files[i].FullName;
            }

            random.Shuffle(newFileNames);

            return newFileNames.Select((x, i) => (files[i], x)).ToArray();
        }

        public void GenerateRandomTexturepack(string[] foldersWithTexturesToRandomize, DirectoryInfo destinationDirectory, byte randomizationPercentage, string? customFileName = null)
        {
            List<ZipArchiveEntry>[] texturesToRandomize = GetTexturesToRandomize(foldersWithTexturesToRandomize);

            // Randomize textures
            List<(ZipArchiveEntry source, string target)> randomizedTextureNames = new List<(ZipArchiveEntry, string)>();
            foreach (List<ZipArchiveEntry> texturesList in texturesToRandomize)
            {
                randomizedTextureNames.AddRange(RandomizeFileNames(texturesList.ToArray(), randomizationPercentage));
            }

            if (randomizedTextureNames.Count == 0) return;

            // Write textures to archive
            MemoryStream destinationArchiveStream = new MemoryStream();
            ZipArchive destinationArchive = new ZipArchive(destinationArchiveStream, ZipArchiveMode.Create, true);

            foreach ((ZipArchiveEntry source, string target) copyPair in randomizedTextureNames)
            {
                using Stream sourceStream = copyPair.source.Open();
                using Stream destinationStream = destinationArchive.CreateEntry(copyPair.target).Open();

                sourceStream.CopyTo(destinationStream);
            }

            // Add icon
            ZipArchiveEntry icon = GetRandomTexturepackIcon(randomizedTextureNames);
            using (Stream sourceStream = icon.Open())
            {
                using Stream destinationStream = destinationArchive.CreateEntry(ICON_NAME).Open();
                sourceStream.CopyTo(destinationStream);
            }

            // Add pack.mcmeta
            string texturepackDescription = GetRandomTexturepackDescription(randomizedTextureNames);
            string texturepackPackFormat = getPackFormatTask.Result;
            try
            {
                if (texturepackPackFormat == string.Empty) texturepackPackFormat = GetPackFormatFromUser();
            }
            catch (OperationCanceledException) { return; }

            if (texturepackPackFormat != "0")
            {
                using Stream mcmetaFileStream = destinationArchive.CreateEntry(MCMETA_FILE_NAME).Open();

                string data = $"{{\"pack\":{{\"description\":\"{texturepackDescription}\",\"pack_format\":{texturepackPackFormat}}}}}";
                mcmetaFileStream.Write(Encoding.ASCII.GetBytes(data));
            }

            destinationArchive.Dispose();

            // Create file
            if (customFileName == null) customFileName = GetRandomTexturepackName(randomizedTextureNames, destinationDirectory);

            using (Stream fileStream = File.Open(Path.Combine(destinationDirectory.FullName, customFileName), FileMode.CreateNew, FileAccess.Write))
            {
                destinationArchiveStream.Seek(0, SeekOrigin.Begin);
                destinationArchiveStream.CopyTo(fileStream);
            }
            destinationArchiveStream.Dispose();
        }

        private string GetRandomTexturepackName(List<(ZipArchiveEntry source, string target)> randomizedTextures, DirectoryInfo parentDirectory)
        {
            Random random = new Random();
            int names = random.Next(2, 4);
            StringBuilder descriptionBuilder = new StringBuilder();

            for (int repeat = 0; repeat < 10000; repeat++)
            {
                for (int i = 0; i < names; i++)
                {
                    ZipArchiveEntry randomEntry = randomizedTextures[random.Next(randomizedTextures.Count)].source;
                    descriptionBuilder.Append(Path.GetFileNameWithoutExtension(randomEntry.Name));

                    if (i < names - 1) descriptionBuilder.Append(" ");
                }
                descriptionBuilder.Append(".zip");

                string texturepackName = descriptionBuilder.ToString();
                if (!File.Exists(Path.Combine(parentDirectory.FullName, texturepackName))) return texturepackName;
            }

            return Path.GetRandomFileName() + ".zip";
        }
        private ZipArchiveEntry GetRandomTexturepackIcon(List<(ZipArchiveEntry source, string target)> randomizedTextures)
        {
            Random random = new Random();
            return randomizedTextures[random.Next(randomizedTextures.Count)].source;
        }
        private string GetRandomTexturepackDescription(List<(ZipArchiveEntry source, string target)> randomizedTextures)
        {
            Random random = new Random();
            int names = random.Next(2, 8);
            StringBuilder descriptionBuilder = new StringBuilder();

            for (int i = 0; i < names; i++)
            {
                ZipArchiveEntry randomEntry = randomizedTextures[random.Next(randomizedTextures.Count)].source;
                descriptionBuilder.Append(Path.GetFileNameWithoutExtension(randomEntry.Name));

                if (i < names - 1) descriptionBuilder.Append(" ");
            }

            return descriptionBuilder.ToString();
        }

        private async Task<string> GetPackFormatAsync()
        {
            string versionName = Path.GetFileNameWithoutExtension(SourceFile.Name);

            string? result = GetPackFormatFromVersion(versionName);
            if (!string.IsNullOrEmpty(result)) return result;

            result = await GetPackFormatFromJSONAsync(sourceArchive);
            if (!string.IsNullOrEmpty(result)) return result;

            result = await GetPackFormatFromWebAsync(versionName);
            if (!string.IsNullOrEmpty(result)) return result;

            return string.Empty;
        }

        private string? GetPackFormatFromVersion(ReadOnlySpan<char> version)
        {
            if (!version.StartsWith("1.")) return null;

            int beginningIndex = version.IndexOf('.') + 1;
            if (beginningIndex < 0) return null;
            int endIndex = version.Slice(beginningIndex).IndexOf('.');
            if (endIndex < 0) return null;

            if (!byte.TryParse(version.Slice(beginningIndex, endIndex), out byte versionNum)) return null;

            if (versionNum <= 5) return "0";
            if (versionNum <= 8) return "1";
            if (versionNum <= 10) return "2";
            if (versionNum <= 12) return "3";
            if (versionNum <= 14) return "4";
            if (versionNum == 15) return "5";
            if (version is "1.16" || version is "1.16.1") return "5";
            if (versionNum == 16) return "6";
            if (versionNum == 17) return "7";
            if (versionNum == 18) return "8";
            if (version is "1.19" || version is "1.19.1" || version is "1.19.2") return "9";
            if (version is "1.19.3") return "12";
            if (version is "1.19.4") return "13";
            if (version is "1.20" || version is "1.20.1") return "15";
            if (version is "1.20.2") return "18";
            if (version is "1.20.3" || version is "1.20.4") return "22";
            if (version is "1.20.5" || version is "1.20.6") return "32";
            if (version is "1.21" || version is "1.21.1") return "34";
            if (version is "1.21.2" || version is "1.21.3") return "42";
            if (version is "1.21.4") return "46";
            if (version is "1.21.5") return "55";
            if (version is "1.21.6") return "63";
            if (version is "1.21.7" || version is "1.21.8") return "64";
            if (version is "1.21.9" || version is "1.21.10") return "69";
            if (version is "1.21.11") return "75";

            return null;
        }
        private async Task<string?> GetPackFormatFromJSONAsync(ZipArchive sourceArchive)
        {
            ZipArchiveEntry? versionEntry = sourceArchive.GetEntry("version.json");
            if (versionEntry == null) return null;

            using (Stream versionEntryStream = await versionEntry.OpenAsync())
            {
                JsonNode? mainNode = await JsonNode.ParseAsync(versionEntryStream);
                if (mainNode == null) return null;

                JsonNode? packVersionNode = mainNode["pack_version"];
                if (packVersionNode == null) return null;

                if (packVersionNode.GetValueKind() == JsonValueKind.Number)
                {
                    return packVersionNode.ToString();
                }

                JsonNode? resourceMajor = packVersionNode["resource_major"];
                if (resourceMajor == null) return null;

                if (resourceMajor.GetValueKind() == JsonValueKind.Number)
                {
                    JsonNode? resourceMinor = packVersionNode["resource_minor"];
                    if (resourceMinor == null || resourceMinor.GetValueKind() != JsonValueKind.Number) return resourceMajor.ToString();

                    string minor = resourceMinor.ToString();
                    if (minor == "0") return resourceMajor.ToString();
                    
                    return $"{resourceMajor.ToString()}.{minor}";
                }
            }
            return null;
        }
        private async Task<string?> GetPackFormatFromWebAsync(string version)
        {
            HttpClient httpClient = new HttpClient();

            using HttpResponseMessage response = await httpClient.GetAsync(PACK_FORMATS_URI);
            if (!response.IsSuccessStatusCode) return null;

            ReadOnlySpan<char> responseContent = await response.Content.ReadAsStringAsync();

            int versionIndex = responseContent.IndexOf($"\"{version}\":", StringComparison.OrdinalIgnoreCase);
            if (versionIndex < 0)
            {
                int lastDotIndex = version.LastIndexOf('.');
                if (lastDotIndex < 0) return null;

                versionIndex = responseContent.IndexOf($"\"{version.Substring(0, lastDotIndex)}.x\":", StringComparison.OrdinalIgnoreCase);
                if (versionIndex < 0) return null;
            }

            ReadOnlySpan<char> versionContent = responseContent.Slice(versionIndex, responseContent.Slice(versionIndex).IndexOf('}'));
            int versionStart = versionContent.IndexOf("resource:") + 9;
            int versionEnd = versionContent.IndexOf(',');
            if (versionStart < 8 || versionEnd < 0 || versionStart >= versionEnd) return null;

            return versionContent.Slice(versionStart, versionEnd - versionStart).ToString();
        }

        private string GetPackFormatFromUser()
        {
            PackFormatInputWindow packFormatInputWindow = new PackFormatInputWindow();
            packFormatInputWindow.ShowDialog();

            if (packFormatInputWindow.DialogResult == null || packFormatInputWindow.PackFormatInputValue == string.Empty) return "0";
            if (packFormatInputWindow.DialogResult == false) throw new OperationCanceledException("Texturepack generating canceled");
            return packFormatInputWindow.PackFormatInputValue;
        }
    }
}
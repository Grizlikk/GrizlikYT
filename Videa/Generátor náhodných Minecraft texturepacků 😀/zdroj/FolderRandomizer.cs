using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Minecraft_random_texturepacks
{
    internal class FolderRandomizer
    {
        public readonly DirectoryInfo SourceDirectory;

        public int TotalFiles { get; private set; } = 0;

        public string[] AllFiles { get; private set; } = Array.Empty<string>();

        public FolderRandomizer(DirectoryInfo folder)
        {
            SourceDirectory = folder;

            ReadFilesInsideFolder();
        }

        private void ReadFilesInsideFolder()
        {
            EnumerationOptions enumerationOptions = new EnumerationOptions()
            {
                RecurseSubdirectories = true,
                IgnoreInaccessible = true,
            };

            AllFiles = Directory.GetFiles(SourceDirectory.FullName, "*", enumerationOptions);
            TotalFiles = AllFiles.Length;
        }

        public void RandomizeFolder(byte randomizationPercentage)
        {
            Random random = new Random();

            string[] files = new string[TotalFiles];
            AllFiles.CopyTo(files);

            random.Shuffle(files);

            string[] newFileNames = new string[(long)files.Length * randomizationPercentage / 100];
            for (int i = 0; i < newFileNames.Length; i++)
            {
                newFileNames[i] = files[i];
            }

            random.Shuffle(newFileNames);

            Dictionary<string, string> tempNames = new Dictionary<string, string>();
            try
            {
                for (int i = 0; i < newFileNames.Length; i++)
                {
                    string tempName = string.Concat(files[i].AsSpan().Slice(0, files[i].LastIndexOf('\\') + 1), Path.GetRandomFileName());
                    tempNames[tempName] = newFileNames[i];
                    File.Move(files[i], tempName, false);
                }
            }
            finally
            {
                foreach (string tempName in tempNames.Keys)
                {
                    File.Move(tempName, tempNames[tempName], false);
                }
            }
        }
    }
}

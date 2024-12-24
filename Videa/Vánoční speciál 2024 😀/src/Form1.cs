using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System.Globalization;

namespace Prejmenovani_fotek
{
	public partial class MainWindow : Form
	{
		private struct Photo
		{
			public FileInfo CurrentFile { get; set; }
			public FileInfo? NewFile { get; set; }

			private Task<string> generateNewNameTask;
			public string GeneratedMetadataName { get { return generateNewNameTask.Result; } }
			public string GeneratedModifiedDateName { get { return CurrentFile.LastWriteTime.ToString("yyyyMMdd_HHmmss"); } }
			public Photo(FileInfo currentFile)
			{
				CurrentFile = currentFile;
				NewFile = null;
				generateNewNameTask = GenerateNewFileNameAsync(CurrentFile);
			}
			public Photo(string filePath) : this(new FileInfo(filePath)) { }
		}

		// List of photo file extensions
		private static readonly HashSet<string> photosExtensions = new HashSet<string> { ".jpg", ".png", ".jpeg", ".gif", ".webp", ".svg", ".bmp", ".jpe", ".jif", ".jfif", ".pjpeg", ".x-png", ".tiff", ".tif", ".xbm", ".avif", ".raw", ".apng" };

		Task<List<Photo>> allSelectedPhotos = Task.Run(() => { return new List<Photo>(); });
		List<Photo> photosForRename = new List<Photo>();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void TlacitloVybratSoubory_Click(object sender, EventArgs e)
		{
			// Show open file dialog
			DialogResult result = VybratSouboryDialog.ShowDialog();
			if (result != DialogResult.OK) return;

			// Set color
			ZobrazeniSouboruText.Text = string.Empty;
			ZobrazeniSouboruText.ForeColor = Color.Black;

			// Display all loaded files
			ZobrazeniSouboruText.Text = string.Join("\n", VybratSouboryDialog.FileNames);
			// Save all loaded photos
			allSelectedPhotos = SaveSelectedPhotosAsync(VybratSouboryDialog.FileNames);

			TlacitkoOdfiltrovatFotky.Enabled = true;
		}

		private void TlacitkoOdfiltrovatFotky_Click(object sender, EventArgs e)
		{
			if (InvalidSetting()) return;

			// Set color
			ZobrazeniSouboruText.ForeColor = Color.ForestGreen;

			// Output all photos
			ZobrazeniSouboruText.Text = string.Join("\n", allSelectedPhotos.Result.Select(x => x.CurrentFile.FullName));

			TlacitkoNahledNazvu.Enabled = true;
		}

		private void TlacitkoNahledNazvu_Click(object sender, EventArgs e)
		{
			// Refresh loaded photos
			photosForRename = new List<Photo>(allSelectedPhotos.Result);

			if (InvalidSetting()) return;

			ZobrazeniSouboruText.Text = "Probíhá generování nových názvů fotek...";
			Application.DoEvents();

			// Remove files that don't need renaming
			HashSet<string> usedFileNames = new HashSet<string>();
			HashSet<string> renamedFiles = new HashSet<string>();
			for (int i = 0; i < photosForRename.Count; i++)
			{
				Photo photo = photosForRename[i];
				string newPhotoName = (UseModifiedDateCheckBox.Checked) ? photo.GeneratedModifiedDateName : photo.GeneratedMetadataName;
				string parentDirectory = photo.CurrentFile.DirectoryName ?? string.Empty;
				FileInfo newFile = new FileInfo(Path.Combine(parentDirectory, newPhotoName + UpdateExtension(photo.CurrentFile.Extension)));
				HashSet<string> allFiles = System.IO.Directory.GetFiles(parentDirectory).Select(x => x.ToLower()).ToHashSet();
				bool save = true;

				uint fileCounter = 2;
				// The file exists now or will exist after renaming
				while ((allFiles.Contains(newFile.FullName.ToLower()) && !renamedFiles.Contains(newFile.FullName.ToLower())) || usedFileNames.Contains(newFile.FullName))
				{
					// The file already has it's name
					if (Path.GetFileNameWithoutExtension(newFile.FullName) == Path.GetFileNameWithoutExtension(photo.CurrentFile.FullName))
					{
						// The file already has it's exact name with extension, so it doesn't need changing
						if (newFile.FullName == photo.CurrentFile.FullName)
						{
							photosForRename.RemoveAt(i);
							i--;
							save = false;
						}
						break;
					}
					newFile = new FileInfo(Path.Combine(parentDirectory, newPhotoName + $" ({fileCounter})" + newFile.Extension));
					fileCounter++;
				}
				if (save)
				{
					photo.NewFile = newFile;
					photosForRename[i] = photo;
					usedFileNames.Add(newFile.FullName);
					renamedFiles.Add(photo.CurrentFile.FullName.ToLower());
				}
			}

			// Set color
			ZobrazeniSouboruText.ForeColor = Color.Blue;
			ZobrazeniSouboruText.Text = string.Empty;

			// All photos already have their correct names
			if (photosForRename.Count == 0)
			{
				ZobrazeniSouboruText.Text = "[Všechny soubory již mají své správné názvy]";
				return;
			}

			// Output all photos for renaming
			foreach (Photo photo in photosForRename)
			{
				if (photo.NewFile == null) continue;
				ZobrazeniSouboruText.AppendText(photo.CurrentFile.FullName + "   -->   " + photo.NewFile.Name + "\n");
			}

			TlacitkoPrejmenovat.Visible = true;
		}

		private void TlacitkoPrejmenovat_Click(object sender, EventArgs e)
		{
			if (FinalniPotvrzeni.Visible == true) return;

			DialogResult dialog;
			// Dialog 1
			dialog = MessageBox.Show("Tato akce je nevratná, opravdu chcete pokračovat?", "Nevratná akce", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialog == DialogResult.No) return;

			// Dialog 2
			dialog = MessageBox.Show("Ale já si nedělám srandu, tato akce je skutečně nevratná, opravdu chcete pokračovat?", "Nevratná akce", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialog == DialogResult.No) return;

			// Dialog 3
			dialog = MessageBox.Show("POZOR!!!\nPrávě se chystáte provést nevratnou akci, jste si jistí?", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
			if (dialog == DialogResult.No) return;

			// Dialog 4
			dialog = MessageBox.Show("K provedení této akce je potřeba:\nPotvrzení", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialog == DialogResult.No) return;

			// Dialog 5
			dialog = MessageBox.Show("K provedení této akce je potřeba:\nPotvrzení na potvrzení", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialog == DialogResult.No) return;

			// Dialog 6
			dialog = MessageBox.Show("K provedení této akce je potřeba:\nPotvrzení na potvrzení na potvrzení", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialog == DialogResult.No) return;

			// Dialog 7
			dialog = MessageBox.Show("Tak dobře, ale tohle už je skutečně POSLEDNÍ POTVRZENÍ!", "NEVRATNÁ AKCE!", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
			if (dialog == DialogResult.No) return;

			FinalniPotvrzeni.Visible = true;
		}

		private void FinalniPotvrzeni_Click(object sender, EventArgs e)
		{
			if (InvalidSetting()) return;

			// Set color
			ZobrazeniSouboruText.ForeColor = Color.Brown;
			ZobrazeniSouboruText.Text = string.Empty;

			// Rename photos
			try
			{
				foreach (Photo photo in photosForRename)
				{
					if (photo.NewFile == null) continue;
					File.Move(photo.CurrentFile.FullName, photo.NewFile.FullName, false);

					ZobrazeniSouboruText.AppendText($"Soubor přejmenován:   {photo.CurrentFile.FullName}   -->   {photo.NewFile.Name}\n");
				}
			}
			catch (IOException)
			{
				// If a file with this name already exists, renaming will be stopped
				MessageBox.Show($"Error: Došlo k pokusu o přepsání souboru!\nPro ochranu vašich souborů byla akce přejmenování zastavena\nPŘEJMENOVÁNÍ NEBYLO DOKONČENO!", "SHODNÉ NÁZVY SOUBORŮ", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ZobrazeniSouboruText.AppendText("\n========================================\n\tDOŠLO K POKUSU O PŘEPSÁNÍ SOUBORU\n========================================");
			}

			FinalniPotvrzeni.Visible = false;
			TlacitkoPrejmenovat.Visible = false;
			TlacitkoNahledNazvu.Enabled = false;
			TlacitkoOdfiltrovatFotky.Enabled = false;
		}

		private void ZobrazeniSouboruText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		private void MalePismenaPripona_MouseClick(object sender, MouseEventArgs e)
		{
			VelkePismenaPripona.Checked = false;
			OriginalniPripona.Checked = false;
			Refresh(sender, e);
		}
		private void VelkePismenaPripona_MouseClick(object sender, MouseEventArgs e)
		{
			MalePismenaPripona.Checked = false;
			OriginalniPripona.Checked = false;
			Refresh(sender, e);
		}
		private void OriginalniPripona_MouseClick(object sender, MouseEventArgs e)
		{
			MalePismenaPripona.Checked = false;
			VelkePismenaPripona.Checked = false;
			Refresh(sender, e);
		}
		private void UseModifiedDateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Refresh(sender, e);
		}

		private void Refresh(object sender, EventArgs e)
		{
			if (TlacitkoNahledNazvu.Enabled)
			{
				TlacitkoNahledNazvu_Click(sender, e);
			}
		}

		private bool InvalidSetting()
		{
			// Set color
			ZobrazeniSouboruText.ForeColor = Color.FromArgb(192, 0, 0);
			if (VybratSouboryDialog.FileNames.Length == 0)
			{
				// Check for empty selected files array
				ZobrazeniSouboruText.Text = "Error! Nebyly vybrany zadne soubory";
				return true;
			}
			else if (allSelectedPhotos.Result.Count == 0)
			{
				// Check for empty photos array
				ZobrazeniSouboruText.Text = "Error! Nebyly vybrany zadne fotky";
				return true;
			}
			return false;
		}
		private static bool IsPhoto(FileInfo file)
		{
			return photosExtensions.Contains(file.Extension.ToLower());
		}
		private string UpdateExtension(string extension)
		{
			if (MalePismenaPripona.Checked) return extension.ToLower();
			if (VelkePismenaPripona.Checked) return extension.ToUpper();
			return extension;
		}
		private static async Task<string> GenerateNewFileNameAsync(FileInfo file)
		{
			if (!file.Exists) return string.Empty;

			DateTime imageCreationDate = file.LastWriteTime;

			await Task.Run(() =>
			{
				// It... Just... Works... ?
				// Prevents extreme lag spikes when all threads try to load at the same time
				Thread.Sleep(100);

				// Tries to read the date the photo was taken from it's metadata
				try
				{
					IReadOnlyList<MetadataExtractor.Directory> metadataDirectories = ImageMetadataReader.ReadMetadata(file.FullName);
					ExifSubIfdDirectory? subIfdDirectory = metadataDirectories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
					if (subIfdDirectory == null) throw new ArgumentNullException();
					string creationTimeString = subIfdDirectory.GetDescription(ExifDirectoryBase.TagDateTimeOriginal) ?? string.Empty;
					imageCreationDate = DateTime.ParseExact(creationTimeString, "yyyy:MM:dd HH:mm:ss", CultureInfo.CurrentCulture);
				}
				// If it fails, just use the last write time of the photo
				catch (Exception) { }
			});

			return imageCreationDate.ToString("yyyyMMdd_HHmmss");
		}
		private async Task<List<Photo>> SaveSelectedPhotosAsync(string[] selectedPhotos)
		{
			List<Photo> photos = new List<Photo>();
			await Task.Run(() => photos = selectedPhotos.Where(x => IsPhoto(new FileInfo(x))).Select(x => new Photo(x)).ToList());
			return photos;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;

namespace Vnrt.Runtime.SaveData
{
    public class GameSave
    {
        private const string GlobalSaveFileName = "global.vnrtsave";
        private const string AutoSaveFileName = "autosave.vnrtsave";

        public string BookSaveFolderName { get; private set; }

        public List<UserSave> UserSaves { get; set; }

        public GameSave(string bookName, string author)
        {
            string invalidRegStr = String.Format(@"([{0}]*\.+$)|([{0}]+)", Regex.Escape(new string(Path.GetInvalidPathChars())));

            BookSaveFolderName = Regex.Replace(bookName + "_" + author, invalidRegStr, "_");
        }

        private async Task<StorageFolder> OpenBookSaveFolderAsync()
        {
            return await ProgramSettings.RoamingFolder.CreateFolderAsync(BookSaveFolderName, CreationCollisionOption.OpenIfExists);
        }

        private async Task<StorageFile> OpenFileAsync(string fileName)
        {
            StorageFolder bookSaveFolder = await OpenBookSaveFolderAsync();
            return await bookSaveFolder.GetFileAsync(fileName);
        }

        private async Task<StorageFile> CreateFileAsync(string fileName, CreationCollisionOption collOption)
        {
            StorageFolder bookSaveFolder = await OpenBookSaveFolderAsync();
            return await bookSaveFolder.GetFileAsync(fileName);
        }

        public async Task<GlobalSave> LoadGlobalAsync()
        {
            Stream stream = await (await OpenFileAsync(GlobalSaveFileName)).OpenStreamForReadAsync();
            string stringContent = await new StreamReader(stream).ReadToEndAsync();

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GlobalSave>(stringContent));
        }

        public async Task<UserSave> LoadAutoSaveAsync()
        {
            return await LoadAsync(AutoSaveFileName);
        }

        public async Task<UserSave> LoadAsync(string fileName)
        {
            Stream stream = await (await OpenFileAsync(fileName)).OpenStreamForReadAsync();
            string stringContent = await new StreamReader(stream).ReadToEndAsync();

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<UserSave>(stringContent));
        }

        public async void SaveGlobal(GlobalSave toSave)
        {
            Stream stream = await (await CreateFileAsync(GlobalSaveFileName, CreationCollisionOption.ReplaceExisting)).OpenStreamForWriteAsync();

            await new StreamWriter(stream).WriteAsync(await Task.Factory.StartNew(() => JsonConvert.SerializeObject(toSave)));
        }

        public async void SaveToAutoSaveAsync(UserSave toSave)
        {
            Stream stream = await (await CreateFileAsync(AutoSaveFileName, CreationCollisionOption.ReplaceExisting)).OpenStreamForWriteAsync();

            await new StreamWriter(stream).WriteAsync(await Task.Factory.StartNew(() => JsonConvert.SerializeObject(toSave)));
        }

        public async void SaveAsync(UserSave toSave)
        {
            Stream stream = await (await CreateFileAsync(DateTime.UtcNow.ToString(), CreationCollisionOption.FailIfExists)).OpenStreamForWriteAsync();

            await new StreamWriter(stream).WriteAsync(await Task.Factory.StartNew(() => JsonConvert.SerializeObject(toSave)));
        }
    }
}

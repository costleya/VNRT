using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;

namespace Vnrt.Utilities
{
    public class FileUtil
    {
        public static async Task<string> LoadGameDirectory()
        {
            try
            {
                FolderPicker picker = new FolderPicker();
                picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
                picker.ViewMode = PickerViewMode.List;
                picker.FileTypeFilter.Add(".vnrt");
                picker.CommitButtonText = "Start";
                StorageFolder ret = await picker.PickSingleFolderAsync();
                if (ret != null)
                {
                    return await InitializeGame(ret);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<string> LoadGameAsJson(string gameName)
        {
            StorageFile file = null;
            StorageFolder gameFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(gameName);
            if ((await gameFolder.TryGetItemAsync(gameFolder.Name + ".vnrt")) != null)
            {
                file = await gameFolder.GetFileAsync(gameFolder.Name + ".vnrt");
            }
            if (file == null)
            {
                return null;
            }
            return await FileIO.ReadTextAsync(file);
        }

        public static async Task<Game> LoadGameAsObject(string gameName)
        {
            try
            {
                Game game = null;
                game = await Task.Run(async () => JsonConvert.DeserializeObject<Game>(await LoadGameAsJson(gameName)));
                return game;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<string> InitializeGame(StorageFolder source)
        {
            StorageFolder destination = null;
            //if ((await ApplicationData.Current.LocalFolder.TryGetItemAsync(source.Name)) == null)
            //{
            destination = await ApplicationData.Current.LocalFolder.CreateFolderAsync(source.Name);
            await CopyFiles(source, destination);
            //}
            return destination.Name;
        }

        private static async Task CopyFiles(StorageFolder source, StorageFolder destination)
        {
            foreach (StorageFile f in (await source.GetFilesAsync()))
            {
                await f.CopyAsync(destination);
            }
            foreach (StorageFolder fo in (await source.GetFoldersAsync()))
            {
                StorageFolder dest = await destination.CreateFolderAsync(fo.Name);
                await CopyFiles(fo, dest);
            }
        }

        public static async Task SaveGame(Game game)
        {
            try
            {
                FileSavePicker picker = new FileSavePicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.DefaultFileExtension = ".vnrt";
                picker.FileTypeChoices.Add("Visual Novel", new string[] { ".vnrt" });
                picker.SuggestedFileName = "MyGame";
                picker.CommitButtonText = "Save";

                StorageFile file = await picker.PickSaveFileAsync();
                if (file != null)
                {
                    CachedFileManager.DeferUpdates(file);
                    await FileIO.WriteTextAsync(file, await Task.Run(() => JsonConvert.SerializeObject(game)));
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                    if (status == FileUpdateStatus.Complete)
                    {
                        //Done
                    }
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        public static async Task<string> LoadImages()
        {
            try
            {
                FileOpenPicker picker = new FileOpenPicker();
                picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                picker.ViewMode = PickerViewMode.List;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".png");
                picker.FileTypeFilter.Add(".svg");
                picker.FileTypeFilter.Add(".bmp");
                picker.CommitButtonText = "OK";
                IReadOnlyList<StorageFile> ret = await picker.PickMultipleFilesAsync();
                if (ret != null)
                {
                    //Stuff
                    return "";
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<string> LoadSounds()
        {
            try
            {
                FileOpenPicker picker = new FileOpenPicker();
                picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
                picker.ViewMode = PickerViewMode.List;
                picker.FileTypeFilter.Add(".midi");
                picker.FileTypeFilter.Add(".wav");
                picker.CommitButtonText = "OK";
                IReadOnlyList<StorageFile> ret = await picker.PickMultipleFilesAsync();
                if (ret != null)
                {
                    //Stuff
                    return "";
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
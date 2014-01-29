using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.Storage.Provider;

namespace Vnrt.Utilities
{
    public class FileUtil
    {
        public static async Task<Game> LoadGame()
        {
            try
            {
                FileOpenPicker picker = new FileOpenPicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.ViewMode = PickerViewMode.List;
                picker.FileTypeFilter.Add(".vnrt");
                picker.CommitButtonText = "Start";
                StorageFile ret = await picker.PickSingleFileAsync();
                if (ret != null)
                {
                    Game game = null;
                    using (StringReader reader = new StringReader(await FileIO.ReadTextAsync(ret)))
                    {
                        game = new XmlSerializer(typeof(Game)).Deserialize(reader) as Game;
                    }
                    return game;
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

        public static async Task SaveGame(Game game)
        {
            try
            {
                FileSavePicker picker = new FileSavePicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.DefaultFileExtension = ".vnrt";
                picker.FileTypeChoices.Add("Visual Novel", new string[] {".vnrt"});
                picker.SuggestedFileName = "MyGame";
                picker.CommitButtonText = "Save";

                StorageFile file = await picker.PickSaveFileAsync();
                if (file != null)
                {
                    CachedFileManager.DeferUpdates(file);
                    XmlSerializer serializer = new XmlSerializer(typeof(Game));
                    using (StringWriter buffer = new StringWriter())
                    {
                        serializer.Serialize(buffer, game);
                        await FileIO.WriteTextAsync(file, buffer.ToString());
                    }
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                    if(status == FileUpdateStatus.Complete)
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

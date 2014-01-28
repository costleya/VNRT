using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;

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
                    Stream reader = await ret.OpenStreamForReadAsync();
                    Game game = new XmlSerializer(typeof(Game)).Deserialize(reader) as Game;
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
                FileOpenPicker picker = new FileOpenPicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.ViewMode = PickerViewMode.List;
                picker.FileTypeFilter.Add(".vnrt");
                picker.CommitButtonText = "Start";
                StorageFile ret = await picker.PickSingleFileAsync();
                if (ret != null)
                {
                    XmlSerializer serializez = new XmlSerializer(typeof(Game));
                    Stream writer = await ret.OpenStreamForWriteAsync();

                    serializez.Serialize(writer,game);
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

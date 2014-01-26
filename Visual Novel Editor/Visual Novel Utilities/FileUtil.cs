using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Game game = new Game();
                    game.Name = ret.DisplayName;
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

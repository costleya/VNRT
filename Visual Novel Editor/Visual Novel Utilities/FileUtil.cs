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

        //Test Model. Replace with actual Model
        public class Game
        {
            public string Name { get; set; }
        }
    }
}

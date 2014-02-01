using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows;
using Vnrt.Utilities;
using System.Threading.Tasks;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace XMLTester
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadTask();
        }

        public async void LoadTask()
        {
            Game game = new Game()
            {
                Name = "Super Stream Fighter",
                Author = "David Patry",
                Scenes = new List<Scene>()
                {
                    new Scene()
                    {
                        Id = Guid.NewGuid().ToString(),
                        BackgroundImage = "A.jpg",
                        BackgroundMusic = "B.wav",
                        Instances = new List<Instance>()
                        {
                            new Instance()
                            {
                                Dialog = new Dialog()
                                {
                                    Text = "Sample Text"
                                },
                                Characters = new List<Character>()
                                { 
                                    new Character()
                                    {
                                        Name = "Aaron"
                                    }
                                }
                            },
                            new Instance()
                            {
                                Dialog = new Dialog()
                                {
                                    Text = "Test Text"
                                },
                                Characters = new List<Character>()
                                {
                                    new Character()
                                    {
                                        Name = "Brandon"
                                    }
                                }
                            }
                        }
                    },
                    new Scene()
                    {
                        Id = Guid.NewGuid().ToString(),
                        BackgroundImage = "C.png",
                        BackgroundMusic = "D.wav",
                        Instances = new List<Instance>()
                        {
                            new Instance()
                            {
                                Dialog = new Dialog()
                                {
                                    Text = "Test"
                                },
                                Characters = new List<Character>()
                                {
                                    new Character()
                                    {
                                        Name = "Omar"
                                    },
                                    new Character()
                                    {
                                        Name = "David"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            await FileUtil.SaveGame(game);
            Game newGame = await FileUtil.LoadGame();
            Console.Text = "Game Name: " + newGame.Name + "\nBackground Music of Scene 1: " + newGame.Scenes[0].BackgroundMusic + "\nSecond character in the first instance of scene 2: " +newGame.Scenes[1].Instances[0].Characters[1].Name;
        }
    }
}

using System;
using System.Collections.Generic;
using Vnrt.Utilities;
using Windows.UI.Xaml.Controls;

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
                        BackgroundImage = "Images/Backgrounds/railroad.jpg",
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
                                        Name = "Momo",
                                        CharacterSprites = new List<CharacterSprite>()
                                        {
                                            new CharacterSprite()
                                            {
                                                Name = "Friendly",
                                                Path = "Images/Characters/Momo/Friendly.png"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            await FileUtil.SaveGame(game);
        }
    }
}
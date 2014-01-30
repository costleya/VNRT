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
            //Game mygame = new Game();
            //mygame.Name = "Super Stream Fighter";
            //mygame.Author = "David Patry";
            //mygame.SceneList.Add(new Scene());

            //Game mygame2 = await FileUtil.LoadGame();
            //Console.Text = mygame2.Name + "\n" + mygame2.Author+ "\n";

            Game game = new Game();
            game.Name = "Super Stream Fighter";
            game.Author = "David Patry";
            game.Scenes = new List<Scene>();

            Scene scene = new Scene();
            scene.Id = Guid.NewGuid().ToString();
            scene.BackgroundImage = "A.jpg";
            scene.BackgroundMusic = "B.wav";
            scene.Instances = new List<Instance>();

            Instance inst = new Instance();
            Dialog d = new Dialog();
            d.Text = "Sample Text";
            inst.Dialog = d;
            Character c = new Character();
            c.Name = "Aaron";
            inst.Characters = new List<Character>();
            inst.Characters.Add(c);

            Instance inst2 = new Instance();
            Dialog d2 = new Dialog();
            d2.Text = "Test Text";
            inst2.Dialog = d2;
            Character c2 = new Character();
            c2.Name = "Brandon";
            inst2.Characters = new List<Character>();
            inst2.Characters.Add(c2);

            scene.Instances.Add(inst);
            scene.Instances.Add(inst2);

            Scene scene2 = new Scene();
            scene2.Id = Guid.NewGuid().ToString();
            scene.BackgroundImage = "C.png";
            scene.BackgroundMusic = "D.wav";
            scene2.Instances = new List<Instance>();

            Instance inst3 = new Instance();
            Dialog d3 = new Dialog();
            d3.Text = "Test";
            inst3.Dialog = d3;
            Character c3 = new Character();
            c3.Name = "Omar";
            Character c4 = new Character();
            c4.Name = "David";
            inst3.Characters = new List<Character>();
            inst3.Characters.Add(c3);
            inst3.Characters.Add(c4);

            scene2.Instances.Add(inst3);

            game.Scenes.Add(scene);
            game.Scenes.Add(scene2);

            await FileUtil.SaveGame(game);
            Game newGame = await FileUtil.LoadGame();
            Console.Text = "Game Name: " + newGame.Name + "\nBackground Music of Scene 1: " + newGame.Scenes[0].BackgroundMusic + "\nSecond character in the first instance of scene 2: " +newGame.Scenes[1].Instances[0].Characters[1].Name;
        }
    }
}

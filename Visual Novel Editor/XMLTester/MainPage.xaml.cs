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
            loadtask();
        }
        public async void loadtask()
        {
            //Game mygame = new Game();
            //mygame.Name = "Super Stream Fighter";
            //mygame.Author = "David Patry";
            //mygame.SceneList.Add(new Scene());

            Game mygame2 = await FileUtil.LoadGame();
            Console.Text = mygame2.Name + "\n" + mygame2.Author+ "\n";
        }
    }
}

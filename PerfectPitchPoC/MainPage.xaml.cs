using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PerfectPitchPoC
{
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer simpleAudioPlayer; 
        public MainPage()
        {
            simpleAudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            simpleAudioPlayer.Loop = false;
            bool ret = simpleAudioPlayer.Load(GetStreamFromFile($"Audio.G-0.wav"));
            InitializeComponent();
        }


        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("PerfectPitchPoC." + filename);

            return stream;
        }
        void OnStartButtonClicked(object sender, EventArgs e)
        {
            simpleAudioPlayer.Play();
        }

        void OnStopButtonClicked(object sender, EventArgs e)
        {
            simpleAudioPlayer.Stop();
        }
    }
}

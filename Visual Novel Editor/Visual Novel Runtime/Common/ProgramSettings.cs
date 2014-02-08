using System;
using System.ComponentModel;
using Windows.Storage;

namespace Vnrt.Runtime.Common
{
    public class ProgramSettings
    {
        public static event EventHandler<PropertyChangedEventArgs> OnStaticPropertyChanged;
        public static void NotifyStaticPropertyChanged(string propName)
        {
            if (OnStaticPropertyChanged != null)
            {
                OnStaticPropertyChanged(null, new PropertyChangedEventArgs(propName));
            }
        }

        private static ApplicationDataContainer LocalSettings
        {
            get { return ApplicationData.Current.LocalSettings; }
        }

        private static ApplicationDataContainer RoamingSettings
        {
            get { return ApplicationData.Current.RoamingSettings; }
        }

        public static StorageFolder LocalFolder
        {
            get { return ApplicationData.Current.LocalFolder; }
        }

        public static StorageFolder RoamingFolder
        {
            get { return ApplicationData.Current.RoamingFolder; }
        }

        public static double SoundFXVolume
        {
            get { return (double)(LocalSettings.Values["SoundFXVolume"] ?? 100.0); }
            set
            {
                if ((double)(LocalSettings.Values["SoundFXVolume"] ?? 100.0) == value)
                {
                    return;
                }
                LocalSettings.Values["SoundFXVolume"] = value;
                NotifyStaticPropertyChanged("SoundFXVolume");
            }
        }

        public static bool SoundFXEnabled { get { return SoundFXVolume > 0; } }

        public static double MusicVolume
        {
            get { return (double)(LocalSettings.Values["MusicVolume"] ?? 100.0); }
            set
            {
                if ((double)(LocalSettings.Values["MusicVolume"] ?? 100.0) == value)
                {
                    return;
                }
                LocalSettings.Values["MusicVolume"] = value;
                NotifyStaticPropertyChanged("MusicVolume");
            }
        }

        public static bool MusicEnabled { get { return MusicVolume > 0; } }

        public static bool AutosaveOnQuestions
        {
            get { return (bool)(LocalSettings.Values["AutosaveOnQuestions"] ?? false); }
            set
            {
                if ((bool)(LocalSettings.Values["AutosaveOnQuestions"] ?? false) == value)
                {
                    return;
                }
                LocalSettings.Values["AutosaveOnQuestions"] = value;
                NotifyStaticPropertyChanged("AutosaveOnQuestions");
            }
        }
    }
}

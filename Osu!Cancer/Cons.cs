﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Osu_Cancer
{
    /// <summary>
    /// Class Contain some commonly use. Resource input as a parent folder of the resource folder
    /// </summary>
    class Cons: INotifyPropertyChanged
    {
        /// <summary>
        /// Use the default application path to access resource
        /// </summary>
        public Cons()
        {
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            Icons = new GameIcon(BaseDir);
            SetProperty();
        }
        /// <summary>
        /// Use a custom path to access resources
        /// </summary>
        /// <param name="defaultPath">A reources path</param>
        public Cons(string defaultPath, GameIcon icons)
        {
            icons = Icons;
            BaseDir = defaultPath;
            SetProperty();
        }

        private void SetProperty()
        {
            Logo = BaseDir + @"Resources\Logo.png";
            NewUpdateandBuildDir = BaseDir + @"Resources\BuildNotes.txt";
            NewUpdateContent = FileOperation.FileToString(NewUpdateandBuildDir, EncodingType.UTF8);
            SongPath = BaseDir + @"Resources\Songs\";
            SkinsParentpath = BaseDir + @"Resources\Skins\";
            settingIcon = new List<BitmapImage>();
            IsSettingPanelOpen = false;
            GetTextureInformation();
            GetAccountInformation();
            ScreenX = int.Parse(SystemParameters.PrimaryScreenWidth.ToString());
            ScreenY = int.Parse(SystemParameters.PrimaryScreenHeight.ToString());
            IsBGMPause = false;
            NowplayingLength = 366;
            isShowPernamentlyInfo = true;
            MasterVolumeValue = 99;
            SongProgress = 50;
            
        }

        private void GetTextureInformation()
        {
            PlayTab = Icons.PlayTab;
            ExitTab = Icons.ExitTab;
            EditTab = Icons.EditTab;
            OptionTab = Icons.OptionTab;
            SoloTab = Icons.SoloTab;
            MultiTab = Icons.MultiTab;
            BackTab = Icons.BackTab;
            SettingIconImage1 = Icons.SettingGear;
            SettingIconImage2 = Icons.SettingDisplay;
            SettingIconImage3 = Icons.SettingCircle;
            SettingIconImage4 = Icons.SettingSound;
            SettingIconImage5 = Icons.SettingBrush;
            SettingIconImage6 = Icons.SettingConsole;
            SettingIconImage7 = Icons.SettingPencil;
            SettingIconImage8 = Icons.SettingWorld;
            SettingIconImage9 = Icons.SettingWrench;
        }

        private void GetAccountInformation()
        {
            Username = FileOperation.GetSettingValueFromFile(BaseDir + @"\Resources\UserInfo.cfg", "Username");
            try { ProgLv = int.Parse(FileOperation.GetSettingValueFromFile(BaseDir + @"\Resources\UserInfo.cfg", "EXP")); }
            catch { ProgLv = 0; }

            Accuracy = FileOperation.GetSettingValueFromFile(BaseDir + @"\Resources\UserInfo.cfg", "Accuracy");
            Lv = FileOperation.GetSettingValueFromFile(BaseDir + @"\Resources\UserInfo.cfg", "LV");
            Pp = FileOperation.GetSettingValueFromFile(BaseDir + @"\Resources\UserInfo.cfg", "PP");
            Rank = FileOperation.GetSettingValueFromFile(BaseDir + @"\Resources\UserInfo.cfg", "Rank");
            Nowplaying = "Nekodex - Circle";
        }

        public void ReloadInformation()
        {
            GetAccountInformation();
        }
        public GameIcon Icons { get; set; }
        public string BaseDir { get; set; }
        private string settingIconImage1;
        public string SettingIconImage1
        {
            get { return settingIconImage1; }
            set
            {
                if(settingIconImage1 != value)
                {
                    settingIconImage1 = value;
                    NotifyPropertyChanged("SettingIconImage1");
                }
            }
        }

        private string settingIconImage2;
        public string SettingIconImage2
        {
            get { return settingIconImage2; }
            set
            {
                if (settingIconImage2 != value)
                {
                    settingIconImage2 = value;
                    NotifyPropertyChanged("SettingIconImage2");
                }
            }
        }
        private string settingIconImage3;
        public string SettingIconImage3
        {
            get { return settingIconImage3; }
            set
            {
                if (settingIconImage3 != value)
                {
                    settingIconImage3 = value;
                    NotifyPropertyChanged("SettingIconImage3");
                }
            }
        }
        private string settingIconImage4;
        public string SettingIconImage4
        {
            get { return settingIconImage4; }
            set
            {
                if (settingIconImage4 != value)
                {
                    settingIconImage4 = value;
                    NotifyPropertyChanged("SettingIconImage4");
                }
            }
        }
        private string settingIconImage5;
        public string SettingIconImage5
        {
            get { return settingIconImage5; }
            set
            {
                if (settingIconImage5 != value)
                {
                    settingIconImage5 = value;
                    NotifyPropertyChanged("SettingIconImage5");
                }
            }
        }
        private string settingIconImage6;
        public string SettingIconImage6
        {
            get { return settingIconImage6; }
            set
            {
                if (settingIconImage6 != value)
                {
                    settingIconImage6 = value;
                    NotifyPropertyChanged("SettingIconImage6");
                }
            }
        }
        private string settingIconImage7;
        public string SettingIconImage7
        {
            get { return settingIconImage7; }
            set
            {
                if (settingIconImage7 != value)
                {
                    settingIconImage7 = value;
                    NotifyPropertyChanged("SettingIconImage7");
                }
            }
        }
        private string settingIconImage8;
        public string SettingIconImage8
        {
            get { return settingIconImage8; }
            set
            {
                if (settingIconImage8 != value)
                {
                    settingIconImage8 = value;
                    NotifyPropertyChanged("SettingIconImage8");
                }
            }
        }
        private string settingIconImage9;
        public string SettingIconImage9
        {
            get { return settingIconImage9; }
            set
            {
                if (settingIconImage9 != value)
                {
                    settingIconImage9 = value;
                    NotifyPropertyChanged("SettingIconImage9");
                }
            }
        }
        private string logo;
        public string Logo {
            get { return logo; }
            set
            {
                if(logo != value)
                {
                    logo = value;
                    NotifyPropertyChanged("Logo");
                }
            }
        }
        private string playTab;
        public string PlayTab {
            get { return playTab; }
            set
            {

                if(playTab != value)
                {
                    playTab = value;
                    NotifyPropertyChanged("PlayTab");
                }
            }
        }
        private string exitTab;
        public string ExitTab
        {
            get { return exitTab; }
            set
            {
                if (exitTab != value)
                {
                    exitTab = value;
                    NotifyPropertyChanged("ExitTab");
                }
            }
        }
        private string editTab;
        public string EditTab
        {
            get { return editTab; }
            set
            {
                if(editTab != value)
                {
                    editTab = value;
                    NotifyPropertyChanged("EditTab");
                }
            }
        }
        private string optionTab;
        public string OptionTab
        {
            get { return optionTab;}
            set
            {
                if(optionTab != value)
                {
                    optionTab = value;
                    NotifyPropertyChanged("OptionTab");
                }
            }
        }
        private string soloTab;
        public string SoloTab
        {
            get { return soloTab; }
            set
            {
                if(soloTab != value)
                {
                    soloTab = value;
                    NotifyPropertyChanged("SoloTab");
                }
            }
        }
        private string multiTab;
        public string MultiTab
        {
            get { return multiTab; }
            set
            {
                if (multiTab != value)
                {
                    multiTab = value;
                    NotifyPropertyChanged("MultiTab");
                }
            }
        }
        private string backTab;
        public string BackTab
        {
            get { return backTab; }
            set
            {
                if(backTab != value)
                {
                    backTab = value;
                    NotifyPropertyChanged("BackTab");
                }
            }
        }
        public Socket CurrentSocket { get; set; }
        public string NewUpdateandBuildDir { get; set; }
        public string NewUpdateContent { get; set; }
        public string SongPath { get; set; }
        public string SkinsParentpath { get; set; }
        public SkinsLib CurrentSkin { get; set; }
        public List<BitmapImage> settingIcon { get; set; }
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }
        public bool IsSettingPanelOpen { get; set; }
        public bool IsBGMPause { get; set; }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if(username != value)
                {
                    username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }
        private string accuracy;
        public string Accuracy
        {
            get { return accuracy; }
            set
            {
                if(accuracy != value)
                {
                    accuracy = value;
                    NotifyPropertyChanged("Accuracy");
                }
            }
        }
        private string lv;
        public string Lv
        {
            get { return lv; }
            set
            {
                if(lv != value)
                {
                    lv = value;
                    NotifyPropertyChanged("Lv");
                }
            }
        }
        private string pp;
        public string Pp
        {
            get { return pp; }
            set
            {
                if(pp != value)
                {
                    pp = value;
                    NotifyPropertyChanged("Pp");
                }
            }
        }
        private int progLv;
        public int ProgLv
        {
            get { return progLv; }
            set
            {
                if (progLv != value)
                {
                    progLv = value;
                    NotifyPropertyChanged("ProgLv");
                }
            }
        }
        private string rank;
        public string Rank
        {
            get { return rank; }
            set
            {
                if(rank != value)
                {
                    rank = value;
                    NotifyPropertyChanged("Rank");
                }
            }
        }
        public string Nowplaying
        {
            get { return nowplaying; }
            set
            {
                if (value != nowplaying)
                {
                    nowplaying = value;
                    NotifyPropertyChanged("Nowplaying");
                }
            }
        }
        private string nowplaying;
        public int NowplayingLength
        {
            get { return nowplayingLength; }
            set
            {
                if(nowplayingLength != value)
                {
                    if(value > 365)
                    {
                        nowplayingLength = value;                       
                    }
                    else
                    {
                        nowplayingLength = 366;
                    }
                    NotifyPropertyChanged("NowplayingLength");
                }
            }
        }
        private int nowplayingLength;
        public bool isShowPernamentlyInfo { get; set; }
        private double songProgress;
        public double SongProgress
        {
            get { return songProgress; }
            set
            {
                if(songProgress != value)
                {
                    songProgress = value * 3;
                    NotifyPropertyChanged("SongProgress");
                }
            }
        }
        #region Volume
        private double _BGMVolume;
        public double BGMVolume
        {
            get { return _BGMVolume; }
            set
            {
                if(_BGMVolume != value)
                {
                    _BGMVolume = value;
                    NotifyPropertyChanged("BGMVolume");
                }
            }
        }
        public double MasterVolumeValue
        {
            get { return masterVolumeValue; }
            set
            {
                if(masterVolumeValue != value && value > 0 && value < 100)
                {
                    masterVolumeValue = value;
                    MasterVolumePathVal = FileOperation.CreateArc(61.5, masterVolumeValue * 3.6);
                    MasterVolumeStringIndicator = masterVolumeValue + "%";
                    BGMVolume = masterVolumeValue / 100;
                }
            }
        }
        private double masterVolumeValue;
        public Geometry MasterVolumePathVal
        {
            get { return masterVolumePathVal; }
            set
            {
                if (masterVolumePathVal != value)
                {
                    masterVolumePathVal = value;
                    NotifyPropertyChanged("MasterVolumePathVal");
                }
            }
        }
        private Geometry masterVolumePathVal;
        public string MasterVolumeStringIndicator
        {
            get { return masterVolumeStringIndicator; }
            set
            {
                if (masterVolumeStringIndicator != value)
                {
                    masterVolumeStringIndicator = value;
                    NotifyPropertyChanged("MasterVolumeStringIndicator");
                }
            }
        }



        private string masterVolumeStringIndicator;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    public class GameIcon
    {
        public GameIcon(string baseDir)
        {
            BaseDir = baseDir + @"Resources\Icon\";
            Information = BaseDir + "Information.png";
            MusicNote = BaseDir + "MusicNote.png";
            Next = BaseDir + "Next.png";
            Stop = BaseDir + "Stop.png";
            Play = BaseDir + "Play.png";
            Pause = BaseDir + "Pause.png";
            Window = BaseDir + "Window.png";
            Previous = BaseDir + "Previous.png";
            SettingBrush = BaseDir + "SettingBrush.png";
            SettingCircle = BaseDir + "SettingCircle.png";
            SettingConsole = BaseDir + "SettingConsole.png";
            SettingDisplay = BaseDir + "SettingDisplay.png";
            SettingGear = BaseDir + "SettingGear.png";
            SettingPencil = BaseDir + "SettingPencil.png";
            SettingSound = BaseDir + "SettingSound.png";
            SettingWorld = BaseDir + "SettingWorld.png";
            SettingWrench = BaseDir + "SettingWrench.png";
            PlayTab = BaseDir + "PlayTab.png";
            ExitTab =  BaseDir + "ExitTab.png";
            EditTab = BaseDir + "EditTab.png";
            OptionTab = BaseDir + "OptionTab.png";
            SoloTab =  BaseDir + "SoloTab.png";
            MultiTab = BaseDir + "MultiTab.png";
            BackTab = BaseDir + "BackTab.png";
        }
        public string Logo { get; set; }
        public string PlayTab { get; set; }
        public string ExitTab { get; set; }
        public string EditTab { get; set; }
        public string OptionTab { get; set; }
        public string SoloTab { get; set; }
        public string MultiTab { get; set; }
        public string BackTab { get; set; }
        public string BaseDir { get; set; }
        public string Previous { get; set; }
        public string Information { get; set; }
        public string MusicNote { get; set; }
        public string Next { get; set; }
        public string Pause { get; set; }
        public string Play { get; set; }
        public string Stop { get; set; }
        public string Window { get; set; }
        public string SettingBrush { get; set; }
        public string SettingCircle { get; set; }
        public string SettingConsole { get; set; }
        public string SettingDisplay { get; set; }
        public string SettingGear { get; set; }
        public string SettingPencil { get; set; }
        public string SettingSound { get; set; }
        public string SettingWorld { get; set; }
        public string SettingWrench { get; set; }
    }

    public enum OsuSection
    {
        PreLoad,
        FadeInPreLoad,
        MainScreen,
    }
    public enum OsuCookieBehaviour
    {
        ClickToOpenTab,
        ClickToAutoSelectPlay,
        ClickToAutoSelectSinglePlayer
    }
    public class EndAnimationPos
    {
        public Thickness Activated;
        public Thickness NonActivated;
        public EndAnimationPos(Thickness activated, Thickness nonActivated)
        {
            Activated = activated;
            NonActivated = nonActivated;
        }
    }
    public class SocketOpreation
    {
        public object State;
        public Socket Socket;
        public byte[] Buffer;
        public int size;

        public SocketOpreation(int size)
        {
            this.size = size;
            Buffer = new byte[this.size];
        }
    }
}

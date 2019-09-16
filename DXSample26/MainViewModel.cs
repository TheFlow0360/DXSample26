namespace DXSample26
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<MasterData>();
            for (int i = 0; i < 25; i++)
            {
                Items.Add(MasterData.CreateDemoDataset());
            }
        }

        public ObservableCollection<MasterData> Items { get; }

        private MasterData _selectedMaster;
        public MasterData SelectedMaster
        {
            get => _selectedMaster;
            set
            {
                _selectedMaster = value;
                OnPropertyChanged();
            }
        }

        private DetailData _selectedDetail;

        public DetailData SelectedDetail
        {
            get => _selectedDetail;
            set
            {
                _selectedDetail = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MasterData
    {
        public String MasterColumnA { get; set; }

        public Int32 MasterColumnB { get; set; }

        public List<DetailData> Details { get; set; } = new List<DetailData>();

        private static Int32 DemoCounter { get; set; }

        public static MasterData CreateDemoDataset()
        {
            DemoCounter++;
            return new MasterData()
            {
                MasterColumnA = "Text " + DemoCounter,
                MasterColumnB = DemoCounter,
                Details = DetailData.CreateDemoDatasets(3, DemoCounter)
            };
        }
    }

    public class DetailData
    {
        public String DetailColumnA { get; set; }

        public Int32 DetailColumnB { get; set; }

        public static List<DetailData> CreateDemoDatasets(Int32 count, Int32 parentNr)
        {
            var list = new List<DetailData>();
            for (var i = 1; i <= count; i++)
            {
                list.Add(new DetailData()
                {
                    DetailColumnA = $"Detailtext {parentNr}.{i}",
                    DetailColumnB = i
                });
            }

            return list;
        }
    }
}
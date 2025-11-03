using System;
using System.Diagnostics;
using Counter.Models;
using Counter.Views;

namespace Counter
{
    public partial class MainPage : ContentPage
    {
        public static MainPage mainPage;

        public AllCounters allCounters = new();
        public string SavePath => Path.Combine(FileSystem.AppDataDirectory, "DataSave.txt");

        public MainPage()
        {
            InitializeComponent();
            mainPage = this;
            LoadCounters();
        }

        private void AddCounterButton(object sender, EventArgs e)
        {
            string name = InputName.Text;
            int number = Convert.ToInt32(InputNumber.Text);

            var model = new Models.Counter(name, number);
            var view = new CounterView(model);

            CounterBox.Children.Add(view);
            allCounters.AddCounters(model);
            allCounters.SaveCounters(SavePath);

            InputName.Text = "";
            InputNumber.Text = "";
        }
        private void LoadCounters()
        {
            allCounters.LoadCountes(SavePath);

            for (int i = 0; i < allCounters.List.Count; i++)
            {
                var model = allCounters.List[i];
                var view = new CounterView(model);
                CounterBox.Children.Add(view);
                view.UpdateView();
            }
        }
        public void SaveDataCounter()
        {
            allCounters.SaveCounters(SavePath);
        }
    }

}

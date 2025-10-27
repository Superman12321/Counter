using System;

namespace Counter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadCounter();
        }
        public static List<CounterView> List = new();
        private void AddCounterButton(object sender, EventArgs e)
        {
            var name = InputName.Text;
            
            var number = Convert.ToInt32(InputNumber.Text);

            var counter = new CounterView(name, number);

            CounterBox.Children.Add(counter);

            List.Add(counter);

            counter.SaveDataCounter();

            //Usuwa nazwę i licznik po dodaniu przycisku
            InputName.Text = "";
            InputNumber.Text = "";
        }

        private void LoadCounter()
        {
            string Data = Path.Combine(FileSystem.AppDataDirectory, "DataSave.txt");

            //Wczytuje plik DataSave.txt
            string[] line = File.ReadAllLines(Data);

            for (int i = 0; i < line.Length; i++)
            {
                var ParseData = line[i].Split(',');

                if (ParseData.Length < 2)
                    continue;

                // Usuwa spacje z nazwy i licznika w jednej linijce pliku DataSave.txt
                string parseName = ParseData[0].Trim();
                int parseNumber = Convert.ToInt32(ParseData[1].Trim());

                var counter = new CounterView(parseName, parseNumber);
                CounterBox.Children.Add(counter);
                List.Add(counter);
            }
        }
    }

}

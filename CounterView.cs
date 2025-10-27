using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Xml;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Collections.Generic;

namespace Counter;

public class CounterView : ContentView
{
    int count = 0;
    private Label nameLabel;
    private string nameCounter;
    public CounterView(string name, int number)
	{
        nameCounter = name;
        count = number;
       
        nameLabel = new Label
        {
            Text = $"{name}",
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        SemanticProperties.SetHeadingLevel(nameLabel, SemanticHeadingLevel.Level1);

        var AddButton = new Button
        {
            Text = "Add",
            WidthRequest = 100
        };

        SemanticProperties.SetHint(AddButton, "Add");

        AddButton.Clicked += AddNumberCounterButton;

        var RemoveButton = new Button
        {
            Text = "Remove",
            WidthRequest = 100
        };

        SemanticProperties.SetHint(RemoveButton, "Remove");

        RemoveButton.Clicked += RemoveNumberCounterButton;

        Content = new VerticalStackLayout
        {
            Spacing = 10,
            Padding = 10,
            Children = { nameLabel, AddButton, RemoveButton}
        };
        
        UpdateCounter();
    }

    public void SaveDataCounter()
    {
        string SavePath = Path.Combine(FileSystem.AppDataDirectory, "DataSave.txt");
        Debug.WriteLine(Path.Combine(FileSystem.AppDataDirectory, "DataSave.txt"));

        //Tworzy obiekt StreamWriter, który otwiera plik pod œcie¿k¹ SavePath i go nadpisuje
        using var counters = new StreamWriter(SavePath, append: false);

        for (int i = 0; i < MainPage.List.Count; i++)
        {
            string line = MainPage.List[i].GetSaveLine();
            counters.WriteLine(line);
        }
    }

    public string GetSaveLine()
    {
        return $"{nameCounter},{count}";
    }

        private void AddNumberCounterButton(object sender, EventArgs e)
    {
        count++;
        SaveDataCounter();
        UpdateCounter();
    }

    private void RemoveNumberCounterButton(object sender, EventArgs e)
    {
        count--;
        SaveDataCounter();
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        if (count == 1)
            nameLabel.Text = $"{nameCounter} {count} time";
        else
            nameLabel.Text = $"{nameCounter} {count} times";

        SaveDataCounter();
    }
}
using Counter.Models;
namespace Counter.Views;

public partial class CounterView : ContentView
{
    private Models.Counter model;
    private Label nameLabel;

    public CounterView(Models.Counter counter)
    {
        model = counter;

        nameLabel = new Label
        {
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };

        var addButton = new Button
        {
            Text = "Add",
            WidthRequest = 100
        };
        addButton.Clicked += AddButton_Clicked;

        var removeButton = new Button
        {
            Text = "Remove",
            WidthRequest = 100
        };
        removeButton.Clicked += RemoveButton_Clicked;

        Content = new VerticalStackLayout
        {
            Spacing = 10,
            Padding = 10,
            Children = { nameLabel, addButton, removeButton }
        };

        UpdateView();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        model.Count++;
        UpdateView();
        MainPage.mainPage.SaveDataCounter();
    }

    private void RemoveButton_Clicked(object sender, EventArgs e)
    {
        model.Count--;
        UpdateView();
        MainPage.mainPage.SaveDataCounter();
    }

    public void UpdateView()
    {
        if (model.Count == 1)
        {
            nameLabel.Text = $"{model.Name} {model.Count} time";
        }
        else
        {
            nameLabel.Text = $"{model.Name} {model.Count} times";
        }
    }
    public Models.Counter GetModel()
    {
        return model;
    }
}
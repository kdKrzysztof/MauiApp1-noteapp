namespace MauiApp1_noteapp.Views;

public partial class About : ContentPage
{
    public About()
    {
        InitializeComponent();
    }
    private async void onLearnMoreClicked(object sender, EventArgs e)
    {
        await Browser.OpenAsync("https://aka.ms/maui");
    }
}
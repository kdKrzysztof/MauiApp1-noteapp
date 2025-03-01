namespace MauiApp1_noteapp;

public partial class About : ContentPage
{
    private async void onLearnMoreClicked(object sender, EventArgs e)
    {
        await Browser.OpenAsync("https://aka.ms/maui");
    }
}
using MauiApp1_noteapp.Models;

namespace MauiApp1_noteapp.Views;

public partial class About : ContentPage
{
    public About()
    {
        InitializeComponent();
    }
    private async void onLearnMoreClicked(object sender, EventArgs e)
    {
        if(BindingContext is AboutModel about)
            await Browser.OpenAsync(about.RedirectUrl);
    }
}
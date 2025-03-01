namespace MauiApp1_noteapp.Views;

public partial class AllNotesView : ContentPage
{
	public AllNotesView()
	{
		InitializeComponent();

		BindingContext = new Models.AllNotesModel();
	}

    protected override void OnAppearing()
    {
		((Models.AllNotesModel)BindingContext).LoadNotes();
    }

	private async void onAddClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(NotePage));
	}

    private async void OnNotesCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
		{
			var note = (Models.NoteModel)e.CurrentSelection[0];

			await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

			notesCollection.SelectedItem = null;
		}
    }
}
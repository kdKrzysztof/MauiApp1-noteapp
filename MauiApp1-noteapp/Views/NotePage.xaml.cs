using System.Threading.Tasks;

namespace MauiApp1_noteapp.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId { set { LoadNote(value); } }
    public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName}.notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
    }

	private async void OnSaveButtonClicked(object Sender, EventArgs e)
	{
		if (BindingContext is Models.NoteModel noteModel)
			File.WriteAllText(noteModel.Filename, noteModel.Text);

		await Shell.Current.GoToAsync("..");
    }

	private async void OnDeleteButtonClicked(object Sender, EventArgs e)
	{
		if (BindingContext is Models.NoteModel noteModel)
		{
			if(File.Exists(noteModel.Filename))
				File.Delete(noteModel.Filename);
		}

		await Shell.Current.GoToAsync("..");
    }

	private void LoadNote(string fileName)
	{
        Models.NoteModel noteModel = new Models.NoteModel();
        noteModel.Filename = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
    }
}
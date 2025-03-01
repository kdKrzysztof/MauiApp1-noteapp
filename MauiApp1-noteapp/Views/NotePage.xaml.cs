namespace MauiApp1_noteapp.Views;

public partial class NotePage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

	public NotePage()
	{
		InitializeComponent();

		if (File.Exists(_fileName))
			TextEditor.Text = File.ReadAllText(_fileName);

		viewNote();
    }

	private void onSaveButtonClicked(object Sender, EventArgs e)
	{
		File.WriteAllText(_fileName, TextEditor.Text);
		viewNote();

    }

	private void onDeleteButtonClicked(object Sender, EventArgs e)
	{
		if (File.Exists(_fileName))
            File.Delete(_fileName);

		TextEditor.Text = "";
		viewNote();

    }

	private void viewNote()
	{
		if (File.Exists(_fileName))
			viewNoteContent.Text = File.ReadAllText(_fileName);
		else
			viewNoteContent.Text = "";
    }
}
using System.Collections.ObjectModel;

namespace MauiApp1_noteapp.Models;

internal class AllNotesModel
{
    public ObservableCollection<NoteModel> NotesCC { get; set; } = new ObservableCollection<NoteModel>();

    public AllNotesModel() => 
        LoadNotes();

    public void LoadNotes()
    {
        NotesCC.Clear();

        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<NoteModel> notes = Directory.EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(filename => new NoteModel
            {
                Filename = filename,
                Text = File.ReadAllText(filename),
                Date = File.GetCreationTime(filename)
            })
            .OrderBy(e => e.Date);

        foreach (NoteModel note in notes)
            NotesCC.Add(note);
    }
}

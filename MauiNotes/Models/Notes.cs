using System;
using System.Collections.ObjectModel;

namespace MauiNotes.Models;

public class Notes
{
    public ObservableCollection<Note> AllNotes { get; set; } = new ObservableCollection<Note>();

    public Notes() =>
        LoadNotes();

    public void LoadNotes()
    {
        AllNotes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<Note> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new Note()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetLastWriteTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (Note note in notes)
            AllNotes.Add(note);
    }
}

using DemoLibrary.Mementos;
using DemoLibrary.Originators;

namespace DemoLibrary.Caretakes;

/// <summary>
/// The Caretaker doesn't depend on the Concrete Memento class. Therefore, it
/// doesn't have access to the originator's state, stored inside the memento.
/// It works with all mementos via the base Memento interface.
/// </summary>
public class DocumentCaretaker
{
    private List<IDocumentMemento> _mementos = new List<IDocumentMemento>();
    private DocumentEditor _editor;

    public DocumentCaretaker(DocumentEditor editor)
    {
        this._editor = editor;
    }

    public void Backup()
    {
        Console.WriteLine("\nCaretaker: Saving DocumentEditor's state...");
        this._mementos.Add(this._editor.Save());
    }

    public void Undo()
    {
        if (this._mementos.Count == 0)
        {
            return;
        }

        var memento = this._mementos.Last();
        this._mementos.Remove(memento);

        Console.WriteLine("Caretaker: Restoring state to: " + memento.GetName());

        try
        {
            this._editor.Restore(memento);
        }
        catch (Exception)
        {
            this.Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("\nCaretaker: Here's the list of mementos:");

        foreach (var memento in this._mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}
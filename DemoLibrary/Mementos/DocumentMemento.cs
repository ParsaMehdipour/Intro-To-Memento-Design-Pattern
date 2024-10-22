namespace DemoLibrary.Mementos;

/// <summary>
/// The Concrete Memento contains the infrastructure for storing the
/// Originator's state.
/// </summary>
public class DocumentMemento : IDocumentMemento
{
    private readonly DocumentState state;
    private readonly DateTime date;

    public DocumentMemento(string text, string fontName, int fontSize, ConsoleColor textColor)
    {
        this.state = new DocumentState(text, fontName, fontSize, textColor);
        this.date = DateTime.Now;
    }

    public DocumentState GetState()
    {
        return state;
    }

    public string GetName()
    {
        return $"{date} / ({state.Text.Substring(0, Math.Min(state.Text.Length, 9))})...";
    }

    public DateTime GetDate()
    {
        return date;
    }
}
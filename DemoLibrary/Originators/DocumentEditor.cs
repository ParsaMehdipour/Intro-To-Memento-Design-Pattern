using DemoLibrary.Mementos;

namespace DemoLibrary.Originators;

/// <summary>
/// The Originator holds some important state that may change over time. It
/// also defines a method for saving the state inside a memento and another
/// method for restoring the state from it.
/// </summary>
public class DocumentEditor
{
    private string text;
    private string fontName;
    private int fontSize;
    private ConsoleColor textColor;

    public DocumentEditor(string initialText)
    {
        this.text = initialText;
        this.fontName = "Arial";
        this.fontSize = 12;
        this.textColor = ConsoleColor.White;
        Console.WriteLine($"DocumentEditor: Initial text is: {initialText}");
    }

    // Business logic that changes state
    public void EditText()
    {
        Console.WriteLine("\nDocumentEditor: Making text changes...");
        this.text = GenerateRandomText(20);
        Console.WriteLine($"DocumentEditor: Text changed to: {text}");
    }

    public void ChangeFont()
    {
        Console.WriteLine("\nDocumentEditor: Changing font settings...");
        string[] fonts = { "Arial", "Times New Roman", "Calibri", "Verdana" };
        this.fontName = fonts[new Random().Next(fonts.Length)];
        this.fontSize = new Random().Next(10, 20);
        Console.WriteLine($"DocumentEditor: Font changed to {fontName}, size {fontSize}");
    }

    private string GenerateRandomText(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    // Save state to memento
    public IDocumentMemento Save()
    {
        return new DocumentMemento(text, fontName, fontSize, textColor);
    }

    // Restore state from memento
    public void Restore(IDocumentMemento memento)
    {
        if (!(memento is DocumentMemento))
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        var state = memento.GetState();
        this.text = state.Text;
        this.fontName = state.FontName;
        this.fontSize = state.FontSize;
        this.textColor = state.TextColor;

        Console.WriteLine($"\nDocumentEditor: State restored to: {text}");
    }
}

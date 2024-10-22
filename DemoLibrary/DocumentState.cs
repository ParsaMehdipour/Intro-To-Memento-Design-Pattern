namespace DemoLibrary;

/// <summary>
/// Document State class to hold the state
/// </summary>
public class DocumentState
{
    public string Text { get; private set; }
    public string FontName { get; private set; }
    public int FontSize { get; private set; }
    public ConsoleColor TextColor { get; private set; }

    public DocumentState(string text, string fontName, int fontSize, ConsoleColor textColor)
    {
        Text = text;
        FontName = fontName;
        FontSize = fontSize;
        TextColor = textColor;
    }
}
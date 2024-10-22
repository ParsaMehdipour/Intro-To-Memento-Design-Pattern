// Client code
using DemoLibrary.Caretakes;
using DemoLibrary.Originators;

DocumentEditor editor = new DocumentEditor("Initial document text.");
DocumentCaretaker caretaker = new DocumentCaretaker(editor);

caretaker.Backup();
editor.EditText();

caretaker.Backup();
editor.ChangeFont();

caretaker.Backup();
editor.EditText();

Console.WriteLine();
caretaker.ShowHistory();

Console.WriteLine("\nClient: Let's rollback!\n");
caretaker.Undo();

Console.WriteLine("\nClient: Once more!\n");
caretaker.Undo();
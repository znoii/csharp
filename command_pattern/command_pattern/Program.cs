using System;
using System.Collections.Generic;

abstract class ICommand
{
    protected TextEditor unit;
    protected string text;
    public abstract void Execute();
    public abstract void Undo();
}

class InsertTextCommand : ICommand
{
    public InsertTextCommand(TextEditor unit, string text)
    {
        this.unit = unit;
        this.text = text;
    }

    public override void Execute()
    {
        unit.InsertText(text);
    }

    public override void Undo()
    {
        unit.DeleteText(text.Length);
    }
}

class DeleteTextCommand : ICommand
{
    private int length;
    private string deletedText;

    public DeleteTextCommand(TextEditor unit, int length)
    {
        this.unit = unit;
        this.length = length;
    }

    public override void Execute()
    {
        this.deletedText = unit.DeleteText(length);
    }

    public override void Undo()
    {
        unit.InsertText(deletedText);
    }
}

class TextEditor
{
    private string text = "";
    private Stack<ICommand> History = new Stack<ICommand>();

    public string Text => text;

    public void InsertText(string text)
    {
        this.text += text;
        Console.WriteLine($"Ввод: {this.text}");
    }

    public string DeleteText(int length)
    {
        if (length > text.Length)
        {
            length = text.Length;  // огр
        }

        string deletedText = text.Substring(text.Length - length);
        text = text.Substring(0, text.Length - length);
        Console.WriteLine($"Удаление: {text}");
        return deletedText;
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        History.Push(command);
    }

    public void Undo()
    {
        if (History.Count > 0)
        {
            ICommand lastCommand = History.Pop();
            lastCommand.Undo();
            Console.WriteLine($"Отмена операции: {text}");
        }
        else
        {
            Console.WriteLine("Пустая история.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        TextEditor editor = new TextEditor();

        ICommand insertHello = new InsertTextCommand(editor, "ввожу ");
        editor.ExecuteCommand(insertHello);

        ICommand deleteText = new DeleteTextCommand(editor, 1);
        editor.ExecuteCommand(deleteText);

        editor.Undo();

        ICommand insertWorld = new InsertTextCommand(editor, "текст ");
        editor.ExecuteCommand(insertWorld);

        

        ICommand insertAgain = new InsertTextCommand(editor, "опять");
        editor.ExecuteCommand(insertAgain);

        
    }
}

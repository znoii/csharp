using System;
using System.Collections.Generic;

public interface IDocumentComponent
{
    void Add(IDocumentComponent component);
    void Remove(IDocumentComponent component);
    void Display(int indentLevel);
}
public class Paragraph : IDocumentComponent
{
    private string text;

    public Paragraph(string text)
    {
        this.text = text;
    }

    public void Add(IDocumentComponent component)
    {
        throw new InvalidOperationException("параграф это простой текст. нельзя добавить");
    }

    public void Remove(IDocumentComponent component)
    {
        throw new InvalidOperationException("параграф это простой текст. нельзя удалить");
    }

    public void Display(int indentLevel)
    {
        Console.WriteLine(new string(' ', indentLevel * 2) + text);
    }
}
public class Section : IDocumentComponent
{
    private string title;
    private List<IDocumentComponent> components = new List<IDocumentComponent>();

    public Section(string title)
    {
        this.title = title;
    }

    public void Add(IDocumentComponent component)
    {
        components.Add(component);
    }

    public void Remove(IDocumentComponent component)
    {
        components.Remove(component);
    }

    public void Display(int indentLevel)
    {
        Console.WriteLine(new string(' ', indentLevel * 2) + "Section: " + title);
        foreach (var component in components)
        {
            component.Display(indentLevel + 1);
        }
    }
}
public class Document : IDocumentComponent
{
    private List<IDocumentComponent> sections = new List<IDocumentComponent>();

    public void Add(IDocumentComponent component)
    {
        if (component is Section)  
        {
            sections.Add(component);
        }
        else
        {
            throw new InvalidOperationException("нет, только секции");
        }
    }

    public void Remove(IDocumentComponent component)
    {
        sections.Remove(component);
    }

    public void Display(int indentLevel)
    {
        Console.WriteLine("документ 1");
        foreach (var section in sections)
        {
            section.Display(indentLevel + 1);
        }
    }
}



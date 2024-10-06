using System;

// Компонент
public interface IComponent
{
    string Operation();
}

// Конкретний компонент
public class ConcreteComponent : IComponent
{
    public string Operation()
    {
        return "ConcreteComponent";
    }
}

// Декоратор
public abstract class Decorator : IComponent
{
    protected IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public virtual string Operation()
    {
        return _component.Operation();
    }
}

// Конкретний декоратор
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component) { }

    public override string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component) { }

    public override string Operation()
    {
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        IComponent component = new ConcreteComponent();
        Console.WriteLine("Client: I've got a simple component:");
        Console.WriteLine(component.Operation());

        component = new ConcreteDecoratorA(component);
        Console.WriteLine("\nClient: Now I've got a decorated component:");
        Console.WriteLine(component.Operation());

        component = new ConcreteDecoratorB(component);
        Console.WriteLine("\nClient: Now I've got a decorated component:");
        Console.WriteLine(component.Operation());
    }
}

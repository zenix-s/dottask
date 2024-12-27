using Domain.Abstractions;

namespace Domain.Enums;

public class Priority : Enumeration<Priority>
{
    public static Priority None => new NonePriority();
    public static Priority Low => new LowPriority();
    public static Priority Medium => new MediumPriority();
    public static Priority High => new HighPriority();
    public static Priority Critical => new CriticalPriority();

    private Priority(int value, string name)
        : base(value, name)
    {
    }
    
    private sealed class NonePriority() : Priority(0, "None");
    private sealed class LowPriority() : Priority(1, "Low");
    private sealed class MediumPriority() : Priority(2, "Medium");
    private sealed class HighPriority() : Priority(3, "High");
    private sealed class CriticalPriority() : Priority(4, "Critical");
    

}
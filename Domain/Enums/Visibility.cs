using Domain.Abstractions;

namespace Domain.Enums;

public class Visibility : Enumeration<Visibility>
{
    public static Visibility Public => new PublicVisibility();
    public static Visibility Private => new PrivateVisibility();

    private Visibility(int value, string name)
        : base(value, name)
    {
    }

    private sealed class PublicVisibility() : Visibility(0, "Public");

    private sealed class PrivateVisibility() : Visibility(1, "Private");
}
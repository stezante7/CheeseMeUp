namespace CheeseMeUp.Core;

public interface IComplimentService
{
    IReadOnlyList<string> History { get; }
    Task<string> PickCompliment();
}
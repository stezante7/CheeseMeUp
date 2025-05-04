using Newtonsoft.Json;

namespace CheeseMeUp.Core;

public class ComplimentService : IComplimentService
{
    private readonly List<string> _complimentsHistory = [];

    private readonly Random _random = new();
    private IList<string> _availableCompliments;

    public ComplimentService(string complimentsPath = "Assets/cheese_compliments.json")
    {
        _availableCompliments = LoadComplimentsFromFile(complimentsPath);
    }

    public IReadOnlyList<string> History => _complimentsHistory.ToList();

    public Task<string> PickCompliment()
    {
        if (_availableCompliments.Count == 0) ResetComplimentPool();

        var pickedIdx = _random.Next(0, _availableCompliments.Count);
        var compliment = _availableCompliments[pickedIdx];

        _complimentsHistory.Add(compliment);
        _availableCompliments.RemoveAt(pickedIdx);

        return Task.FromResult(compliment);
    }

    private IList<string> LoadComplimentsFromFile(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("Compliment json file not found", path);

        return JsonConvert.DeserializeObject<IList<string>>(File.ReadAllText(path))
               ?? throw new InvalidOperationException("Compliment file is empty or malformed");
    }

    private void ResetComplimentPool()
    {
        _availableCompliments = new List<string>(_complimentsHistory);
        _complimentsHistory.Clear();
    }
}
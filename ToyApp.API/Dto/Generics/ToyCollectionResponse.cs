using System.Linq;

namespace ToyApp.API.Dto.Generics;

public class ToyCollectionResponse<T>
{
    private IEnumerable<T> _items = new List<T>();

    // the items requested
    public required IEnumerable<T> Items { get => _items; set => _items = value; }
    //the number retrieved
    public int Count { get { return Items.ToList().Count; } }
    public required int Offset { get; set; }
}
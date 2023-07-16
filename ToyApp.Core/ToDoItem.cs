namespace ToyApp.Core;
public class TodoItem
{
    public string Title { get; set; }
    private DateTime _dueDate;
    public DateTime DueDate
    {
        get { return _dueDate; }
        set
        {
            var currentDate = DateTime.UtcNow;
            if (value < currentDate)
            {
                throw new InvalidDataException("Due date is in the past");
            }
            _dueDate = value;
        }
    }

    public TodoItem(string title, DateTime dueDate)
    {
        Title = title;
        _dueDate = dueDate;
    }
}

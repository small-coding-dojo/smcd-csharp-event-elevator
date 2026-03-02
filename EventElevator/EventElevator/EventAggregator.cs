namespace EventElevator;

public class EventAggregator
{
    private readonly List<ButtonPressedEvent> _events = [];
    private static EventAggregator? _aggregator;


    private EventAggregator()
    {
    }

    public void Add(ButtonPressedEvent theEvent)
    {
        _events.Add(theEvent);
    }

    public static EventAggregator GetEventAggregator()
    {
        if (_aggregator is null)
        {
            _aggregator = new EventAggregator();
        }
        return _aggregator;
    }

    public ButtonPressedEvent? LastEvent()
    {
        return _events.LastOrDefault(); 
    }
}

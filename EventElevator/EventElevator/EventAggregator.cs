namespace EventElevator;

public class EventAggregator
{
    private readonly List<ButtonPressedEvent> _events = [];
    private static EventAggregator? _aggregator;
    private readonly List<Action<ButtonPressedEvent>> _eventHandlers = [];


    private EventAggregator()
    {
    }

    public void Add(ButtonPressedEvent theEvent)
    {
        _events.Add(theEvent);
        foreach (var handler in _eventHandlers)
        {
            handler(theEvent);
        }
    }

    public void Subscribe(Type eventType, Action<ButtonPressedEvent> eventHandler)
    {
        _eventHandlers.Add(eventHandler);
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

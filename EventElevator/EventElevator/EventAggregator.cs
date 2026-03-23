namespace EventElevator;

public class EventAggregator
{
    private readonly List<ButtonPressedEvent> _events = [];
    private readonly List<MoveUpEvent> _move_up_events = [];
    private static EventAggregator? _aggregator;
    private readonly List<Action<ButtonPressedEvent>> _eventHandlers = [];
    private readonly List<Action<MoveUpEvent>> _move_up_eventHandlers = [];


    private EventAggregator()
    {
    }

    // Notify about button press
    public void Add(ButtonPressedEvent theEvent)
    {
        _events.Add(theEvent);
        foreach (var handler in _eventHandlers)
        {
            handler(theEvent);
        }
    }

    // Notify about button press
    public void Add(MoveUpEvent theEvent)
    {
        _move_up_events.Add(theEvent);
        foreach (var handler in _move_up_eventHandlers)
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

    //todo: remove me
    public ButtonPressedEvent? LastEvent()
    {
        return _events.LastOrDefault(); 
    }
}

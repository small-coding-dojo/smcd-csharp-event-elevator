namespace EventElevator;

public class EventAggregator
{
    private readonly List<ElevatorEvent> _events = [];
    private static EventAggregator? _aggregator;
    private readonly List<Action<ElevatorEvent>> _eventHandlers = [];
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
            // TODO: wenn parameter ButtonPressedEvent, dann ...
            handler(theEvent);
        }
    }

    // Notify about button press
    public void Add(MoveUpEvent theEvent)
    {
        _events.Add(theEvent);
        foreach (var handler in _eventHandlers)
        {
            handler(theEvent);
        }
    }
    
    public void Subscribe<EventType>(Action<ElevatorEvent> eventHandler)
    {
        
        // TODO: tech debt: extract subclass needed
        if (typeof(EventType) == typeof(MoveUpEvent))
        {
            _move_up_eventHandlers.Add(eventHandler);
            _eventHandlers.Add(eventHandler);
        }
        else
        {
            _eventHandlers.Add(eventHandler);
        }
    }

    public static EventAggregator GetEventAggregator()
    {
        if (_aggregator is null)
        {
            _aggregator = new EventAggregator();
        }
        return _aggregator;
    }
}

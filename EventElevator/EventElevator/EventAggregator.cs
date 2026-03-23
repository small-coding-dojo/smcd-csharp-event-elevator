namespace EventElevator;

public class EventAggregator
{
    private readonly List<ElevatorEvent> _events = [];
    private static EventAggregator? _aggregator;

    private readonly Dictionary<Type, List<Action<ElevatorEvent>>> _newEventHandlers = new();


    private EventAggregator()
    {
    }

    // Notify about button press
    public void Add(ButtonPressedEvent theEvent)
    {
        _events.Add(theEvent);
        var handlers = _newEventHandlers.GetValueOrDefault(typeof(ButtonPressedEvent))?? [];
        foreach (var handler in handlers)
        {
            handler(theEvent);
         
        }
    }

    // Notify about button press
    public void Add(MoveUpEvent theEvent)
    {
        _events.Add(theEvent);
        var handlers = _newEventHandlers.GetValueOrDefault(typeof(MoveUpEvent))?? [];
        foreach (var handler in handlers)
        {
            handler(theEvent);
        }
    }
    
    public void Subscribe<EventType>(Action<ElevatorEvent> eventHandler)
    {
        // TODO: write test for more than one event handler ( and fix )
        _newEventHandlers.Add(typeof(EventType), [eventHandler]);
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

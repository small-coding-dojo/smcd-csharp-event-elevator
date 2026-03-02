namespace EventElevator;

public class ElevatorController
{
    public void PushFloorButton(int targetFloor)
    {
        var eventAggregator = EventAggregator.GetEventAggregator();

        eventAggregator.Add(new ButtonPressedEvent(targetFloor));
    }
}
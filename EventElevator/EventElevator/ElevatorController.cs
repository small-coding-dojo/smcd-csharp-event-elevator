namespace EventElevator;

public class ElevatorController
{
    public int CurrentFloor { get; private set; }

    public void PushFloorButton(int targetFloor)
    {
        var eventAggregator = EventAggregator.GetEventAggregator();

        eventAggregator.Add(new ButtonPressedEvent(targetFloor));
    }

    public void TellCurrentFloor(int currentFloor)
    {
        CurrentFloor = currentFloor;
    }

    public void EvaluateDirection(int targetFloor)
    {
    }
}

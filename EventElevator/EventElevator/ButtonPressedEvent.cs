namespace EventElevator;

public class ButtonPressedEvent(int _targetFloor) : ElevatorEvent
{
    public int TargetFloor { get; set; } = _targetFloor;
}
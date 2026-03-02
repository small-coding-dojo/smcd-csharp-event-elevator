namespace EventElevator;

public class ButtonPressedEvent(int _targetFloor)
{
    public int TargetFloor { get; set; } = _targetFloor;
}
namespace EventElevator;

public class MoveUpEvent : ElevatorEvent
{
    public int TargetFloor { get; set; }
}
namespace EventElevator.Tests;

// shitty name
public class UnitTest1
{
    // shitty name
    [Fact]
    public void Test1()
    {
        var controller = new ElevatorController();

        var eventAggregator = EventAggregator.GetEventAggregator();
        var targetFloor = 5;
        
        controller.PushFloorButton(targetFloor);
        var lastEvent = eventAggregator.LastEvent();

        Assert.Equal(typeof(ButtonPressedEvent), lastEvent!.GetType());
        Assert.Equal(targetFloor, lastEvent.TargetFloor);
    }

    // shitty name
    [Fact]
    public void Test2()
    {
        var controller = new ElevatorController();

        controller.TellCurrentFloor(0);
        
        Assert.Equal(0, controller.CurrentFloor);
    }
}

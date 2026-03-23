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
        var actualTargetFloor = 0;
        eventAggregator.Subscribe<ButtonPressedEvent>((theEvent) =>
        {
            actualTargetFloor = ((ButtonPressedEvent) theEvent).TargetFloor;
        });
        var expectedTargetFloor = 5;
        
        controller.PushFloorButton(expectedTargetFloor);

        Assert.Equal(expectedTargetFloor, actualTargetFloor);
    }

    // shitty name
    [Fact]
    public void Test2()
    {
        var controller = new ElevatorController();

        controller.TellCurrentFloor(0);
        
        Assert.Equal(0, controller.CurrentFloor);
    }
    
    // shitty name
    // Skip = "we want to redesign first to test on eventHandlers and not on lastEvents"
    [Fact]
    public void Test3()
    {
        var controller = new ElevatorController();
        var eventAggregator = EventAggregator.GetEventAggregator();
        var actualTargetFloor = 0;
        
        // we subscribe to expected event
        eventAggregator.Subscribe<MoveUpEvent>((theEvent) =>
        {
            actualTargetFloor = ((MoveUpEvent)theEvent).TargetFloor;
        });
        var targetFloor = 5;
        var expectedTargetFloor = 5;
        
        // Tell the controller where we are
        controller.TellCurrentFloor(0);
        
        // Tell the controller where we want to go (floor 5)
        controller.EvaluateDirection(targetFloor);
        
        // Assert we received move up event for target floor 5
        Assert.Equal(expectedTargetFloor, actualTargetFloor);
    }
}
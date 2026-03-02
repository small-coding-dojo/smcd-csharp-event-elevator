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
        eventAggregator.Subscribe(typeof(ButtonPressedEvent), (theEvent) =>
        {
            actualTargetFloor = theEvent.TargetFloor;
        });
        var expectedTargetFloor = 5;
        
        controller.PushFloorButton(expectedTargetFloor);
        var lastEvent = eventAggregator.LastEvent(); // TODO: (see test3) remove me

        Assert.Equal(expectedTargetFloor, actualTargetFloor);
        Assert.Equal(typeof(ButtonPressedEvent), lastEvent!.GetType());
        Assert.Equal(expectedTargetFloor, lastEvent.TargetFloor);
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
    [Fact(Skip = "we want to redesign first to test on eventHandlers and not on lastEvents")]
    public void Test3()
    {
        var controller = new ElevatorController();
        var eventAggregator = EventAggregator.GetEventAggregator();
        var targetFloor = 5;
        
        controller.TellCurrentFloor(0);
        controller.EvaluateDirection(targetFloor);
        var lastEvent = eventAggregator.LastEvent(); // We don't need it
        /*
         * Event triggers eventHandler
         * 
         */

        Assert.Equal(typeof(MoveUpEvent), lastEvent!.GetType());
        Assert.Equal(targetFloor, lastEvent.TargetFloor);
    }
}
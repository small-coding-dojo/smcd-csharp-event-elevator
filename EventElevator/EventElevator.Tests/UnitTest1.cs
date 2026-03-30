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

    [Fact]
    public void SequenceAndNumberOfSubscriptions()
    {
        var controller = new ElevatorController();
        var eventAggregator = EventAggregator.GetEventAggregator();
        var moveUpTargetFloor = -1;
        var buttonPressedTargetFloor = -1;
        var countReceivedEvents = 0;
        
        // Subscribe to: MoveUp and ButtonPressed
        eventAggregator.Subscribe<MoveUpEvent>(theEvent =>
        {
            moveUpTargetFloor = ((MoveUpEvent)theEvent).TargetFloor;
            ++countReceivedEvents;
            Assert.Equal(1, countReceivedEvents);
        });
        
        eventAggregator.Subscribe<MoveUpEvent>(theEvent =>
        {
            moveUpTargetFloor = 42;
            ++countReceivedEvents;
            Assert.Equal(2, countReceivedEvents);
        });
        
        eventAggregator.Subscribe<ButtonPressedEvent>(theEvent =>
        {
            buttonPressedTargetFloor = ((ButtonPressedEvent)theEvent).TargetFloor;
            ++countReceivedEvents;
            Assert.Equal(3, countReceivedEvents);
        });
        
        // act
        eventAggregator.Add(new MoveUpEvent(){TargetFloor = 5});
        eventAggregator.Add(new ButtonPressedEvent(5));
        
        Assert.Equal(3, countReceivedEvents);
    }
}
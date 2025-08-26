using System;

namespace EngineRoom.Examples.Interfaces
{
    public interface ITimeService
    {
        event Action SecondPassed;
        
        int SecondsPassed { get; }
    }
}
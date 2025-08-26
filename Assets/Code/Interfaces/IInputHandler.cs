namespace EngineRoom.Examples.Interfaces
{
    public interface IInputHandler
    {
        float AimDirection { get; }
        bool IsFireButtonPressed { get; }
    }
}
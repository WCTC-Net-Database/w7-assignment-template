using W7_assignment_template.Services;

namespace W7_assignment_template.Interfaces;

public interface IRoomFactory
{
    IRoom CreateRoom(string roomType, OutputManager outputManager);
}

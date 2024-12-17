using ECHO.SharedKernel.Application.Contracts.Enums;

namespace ECHO.SharedKernel.Application.Contracts.Interfaces;

public interface IMessageTracker
{
    TrackerKind Kind { get; }
    Task<bool> HasProcessedAsync(long eventId, string trackerName);
    Task MarkAsProcessedAsync(long eventId, string trackerName);
}
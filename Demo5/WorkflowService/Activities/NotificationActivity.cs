using Dapr.Workflow;

namespace WorkflowService.Activities;

public class NotificationActivity : WorkflowActivity<NotificationInput, NotificationResult>
{
    private readonly ILogger<NotificationActivity> _logger;

    public NotificationActivity(ILogger<NotificationActivity> logger)
    {
        _logger = logger;
    }

    public override Task<NotificationResult> RunAsync(
        WorkflowActivityContext context, 
        NotificationInput input)
    {
        _logger.LogInformation("Validation Result: {ValidationMessage}", input.ValidationMessage);
        _logger.LogInformation("Storage Result: {StorageMessage}", input.StorageMessage);

        return Task.FromResult(new NotificationResult(true, "Notification sent successfully."));
    }
}

public record NotificationInput(string ValidationMessage, string StorageMessage);
public record NotificationResult(bool Success, string Message);

using Dapr.Workflow;
using WorkflowService.Activities;
using WorkflowService.Models;

namespace WorkflowService.Workflows;

public class ProfileWorkflow : Workflow<SocialProfileDetails, ProfileWorkflowResult>
{
    public override async Task<ProfileWorkflowResult> RunAsync(
        WorkflowContext context, 
        SocialProfileDetails input)
    {
        // Step 1: Validate the profile
        var validationResult = await context.CallActivityAsync<ValidationResult>(
            nameof(ValidationActivity),
            input);

        if (!validationResult.IsValid)
        {
            return new ProfileWorkflowResult(
                false, 
                validationResult.Message, 
                null);
        }

        // Step 2: Store the profile
        var storageResult = await context.CallActivityAsync<StorageResult>(
            nameof(StorageActivity),
            input);

        // Step 3: Send notification
        var notificationInput = new NotificationInput(
            validationResult.Message, 
            storageResult.Message);

        var notificationResult = await context.CallActivityAsync<NotificationResult>(
            nameof(NotificationActivity),
            notificationInput);

        return new ProfileWorkflowResult(
            true,
            "Workflow completed successfully.",
            input.Id);
    }
}

public record ProfileWorkflowResult(bool Success, string Message, string? ProfileId);

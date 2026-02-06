using Dapr.Client;
using Dapr.Workflow;
using WorkflowService.Models;

namespace WorkflowService.Activities;

public class StorageActivity : WorkflowActivity<SocialProfileDetails, StorageResult>
{
    private const string StateStoreComponentName = "mystatestore";
    private readonly DaprClient _daprClient;

    public StorageActivity(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public override async Task<StorageResult> RunAsync(
        WorkflowActivityContext context, 
        SocialProfileDetails input)
    {
        await _daprClient.SaveStateAsync(
            StateStoreComponentName,
            input.Id,
            input);

        return new StorageResult(true, $"Profile {input.Id} saved to state store.");
    }
}

public record StorageResult(bool Success, string Message);

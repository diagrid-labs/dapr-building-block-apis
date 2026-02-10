using Dapr.Client;
using Dapr.Workflow;
using WorkflowService.Models;

namespace WorkflowService.Activities;

public class StorageActivity : WorkflowActivity<SocialProfileDetails, StorageResult>
{
    private const string StateStoreComponentName = "mystatestore";
    private readonly DaprClient _daprClient;
    private readonly ILogger<StorageActivity> _logger;

    public StorageActivity(DaprClient daprClient, ILogger<StorageActivity> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    public override async Task<StorageResult> RunAsync(
        WorkflowActivityContext context, 
        SocialProfileDetails input)
    {
        _logger.LogInformation("Saving profile {ProfileId} to state store.", input.Id);

        //  😱 Simulate some processing time so I have enough time to stop this application 
        // to demonstrate resilience of stateful workflows.
        Thread.Sleep(7000);
        
        await _daprClient.SaveStateAsync(
            StateStoreComponentName,
            input.Id,
            input);

        return new StorageResult(true, $"Profile {input.Id} saved to state store.");
    }
}

public record StorageResult(bool Success, string Message);

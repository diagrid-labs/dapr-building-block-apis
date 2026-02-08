using Dapr.Workflow;
using WorkflowService.Activities;
using WorkflowService.Models;
using WorkflowService.Workflows;

var builder = WebApplication.CreateBuilder(args);

// Register Dapr Client
builder.Services.AddDaprClient();

// Register Dapr Workflow
builder.Services.AddDaprWorkflow(options =>
{
    // Register workflow
    options.RegisterWorkflow<ProfileWorkflow>();

    // Register activities
    options.RegisterActivity<ValidationActivity>();
    options.RegisterActivity<StorageActivity>();
    options.RegisterActivity<NotificationActivity>();
});

var app = builder.Build();

app.MapPost("/start", async (
    SocialProfileDetails profileDetails,
    DaprWorkflowClient workflowClient) =>
{
    var instanceId = $"PROF-{Guid.NewGuid()}";
    
    await workflowClient.ScheduleNewWorkflowAsync(
        name: nameof(ProfileWorkflow),
        instanceId: instanceId,
        input: profileDetails);

    return Results.Accepted(value: new { instanceId });
});

app.MapGet("/status/{instanceId}", async (
    string instanceId,
    DaprWorkflowClient workflowClient) =>
{
    var state = await workflowClient.GetWorkflowStateAsync(instanceId);

    if (state is null)
    {
        return Results.NotFound(new { message = "Workflow not found" });
    }

    return Results.Ok(new
    {
        status = state.RuntimeStatus.ToString(),
        createdAt = state.CreatedAt,
        lastUpdatedAt = state.LastUpdatedAt,
        result = state.ReadOutputAs<ProfileWorkflowResult>()
    });
});

app.Run();

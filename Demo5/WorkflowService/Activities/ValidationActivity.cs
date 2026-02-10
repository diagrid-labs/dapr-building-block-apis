using Dapr.Workflow;
using WorkflowService.Models;
using WorkflowService.Validators;

namespace WorkflowService.Activities;

public class ValidationActivity : WorkflowActivity<SocialProfileDetails, ValidationResult>
{
    private readonly SocialProfileDetailsValidator _validator;
    private readonly ILogger<ValidationActivity> _logger;
    
    public ValidationActivity(SocialProfileDetailsValidator validator, ILogger<ValidationActivity> logger)
    {
        _validator = validator;
        _logger = logger;
    }
    
    public override Task<ValidationResult> RunAsync(
        WorkflowActivityContext context, 
        SocialProfileDetails input)
    {
        _logger.LogInformation("Validating profile {ProfileId}.", input.Id);
        
        var result = _validator.Validate(input);

        return Task.FromResult(new ValidationResult(
            result.IsValid,
            result.IsValid 
                ? "Validation successful" 
                : string.Join("; ", result.Errors.Select(e => e.ErrorMessage))));
    }
}

public record ValidationResult(bool IsValid, string Message);

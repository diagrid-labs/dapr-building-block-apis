using Dapr.Workflow;
using WorkflowService.Models;
using WorkflowService.Validators;

namespace WorkflowService.Activities;

public class ValidationActivity : WorkflowActivity<SocialProfileDetails, ValidationResult>
{
    public override Task<ValidationResult> RunAsync(
        WorkflowActivityContext context, 
        SocialProfileDetails input)
    {
        var validator = new SocialProfileDetailsValidator();
        var result = validator.Validate(input);

        return Task.FromResult(new ValidationResult(
            result.IsValid,
            result.IsValid 
                ? "Validation successful" 
                : string.Join("; ", result.Errors.Select(e => e.ErrorMessage))));
    }
}

public record ValidationResult(bool IsValid, string Message);

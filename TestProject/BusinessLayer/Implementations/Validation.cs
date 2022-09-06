using System.ComponentModel.DataAnnotations;

namespace TestProject.BusinessLayer.Implementations;

public static class Validation
{
	public static void ValidationModel<TModel>(TModel model)
			where TModel : class
	{
		ValidationContext context = new(model);
		List<ValidationResult> results = new();
		if (Validator.TryValidateObject(model, context, results, true) == false) {
			throw new Exception(GetValidationError(results));
		}
	}
	private static string GetValidationError(List<ValidationResult> results)
	{
		string result = "";
		foreach (ValidationResult validationResult in results) {
			result += $"{validationResult}\n";
		}
		return result;
	}

}
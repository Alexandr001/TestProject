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
			throw new ValidationException(GetValidationError(results));
		}
	}
	public static void IdVerification(int id)
	{
		const int MIN_VALUE_ID = 1;
		if (id < MIN_VALUE_ID) {
			throw new Exception("The field Id must be between 1 and 2147483647.");
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
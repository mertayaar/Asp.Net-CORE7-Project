using System;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLayer.ValidationRules
{
	public class PortfolioValidator : AbstractValidator<Portfolio>
	{
		public PortfolioValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Project name cannot be empty!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image URL cannot be empty!");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Project URL cannot be empty!");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Completion cannpt be empty!");
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform URL cannot be empty!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Project name must be at least 5 charachers!");
            RuleFor(x => x.Value).LessThanOrEqualTo(100).WithMessage("Complation must be between 0 and 100!");
        }

     
    }
}


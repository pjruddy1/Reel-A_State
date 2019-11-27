using FluentValidation;
using Reel_A_StateData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.Validators
{
    public class EstateValidator : AbstractValidator<EstateProperties>
    {


        public EstateValidator()
        {
            RuleFor(p => p.Address).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Can't be Empty")
                .Length(5,75).WithMessage("{PropertyName} should be between 5,75 characters");
            RuleFor(p => p.City).Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty().WithMessage("{PropertyName} Can't be Empty")
                 .Length(5, 75).WithMessage("{PropertyName} should be between 2,25 characters");
            RuleFor(p => p.State).Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty().WithMessage("{PropertyName} Can't be Empty")
                 .Length(2, 2).WithMessage("{PropertyName} should be between 2,25 characters");
            RuleFor(p => p.Zipcode).Cascade(CascadeMode.StopOnFirstFailure)
                .LessThan(99999).WithMessage("{PropertyName} Must Be Valid")
                .GreaterThan(10000).WithMessage("{PropertyName} Must Be Valid");
            RuleFor(p => p.SqrFeet).Cascade(CascadeMode.StopOnFirstFailure)
                .LessThan(99999).WithMessage("{PropertyName} Must Be Valid")
                .GreaterThan(100).WithMessage("{PropertyName} Must Be Valid");
            RuleFor(p => p.Price).Cascade(CascadeMode.StopOnFirstFailure)
                .LessThan(1000000000).WithMessage("{PropertyName} Must Be Valid")
                .GreaterThan(100).WithMessage("{PropertyName} Must Be Valid");
            RuleFor(p => p.Bedrooms).Cascade(CascadeMode.StopOnFirstFailure)
                .LessThan(100).WithMessage("{PropertyName} Must Be Valid")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} Must Be Valid");
            RuleFor(p => p.Bathrooms).Cascade(CascadeMode.StopOnFirstFailure)
                .LessThan(100).WithMessage("{PropertyName} Must Be Valid")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} Must Be Valid");
            RuleFor(p => p.Fireplace).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("{PropertyName} Can't be Empty");
            RuleFor(p => p.Pool).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("{PropertyName} Can't be Empty");
        }
    }
}

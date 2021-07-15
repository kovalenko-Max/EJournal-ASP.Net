using EJournalDAL.Models;
using FluentValidation;
using System;
using System.Linq;

namespace EJournal_ASP.Net.Validators
{
    public class ExerciseValidator : AbstractValidator<Exercise>
    {
        public ExerciseValidator()
        {
            RuleFor(exercise => exercise.Id)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(exercise => exercise.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 40).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid. {PropertyName} length must be from 2 to 40");
            RuleFor(exercise => exercise.IdGroup)
                .NotEmpty().WithMessage("{PropertyName} is Empty");
        }
    }
}

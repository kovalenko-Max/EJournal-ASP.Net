using EJournalDAL.Models;
using FluentValidation;
using System;
using System.Linq;

namespace EJournal_ASP.Net.Validators
{
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(lesson => lesson.Id)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(lesson => lesson.Topic)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 40).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid. {PropertyName} length must be from 2 to 40");
            RuleFor(lesson => lesson.IdGroup)
                .NotEmpty().WithMessage("{PropertyName} is Empty");
        }
    }
}

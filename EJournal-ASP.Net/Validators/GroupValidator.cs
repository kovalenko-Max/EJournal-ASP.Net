using EJournalDAL.Models;
using FluentValidation;

namespace EJournal_ASP.Net.Validators
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(group => group.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(group => group.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(1, 50).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid. {PropertyName} length must be from 1 to 50");
        }
    }
}

using EJournalDAL.Models;
using FluentValidation;

namespace EJournal_ASP.Net.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(comment => comment.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(comment => comment.CommentText)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 300).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 2 to 200");
            RuleFor(comment => comment.CommentType)
                .Length(2, 20).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 2 to 20");
        }
    }
}

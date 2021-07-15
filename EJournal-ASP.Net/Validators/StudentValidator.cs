using EJournalDAL.Models;
using FluentValidation;
using System;
using System.Linq;

namespace EJournal_ASP.Net.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {

        public StudentValidator()
        {
            RuleFor(student => student.Id)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(student => student.Name)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .Must(BeAValidNameAndLastName).WithMessage("First Name contains Invalid Charators")
                    .Length(2, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 2 to 30");
            RuleFor(student => student.Surname)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .Must(BeAValidNameAndLastName).WithMessage("Last Name contains Invalid Charators")
                    .Length(2, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 2 to 30");
            RuleFor(student => student.Email)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .Length(8, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 8 to 30");
            RuleFor(student => student.City)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty().WithMessage("{PropertyName} is Empty")
                     .Length(3, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 3 to 30");
            RuleFor(student => student.Git)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty().WithMessage("{PropertyName} is Empty")
                     .Length(8, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 8 to 30");
            RuleFor(student => student.Phone)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty().WithMessage("{PropertyName} is Empty")
                     .Length(11, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 11 to 30");
            RuleFor(student => student.Ranking)
                     .NotEmpty().WithMessage("{PropertyName} is Empty");
            RuleFor(student => student.TeacherAssessment)
                     .NotEmpty().WithMessage("{PropertyName} is Empty");
            RuleFor(student => student.AgreementNumber)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .Length(2, 30).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid. {PropertyName} length must be from 2 to 30");
        }
        public bool BeAValidNameAndLastName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }

    }
}

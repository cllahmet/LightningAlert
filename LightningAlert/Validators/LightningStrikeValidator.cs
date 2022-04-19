using FluentValidation;
using LightningAlert.Data.Enums;
using LightningAlert.Model;
using System;

namespace LightningAlert.Validators
{
    public class LightningStrikeValidator : AbstractValidator<LightningStrike>
    {
        public LightningStrikeValidator()
        {
            RuleFor(s => s.latitude)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Latitude is Empty")
                .GreaterThan(-180).WithMessage("Latitude is Invalid")
                .LessThan(180).WithMessage("Latitude is Invalid");

            RuleFor(s => s.longitude)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Longitude is Empty")
                .GreaterThan(-180).WithMessage("Longitude is Invalid")
                .LessThan(180).WithMessage("Longitude is Invalid");

            RuleFor(s => s.strikeTime)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("StrikeTime is Empty")
                .GreaterThan(0).WithMessage("StrikeTime is Invalid");

            RuleFor(s => s.receivedTime)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ReceivedTime is Empty")
                .GreaterThan(0).WithMessage("ReceivedTime is Invalid");

            RuleFor(s => s.flashType)
                .Cascade(CascadeMode.Stop)
                .Must(checkFlashType).WithMessage("FlashType is Invalid");
        }

        protected bool checkFlashType(int value)
        {
            return Enum.IsDefined(typeof(FlashTypes), value);
        }
    }
}

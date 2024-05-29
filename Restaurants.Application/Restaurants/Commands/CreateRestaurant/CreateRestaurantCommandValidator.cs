﻿

using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please choose from the valid categories.");


        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("Please Provide a valid email address");


        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please provide a valid postal code (XX-XXX)");

    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.VehicleImage.Create
{
    public class CreateVehicleImageValidator : AbstractValidator<CreateVehicleImageCommand>
    {
        private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

        private static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".gif",
            ".webp"
        };

        private static readonly string[] AllowedContentTypes =
        {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/webp"
        };

        private static readonly string[] AllowedImageTypes =
        {
            "Front",
            "Back",
            "Left",
            "Right",
            "Side",
            "Interior",
            "Other"
        };

        public CreateVehicleImageValidator()
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty()
                .WithMessage("Vehicle ID is required.");

            RuleFor(x => x.Images)
                .NotNull()
                .WithMessage("At least one image is required.")
                .Must(images => images != null && images.Count > 0)
                .WithMessage("At least one image is required.")
                .Must(images => images != null && images.Count <= 10)
                .WithMessage("You can upload a maximum of 10 images.");

            RuleForEach(x => x.Images)
                .ChildRules(image =>
                {
                    image.RuleFor(x => x.ImageFile)
                        .NotNull()
                        .WithMessage("Image file is required.");

                    image.RuleFor(x => x.ImageFile.Length)
                        .GreaterThan(0)
                        .WithMessage("Image file cannot be empty.")
                        .LessThanOrEqualTo(MaxFileSize)
                        .WithMessage("Image file size cannot exceed 5 MB.");

                    image.RuleFor(x => x.ImageFile.FileName)
                        .NotEmpty()
                        .WithMessage("Image file name is required.")
                        .Must(IsAllowedExtension)
                        .WithMessage("Only JPG, JPEG, PNG, GIF, and WebP files are allowed.");

                    image.RuleFor(x => x.ImageFile.ContentType)
                        .Must(IsAllowedContentType)
                        .WithMessage("Only JPEG, PNG, GIF, and WebP images are allowed.");

                    image.RuleFor(x => x.ImageType)
                        .NotEmpty()
                        .WithMessage("Image type is required.")
                        .Must(type => AllowedImageTypes.Contains(type))
                        .WithMessage($"Image type must be one of: {string.Join(", ", AllowedImageTypes)}");
                });

            // Ensure only one primary image
            RuleFor(x => x.Images)
                .Must(images => images.Count(img => img.IsPrimary) <= 1)
                .WithMessage("Only one image can be marked as primary.");
        }

        private static bool IsAllowedExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            var extension = Path.GetExtension(fileName);

            return AllowedExtensions.Contains(
                extension,
                StringComparer.OrdinalIgnoreCase);
        }

        private static bool IsAllowedContentType(string contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType))
                return false;

            return AllowedContentTypes.Contains(
                contentType,
                StringComparer.OrdinalIgnoreCase);
        }
    }
}

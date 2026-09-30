using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CustomerFiles.Create
{
    public class CreateCustomerFileValidation : AbstractValidator<CreateCustomerFilesCommand>
    {
        private const long MaxFileSize = 5 * 1024 * 1024;

        private static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

        private static readonly string[] AllowedContentTypes =
        {
            "image/jpeg",
            "image/png"
        };

        public CreateCustomerFileValidation()
        {
            RuleFor(x => x.CustomerDocumentId)
            .NotEmpty().WithMessage("CustomerDocumentId is required.");

            RuleFor(x => x.Files)
                .NotNull()
                .WithMessage("At least one file is required.")
                .Must(files => files != null && files.Count > 0)
                .WithMessage("At least one file is required.")
                .Must(files => files != null && files.Count <= 5)
                .WithMessage("You can upload a maximum of 5 files.");

            RuleForEach(x => x.Files)
               .ChildRules(file =>
               {
                   file.RuleFor(x => x)
                       .NotNull()
                       .WithMessage("File is required.");

                   file.RuleFor(x => x.Length)
                       .GreaterThan(0)
                       .WithMessage("File cannot be empty.")
                       .LessThanOrEqualTo(MaxFileSize)
                       .WithMessage("File size cannot exceed 5 MB.");

                   file.RuleFor(x => x.FileName)
                       .NotEmpty()
                       .WithMessage("File name is required.");

                   file.RuleFor(x => x.FileName)
                       .Must(IsAllowedExtension)
                       .WithMessage("Only JPG, JPEG, and PNG files are allowed.");

                   file.RuleFor(x => x.ContentType)
                       .Must(IsAllowedContentType)
                       .WithMessage("Only JPEG and PNG images are allowed.");
               });
        }

        private static bool IsAllowedExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            return AllowedExtensions.Contains(
                extension,
                StringComparer.OrdinalIgnoreCase);
        }

        private static bool IsAllowedContentType(string contentType)
        {
            return AllowedContentTypes.Contains(
                contentType,
                StringComparer.OrdinalIgnoreCase);
        }
    }
}

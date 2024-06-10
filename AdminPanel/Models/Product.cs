using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace AdminPanel.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nazwa produktu musi zawierać od 3 do 20 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wartość produktu jest wymagana.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Wartość produktu musi być liczbą dodatnią.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Waga produktu jest wymagana.")]
        [Range(0.01, 100, ErrorMessage = "Waga produktu musi być liczbą dodatnią mniejszą niż 100.")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Data ważności jest wymagana.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Data ważności musi być w przyszłości.")]
        public DateTime ExpireDate { get; set; }

        [Required(ErrorMessage = "Typ zatrzymania jest wymagany.")]
        public TypesOfMicroclimate TypeOfDetention { get; set; }

        [Required(ErrorMessage = "Typ produktu jest wymagany.")]
        public TypesOfProduct TypeOfProduct { get; set; }
        public int ShelfId { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                if (date < DateTime.Now.AddDays(2))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}


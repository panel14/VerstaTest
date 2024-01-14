using System.ComponentModel.DataAnnotations;

namespace OrderTest.Models
{
    public class OrderModel : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string SenderCity { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string SenderAddress { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string RecipientCity { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string RecipientAddress { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(0, 999999)]
        public double Weight { get; set; }

        [Required]
        public DateTime PickUpDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PickUpDate.Ticks < DateTime.Now.Ticks)
            {
                yield return new ValidationResult("Дата забора заказа должна быть больше текущей даты", ["PickUpDate"]);
            }
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Globalization;
using System.Text.Json;
using dummy.Models;

namespace dummy.Models
{
    [Table("shift_table")]
    public class Shift
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("shift_id")]
        public int shiftId { get; set; }

        [Required(ErrorMessage = "Shift job description is required")]
        [Column("job")]
        public string shiftJob { get; set; }

        [Required(ErrorMessage = "Start time can't be null")]
        [Column("start_time")]
        [DataType(DataType.DateTime)]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        [Future(ErrorMessage = "Enter a Valid Start Time")]
        public DateTime shiftStartTime { get; set; }

        [Required(ErrorMessage = "End time can't be null")]
        [Column("end_time")]
        [DataType(DataType.DateTime)]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime shiftEndTime { get; set; }

        [Column("requested_user_id")]
        public int? requested_user_id { get; set; }

        [ForeignKey("user_id")]
        public User user { get; set; }

        public bool IsValidShiftTimeRange()
        {
            if (shiftStartTime != null && shiftEndTime != null)
            {
                return shiftStartTime < shiftEndTime;
            }
            return true;
        }
    }

    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();

            // Parse the ISO 8601 formatted string
            if (!DateTime.TryParseExact(dateString, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime result))
            {
                throw new JsonException($"Invalid DateTime format: {dateString}. Expected format: yyyy-MM-ddTHH:mm:ss.fffZ");
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
        }
    }

    public class FutureAttribute : ValidationAttribute
    {
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dt)
            {
                if (dt.ToUniversalTime() >= DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? "The date must be in the future.");
                }
            }
            return new ValidationResult("Invalid DateTime format.");
        }
    }

}

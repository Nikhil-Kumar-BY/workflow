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
            return DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }

    public class FutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            return dt > DateTime.Now;
        }
    }

}

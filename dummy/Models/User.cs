using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dummy.Models
{
    [Table("user_table")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int userId { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [Column("user_name")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Column("user_email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column("user_password")]
        public string password { get; set; }

        [Required(ErrorMessage = "User role is required")]
        [Column("user_role")]
        public UserRole userRole { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Column("user_gender")]
        public Gender gender { get; set; }

        [Column("last_login_time_stamp")]
        public DateTime? lastLoginTimeStamp { get; set; }

        public enum UserRole
        {
            ADMIN,
            SITEMANAGER,
            EMPLOYEE
        }

        public enum Gender
        {
            MALE,
            FEMALE,
            OTHER
        }
    
}
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountForm.Models
{
	public class AccountModel
	{
		[Key]
		public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime FormFillDate { get; set; }


        [DataType(DataType.Time)]
        public DateTime FormFillTime { get; set; }

        [Required]
		public string Title { get; set; }

		[Required]
		public string FirstName { get; set; }

        public string MiddleName { get; set; }


        [Required]
		public string LastName { get; set; }

        

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Date of Birth")]
		public DateTime DateOfBirth { get; set; }

		public int Age { get; set; }

		[Required]
		[Display(Name = "Mobile Number")]
		[StringLength(10, MinimumLength = 10)]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Mobile Number must be numeric.")]
		public string MobileNumber { get; set; }

		[Required]
		[Display(Name = "Email Address")]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Sex")]
		public string Sex { get; set; }

		[Required]
		[Display(Name = "Type of Account")]
		public string AccountType { get; set; }

		[Required]
		[Display(Name = "STD Code")]
		public string StdCode { get; set; }

		[Required]
		[Display(Name = "Telephone")]
		public string Telephone { get; set; }

		public int StateId { get; set; }

		public int CityId { get; set; }

		public int BranchId { get; set; }

		public int LanguageId { get; set; }

		// Navigation properties
		[ForeignKey("StateId")]
		public State State { get; set; }

		[ForeignKey("CityId")]
		public City City { get; set; }

		[ForeignKey("BranchId")]
		public Branch Branch { get; set; }

		[ForeignKey("LanguageId")]
		public Language Language { get; set; }




	}

	

  
}

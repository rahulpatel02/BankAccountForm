using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountForm.Models
{
	public class Branch
	{

		[Key]
		public int Branch_code { get; set; }
		public string Branch_name { get; set;}

		[ForeignKey("Branch_City_code")]

		public int Branch_City_code { get; set;}

	}
}

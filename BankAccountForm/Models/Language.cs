using System.ComponentModel.DataAnnotations;

namespace BankAccountForm.Models
{
	public class Language
	{
		[Key]
		public int Laanguage_Code { get; set; }

		public string Language_Name { get; set;}
	}
}

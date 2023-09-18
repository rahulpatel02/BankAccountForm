using System.ComponentModel.DataAnnotations;

namespace BankAccountForm.Models
{
	public class State
	{
		[Key]
		public int StateCode { get; set; }
		public string StateName { get; set; }

	}
}

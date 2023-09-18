using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountForm.Models
{
	public class City
	{
		[Key]
		public int CityCode { get; set; }
		public string CityName { get; set; }

		[ForeignKey("City_Stat_Code")]
		public string City_Stat_Code { get; set; }

	}
}

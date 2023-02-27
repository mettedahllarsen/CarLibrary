using System.Transactions;
using System.Xml.Linq;

namespace CarLibrary
{
	public class Car
	{
		public int Id { get; set; }
		public string? Model { get; set; }
		public int Price { get; set; }
		public string? LicensePlate { get; set; }


		public override string ToString()
		{
			return Id + " " + Model + " " + Price + " " + LicensePlate;
		}

		/// <summary>
		/// ValidateModel() throws 1 out of 2 Exceptions, if Model is null or less 4 characters. 
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public void ValidateModel()
		{
			if (Model == null)
				throw new ArgumentNullException("Invalid model. Must not be null. Your input: " + Model);
			if (Model.Length <= 4)
				throw new ArgumentException("Invalid model. Must be at least 4 characters. Your input: " + Model);
		}

		/// <summary>
		/// ValidatePrice() throws an Exception, if Price is less than 1.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public void ValidatePrice()
		{
			if (Price < 1)
				throw new ArgumentOutOfRangeException("Invalid price. Must be at least 1. Your input: " + Price);
		}

		/// <summary>
		/// ValidateLicensePlate() throws 1 out of 2 Exceptions, if LicensePlate is null, less than 2 or larger than 7. 
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public void ValidateLicensePlate()
		{
			if (LicensePlate == null)
				throw new ArgumentNullException("Invalid license plate. Must not be null. Your input: " + LicensePlate);
			if (LicensePlate.Length < 2 || LicensePlate.Length > 7)
				throw new ArgumentOutOfRangeException("Invalid license plate. Must be between 2-7 characters. The length of your input: " + LicensePlate.Length);
		}

		/// <summary>
		/// Call all validate methods collectively.   
		/// </summary>
		public void ValidateAll()
		{
			ValidateModel();
			ValidatePrice();
			ValidateLicensePlate();
		}
	}
}
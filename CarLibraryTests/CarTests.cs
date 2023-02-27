using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary.Tests
{
	[TestClass()]
	public class CarTests
	{
		//ToStringTest()-case
		Car validToString = new Car() { Id = 1, Model = "Model", Price = 2, LicensePlate = "AB12345" };

		//ValidateModelTest()-cases
		Car validModel = new Car() { Id = 2, Model = "Model", Price = 2, LicensePlate = "AB12345" };
		Car invalidModelNull = new Car() { Id = 3, Model = null, Price = 2, LicensePlate = "AB12345" };
		Car invalidModelEmpty = new Car() { Id = 4, Model = "", Price = 2, LicensePlate = "AB12345" };

		//ValidatePriceTest()-cases
		Car validPrice = new Car() { Id = 5, Model = "Model", Price = 2, LicensePlate = "AB12345" };
		Car invalidPrice = new Car() { Id = 6, Model = "Model", Price = 0, LicensePlate = "AB12345" };

		//ValidateLicensePlateTest()-cases
		Car validLicensePlateMin = new Car() { Id = 7, Model = "Model", Price = 2, LicensePlate = "AB" };
		Car validLicensePlateMax = new Car() { Id = 8, Model = "Model", Price = 2, LicensePlate = "AB12345" };
		Car invalidLicensePlateNull = new Car() { Id = 9, Model = "Model", Price = 2, LicensePlate = null };
		Car invalidLicensePlateLessThan = new Car() { Id = 10, Model = "Model", Price = 2, LicensePlate = "A" };
		Car invalidLicensePlateGreaterThan = new Car() { Id = 11, Model = "Model", Price = 2, LicensePlate = "AB123456" };

		//ValidateAll()-
		Car validCar = new Car() { Id = 12, Model = "Model", Price = 2, LicensePlate = "AB12345" };
		
		[TestMethod()]
		public void ToStringTest()
		{
			Assert.AreEqual("1 Model 2 AB12345", validToString.ToString());
		}

		[TestMethod()]
		public void ValidateModelTest()
		{
			validModel.ValidateModel();
			Assert.ThrowsException<ArgumentNullException>(() => invalidModelNull.ValidateModel());
			Assert.ThrowsException<ArgumentException>(() => invalidModelEmpty.ValidateModel());
		}

		[TestMethod()]
		public void ValidatePriceTest()
		{
			validPrice.ValidatePrice();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidPrice.ValidatePrice());
		}

		[TestMethod()]
		public void ValidateLicensePlateTest()
		{
			validLicensePlateMin.ValidateLicensePlate();
			validLicensePlateMax.ValidateLicensePlate();
			Assert.ThrowsException<ArgumentNullException>(() => invalidLicensePlateNull.ValidateLicensePlate());
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidLicensePlateLessThan.ValidateLicensePlate());
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidLicensePlateGreaterThan.ValidateLicensePlate());
		}

		[TestMethod()]
		public void ValidateAllTest()
		{
			validCar.ValidateAll();

			Assert.ThrowsException<ArgumentNullException>(() => invalidModelNull.ValidateModel());
			Assert.ThrowsException<ArgumentException>(() => invalidModelEmpty.ValidateModel());

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidPrice.ValidatePrice());

			Assert.ThrowsException<ArgumentNullException>(() => invalidLicensePlateNull.ValidateLicensePlate());
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidLicensePlateLessThan.ValidateLicensePlate());
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidLicensePlateGreaterThan.ValidateLicensePlate());
		}
	}
}
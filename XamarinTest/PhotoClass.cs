using System;

namespace XamarinTest
{
	public class PhotoClass
	{
		public PhotoClass()
		{
		}

		public static string ImageURL()
		{
			Random random = new Random();
			int number = random.Next(10000);
			return "https://unsplash.it/300/?random&random_number=" + number.ToString();
		}
	}
}


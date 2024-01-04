//namespace PizzaOrderCenterAPI.Services
//{
//	public enum EnrollmentEligibility
//	{
//		None = 0,
//		Provisional = 1,
//		Eligible = 2,
//	}
//	public class Elector
//	{
//		private int _age;
//		public int Age
//		{
//			get => _age;
//			private set
//			{
//				if (value < 0)
//				{ throw new ArgumentException("Age cannot be negative"); }
//				_age = value;
//			}
//		}
//		public Elector(int age)
//		{
//			Age = age;
//		}
//		public EnrollmentEligibility EnrollmentEligibility
//		{
//			get
//			{
//				if (Age < 0)
//					return EnrollmentEligibility.None;
//				else if (Age < 17)
//					return EnrollmentEligibility.Provisional;
//				else return EnrollmentEligibility.Eligible;
//			}
//		}
//	}
//}

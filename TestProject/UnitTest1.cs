//using FluentAssertions;

//namespace TestProject
//{
//	public class UnitTest1
//	{
//		[Fact]
//		public void Divide_ByZero_ThrowsDivideByZeroException()
//		{
//			// Arrange
//			var myClass = new MyClass();

//			// Act & Assert
//			var ex = Assert.Throws<DivideByZeroException>(() => myClass.Divide(10, 0));

//			// Assert
//			Assert.Equal("Cannot divide by zero.", ex.Message);
//		}
//		[Fact]
//		public void Divide_NotThrowingException()
//		{
//			// Arrange
//			var myClass = new MyClass();

//			// Act & Assert (checking for no exception)
//			var ex = Record.Exception(() => myClass.Divide(10, 2));

//			// Assert
//			Assert.Null(ex);
//		}

//		[Theory]
//		[InlineData(10, 10)]
//		[InlineData(10, 22)]
//		public void Divide_ByZero_ThrowsDivideByZeroException(int v1, int v2)
//		{
//			// Arrange
//			var myClass = new MyClass();

//			myClass.Invoking(x=> x.Divide(1,1)).Should().Throw<DivideByZeroException>();

//			// Act & Assert using Fluent Assertions
//			myClass.Invoking(x => x.Divide(v1, v2))
//				.Should().Throw<DivideByZeroException>()
//				.WithMessage("Cannot divide by zero.");
//		}

//		[Fact]
//		public void Divide_NotThrowingException()
//		{
//			// Arrange
//			var myClass = new MyClass();

//			// Act & Assert using Fluent Assertions
//			myClass.Invoking(x => x.Divide(10, 2)).Should().NotThrow();
//		}
//	}

//	internal class MyClass
//	{
//		public MyClass()
//		{
//		}

//		internal void Divide(int v1, int v2)
//		{
//			var x = v1 / 0;
//		}
//	}
//}
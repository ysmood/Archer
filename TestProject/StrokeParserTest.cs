using ys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for StrokeParserTest and is intended
    ///to contain all StrokeParserTest Unit Tests
    ///</summary>
	[TestClass()]
	public class StrokeParserTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for RunCommonCommand
		///</summary>
		[TestMethod()]
		[DeploymentItem("Archer.exe")]
		public void RunCommonCommandTest()
		{
			string stroke = "bAck"; // TODO: Initialize to an appropriate value
			bool expected = true; // TODO: Initialize to an appropriate value
			bool actual;
			actual = StrokeParser_Accessor.RunCommonCommand(stroke);
			Assert.AreEqual(expected, actual);
		}
	}
}

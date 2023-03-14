using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App03;
using System;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class TestStudentGrades
    {

        private readonly StudentGrades converter = new StudentGrades();


        private int[] testMarks;
        public TestStudentGrades()
        {
            testMarks = new int[]
            {
                10, 20, 30, 40, 50, 60, 70, 80, 90, 100
            };
        }

        [TestMethod]
        public void TestCovert0ToGradeF()
        {
            //Arrange
            Grades expectedGrade = Grades.F;
            //Act
            Grades actualGrade = converter.ConvertToGrade(0);
            //Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }
        [TestMethod]
        public void TestCovert39ToGradeF()
        {
            //Arrange
            Grades expectedGrade = Grades.F;
            //Act
            Grades actualGrade = converter.ConvertToGrade(39);
            //Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestCalculateMean()
        {


            converter.Marks = testMarks;

            double expectedMean = 55.0;

            converter.CalculateStats();

            Assert.AreEqual(expectedMean, converter.Mean);
        }

        [TestMethod]
        public void TestGradeProfile()
        {
            // Arrange
            converter.Marks = testMarks;
            // Act
            converter.CalculateGradeProfile();

            bool expectedProfile;

            expectedProfile = ((converter.GradeProfile[0] == 3) &&
            (converter.GradeProfile[1] == 1) &&
            (converter.GradeProfile[2] == 1) &&
            (converter.GradeProfile[3] == 1) &&
            (converter.GradeProfile[4] == 4));
            // Assert
            Assert.IsTrue(expectedProfile);

        }

        [TestMethod]    
        public void TestCalculateMin()
        {
            //Arrange
            converter.Marks = testMarks;
            int expectedMin = 10;
            
            //Act
            converter.CalculateStats();

            //Assert
            Assert.AreEqual(expectedMin, converter.Minimum);
        }
    }
}
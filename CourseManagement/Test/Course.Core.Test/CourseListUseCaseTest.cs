using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coures.Core.Gateways;
using CourseManagement.EF;
using Coures.Core.UseCases;
using Coures.Core.ViewModels;

namespace Coures.Core.Test
{
    /// <summary>
    /// Summary description for CourseListUseCaseTest
    /// </summary>
    [TestClass]
    public class CourseListUseCaseTest
    {
        public CourseListUseCaseTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 

        FakeDataBase dataBase = new FakeDataBase();


        [TestInitialize()]
        public void MyTestInitialize() {

            List<Course> courseList = new List<Course>();
            courseList.Add(new Course { Id = 1, Description ="My Test Course 1", Memo ="Memo Course 1", Name = "Test", Price = 100 });
            courseList.Add(new Course { Id = 2, Description = "My Test Course 2", Memo = "Memo Course 2", Name = "Test2", Price = 1000 });
            courseList.Add(new Course { Id = 3, Description = "My Test Course 3", Memo = "Memo Course 3", Name = "Test3", Price = 101 });
            dataBase.Add(courseList);

        }



        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_List_All_Course_Use_Case()
        {
            IDataAccess<Course> dataAccess = new  FakeCourseDataAccess(dataBase);

            CourseHandler handler = new CourseHandler(dataAccess);

            List<CourseViewModel> vms =  handler.List();

            int actual = vms.Count;

            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Query_Course_Use_Case_By_Given_Id_2()
        {
            IDataAccess<Course> dataAccess = new FakeCourseDataAccess(dataBase);

            CourseHandler handler = new CourseHandler(dataAccess);

            CourseEditModel vm = handler.QueryById(2);

            string actual = vm.Name;

            string expected = "Test2";
            
            Assert.AreEqual(expected, actual);

        }
    }

    internal class FakeDataBase
    {
        private List<Course> course;

        public FakeDataBase()
        {
            this.course = new List<Course>();
        }

        public List<Course> GetDataBase() {
            return this.course;
        }

        internal void Add(List<Course> courseList)
        {
            course.AddRange(courseList);
        }
    }
}

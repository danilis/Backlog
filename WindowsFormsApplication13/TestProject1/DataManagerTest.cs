using WindowsFormsApplication13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DataManagerTest and is intended
    ///to contain all DataManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataManagerTest
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

        /*
         *******************************    Sprint    **********************************************
        */
        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintAddNewSprintTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            DateTime start = DateTime.Parse("14.4.13");
            DateTime end = DateTime.Parse("14.5.13");
            int actual;
            actual = target.SprintAddNewSprint(start, end);
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetAllExpectedHoursTeest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 14; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetAllExpectedHours();
            Assert.AreEqual(expected, actual);
        }


        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetAllRemainHoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 6; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetAllRemainHours();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetNumberOfWorkHoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 8; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetNumberOfWorkHours();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetPassedWorkingDaysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 3; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetPassedWorkingDays();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetPassedAllDaysTesr()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 24; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetPassedAllDays();
            Assert.AreEqual(expected, actual);
        }


        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetRemainWorkingDaysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetRemainWorkingDays();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetEndingDayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Parse("20.1.13"); // TODO: Initialize to an appropriate value
            DateTime actual;
            actual = target.SprintGetEndingDay();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        [TestMethod()]
        public void SprintGetAllWorkingDaysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime[] expected = new DateTime[3]; // TODO: Initialize to an appropriate value
            expected[0] = DateTime.Parse("1.12.12");
            expected[1] = DateTime.Parse("3.12.12");
            expected[2] = DateTime.Parse("20.1.13");
            DateTime[] actual;
            actual = target.SprintGetAllWorkingDays();
            CollectionAssert.AreEqual(expected, actual);
        }


        /////////////////////////////////////    ok      /////////////////////////////////////////
        /// <summary>
        ///A test for SprintGetLengthAllDays
        ///</summary>
        [TestMethod()]
        public void SprintGetLengthAllDays()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 50; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetLengthAllDays();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        /// <summary>
        ///A test for SprintGetLengthWorkingDays
        ///</summary>
        [TestMethod()]
        public void SprintGetLengthWorkingDaysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 3; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetLengthWorkingDays();
            Assert.AreEqual(expected, actual);
        }


        /////////////////////////////////////    ok      /////////////////////////////////////////
        /// <summary>
        ///A test for SprintGetTableLength
        ///</summary>
        [TestMethod()]
        public void SprintGetTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 2; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetTableLength();
            Assert.AreEqual(expected, actual);
        }

        /////////////////////////////////////    ok      /////////////////////////////////////////
        /// <summary>
        ///A test for get_sprint_all_work_hours
        ///</summary>
        [TestMethod()]
        public void Sprintget_all_sprint_work_hoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 8; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetNumberOfWorkHours();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////////  ok  ////////////////////////////////////
        /// <summary>
        ///A test for get_all_sprint_days
        ///</summary>
        [TestMethod()]
        public void SprintGetAllDaysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime[] expected = new DateTime[4]; // TODO: Initialize to an appropriate value
            expected[0] = DateTime.Parse("01.12.2012");
            expected[1] = DateTime.Parse("02.12.2012");
            expected[2] = DateTime.Parse("03.12.2012");
            expected[3] = DateTime.Parse("20.01.2013");
            DateTime[] actual;
            actual = target.SprintGetAllDays();
            CollectionAssert.AreEqual(expected, actual);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////////   ok   //////////////////////////////////////////////////
        /// <summary>
        ///A test for get_sprint_length_working_daysTest
        ///</summary>
        [TestMethod()]
        public void Sprintget_sprint_length_working_daysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 3; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetLengthWorkingDays();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /////////////////////////////////////////////   ok    ///////////////////////////////////////
        /// <summary>
        ///A test for get_sprint_beggining_day
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication13.exe")]
        public void Sprintget_sprint_beggining_dayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Parse("01.12.2012"); // TODO: Initialize to an appropriate value
            DateTime actual;
            actual = target.SprintGetBegginingDay();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////   ok   ///////////////////////////////////////////
        /// <summary>
        ///A test for get_sprint_all_remain_hours
        ///</summary>
        [TestMethod()]
        public void Sprintget_all_sprint_remain_hoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 4; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetAllRemainHours();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ////////////// not comleted. need to be tested again   ///////////////////////////////////
        //////////////  returns passed days -1 (was checked early in the mornning)
        /// <summary>
        ///A test for get_sprint_all_passed_days
        ///</summary>
        [TestMethod()]
        public void Sprintget_sprint_passed_all_daysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 23; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetPassedAllDays();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }


        ///////////////////////////////  ok   ///////////////////////////////////////
        /// <summary>
        ///A test for get_sprint_remain_days
        ///</summary>
        [TestMethod()]
        public void Sprintget_sprint_remain_daysTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 27; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetRemainDays();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////////   ok   ///////////////////////////////////////////////
        /// <summary>
        ///A test for get_ending_day
        ///</summary>
        [TestMethod()]
        public void Sprintget_ending_dayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Parse("20.01.2013"); ; // TODO: Initialize to an appropriate value
            DateTime actual;
            actual = target.SprintGetEndingDay();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////   ok    ////////////////////////////////////////////
        /// <summary>
        ///A test for get_all_expected_hours
        ///</summary>
        [TestMethod()]
        public void Sprintget_all_sprint_expected_hoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 12; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SprintGetAllExpectedHours();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /*
         *******************************    Story    **********************************************
        */

        // its dificcult to insert image to DB
        /// <summary>
        ///A test for add_new_story
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication13.exe")]
        // *********************************   doesnt work   ******************************************
        public void Storyadd_new_storyTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            // int ID = 0; // TODO: Initialize to an appropriate value
            int Story_Owner = 0; // TODO: Initialize to an appropriate value
            DateTime Current_Sprint = DateTime.Parse("01.12.2012"); ; // TODO: Initialize to an appropriate value
            int Work_Status = 0; // TODO: Initialize to an appropriate value
            int Priority = 0; // TODO: Initialize to an appropriate value
            string Description = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            string str = " ";
            Image pic = null;
            actual = target.StoryAddNewStory(Story_Owner, Current_Sprint, str, pic, Description, Priority, Work_Status);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetStoryTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.StoryGetStoryTableLength();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetOwnerIDTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 1; 
            int actual;
            actual = target.StoryGetOwnerID(3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StorySetOwnerIDTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.StorySetOwnerID(3,1,6);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetCurrentSprintTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Parse("1.12.12");
            DateTime actual;
            actual = target.StoryGetCurrentSprint();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetCurrentSprintForStoryIDTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Parse("14.2.13");
            DateTime actual;
            actual = target.StoryGetCurrentSprintForStoryID(3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StorySetCurrentSprintTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            DateTime day = DateTime.Parse("14.2.13");
            int actual;
            actual = target.StorySetCurrentSprint(3, day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetStoryDemoDesTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            string expected = "fignia";
            string actual;
            actual = target.StoryGetStoryDemoDes(3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StorySetStoryDemoDesTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected =0;
            int actual;
            actual = target.StorySetStoryDemoDes(3, "ne fignia");
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetStoryDescriptionTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            string expected = "toje fignia";
            string actual;
            actual = target.StoryGetStoryDescription(3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StorySetStoryDescriptionTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.StorySetStoryDescription(3, "hz");
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetStoryPriorityTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 1;
            int actual;
            actual = target.StoryGetStoryPriority(3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StorySetStoryPriorityTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.StorySetStoryPriority(3, 2);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StorySetStoryWorkStatusTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.StorySetStoryWorkStatus(3,1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetStoryWorkStatusTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 1;
            int actual;
            actual = target.StoryGetStoryWorkStatus(3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void StoryGetStoriesIDForStoryOwnerTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int[] expected = {3};
            int[] actual;
            actual = target.StoryGetStoriesIDForStoryOwner(6);
            CollectionAssert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /*
         *******************************    Task    **********************************************
        */

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        /// <summary>
        ///A test for add_new_task
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication13.exe")]
        public void Taskadd_new_taskTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            // int ID = 0; // TODO: Initialize to an appropriate value
            int Task_Owner = 1; // TODO: Initialize to an appropriate value
            int Story_ID = 3; // TODO: Initialize to an appropriate value
            string Description = " "; // TODO: Initialize to an appropriate value
            int Priority = 2; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.TaskAddNewTask(Story_ID, Priority, Description, Task_Owner);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskGetTaskTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 2;
            int actual;
            actual = target.TaskGetTaskTableLength();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskSetTaskStoryIDTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.TaskSetTaskStoryID(1,3);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskGetTaskStoryIDTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 3;
            int actual;
            actual = target.TaskGetTaskStoryID(1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskSetTaskPriorityTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.TaskSetTaskPriority(1,4);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskGetTaskPriorityTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 4;
            int actual;
            actual = target.TaskGetTaskPriority(1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskGetTaskDescriptionTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            string expected = "hz";
            string actual;
            actual = target.TaskGetTaskDescription(1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskSetTaskDescriptionTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.TaskSetTaskDescription(1,"hz");
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskSetTaskOwnerTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.TaskSetTaskOwner(1,6);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void TaskGetTaskOwnerTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 6;
            int actual;
            actual = target.TaskGetTaskOwner(1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /*
         *******************************    Programmer    **********************************************
        */

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerGetProgrammerTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 3;
            int actual;
            actual = target.ProgrammerGetProgrammerTableLength();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerGetAllProgrammersTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int[] expected = {1,6,7};
            int[] actual;
            actual = target.ProgrammerGetAllProgrammers();
            CollectionAssert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerAddNewProgrammerTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.ProgrammerAddNewProgrammer("Dan",50,4);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////////////     ok              ////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerUpdateExpectedwork_hoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int Programmer_ID = 6; // TODO: Initialize to an appropriate value
            int hours = 14; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ProgrammerUpdateProgrammerExpectedWorkHours(Programmer_ID, hours);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void add_programmer_expected_work_hoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = target.add_programmer_expected_work_hours(6,4);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerUpdateProgrammerNameTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0;
            int actual;
            actual = DataManager.ProgrammerUpdateProgrammerName(6,"Vasia Petia4kin");
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerGetCurrentWorkHoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 6;
            float actual;
            actual = target.ProgrammerGetCurrentWorkHours(6);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////    ok      ///////////////////////////////////////////////////////
        [TestMethod()]
        public void ProgrammerGetNameTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            string expected = "vasia";
            string actual;
            actual = target.ProgrammerGetName(6);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        
        [TestMethod()]
        public void ProgrammerGetIDByNameTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int[] expected = {1};
            int[] actual;
            actual = target.ProgrammerGetIDByName("Anton");
            CollectionAssert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /*
         *******************************    Date    **********************************************
        */

        ////////////////////////////////   ok    ///////////////////////////////////
        /// <summary>
        ///A test for add_new_day
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication13.exe")]
        public void Dateadd_new_dayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime day = DateTime.Today;
            int status = 1;
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.DateAddNewDay(day, status);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////////   ok    ///////////////////////////////////
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication13.exe")]
        public void DateGetTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 5; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.DateGetTableLength();
            Assert.AreEqual(expected, actual);
        }

        ///////////////////////////   ok    ///////////////////////////////////
        [TestMethod()]
        public void Dateupdate_day_statusTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            DateTime day = DateTime.Parse("20.01.2013");
            actual = target.DateUpdateDayStatus(day, 1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
        ///////////////////////////   ok    ///////////////////////////////////
        [TestMethod()]
        public void DateGetDayStatusTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            DateTime day = DateTime.Parse("20.01.2013");
            actual = target.DateGetDayStatus(day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
            //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void DateUpdateDayStatusTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            DateTime day = DateTime.Parse("3.12.2012");
            actual = target.DateUpdateDayStatus(day,0);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void Dateget_current_dayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Today; // TODO: Initialize to an appropriate value
            DateTime actual;
            actual = target.DateGetCurrentDay();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /*
         *******************************    Work Hours    **********************************************
        */

        
        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetAllSprintWorkHoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float[] expected = {5,2,7}; // TODO: Initialize to an appropriate value
            float[] actual;
            actual = target.WorkHoursGetAllSprintWorkHours();
            CollectionAssert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetWorkHoursTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int expected = 4; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.WorkHoursGetWorkHoursTableLength();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetProgrammerWorkHoursForTodayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 4; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.WorkHoursGetProgrammerWorkHoursForToday(1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///////////////////////////   ok    //////////////////////////////
        [TestMethod()]
        public void WorkHoursAddNewDayWorkHoursTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 0; // TODO: Initialize to an appropriate value
            float actual;
            DateTime day = DateTime.Parse("1.12.12");
            actual = target.WorkHoursAddNewDayWorkHours(6,day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetProgrammerWorkHoursForDayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = -1; // TODO: Initialize to an appropriate value
            float actual;
            DateTime day = DateTime.Parse("20.1.13");
            actual = target.WorkHoursGetProgrammerWorkHoursForDay(1,day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursSetProgrammerWorkHoursForTodayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 0; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.WorkHoursSetProgrammerWorkHoursForToday(1, 5);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursAddProgrammerWorkHoursForDayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 0; // TODO: Initialize to an appropriate value
            float actual;
            DateTime day = DateTime.Parse("1.12.12");
            actual = target.WorkHoursAddProgrammerWorkHoursForDay(1, 5, day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetProgrammerWorkHoursAllTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 13; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.WorkHoursGetProgrammerWorkHoursAll(1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetAllWorkHoursForTodayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 0; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.WorkHoursGetAllWorkHoursForToday();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void WorkHoursGetAllWorkHoursForDayTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 10; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.WorkHoursGetAllWorkHoursForDay(DateTime.Parse("1.12.12"));
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /*
         *******************************    Story in sprint    **********************************************
        */

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void StoryInSprintGetStoryInSprintTableLengthTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 3; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.StoryInSprintGetStoryInSprintTableLength();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void StoryInSprintAddNewStoryInSprintTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 0; // TODO: Initialize to an appropriate value
            float actual;
            DateTime day = DateTime.Parse("14.2.13");
            actual = target.StoryInSprintAddNewStoryInSprint(3,day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        //////////////////////////////   ok     ///////////////////////
        [TestMethod()]
        public void StoryInSprintTransferStoryToOtherSprintTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            float expected = 0; // TODO: Initialize to an appropriate value
            float actual;
            DateTime day = DateTime.Parse("14.4.13");
            actual = target.StoryInSprintTransferStoryToOtherSprint(3,day);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
        
        /*
        /// <summary>
        ///A test for DataManager Constructor
        ///</summary>
        [TestMethod()]
        public void DataManagerConstructorTest()
        {
            DataManager target = new DataManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
        */
        
        /// <summary>
        ///A test for update_programmer_name
        ///</summary>
        /*[TestMethod()]
        public void update_programmer_nameTest()
        {
            DataManager target = new DataManager(); // TODO: Initialize to an appropriate value
            int ID = 2; // TODO: Initialize to an appropriate value
            string name = "ccc2"; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.update_programmer_name(ID, name);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }*/
    }
}

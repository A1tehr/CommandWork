using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerProject.MainScreen;
using TaskManagerProject.Login_Registration;
using TaskManagerProject.Models;
using TaskManagerProject.Repository;
using System.Diagnostics;

namespace TaskManagerProject.Tests
{
    [TestClass]
    public class UnitTestStudent
    {
        [TestMethod]
        public void TestCheckStudent()
        {
            // Создаем объект для теста 
            var studentManager = new SQLManager();

            // Проверяем, что студент существует
            var result = studentManager.GetStudent("Иван", "Мигаль", "Владимирович");
            Assert.IsNotNull(result);
            Assert.AreEqual("Иван", result.Result.firstName);
           
        }

        [TestMethod]
        public async Task TestGetTaskIdByName()
        {

            var taskManager = new SQLManager();
            string taskName = "Сетевые технологии";

            int taskId = await taskManager.GetTaskIdByName(taskName);

            // Assert
            Assert.AreNotEqual(-1, taskId, "Номер задачи не должен быть -1");
        }

        [TestMethod]
        public async Task TestGetAllStudentsIdsByGrade()
        {
            var studentManager = new SQLManager();
            int grade = 4;  

            List<Student> students = await studentManager.GetAllStudentsIdsByGrade(grade);

            // Assert
            Assert.IsNotNull(students, "Список не должен быть пустым");
            Assert.IsTrue(students.Count > 0, "Должен быть хотя бы 1 студент");
        }


        [TestMethod]
        public async Task TestGetSubjectId()
        {

            var taskManager = new SQLManager();

            string subjectName = "Сетевые технологии";
            int subjectId = await taskManager.GetSubjectId(subjectName);

            Assert.AreNotEqual(0, subjectId, "Предмет не должен быть с индексом 0");
        }

        [TestMethod]
        public async Task TestGetAllGroups()
        {

            var groupManager = new SQLManager();

            List<Group> groups = await groupManager.GetAllGroups();

            Assert.IsNotNull(groups, "Список не должен быть пуст");
            Assert.IsTrue(groups.Count > 0, "Должна быть хотя бы 1 группа в списке");
        }

    }

}

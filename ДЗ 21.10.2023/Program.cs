using System;
using System.Collections.Generic;


namespace ДЗ_21._10._2023
{
    enum WorkingDepartments
    {
        системщики,
        разработчики,
        начальство,
    }
    class Employee
    {
        
        private string employeeName;
        private string jobTitle;
        private WorkingDepartments workDepartment;
        private List<Employee> superiors = new List<Employee>();
        
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
        }
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
        }
        public WorkingDepartments WorkDepartment
        {
            get
            {
                return workDepartment;
            }
        }
        public List<Employee> Superiors
        {
            get
            {
                return superiors;
            }
        }
       
        class Task
        {
            
            private string taskContent;
            private WorkingDepartments taskAddress;
           
            public string TaskContent
            {
                get
                {
                    return taskContent;
                }
            }
            public WorkingDepartments TaskAddress
            {
                get
                {
                    return taskAddress;
                }
            }
           
            public Task(string taskContent, WorkingDepartments taskAddress)
            {
                this.taskContent = taskContent;
                this.taskAddress = taskAddress;
            }
         
        }
       
        public void AssignmentOfTask(Task task, Employee employee)
        {
            Console.WriteLine($"От {employee.EmployeeName} ({employee.JobTitle}) дается задача\n{task.TaskContent} работнику {employeeName} ({jobTitle})");

            if (superiors.Contains(employee) && (workDepartment == task.TaskAddress))
            {
                Console.WriteLine($"{employeeName} ({jobTitle}) берет задачу\n");
            }
            else
            {
                Console.WriteLine($"{employeeName} ({jobTitle}) не берет задачу\n");
            }
        }
        
        public Employee(string employeeName, string jobTitle, WorkingDepartments workDepartment, params Employee[] superiors)
        {
            this.employeeName = employeeName;
            this.jobTitle = jobTitle;
            this.workDepartment = workDepartment;
            this.superiors.AddRange(superiors);
        }
      
        internal class Program
        {
            static void Main()
            {
                
                
                Console.WriteLine("ПРОГРАММА СОЗДАЕТ ИЕРАРХИЮ СОТРУДНИКОВ, ДАЕТ ИМ ЗАДАЧИ И ВЫВОДИТ НА ЭКРАН, БЕРУТ ОНИ ЕЕ ИЛИ НЕТ\n");
                
                Employee Semyon = new Employee("Семен", "Генеральный директор", WorkingDepartments.начальство);

                Employee Rashid = new Employee("Рашид", "Финансовый директор", WorkingDepartments.начальство, Semyon);
                Employee Lucas = new Employee("Лукас", "Начальник бухгалтерии", WorkingDepartments.начальство, Rashid);

                Employee OIlham = new Employee("О Ильхам", "Директор по автоматизации", WorkingDepartments.начальство, Semyon);
                Employee Orkady = new Employee("Оркадий", "Начальник отдела информационных технологий", WorkingDepartments.начальство, OIlham);
                Employee Volodya = new Employee("Володя", "Зам. начальника отдела информационных технологий", WorkingDepartments.начальство, Orkady);

                Employee Ilshat = new Employee("Ильшат", "Начальник отдела системщиков", WorkingDepartments.начальство, Orkady, Volodya);
                Employee Ivanych = new Employee("Иваныч", "Зам. начальника отдела системщиков", WorkingDepartments.начальство, Ilshat);

                Employee Ilya = new Employee("Илья", "Работник отдела системщиков", WorkingDepartments.системщики, Ivanych);
                Employee Vitya = new Employee("Витя", "Работник отдела системщиков", WorkingDepartments.системщики, Ivanych);
                Employee Zhenya = new Employee("Женя", "Работник отдела системщиков", WorkingDepartments.системщики, Ivanych);

                Employee Sergey = new Employee("Сергей", "Начальник отдела разработчиков", WorkingDepartments.начальство, Orkady, Volodya);
                Employee Laysan = new Employee("Ляйсан", "Зам. начальника отдела разработчиков", WorkingDepartments.начальство, Sergey);

                Employee Marat = new Employee("Марат", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
                Employee Dina = new Employee("Дина", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
                Employee Ildar = new Employee("Ильдар", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
                Employee Anton = new Employee("Антон", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
                
                Task task1 = new Task("Расчитать прибыль компании", WorkingDepartments.начальство);
                Task task2 = new Task("Разработать приложение", WorkingDepartments.разработчики);
                Task task3 = new Task("Настроить работу корпоративной сети", WorkingDepartments.системщики);
                Task task4 = new Task("Провести собрание с сотрудниками", WorkingDepartments.начальство);
                

                Ilya.AssignmentOfTask(task3, Ivanych);
                Vitya.AssignmentOfTask(task3, Lucas);
                Zhenya.AssignmentOfTask(task1, Ivanych);

                Marat.AssignmentOfTask(task2, Laysan);
                Dina.AssignmentOfTask(task3, Laysan);
                Ildar.AssignmentOfTask(task2, Sergey);
                Anton.AssignmentOfTask(task4, Marat);

                Sergey.AssignmentOfTask(task4, Orkady);
                Sergey.AssignmentOfTask(task4, Volodya);
            }
        }
    }
}


using System;
using System.Collections.Generic;

namespace _003_Liskov_subsitution_principle_LSP
{


    #region BadVariante

    public abstract class BadEmployee
    {
        public virtual string GetProjectDetails(int employeeId)
        {
            return "Base Projekt";
        }

        public virtual string GetEmployeeDetails (int employeeId)
        {
            return "Base Employee";
        }
    }


    public class BadCasualEmployee : BadEmployee
    {
        public override string GetEmployeeDetails(int employeeId)
        {
            return " Employee BaseInfors";
        }

        public override string GetProjectDetails(int employeeId)
        {
            base.GetProjectDetails(employeeId);
            return "Employee ProjectInfos";
        }
    }

    public class BadContractualEmployee : BadEmployee
    {
        public override string GetEmployeeDetails(int employeeId)
        {
            return "ContractualEmployee -> GetEmployeeDetails";
        }

        public override string GetProjectDetails(int employeeId)
        {
            string baseString = base.GetProjectDetails(employeeId);            
            return baseString + " ContractEmployee -> GetProjectDetails";
        }
    }



    #endregion


    public interface IEmployee
    {
        string GetEmployeeDetails(int employeeId);
    }

    public interface IProject
    {
        string GetProjectDetails(int employeeId);
    }

    public class CasualEmployee : IEmployee, IProject
    {
        public  string GetEmployeeDetails(int employeeId)
        {
            return " Employee BaseInfos";
        }

        public string GetProjectDetails(int employeeId)
        {
            
            return "Employee ProjectInfos";
        }
    }

    public class ContractualEmployee : IEmployee, IProject
    {
        public string GetEmployeeDetails(int employeeId)
        {
            return "ContractualEmployee -> GetEmployeeDetails";
        }

        public string GetProjectDetails(int employeeId)
        {
            return "ContractEmployee -> GetProjectDetails";
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            #region Now, check the below code and it will violate the LSP principle.
            List<BadEmployee> employeeList = new List<BadEmployee>();


            employeeList.Add(new BadContractualEmployee());
            employeeList.Add(new BadCasualEmployee());
            
            foreach (BadEmployee e in employeeList)
            {
                e.GetEmployeeDetails(1245);
            }
            #endregion


            //Bessere Variante
            List<IProject> projectEmployeeList = new List<IProject>();

            IProject employeeProject = new ContractualEmployee();
            projectEmployeeList.Add(employeeProject);

            foreach (IProject currentProject in projectEmployeeList)
            {
                currentProject.GetProjectDetails(12345);
            }

        }
    }
}

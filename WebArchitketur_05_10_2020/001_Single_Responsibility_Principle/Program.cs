using System;

namespace _001_Single_Responsibility_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }




    #region Bad Sample
    //Eine Klasse soll eine gewisse Sache machen und nicht multiple Aufgabengebiete abdecken! 
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }



        public bool IsEmployeeInTableAvailable(Employee em)
        {


            return true; 
        }
        public bool InsertIntoEmployeeTable(Employee em)
        {
            //Speicher was in die Datenbank
            return true;
        }


        //Wird rausgelagert. 
        public void GenerateReport(Employee em)
        {
            // Erstelle ein Report // Exportieren
        }
    }
    #endregion


    // GenerateReport wird 
    // Reportings benötigen 1.) Template 2.) Daten => Report 
    public class ReportGenerator
    {
        public void GenerateReport(Employee em)
        {

        }
    }
}

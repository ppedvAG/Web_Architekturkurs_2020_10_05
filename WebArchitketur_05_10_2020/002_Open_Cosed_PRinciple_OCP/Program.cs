using System;

namespace _002_Open_Cosed_PRinciple_OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region BadCode-Sample
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
    }



    // GenerateReport wird 
    // Reportings benötigen 1.) Template 2.) Daten => Report 
    public class BadReportGenerator
    {
        public string ReportType { get; set; }
        
        public void GenerateReport(Employee em)
        {
            // Wenn mehrere Report-Typen verwendet werden, werden diese nicht in EINER Methode implementiert. 
            if (ReportType == "CSR")
            {

            }

            if (ReportType == "PDF")
            {

            }

            if (ReportType == "CSV")
            {

            }
        }
    }
    #endregion


    #region Betert Variante

    public class ReportGenerator // Open Princip
    {
        public virtual void GenerateReport (Employee em)
        {

        }

        public virtual void DisplayGenereatedReport()
        {

        }


    }

   // Weitere Variante von OpenCloses anstatt -> virtual void GenerateReport 
    public interface IReportGenerator
    {
        void GenerateReport(Employee em);

        //void DisplayGenereatedReport();
    }

    //In der Besseren Variante werden Sub-Klassen für jeden ReportTyp verwendet. Man kann auf Initialisierungen je nach Library eingehen. 
    // Warum? -> 
    public class CrystalReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            // Erstelle ein  CrystalReport
        }

        // Für andere Typen kann man Reports erstellen
    }

    public class PDFGenerator : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            // Erstelle ein  PDF
        }
    }

    public class CSVGenerator : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            // Erstelle ein  PDF
        }
    }



    //Interfaces geben an, dass eine Implementierung folgen muss!
    public class CrystalReportGeneratorWithInterface : IReportGenerator
    {
        public void GenerateReport(Employee em)
        {
            
        }
    }

    public class PDFGeneratorWithInterface : IReportGenerator
    {
        public void GenerateReport(Employee em)
        {

        }
    }

    public class CSVGeneratorWithInterface : IReportGenerator
    {
        public void GenerateReport(Employee em)
        {

        }
    }
    #endregion

}

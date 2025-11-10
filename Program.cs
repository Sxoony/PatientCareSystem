using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Xml.Linq;
using System.IO;
namespace ITPCA_Question_2
{
   
    
        public class Patient
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string MedicalCondition { get; set; }
            public Patient(string name, int age, string medicalCondition)
            {
                Name = name;
                Age = age;
                MedicalCondition = medicalCondition;
            }
            public void Display()
            {
                Console.WriteLine($"Name: {Name}\nAge: {Age}\nMedical Condition: {MedicalCondition}");
            }
        }
    public class ClinicManagement
    {
        public int index = 0;
        //  private List<Patient> patients = new List<Patient>();
        private Patient[] patients = new Patient[10];
        private int patientCount = 0;
        public void WritePatientInfo()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "patient_information.txt");
            
            foreach (Patient patient in patients)
            {
                File.AppendAllText(filePath, patient.Name + ", " + patient.Age + ", " + patient.MedicalCondition);

            }
            Console.WriteLine($"Patient information printed to file: patient_information.txt");
        }
        public void AddPatient(Patient patient)
        {
            if (patientCount >= patients.Length)
            {
                Console.WriteLine("Error: Maximum number of patients reached.");
                return;
            }
            for (int i = 0; i < patientCount; i++)
            {
                if (patients[i].Name.Equals(patient.Name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Patient Found!");
                    index = i;
                    return;
                }
            }
            patients[patientCount] = patient;
            patientCount++;
          //  Console.WriteLine("Patient successfully added!");
        }
        public void FindPatient(string name)
        {
            index = -1;
            for (int i = 0; i < patientCount; i++)
            {
                if (patients[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Patient Found!");
                    index = i; break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("Error: Patient not found.");
                return;
            }

        }
        public void RemovePatient(string name)
        {
            FindPatient(name);
            patients[patientCount - 1] = null;
            patientCount--;
            Console.WriteLine("Patient successfully removed.");
        }
        public void SearchForPatient(string name)
        {
            FindPatient(name);
            patients[index].Display();
        }
        public void DisplayAll()
        {
            if (patientCount == 0)
            {
                Console.WriteLine("No patients in the system found.");
                return;
            }

            for (int i = 0; i < patientCount; i++)
            {
                Console.Write($"Patient {i + 1}: ");
                patients[i].Display();
            }
        }
    }
            internal class Program
            {
            
                static void Main(string[] args)
                {

                    ClinicManagement clinic = new ClinicManagement();







                //QUESTION 2 CODE
                string[] Arrname = { "Sara", "Dihan", "Ryley", "John", "Gershwin", "Dylan", "Enrique", "Linda", "Jess", "Frans" };
                int[] Arrage = { 10, 18, 4, 24, 67, 79, 84, 34, 17, 44 };
                string[] Arrcondition = { "ADHD\n", "Schizophrenia\n", "Autism\n", "Diabetes\n", "Pneumonia\n", "Dwarfism\n", "High Cholesterol\n", "Ovarian Cancer\n", "N/A\n", "Down Syndrome\n" };
                for (int i = 0; i < 10; i++)
                {
                    Patient newPatient = new Patient(Arrname[i], Arrage[i], Arrcondition[i]);
                    clinic.AddPatient(newPatient);
                }









                bool bDone = false;
                    int Option = 0;
                    bool bValidated = false;
                    Console.WriteLine("Welcome to RANDS Health Clinic - Patient Management System!");
                    while (!bDone)
                    {
                        Console.Write($"1. Add a Patient\n2. Remove a Patient\n3. Search for a Patient\n4. Display all Patients\n5.Print Patient Information to File\n6. Exit the Program\nEnter the number of the desired action: ");

                        try
                        {
                            Option = Convert.ToInt32(Console.ReadLine());
                            if (Option > 0 && Option < 6)
                            {

                                switch (Option)
                                {
                                    case 1:
                                        Console.Write("Enter name: ");
                                        string name = Console.ReadLine();

                                        if (name == null || name.Length <= 0)
                                        {
                                            while (!bValidated)
                                            {
                                                Console.WriteLine("Error: Input was null. Please try again.");
                                                Console.Write("Enter name: ");
                                                name = Console.ReadLine();
                                                if (!(name == null || name.Length <= 0))
                                                {
                                                    bValidated = true;
                                                }
                                            }
                                        }
                                        Console.Write("Enter age: ");
                                        int age = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter medical condition (or press Enter for none): ");
                                        string condition = Console.ReadLine();
                                        if (condition == null)
                                        {
                                            condition = "N/A";
                                        }
                                        Patient newPatient = new Patient(name, age, condition);
                                        clinic.AddPatient(newPatient);
                                Console.WriteLine("Patient Sucessfully Added!");

                                        break;
                                    case 2:
                                        Console.Write("Enter name of patient to remove: ");
                                        clinic.RemovePatient(Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.Write("Enter name of patient to search for: ");
                                        clinic.SearchForPatient(Console.ReadLine());
                                        break;
                                    case 4:
                                        clinic.DisplayAll();
                                        break;






                                    case 5:clinic.WritePatientInfo();
                                    break;



                                    case 6:
                                            bDone = true;
                                            Console.WriteLine("Thank you for using the Clinic Management!");
                                            break;
                                        } 
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number corresponding to the menu list!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }


                }
            }
        
    }


   
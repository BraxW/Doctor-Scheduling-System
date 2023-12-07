/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 4.6 Course Project
*
* Main Application Class
*/
using System.Data.SQLite;
public class AppointmentSystem
{
    static void Main(string[] args)
    {
        Console.WriteLine("Braxton W - 4.6 Project\n");

        const string dbName = "HospitalFrontDesk.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null)
        {
            AppointmentDB.CreateTable(conn);
            ResultsDB.CreateTable(conn);
            PersonDB.CreateTable(conn);

            // Schedule
            Schedule schedule = new Schedule();

            // Dates
            DateTime pastDateOne = new DateTime(1999, 5, 12);
            DateTime pastDateTwo = new DateTime(1990, 1, 2);
            DateTime pastDateThree = new DateTime(2000, 8, 7);

            DateTime futureDateOne = new DateTime(2024, 1, 3);
            DateTime futureDateTwo = new DateTime(2024, 12, 10);
            DateTime futureDateThree = new DateTime(2025, 11, 10);

            // Patient
            Patient patientOne = new Patient("John", "Mad", pastDateOne, "When checking in patient was very mad");
            Patient patientTwo = new Patient("Joe", "Smo", pastDateThree, "");

            // Doctor
            Doctor doctorOne = new Doctor("March", "Green", pastDateTwo, 6, 15);
            Doctor doctorTwo = new Doctor("Indigo", "Flat", pastDateOne, 13, 19);

            // Update Person DB
            PersonDB.AddPerson(conn, patientOne);
            PersonDB.AddPerson(conn, patientTwo);
            PersonDB.AddPerson(conn, doctorOne);
            PersonDB.AddPerson(conn, doctorTwo);

            // Appointments
            Appointment johnAppointment = new Appointment(patientOne, doctorOne, futureDateTwo, "Always angry all the time.");
            Appointment joeAppointment = new Appointment(patientTwo, doctorOne, futureDateThree, "General Checkup");

            // Print SQL before schedule update
            Console.WriteLine("Appointment Database before schedule update:\n");
            printAppointments(AppointmentDB.GetAllAppointments(conn));

            // Adding to schedule
            schedule.AddAppointment(johnAppointment);
            schedule.AddAppointment(joeAppointment);
            // Mirror to sql database
            AppointmentDB.AddAppointment(conn, johnAppointment);
            AppointmentDB.AddAppointment(conn, joeAppointment);

            // Printing

            // Print SQL after schedule update
            Console.WriteLine("Appointment Database after schedule update:\n");
            printAppointments(AppointmentDB.GetAllAppointments(conn));

            // Scheduled appointments
            printAppointments(schedule.Appointments);

            // Appointment at date
            Console.WriteLine("Appointments on " + futureDateThree + ":\n");
            foreach (var dateAppointment in schedule.GetAppointmentsAtDate(futureDateThree))
            {
                Console.WriteLine("\t" + dateAppointment);
            }

            // Print SQL before finishing appointment
            Console.WriteLine("Appointment and result Database before finishing appointment:\n");
            printAppointments(AppointmentDB.GetAllAppointments(conn));
            printResults(ResultsDB.GetAllResults(conn));

            // Remove and reprint
            AppointmentResult joeResult = joeAppointment.FinishAppointment("Perfectly healthly");

            // Add to results database and remove from appointments
            ResultsDB.AddResult(conn, joeResult);
            //AppointmentDB.DeleteAppointment(conn, joeAppointment.ID);

            schedule.RemoveAppointment(joeAppointment);
            // Mirror to sql database
            //AppointmentDB.DeleteAppointment(conn, joeAppointment.ID);

            Console.WriteLine("Finished Joe's Appointment and removed from schedule");
            Console.WriteLine(joeResult);
            Console.WriteLine("\nSchedule updated");
            Console.WriteLine(schedule);

            // Print SQL after finishing appointment
            Console.WriteLine("Appointment and result Database before finishing appointment:\n");
            printAppointments(AppointmentDB.GetAllAppointments(conn));
            printResults(ResultsDB.GetAllResults(conn));


            // Patients and doctors
            Console.WriteLine("Patients:");
            Console.WriteLine(patientOne);
            Console.WriteLine(patientTwo);
            Console.WriteLine("From Database:");
            printPatients(PersonDB.GetAllPatients(conn));

            Console.WriteLine("Doctors:");
            Console.WriteLine(doctorOne);
            Console.WriteLine(doctorTwo);
            Console.WriteLine("From Database:");
            printDoctors(PersonDB.GetAllDoctors(conn));

            //Updating Doctor ID 2
            Doctor doctorId2 = PersonDB.GetDoctor(conn, 2);
            doctorId2.LastName = "Crum";
            PersonDB.UpdatePerson(conn, doctorId2, true);
            Console.WriteLine("Updated doctor ID 2:");
            Console.WriteLine(PersonDB.GetDoctor(conn, 2));

        }
    }

    public static void printAppointments(List<Appointment> appointments) 
    {
        foreach (Appointment appointment in appointments)
        {
            Console.WriteLine(appointment);
        }
    }
        public static void printResults(List<AppointmentResult> results) 
    {
        foreach (AppointmentResult result in results)
        {
            Console.WriteLine(result);
        }
    }

    public static void printPatients(List<Patient> patients) 
    {
        foreach (Patient patient in patients)
        {
            Console.WriteLine(patient);
        }
    }
     public static void printDoctors(List<Doctor> doctors) 
    {
        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine(doctor);
        }
    }
}
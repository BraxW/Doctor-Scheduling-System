/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
using System.Data.SQLite;
public class Schedule
{
    public List<Appointment> Appointments { get; set;}
    // Constructor
    public Schedule()
    {
        Appointments = new List<Appointment>();
    }

    public void AddAppointment(Appointment appointment) {

        Appointments.Add(appointment);

        return;
    }

    public void RemoveAppointment(Appointment appointment) {
        
        Appointments.Remove(appointment);

        return;
    }


    public List<Appointment> GetAppointmentsAtDate(DateTime date) {

        // For use in GetAppointmentsAtDate method
        bool appointmentAtProvidedDate(Appointment appointment) {
            if (appointment.ScheduledDate == date) {
                return true;
            }
            else {
                return false;
            }
        }
        
        List<Appointment> appointmentsAtTime = new List<Appointment>(Appointments.FindAll(appointmentAtProvidedDate));

        return appointmentsAtTime;
    }


    public override string ToString()
    {

        string allAppointmentsString = "";

        foreach (var scheduledAppointment in Appointments) {
            allAppointmentsString = allAppointmentsString + scheduledAppointment +"\n\n";
        }

        return string.Format("Appointments scheduled:\n\n{0}",
        allAppointmentsString);
    }
}
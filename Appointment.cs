/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
public class Appointment: AppointmentBase
{    
    
    // Constructor
    public Appointment(int id, Patient patient, Doctor doctor, DateTime date, string reason):
    base(id, patient, doctor, date, reason)
    {
        ID = id;
        Patient = patient;
        Doctor = doctor;
        ScheduledDate = date;
        Reason = reason;
    }
    public Appointment(Patient patient, Doctor doctor, DateTime date, string reason):
    base(patient, doctor, date, reason)
    {
        Patient = patient;
        Doctor = doctor;
        ScheduledDate = date;
        Reason = reason;
    }

    public AppointmentResult FinishAppointment(string resultString) {

        AppointmentResult result = new AppointmentResult(ID, Patient, Doctor, ScheduledDate, Reason, resultString);

        return result;
    }
}
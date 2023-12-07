/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
public class AppointmentResult: AppointmentBase
{
    public string Results { get; private set; }
    
    // Constructor
    public AppointmentResult(int id, Patient patient, Doctor doctor, DateTime date, string reason, string result):
    base(id, patient, doctor, date, reason)
    {
        ID = id;
        Patient = patient;
        Doctor = doctor;
        ScheduledDate = date;
        Reason = reason;
        Results = result;
    }
    public AppointmentResult(Patient patient, Doctor doctor, DateTime date, string reason, string result):
    base(patient, doctor, date, reason)
    {
        Patient = patient;
        Doctor = doctor;
        ScheduledDate = date;
        Reason = reason;
        Results = result;
    }

     public override string ToString() {

        return string.Format(
            "{0} {1}'s {2} appointment.\n\tDoctor: Dr. {3}\n\tVisit reason: {4}\n\tAppointment Result: {5}",
            Patient.FirstName, Patient.LastName, ScheduledDate, Doctor.LastName, Reason, Results
        );
    }
}
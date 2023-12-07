/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
public abstract class AppointmentBase
{
    public int ID { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string Reason { get; set; }
    
    // Constructor
    public AppointmentBase(int id, Patient patient, Doctor doctor, DateTime date, string reason)
    {
        ID = id;
        Patient = patient;
        Doctor = doctor;
        ScheduledDate = date;
        Reason = reason;
    }
    public AppointmentBase(Patient patient, Doctor doctor, DateTime date, string reason)
    {
        Patient = patient;
        Doctor = doctor;
        ScheduledDate = date;
        Reason = reason;
    }


     public override string ToString() {

        return string.Format(
            "This appointment is for {0} {1} at {2} with Dr. {3} for reason '{4}'.",
            Patient.FirstName, Patient.LastName, ScheduledDate, Doctor.LastName, Reason
        );
    }
}
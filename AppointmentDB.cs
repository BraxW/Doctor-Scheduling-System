/*******************************************************************
* Name: Braxton 
* Date: 11/30/2023
* Assignment: CIS317 4.6 Course Project
*
*/
using System.Data.SQLite;
public class AppointmentDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
        "CREATE TABLE IF NOT EXISTS Appointments (\n"
        + " ID integer PRIMARY KEY\n"
        + " ,PatientID integer\n"
        + " ,DoctorID integer\n"
        + " ,ScheduledDate DATE\n"
        + " ,Reason varchar(40));";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void AddAppointment(SQLiteConnection conn, Appointment a)
    {
        string sql = string.Format(
        "INSERT INTO Appointments(PatientID, DoctorID, ScheduledDate, Reason) "
        + "VALUES({0},{1},'{2}','{3}')",
        a.Patient.ID, a.Doctor.ID, a.ScheduledDate.ToString("yyyy-MM-dd"), a.Reason);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void UpdateAppointment(SQLiteConnection conn, Appointment a)
    {
        string sql = string.Format(
        "UPDATE Appointments SET PatientID={1}, DoctorID={2}, ScheduledDate='{3}', Reason='{4}'"
        + " WHERE ID={0}", a.ID ,a.Patient.ID, a.Doctor.ID, a.ScheduledDate.ToString("yyyy-MM-dd"), a.Reason);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void DeleteAppointment(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Appointments WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static List<Appointment> GetAllAppointments(SQLiteConnection conn)
    {
        List<Appointment> appointments = new List<Appointment>();
        string sql = "SELECT * FROM Appointments";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            appointments.Add(new Appointment(
            rdr.GetInt32(0),
            PersonDB.GetPatient(conn,rdr.GetInt32(1)),
            PersonDB.GetDoctor(conn,rdr.GetInt32(2)),
            Convert.ToDateTime(rdr.GetString(3)),
            rdr.GetString(4)
            ));
        }
        return appointments;
    }
    public static Appointment GetAppointment(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Appointments WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new Appointment(
            rdr.GetInt32(0),
            PersonDB.GetPatient(conn,rdr.GetInt32(1)),
            PersonDB.GetDoctor(conn,rdr.GetInt32(2)),
            Convert.ToDateTime(rdr.GetString(3)),
            rdr.GetString(4)
            );
        }
        else
        {
            return  new Appointment(-1, new Patient(-1, "", "", new DateTime(), ""),
             new Doctor(-1, "", "", new DateTime(), -1, -1),
              new DateTime(), string.Empty);
        }
    }
}
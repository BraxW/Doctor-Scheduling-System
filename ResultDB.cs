/*******************************************************************
* Name: Braxton 
* Date: 11/30/2023
* Assignment: CIS317 4.6 Course Project
*
* Class for modifying the database that holds Appointment Results
*/
using System.Data.SQLite;
using static PersonDB;
public class ResultsDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
        "CREATE TABLE IF NOT EXISTS Results (\n"
        + " ID integer PRIMARY KEY\n"
        + " ,PatientID integer\n"
        + " ,DoctorID integer\n"
        + " ,ScheduledDate DATE\n"
        + " ,Reason varchar(40)\n"
        + " ,Result varchar(40));";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void AddResult(SQLiteConnection conn, AppointmentResult a)
    {
        string sql = string.Format(
        "INSERT INTO Results(PatientID, DoctorID, ScheduledDate, Reason, Result) "
        + "VALUES({0},{1},'{2}','{3}','{4}')",
        a.Patient.ID, a.Doctor.ID, a.ScheduledDate.ToString("yyyy-MM-dd"), a.Reason, a.Results);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void UpdateResult(SQLiteConnection conn, AppointmentResult a)
    {
        string sql = string.Format(
        "UPDATE Results SET PatientID={1}, DoctorID={2}, ScheduledDate='{3}', Reason='{4}' Result='{5}'"
        + " WHERE ID={0}", a.ID ,a.Patient.ID, a.Doctor.ID, a.ScheduledDate.ToString("yyyy-MM-dd"), a.Reason, a.Results);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void DeleteResult(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Results WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static List<AppointmentResult> GetAllResults(SQLiteConnection conn)
    {
        List<AppointmentResult> appointments = new List<AppointmentResult>();
        string sql = "SELECT * FROM Results";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            appointments.Add(new AppointmentResult(
            rdr.GetInt32(0),
            PersonDB.GetPatient(conn,rdr.GetInt32(1)),
            PersonDB.GetDoctor(conn,rdr.GetInt32(2)),
            Convert.ToDateTime(rdr.GetString(3)),
            rdr.GetString(4),
            rdr.GetString(5)
            ));
        }
        return appointments;
    }
    public static AppointmentResult GetResult(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Results WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new AppointmentResult(
            rdr.GetInt32(0),
            PersonDB.GetPatient(conn,rdr.GetInt32(1)),
            PersonDB.GetDoctor(conn,rdr.GetInt32(2)),
            Convert.ToDateTime(rdr.GetString(3)),
            rdr.GetString(4),
            rdr.GetString(5)
            );
        }
        else
        {
            return new AppointmentResult(-1, new Patient(-1, "", "", new DateTime(), ""),
             new Doctor(-1, "", "", new DateTime(), -1, -1),
              new DateTime(), string.Empty, string.Empty);
        }
    }
}
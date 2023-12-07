/*******************************************************************
* Name: Braxton 
* Date: 11/30/2023
* Assignment: CIS317 4.6 Course Project
*
*/
using System.Data.SQLite;
public class PersonDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new patient table
        string patientSql =
        "CREATE TABLE IF NOT EXISTS Patients (\n"
        + " ID integer PRIMARY KEY\n"
        + " ,FirstName varchar(20)\n"
        + " ,LastName varchar(40)\n"
        + " ,BirthDate DATE\n"
        + " ,PatientNotes varchar(40));";

        // SQL statement for creating a new doctor table
        string doctorSql =
        "CREATE TABLE IF NOT EXISTS Doctors (\n"
        + " ID integer PRIMARY KEY\n"
        + " ,FirstName varchar(20)\n"
        + " ,LastName varchar(40)\n"
        + " ,BirthDate DATE\n"
        + " ,WorkStart integer\n"
        + " ,WorkEnd integer);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = patientSql;
        cmd.ExecuteNonQuery();
        cmd.CommandText = doctorSql;
        cmd.ExecuteNonQuery();
    }

    public static void AddPerson(SQLiteConnection conn, dynamic p)
    {
        // Change sql string based on class
        string sql = "";
        switch(p.GetType().Name)
        {
            case "Patient":
                sql = string.Format(
                "INSERT INTO Patients(FirstName, LastName, BirthDate, PatientNotes) "
                + "VALUES('{0}','{1}','{2}','{3}')",
                p.FirstName, p.LastName, p.Birthdate, p.PatientNotes);
                break;

            case "Doctor":
                sql = string.Format(
                "INSERT INTO Doctors(FirstName, LastName, BirthDate, WorkStart, WorkEnd) "
                + "VALUES('{0}','{1}','{2}',{3},{4})",
                p.FirstName, p.LastName, p.Birthdate, p.WorkTimeStart, p.WorkTimeEnd);
                break;
        }

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void UpdatePerson(SQLiteConnection conn, dynamic p, bool isDoctor)
    {
        // Change sql string based on class
        string sql = "";
        switch(isDoctor)
        {
            case false:

                sql = string.Format(
                "UPDATE Patients SET FirstName='{1}', LastName='{2}', BirthDate='{3}', PatientNotes='{4}'"
                + " WHERE ID={0}", p.ID, p.FirstName, p.LastName, p.Birthdate, p.PatientNotes);
                break;

            case true:
            
                sql = string.Format(
                "UPDATE Doctors SET FirstName='{1}', LastName='{2}', BirthDate='{3}', WorkStart={4}, WorkEnd={5}"
                + " WHERE ID={0}", p.ID, p.FirstName, p.LastName, p.Birthdate, p.WorkTimeStart, p.WorkTimeEnd);
                break;
        }

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void DeletePerson(SQLiteConnection conn, int id, bool isDoctor)
    {
        string tableToDeleteFrom = "Patients";
        if ( isDoctor == true ) {
            tableToDeleteFrom = "Doctors";
        }

        string sql = string.Format("DELETE from "+tableToDeleteFrom+" WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    static Patient readPatient(SQLiteDataReader rdr) 
    {
        return new Patient(
            rdr.GetInt32(0),
            rdr.GetString(1),
            rdr.GetString(2),
            Convert.ToDateTime(rdr.GetString(3)),
            rdr.GetString(4)
        );
    }
    static Doctor readDoctor(SQLiteDataReader rdr) 
    {
        return new Doctor(
            rdr.GetInt32(0),
            rdr.GetString(1),
            rdr.GetString(2),
            Convert.ToDateTime(rdr.GetString(3)),
            rdr.GetInt32(4),
            rdr.GetInt32(5)
        );
    }
    public static List<Patient> GetAllPatients(SQLiteConnection conn)
    {
        List<Patient> patients = new List<Patient>();
        string sql = "SELECT * FROM Patients";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            patients.Add(readPatient(rdr));
        }
        return patients;
    }
    public static List<Doctor> GetAllDoctors(SQLiteConnection conn)
    {
        List<Doctor> doctors = new List<Doctor>();
        string sql = "SELECT * FROM Doctors";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            doctors.Add(readDoctor(rdr));
        }
        return doctors;
    }
    public static Patient GetPatient(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Patients WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return readPatient(rdr);
        }
        else
        {
            return new Patient(-1, string.Empty, string.Empty, new DateTime(), string.Empty);
        }
    }
    public static Doctor GetDoctor(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Doctors WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return readDoctor(rdr);
        }
        else
        {
            return new Doctor(-1, string.Empty, string.Empty, new DateTime(), -1, -1);
        }
    }
}
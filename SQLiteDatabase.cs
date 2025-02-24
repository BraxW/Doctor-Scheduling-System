/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: CIS317 4.6 Project
*
*/
using System.Data.SQLite;
public class SQLiteDatabase
{
    public static SQLiteConnection Connect(string database)
    {
        string cs = @"Data Source=" + database;
        SQLiteConnection conn = new SQLiteConnection(cs);
        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return conn;
    }
}

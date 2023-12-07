/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
public class Person
{

    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    // constructor
     public Person(int id, string firstName, string lastName, DateTime birthdate)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
    }

    public Person(string firstName, string lastName, DateTime birthdate)
    {
       FirstName = firstName;
       LastName = lastName;
       Birthdate = birthdate;
    }

    public int GetAge() {

        TimeSpan timeDiff = DateTime.Today.Subtract(Birthdate);

        return timeDiff.Days;
    }

    public override string ToString() {

        return string.Format(
            "[Person ID: {0}] {1} {2} is {3} years old and was born on {4}.",
            ID, FirstName, LastName, (GetAge()/365), Birthdate
        );
    }
}
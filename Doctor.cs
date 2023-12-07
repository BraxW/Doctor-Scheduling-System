/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
public class Doctor: Person
{
    public int WorkTimeStart { get; set; }
    public int WorkTimeEnd { get; set; }
    
    // Constructor
    public Doctor(int id, string firstName, string lastName, DateTime birthdate, int startWork, int endWork)
    : base(id, firstName, lastName, birthdate)
    {
        ID = id;
       FirstName = firstName;
       LastName = lastName;
       Birthdate = birthdate;
       WorkTimeStart = startWork;
       WorkTimeEnd = endWork;
    }
        public Doctor(string firstName, string lastName, DateTime birthdate, int startWork, int endWork)
    : base(firstName, lastName, birthdate)
    {
       FirstName = firstName;
       LastName = lastName;
       Birthdate = birthdate;
       WorkTimeStart = startWork;
       WorkTimeEnd = endWork;
    }

     public override string ToString() {

        return string.Format(
            "[Person ID: {0}] Dr. {1} is {2} years old and was born on {3}.\n\tThey work from {4} - {5} (24 Hour Format)\n",
            ID, LastName, (GetAge()/365), Birthdate, WorkTimeStart, WorkTimeEnd
        );
    }
}
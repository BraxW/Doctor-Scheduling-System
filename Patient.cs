/*******************************************************************
* Name: Braxton W
* Date: 11/30/2023
* Assignment: 3.7 Course Project
*
*/
public class Patient: Person
{
    public string PatientNotes { get; set; }
    
    // Constructor
    public Patient(int id, string firstName, string lastName, DateTime birthdate, string initalNotes)
    : base(id, firstName, lastName, birthdate)
    {
        ID = id;
       FirstName = firstName;
       LastName = lastName;
       Birthdate = birthdate;
       PatientNotes = initalNotes;
    }
        public Patient(string firstName, string lastName, DateTime birthdate, string initalNotes)
    : base( firstName, lastName, birthdate)
    {

       FirstName = firstName;
       LastName = lastName;
       Birthdate = birthdate;
       PatientNotes = initalNotes;
    }

     public override string ToString() {

        string notesString = PatientNotes == "" ? "None" : PatientNotes;

        return string.Format(
            "[Person ID: {0}] The patient {1} {2} is {3} years old and was born on {4}.\n\tNotes: {5}\n",
            ID, FirstName, LastName, (GetAge()/365), Birthdate, notesString
        );
    }
}
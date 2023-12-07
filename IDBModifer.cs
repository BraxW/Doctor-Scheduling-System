/*******************************************************************
* Name: Braxton 
* Date: 11/30/2023
* Assignment: CIS317 4.6 Course Project
*
* Interface for all database modifers
*/
using System.Data.SQLite;
interface DBModifer
{
    public abstract void CreateTable();
    public abstract void AddResult();
    public abstract void UpdateResult();
    public abstract void DeleteResult();
}
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Person>();
        }

        public List<Person> GetAllEmployees()
        {
            return dbConn.Query<Person>("Select * From [Person]");
        }
        public int SaveEmployee(Person aEmployee)
        {
            return dbConn.Insert(aEmployee);
        }
        public int DeleteEmployee(Person aEmployee)
        {
            return dbConn.Delete(aEmployee);
        }
        public int EditEmployee(Person aEmployee)
        {
            return dbConn.Update(aEmployee);
        }

        public Person SelectEmployee(Person aEmployee)
        {
            return dbConn.Find<Person>(a => a.UserName == aEmployee.UserName & a.Password==a.Password);
        }
    }
}

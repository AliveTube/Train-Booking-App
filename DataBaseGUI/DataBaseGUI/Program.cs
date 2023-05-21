using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public abstract class User
{
    private String firstName;
    private String lastName;
    private String password;
    private String email;
    private String phoneNumber;
    public void setfirstName(String fName)
    {
        firstName = fName;
    }
    public String getfirstName()
    {
        return firstName;
    }

    public void setlastName(String lName)
    {
        lastName = lName;
    }
    public String getlastName()
    {
        return lastName;
    }

    public void setPassword(String pass)
    {
        password = pass;
    }
    public String getPassword()
    {
        return password;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }
    public String getEmail()
    {
        return email;
    }

    public void setPhoneNumber(String phone)
    {
        phoneNumber = phone;
    }
    public String getPhoneNumber()
    {
        return phoneNumber;
    }
}
public class Admin : User
{
    private int adminID;

    public void setAdminID(int id)
    {
        adminID = id;
    }
    public int getAdminID()
    {
        return adminID;
    }
}
public class Customer : User
{
    private int customerID;

    public void setCustomerID(int id)
    {
        customerID = id;
    }
    public int getCustomerID()
    {
        return customerID;
    }
}
public class Trip
{
    private String tripID;
    private Train train;
    private String tripDate;
}
public class Train
{
    private String model;
    private int trainID;
}
namespace DataBaseGUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

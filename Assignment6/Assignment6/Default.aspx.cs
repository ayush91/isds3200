using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Assignment6;
//Ayush Gupta
// isds 3200
// Saving everything in a dictionary  

namespace Assignment6
{
    public partial class Default : System.Web.UI.Page
    {
        Account newaccount = new Account();
        Account newaccount2 = new Account();
        private const string Sessionname = "PleaseWork";
        Dictionary<int, Account> dict = new Dictionary<int , Account>();
        
        
        
        private string total;
        private int check;

       

        protected void Page_Load(object sender, EventArgs e)
        {
           // if (Session["AccountData"] == null)
            //{
              //  Account newAccount2 = new Account() { AccountId = 1050, Name = "Jones", Balance = 800.50 };
               // Account newAccount3 = new Account() { AccountId = 1001, Name = "Adams", Balance = 750.18 };
               // Account newAccount4 = new Account() { AccountId = 1020, Name = "Gonzales", Balance = 1800.21 };
               // Account newAccount5 = new Account() { AccountId = 1032, Name = "Senor Chang", Balance = 1200.50 };
               // dict.Add(newAccount2.AccountId, newAccount2);
               // dict.Add(newAccount3.AccountId, newAccount3);
               // dict.Add(newAccount4.AccountId, newAccount4);
               // dict.Add(newAccount5.AccountId, newAccount5);
               // Session["AccountData"] = dict;
           // }
            if (Session[Sessionname] != null)
            {
                dict = (Dictionary<int, Account>)Session[Sessionname];
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Dictionary<int, Account> dict = (Dictionary<int, Account>)Session["AccountData"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            check = int.Parse(TextBox1.Text);
            newaccount2.AccountId = check;
            newaccount2.Name = TextBox2.Text.ToString();
            newaccount2.Balance = double.Parse(TextBox3.Text);

            if( dict == null)
            {

                dict.Add(newaccount2.AccountId, newaccount2);
                ListBox1.Items.Add(newaccount2.ToString());

            }
            
            //Account checking = dict.ContainsKey(check) ? dict[check] : null;


            if ( dict.ContainsKey(check))  // not fully working yet
            {
                Label1.Text = " Entry already exist";
            }
            else
            {
                
                dict.Add(newaccount2.AccountId, newaccount2);
                
                //foreach(var account in dict)
                //{
                //   ListBox1.Text = account.Value.ToString();
                //}
                //total = newaccount.AccountId.ToString() + ", " + newaccount.Name + ", " + newaccount.Balance.ToString();
               
               ListBox1.Items.Add(newaccount2.ToString());
               

            }
            Session[Sessionname] = dict;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            check = int.Parse(TextBox1.Text);
            newaccount2.AccountId = check;
            newaccount2.Name = TextBox2.Text.ToString();
            newaccount2.Balance = double.Parse(TextBox3.Text);

            if ( dict.ContainsKey(check))
            {
                dict.Remove(check);
                ListBox1.Items.Clear();
                dict.Add(newaccount.AccountId, newaccount2);
                foreach ( Account newre in dict.Values)
                {
                    ListBox1.Items.Add(newaccount2.ToString());
                }
            }
            else
            {
                Label1.Text = " The key doesn't Exist";
            }
        }
        
        
 
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VoiceSageAssessment.Interface;
using VoiceSageAssessment.Models;

namespace VoiceSageAssessment.Repository
{
    public class ContactRepository : IContactRepository
    {
        string cnnString;
        public ContactRepository()
        {
            this.cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<ContactDetail> GetAllContactDetails()
        {
            List<ContactDetail> contactList = new List<ContactDetail>();


            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_select_ContactDetail";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require

            DataTable dt = new System.Data.DataTable();
            cnn.Open();
            sd.Fill(dt);
            cnn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                contactList.Add(
                    new ContactDetail
                    {
                        columnId = Convert.ToInt32(dr["columnId"]),
                        name = Convert.ToString(dr["name"]),
                        email = Convert.ToString(dr["email"]),
                        number = Convert.ToInt32(dr["number"]),
                        groupId = Convert.ToInt32(dr["GroupId"]),
                        groupName = Convert.ToString(dr["GroupName"])
                    });
            }
            return contactList;
        }

        public IEnumerable<GroupDetail> GetAllGroupName()
        {
            List<GroupDetail> GroupList = new List<GroupDetail>();


            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_select_GroupDetail";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require

            DataTable dt = new System.Data.DataTable();
            cnn.Open();
            sd.Fill(dt);
            cnn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                GroupList.Add(
                    new GroupDetail
                    {
                        GroupId = Convert.ToInt32(dr["GroupId"]),
                        GroupName = Convert.ToString(dr["GroupName"])
                    });
            }
            return GroupList;
        }

        public ContactDetail GetContact(int contactId)
        {
            ContactDetail contact = new ContactDetail();
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_select_Contact";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@contactId", contactId);
            DataTable dt = new System.Data.DataTable();
            cnn.Open();
            sd.Fill(dt);
            cnn.Close();

            // grpData.GroupId = Convert.ToInt32(dt.Rows[grupId]);

            foreach (DataRow dr in dt.Rows)
            {
                contact.columnId = Convert.ToInt32(dr["columnId"]);
                contact.name = Convert.ToString(dr["name"]);
                contact.email = Convert.ToString(dr["email"]);
                contact.number = Convert.ToInt32(dr["number"]);
                contact.groupId = Convert.ToInt32(dr["GroupId"]);
                contact.groupName = Convert.ToString(dr["GroupName"]);
                
            }
            return contact;
        }

        public void InsertContactDetails(ContactDetail contact)
        {
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert_Contact_details";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@name", contact.name);
            cmd.Parameters.AddWithValue("@number", contact.number);
            cmd.Parameters.AddWithValue("@email", contact.email);
            cmd.Parameters.AddWithValue("@groupId", contact.groupName);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void UpdateContactDetails(ContactDetail contact)
        {

            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_update_contact_details";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@name", contact.name);
            cmd.Parameters.AddWithValue("@number", contact.number);
            cmd.Parameters.AddWithValue("@email", contact.email);
            cmd.Parameters.AddWithValue("@groupId", contact.groupName);
            cmd.Parameters.AddWithValue("@contactId", contact.columnId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void DeleteContact(int contactId)
        {

            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_delete_Contact";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@contactId", contactId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
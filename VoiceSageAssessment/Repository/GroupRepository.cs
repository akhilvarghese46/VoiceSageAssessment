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
    public class GroupRepository : IGroupRepository
    {
        string cnnString;
        public GroupRepository()
        {
            this.cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<GroupDetail> GetAllGroupDetails()
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
                        GroupDescription = Convert.ToString(dr["GroupDescription"]),
                        GroupName = Convert.ToString(dr["GroupName"])
                    });
            }
            return GroupList;
        }

        public GroupDetail GetGroup(int grupId)
        {
            GroupDetail grpData = new GroupDetail();
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_select_Group";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@groupId", grupId);
            DataTable dt = new System.Data.DataTable();
            cnn.Open();
            sd.Fill(dt);
            cnn.Close();

           // grpData.GroupId = Convert.ToInt32(dt.Rows[grupId]);

            foreach (DataRow dr in dt.Rows)
            {
                grpData.GroupId = Convert.ToInt32(dr["GroupId"]);
                grpData.GroupDescription = Convert.ToString(dr["GroupDescription"]);
                grpData.GroupName = Convert.ToString(dr["GroupName"]);

            }
            return grpData;
        }

        public void InsertGroupDetails(GroupDetail group)
        {
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert_groupdetails";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@groupName", group.GroupName);
            cmd.Parameters.AddWithValue("@groupDescription", group.GroupDescription);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void DeleteGroup(int groupId)
        {
          
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_delete_Group";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            
        }

        public void UpdateGroupDetails(GroupDetail group)
        {
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_update_groupdetails";
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@groupName", group.GroupName);
            cmd.Parameters.AddWithValue("@groupDescription", group.GroupDescription);
            cmd.Parameters.AddWithValue("@groupId", group.GroupId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

    }
}
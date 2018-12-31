using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality{ get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Member()
        {

        }

        public Member(string firstName, string lastName, string nationality, string gender,
                     DateTime birthDate, string photo, string phone, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            Gender = gender;
            BirthDate = birthDate;
            Photo = photo;
            Phone = phone;
            Email = email;
            Address = address;
        }

        /************************************************A method to append a new member into database*************************************************/
        public int AddMember(Member member)
        {
            int memberID = -1;

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddMember",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = member.FirstName;
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = member.LastName;
            sqlCommand.Parameters.Add("@nationality", SqlDbType.NVarChar).Value = member.Nationality;
            sqlCommand.Parameters.Add("@gender", SqlDbType.NVarChar).Value = member.Gender;
            sqlCommand.Parameters.Add("@birthDate", SqlDbType.Date).Value = member.BirthDate;
            sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = member.Photo;
            sqlCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = member.Phone;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = member.Email;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar).Value = member.Address;

            //Sets Up an output parameter
            sqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@memberID",
                SqlDbType = SqlDbType.Int,
                Value = -1,
                Direction = ParameterDirection.Output
            });

            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);

                //Retrieves the ID of the newly added member
                memberID = Convert.ToInt32(sqlCommand.Parameters["@memberID"].Value);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Dispose the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return memberID;
        }

        /************************************************A method to update an existing member into database*************************************************/
        public void UpdateMember(int memberID, Member member)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdateMember",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@memberID", SqlDbType.Int).Value = member.ID;
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = member.FirstName;
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = member.LastName;
            sqlCommand.Parameters.Add("@nationality", SqlDbType.NVarChar).Value = member.Nationality;
            sqlCommand.Parameters.Add("@gender", SqlDbType.NVarChar).Value = member.Gender;
            sqlCommand.Parameters.Add("@birthDate", SqlDbType.Date).Value = member.BirthDate;
            sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = member.Photo;
            sqlCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = member.Phone;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = member.Email;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar).Value = member.Address;

            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Dispose the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }

        /************************************************A method to delete a member from database*************************************************/
        public void DeleteMember(int memberID)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeleteMember",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameter to the SqlCommand object & Sets its value
            sqlCommand.Parameters.Add("@memberID", SqlDbType.Int).Value = memberID;

            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Dispose the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }

        /**************************************************Check Member Name Method***************************************************/
        public bool CheckIfMemberExists(string firstName, string lastName)
        {
            bool memberExists = false;
            DataSet dataSet = new DataSet();

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spCheckIfMemberExists",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;

            try
            {
                //Executes the SqlCommand
                int result = DataAccess.ReturnSingleValue(sqlCommand);

                if (result == 1)
                    memberExists = true;
            }

            finally
            {
               sqlCommand.Parameters.Clear();
               sqlCommand.Dispose();
            }

            return memberExists;
        }

        /**************************************************A method to get a Subscriber's details************************************************************/
        public DataSet GetMemberByID(int memberID)
        {
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand()
            {
                CommandText = "spGetMemberByID",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@memberID",
                SqlDbType = SqlDbType.Int,
                Value = memberID 
            });

            try
            {
                dataSet = DataAccess.SelectData(command);
            }

            catch (SqlException ex)
            {
                ex.ToString();
                return null;
            }

            finally
            {
                command.Parameters.Clear();
                command.Dispose();
            }

            return dataSet;
        }

        /**************************************************A method to retrieve all members from database******************************************************/
        public DataSet ShowAllMembers()
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spShowAllMembers",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                dataSet = DataAccess.SelectData(command);
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                command.Parameters.Clear();
                command.Dispose();
            }

            return dataSet;
        }

        /**************************************************A method to search for a member by name*************************************/
        public DataSet SearchMembersByName(string memberName)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spSearchMembersByName",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@memberName",
                SqlDbType = SqlDbType.NVarChar,
                Value = memberName
            });

            try
            {
                dataSet = DataAccess.SelectData(command);
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                command.Parameters.Clear();
                command.Dispose();
            }

            return dataSet;
        }
    }
}
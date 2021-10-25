using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.OutMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace stadium_management.Persistence
{
    public class Clients : Connection
    {
        public static SignUpClientOut SignUpClient(Client ClientIn)
        {
            SignUpClientOut result = new SignUpClientOut { OperationResult = OperationResult.InvalidUser };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();
                bool rtn = true;
                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Clients_GetClientByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Username", ClientIn.Username));

                    var returnValue = cmd.Parameters.Add("@ClientExists", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    rtn = Convert.ToBoolean(Convert.ToInt32(returnValue.Value));
                }

                if (!rtn)
                {
                    using (cmd = new SqlCommand("Clients_SignUp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Name", ClientIn.Name));
                        cmd.Parameters.Add(new SqlParameter("@Lastname", ClientIn.LastName));
                        cmd.Parameters.Add(new SqlParameter("@Password", ClientIn.Password));
                        cmd.Parameters.Add(new SqlParameter("@Username", ClientIn.Username));

                        int rtnInsert = Convert.ToInt32(cmd.ExecuteScalar());
                        if (rtnInsert > 0)
                        {
                            result.Client = new Client
                            {
                                Id = rtnInsert,
                                Name = ClientIn.Name,
                                LastName = ClientIn.LastName,
                                Password = ClientIn.Password,
                                Username = ClientIn.Username,
                                IsDeleted = false
                            };
                            result.OperationResult = OperationResult.Success;
                        }
                    }
                }
                else
                {
                    result.OperationResult = OperationResult.UsernameAlreadyExist;
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static SignInClientOut SignInClient(Client ClientIn)
        {
            SignInClientOut result = new SignInClientOut { OperationResult = OperationResult.InvalidUser };
            Client client = new Client();
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Clients_SignIn", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Username", ClientIn.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", ClientIn.Password));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var clientExist = int.Parse(oReader["clientExists"].ToString());
                        if (clientExist == 1)
                        {
                            client.Id = int.Parse(oReader["ClientId"].ToString());
                            client.Name = oReader["Name"].ToString();
                            client.Password = oReader["Password"].ToString();
                            client.Username = oReader["Username"].ToString();
                            client.LastName = oReader["Lastname"].ToString();
                            client.IsDeleted = bool.Parse(oReader["IsDeleted"].ToString());
                            result.OperationResult = OperationResult.Success;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            result.Client = client;
            return result;
        }
    }
}
using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.InMethods;
using stadium_management.CrossCuttingConcerns.OutMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace stadium_management.Persistence
{
    public class Administrators : Connection
    {
        public static SignInAdministratorOut SignInAdministrator(Administrator AdminIn)
        {
            SignInAdministratorOut result = new SignInAdministratorOut { OperationResult = OperationResult.InvalidUser };
            Administrator administrator = new Administrator();
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Administrators_SignIn", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Username", AdminIn.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", AdminIn.Password));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        var adminExist = int.Parse(oReader["adminExist"].ToString());
                        if (adminExist == 1)
                        {
                            administrator.Id = int.Parse(oReader["AdministratorId"].ToString());
                            administrator.DocumentNumber = oReader["DocumentNumber"].ToString();
                            administrator.LastName = oReader["Lastname"].ToString();
                            administrator.Name = oReader["Name"].ToString();
                            administrator.Password = oReader["Password"].ToString();
                            administrator.Telephone = oReader["Telephone"].ToString();
                            administrator.Username = oReader["Username"].ToString();
                            administrator.IsDeleted = bool.Parse(oReader["IsDeleted"].ToString());
                                
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

            result.Administrator = administrator;
            return result;
        }


        public static GetAdministratorsOut GetAdministrators(GetAdministratorsIn AdminIn)
        {
            GetAdministratorsOut result = new GetAdministratorsOut { OperationResult = OperationResult.Error, Administrators = new List<Administrator>() };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Administrators_GetAdministrators", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter paramStartIndex = new SqlParameter
                {
                    ParameterName = "@PageIndex",
                    Value = AdminIn.PageIndex
                };
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter
                {
                    ParameterName = "@PageSize",
                    Value = AdminIn.PageSize
                };
                cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramOutputTotalRows = new SqlParameter
                {
                    ParameterName = "@TotalRows",
                    Direction = ParameterDirection.Output,
                    SqlDbType = SqlDbType.Int
                };

                cmd.Parameters.Add(paramOutputTotalRows);

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Administrator administrator = new Administrator();
                        administrator.Id = int.Parse(oReader["AdministratorId"].ToString());
                        administrator.DocumentNumber = oReader["DocumentNumber"].ToString();
                        administrator.LastName = oReader["Lastname"].ToString();
                        administrator.Name = oReader["Name"].ToString();
                        administrator.Password = oReader["Password"].ToString();
                        administrator.Telephone = oReader["Telephone"].ToString();
                        administrator.Username = oReader["Username"].ToString();
                        result.Administrators.Add(administrator);
                    }
                    oReader.Close();
                    result.TotalRows = (int)cmd.Parameters["@TotalRows"].Value;
                    result.OperationResult = OperationResult.Success;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static AddAdministratorOut AddAdministrator(Administrator AdminIn)
        {
            AddAdministratorOut result = new AddAdministratorOut { OperationResult = OperationResult.InvalidUser };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();
                bool rtn = true;
                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Administrators_GetAdministratorByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Username", AdminIn.Username));

                    var returnValue = cmd.Parameters.Add("@AdministratorExist", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    rtn = Convert.ToBoolean(Convert.ToInt32(returnValue.Value));
                }

                if (!rtn)
                {
                    using (cmd = new SqlCommand("Administrators_AddAdministrator", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Name", AdminIn.Name));
                        cmd.Parameters.Add(new SqlParameter("@Lastname", AdminIn.LastName));
                        cmd.Parameters.Add(new SqlParameter("@DocumentNumber", AdminIn.DocumentNumber));
                        cmd.Parameters.Add(new SqlParameter("@Telephone", AdminIn.Telephone));
                        cmd.Parameters.Add(new SqlParameter("@Password", AdminIn.Password));
                        cmd.Parameters.Add(new SqlParameter("@Username", AdminIn.Username));

                        int rtnInsert = Convert.ToInt32(cmd.ExecuteNonQuery());
                        if (rtnInsert > 0)
                        {
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

        public static DeleteAdministratorOut DeleteAdministrator(Administrator AdminIn)
        {
            DeleteAdministratorOut result = new DeleteAdministratorOut { OperationResult = OperationResult.Error };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Administrators_DeleteAdministrator", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdministratorId", AdminIn.Id));

                    int rtnDelete = cmd.ExecuteNonQuery();
                    if (rtnDelete > 0)
                    {
                        result.OperationResult = OperationResult.Success;
                    }
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

        public static GetAdministratorByIdOut GetAdministratorById(Administrator AdminIn)
        {
            GetAdministratorByIdOut result = new GetAdministratorByIdOut { OperationResult = OperationResult.Error, Administrator = new Administrator() };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Administrators_GetAdministratorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdministratorId", AdminIn.Id));

                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Administrator administrator = new Administrator
                            {
                                Id = int.Parse(oReader["AdministratorId"].ToString()),
                                Name = oReader["Name"].ToString(),
                                LastName = oReader["Lastname"].ToString(),
                                DocumentNumber = (oReader["DocumentNumber"].ToString()),
                                Telephone = oReader["Telephone"].ToString(),
                                Username = oReader["Username"].ToString(),
                                Password = oReader["Password"].ToString(),
                                IsDeleted = Convert.ToBoolean(oReader["IsDeleted"].ToString())
                            };
                            result.Administrator = administrator;
                            result.OperationResult = OperationResult.Success;
                        }

                        conn.Close();
                    }
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

        public static UpdateAdministratorOut UpdateAdministrator(Administrator AdminIn)
        {
            UpdateAdministratorOut result = new UpdateAdministratorOut { OperationResult = OperationResult.Error };

            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Administrators_UpdateAdministrator", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdministratorId", AdminIn.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", AdminIn.Name));
                    cmd.Parameters.Add(new SqlParameter("@Lastname", AdminIn.LastName));
                    cmd.Parameters.Add(new SqlParameter("@DocumentNumber", AdminIn.DocumentNumber));
                    cmd.Parameters.Add(new SqlParameter("@Telephone", AdminIn.Telephone));
                    cmd.Parameters.Add(new SqlParameter("@Username", AdminIn.Username));
                    cmd.Parameters.Add(new SqlParameter("@Password", AdminIn.Password));

                    cmd.Parameters.Add("@AdministratorUsernameExist", SqlDbType.Bit);
                    cmd.Parameters["@AdministratorUsernameExist"].Direction = ParameterDirection.Output;

                    int rtnUpdate = cmd.ExecuteNonQuery();
                    bool AdministratorUsernameExist = bool.Parse(cmd.Parameters["@AdministratorUsernameExist"].Value.ToString());
                    if (!AdministratorUsernameExist)
                    {
                        if (rtnUpdate > 0)
                        {
                            result.OperationResult = OperationResult.Success;
                        }
                    }
                    else
                    {
                        result.OperationResult = OperationResult.UsernameAlreadyExist;
                    }
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
    }
}
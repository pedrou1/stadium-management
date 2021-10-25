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
    public class Events : Connection
    {
        public static GetEventsOut GetEvents(GetEventsIn EventIn)
        {
            GetEventsOut result = new GetEventsOut { OperationResult = OperationResult.Error, Events = new List<Event>() };

            using (SqlConnection con = new SqlConnection(ConnectionStringBuilder))
            {
                SqlCommand cmd = new SqlCommand("Events_GetEvents", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter paramStartIndex = new SqlParameter
                {
                    ParameterName = "@PageIndex",
                    Value = EventIn.PageIndex
                };
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter
                {
                    ParameterName = "@PageSize",
                    Value = EventIn.PageSize
                };
                cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramOutputTotalRows = new SqlParameter
                {
                    ParameterName = "@TotalRows",
                    Direction = ParameterDirection.Output,
                    SqlDbType = SqlDbType.Int
                };

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader oReader = cmd.ExecuteReader();
                while (oReader.Read())
                {
                    Event Event = new Event { EventType = new EventType() };
                    Event.Id = int.Parse(oReader["EventId"].ToString());
                    Event.Name = oReader["Name"].ToString();
                    Event.Description = oReader["Description"].ToString();
                    Event.Requirements = oReader["Requirements"].ToString();
                    Event.StartTime = Convert.ToDateTime(oReader["startTime"].ToString());
                    Event.EndTime = Convert.ToDateTime(oReader["EndTime"].ToString());
                    Event.Image = oReader["Image"].ToString();
                    Event.SeatsAvailableStandard = int.Parse(oReader["SeatsAvailableStandard"].ToString());
                    Event.SeatsAvailablePlus = int.Parse(oReader["SeatsAvailablePlus"].ToString());
                    Event.BasePrice = int.Parse(oReader["EventId"].ToString());
                    Event.EventType = new EventType
                    {
                        Id = int.Parse(oReader["EventTypeId"].ToString()),
                        Name = (oReader["EventTypeName"].ToString())
                    };
                    Event.Stage = new Stage
                    {
                        Id = int.Parse(oReader["StageId"].ToString())
                    };
                    result.Events.Add(Event);
                }

                oReader.Close();
                result.OperationResult = OperationResult.Success;
                result.TotalRows = (int)cmd.Parameters["@TotalRows"].Value;

            }

            return result;
        }

        public static GetEventTypesOut GetEventTypes()
        {
            GetEventTypesOut result = new GetEventTypesOut { OperationResult = OperationResult.Error, EventTypes = new List<EventType>() };

            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Events_GetEventTypes", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        EventType EventType = new EventType
                        {
                            Id = int.Parse(oReader["EventTypeId"].ToString()),
                            Name = oReader["Name"].ToString()
                        };
                        result.EventTypes.Add(EventType);
                    }
                    result.OperationResult = OperationResult.Success;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static AddEventOut AddEvent(Event EventIn)
        {
            AddEventOut result = new AddEventOut { OperationResult = OperationResult.Error };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Events_AddEvent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
   
                    cmd.Parameters.Add(new SqlParameter("@Name", EventIn.Name));
                    cmd.Parameters.Add(new SqlParameter("@Description", EventIn.Description));
                    cmd.Parameters.Add(new SqlParameter("@StageId", EventIn.Stage.Id));
                    cmd.Parameters.Add(new SqlParameter("@Requirements", EventIn.Requirements));
                    cmd.Parameters.Add(new SqlParameter("@Image", EventIn.Image));
                    cmd.Parameters.Add(new SqlParameter("@StartTime", EventIn.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@EndTime", EventIn.EndTime));
                    cmd.Parameters.Add(new SqlParameter("@SeatsAvailableStandard", EventIn.SeatsAvailableStandard));
                    cmd.Parameters.Add(new SqlParameter("@SeatsAvailablePlus", EventIn.SeatsAvailablePlus));
                    cmd.Parameters.Add(new SqlParameter("@BasePrice", EventIn.BasePrice));
                    cmd.Parameters.Add(new SqlParameter("@EventTypeId", EventIn.EventType.Id));

                    int rtnInsert = cmd.ExecuteNonQuery();
                    if (rtnInsert > 0)
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

        public static GetEventByIdOut GetEventById(Event EventIn)
        {
            GetEventByIdOut result = new GetEventByIdOut { OperationResult = OperationResult.Error, Event = new Event { EventType = new EventType() } };

            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Events_GetEventById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@EventId", EventIn.Id));

                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {

                        while (oReader.Read())
                        {
                            Event Event = new Event { EventType = new EventType() };
                            Event.Id = int.Parse(oReader["EventId"].ToString());
                            Event.Name = oReader["Name"].ToString();
                            Event.Description = oReader["Description"].ToString();
                            Event.Requirements = oReader["Requirements"].ToString();
                            Event.StartTime = Convert.ToDateTime(oReader["startTime"].ToString());
                            Event.EndTime = Convert.ToDateTime(oReader["EndTime"].ToString());
                            Event.Image = oReader["Image"].ToString();
                            Event.SeatsAvailableStandard = int.Parse(oReader["SeatsAvailableStandard"].ToString());
                            Event.SeatsAvailablePlus = int.Parse(oReader["SeatsAvailablePlus"].ToString());
                            Event.BasePrice = int.Parse(oReader["EventId"].ToString());
                            Event.EventType = new EventType
                            {
                                Id = int.Parse(oReader["EventTypeId"].ToString()),
                                Name = (oReader["EventTypeName"].ToString())
                            };
                            Event.Stage = new Stage
                            {
                                Id = int.Parse(oReader["StageId"].ToString())
                            };
                            
                            result.Event = Event;
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

        public static DeleteEventOut DeleteEvent(Event EventIn)
        {
            DeleteEventOut result = new DeleteEventOut { OperationResult = OperationResult.Error };
            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Events_DeleteEvent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@EventId", EventIn.Id));

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

        public static UpdateEventOut UpdateEvent(Event EventIn)
        {
            UpdateEventOut result = new UpdateEventOut { OperationResult = OperationResult.Error };

            try
            {
                var conn = new SqlConnection(ConnectionStringBuilder);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                using (cmd = new SqlCommand("Events_UpdateEvent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Name", EventIn.Name));
                    cmd.Parameters.Add(new SqlParameter("@Description", EventIn.Description));
                    cmd.Parameters.Add(new SqlParameter("@StageId", EventIn.Stage.Id));
                    cmd.Parameters.Add(new SqlParameter("@Requirements", EventIn.Requirements));
                    cmd.Parameters.Add(new SqlParameter("@Image", EventIn.Image));
                    cmd.Parameters.Add(new SqlParameter("@StartTime", EventIn.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@EndTime", EventIn.EndTime));
                    cmd.Parameters.Add(new SqlParameter("@SeatsAvailableStandard", EventIn.SeatsAvailableStandard));
                    cmd.Parameters.Add(new SqlParameter("@SeatsAvailablePlus", EventIn.SeatsAvailablePlus));
                    cmd.Parameters.Add(new SqlParameter("@BasePrice", EventIn.BasePrice));
                    cmd.Parameters.Add(new SqlParameter("@EventTypeId", EventIn.EventType.Id));

                    int rtnUpdate = cmd.ExecuteNonQuery();
                    if (rtnUpdate > 0)
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
    }
}
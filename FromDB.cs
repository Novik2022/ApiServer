using System;
using System.Collections.Generic;
using ApiServer.Controllers;
using Npgsql;

namespace ApiServer
{

    public class RelatedProcess
    {
        public int Id { get; set; }          //0
        public int Parent_Id { get; set; }   //1
        public int Related_Id { get; set; }  //2
        public int RelationType_Id { get; set; }  //3

    }

    public class Stage
    {
        public int Id { get; set; }  //0
        public string Name { get; set; } //1
        public bool isBase { get; set; } //1

    }
    public class Incident
    {
        public int Id { get; set; }  //0
        public string Number { get; set; } //1
        public int Type_Id { get; set; } //2
        public int Priority_Id { get; set; } //3
        public int Stage_Id { get; set; }  //4
        public int Initiator_Id { get; set; } //5
        public string Description { get; set; } //6
        public int Classification_Id { get; set; } //7
        public DateTime EventTime { get; set; } //8
        public DateTime LrRegistrationTime { get; set; }  //9
        public int Executor_Id { get; set; }  //10
        public DateTime WorkStartTime { get; set; }  //11
        public int Coordinator_Id { get; set; }  //12
        public DateTime WorkCompleteTime { get; set; }  //13
        public DateTime ClosedTime { get; set; }  //14

        //public Duration //15
        public string Result { get; set; } //16
        public int Solution_Id { get; set; }  //17
        public int[] WorkExecutors { get; set; } //18
        public bool NeedApproving { get; set; } //19
        public DateTime DurationStartDate { get; set; } //20
        public DateTime FirstStageUsedInElapsedTime { get; set; }  //21
        public string CreateUserLogin { get; set; } //22
        public string UpdateUserLogin { get; set; } //23
        public string DeleteUserLogin { get; set; } //24
        public DateTime CreateDate { get; set; } //25
        public DateTime UpdateDate { get; set; } //26
        public DateTime DeleteDate { get; set; } //27
        public string Type { get; set; }
        public string Priority { get; set; }
        public string Stage { get; set; }
        public string Initiator { get; set; }
        public string Coordinator { get; set; }
        public string Executor { get; set; }
        public string Classification { get; set; }
        public string Reason { get; set; }
        public int Parent_Id { get; set; }
        //  public bool StatusRequest { get; set; }
        //  public string StatusRequestString { get; set; }

    }



    public class FromDB
    {
        //private object[] values;

        public struct DateTimeWithZone
        {
            private readonly DateTime utcDateTime;
            private readonly TimeZoneInfo timeZone;

            public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
            {
                var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
                utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
                this.timeZone = timeZone;
            }

            public DateTime UniversalTime { get { return utcDateTime; } }

            public TimeZoneInfo TimeZone { get { return timeZone; } }

            public DateTime LocalTime
            {
                get
                {
                    return TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
                }
            }
        }

        //Reason НАЧАЛО
        public string getReason(int Inc_id)
        {
            string reason = "";
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select * from "Trs.Lr.Process"."Stage"
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Incident" + '\u0022' + "." + '\u0022' + "OccurrenceReason" + '\u0022' + " " + "where " + '\u0022' + "Id" + '\u0022' + "= " + Inc_id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    reason = reader.GetString(4);
                }
                catch
                { }

            }
            reader.Close();
            conn.Close();
            return reason;

        }
        //Reason КОНЕЦ


        //ReasonId НАЧАЛО
        public int getReasonId(int Inc_id)
        {
            int reasonId = 0;
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select * from "Trs.Lr.Process"."Stage"
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Incident" + '\u0022' + "." + '\u0022' + "Incident" + '\u0022' + " " + "where " + '\u0022' + "Process_Id" + '\u0022' + "= " + Inc_id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    reasonId = reader.GetInt32(2);
                }
                catch
                { }

            }
            reader.Close();
            conn.Close();
            return reasonId;

        }
        //ReasonId КОНЕЦ

        //Iniciator НАЧАЛО
        public String getEmpl(int Emlp_id)
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";
            string Empl = "";
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select * from "Trs.Lr.Process"."Stage"
            string sqlQuery = "select * from " + '\u0022' + "Trs.OrgStructure" + '\u0022' + "." + '\u0022' + "Employee" + '\u0022' + " " + "where " + '\u0022' + "Id" + '\u0022' + "= " + Emlp_id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Empl = reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5);

            }
            reader.Close();
            conn.Close();
            return Empl;

        }
        //Iniciator КОНЕЦ*/


        //СТАТУС НАЧАЛО
        public String getStage(int Stage_id)
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";
            string Stage = "Открыто";
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select * from "Trs.Lr.Process"."Stage"
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "Stage" + '\u0022' + " " + "where " + '\u0022' + "Id" + '\u0022' + "= " + Stage_id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Stage = reader.GetString(1);

            }
            reader.Close();
            conn.Close();
            return Stage;
        }
        //СТАТУС КОНЕЦ*/

        public object getIncList()
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            List<Incident> incidents = new List<Incident>();
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "LrProcess" + '\u0022' + " where " + '\u0022' + "Type_Id" + '\u0022' + " = 1";
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Incident incident = new Incident();
                if (reader.GetString(1) != null)
                {
                    incident.Id = reader.GetInt32(0);
                    incident.Number = reader.GetString(1);
                    incident.Type_Id = reader.GetInt32(2);
                    incident.Priority_Id = reader.GetInt32(3);
                    incident.Stage_Id = reader.GetInt32(4);
                    incident.Initiator_Id = reader.GetInt32(5);
                    try
                    {
                        incident.Description = reader.GetString(6);
                    }
                    catch
                    { }
                    incident.Classification_Id = reader.GetInt32(7);
                    incident.EventTime = reader.GetDateTime(8).ToLocalTime();
                    incident.LrRegistrationTime = reader.GetDateTime(9).ToLocalTime();
                    incident.Executor_Id = reader.GetInt32(10);
                    try
                    {
                        incident.WorkStartTime = reader.GetDateTime(11).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.Coordinator_Id = reader.GetInt32(12);
                    }
                    catch
                    { }
                    try
                    {
                        incident.WorkCompleteTime = reader.GetDateTime(13).ToLocalTime();
                    }
                    catch
                    { }
                    //incident.ClosedTime = reader.GetDateTime(14);
                    try
                    {
                        incident.Result = reader.GetString(16);
                    }
                    catch
                    { }
                    //int[] values = new int[5];
                    //incident.Solution_Id = reader.GetInt32(17);
                    //incident.WorkExecutors = reader.GetValues(values);
                    incident.NeedApproving = reader.GetBoolean(19);
                    try
                    {
                        incident.DurationStartDate = reader.GetDateTime(20).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.FirstStageUsedInElapsedTime = reader.GetDateTime(21).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.CreateUserLogin = reader.GetString(22);
                    }
                    catch
                    { }
                    //incident.UpdateUserLogin = reader.GetString(23);
                    try
                    {
                        incident.DeleteUserLogin = reader.GetString(24);
                    }
                    catch
                    { }
                    incident.CreateDate = reader.GetDateTime(25).ToLocalTime();
                    incident.Type = "Инцидент";
                    incident.Priority = "Высший";
                    incident.Classification = "Другой";
                    incident.Stage = getStage(incident.Stage_Id);
                    incident.Coordinator = getEmpl(incident.Coordinator_Id);
                    incident.Executor = getEmpl(incident.Executor_Id);
                    incident.Initiator = getEmpl(incident.Initiator_Id);

                    incident.Reason = getReason(getReasonId(incident.Id));

                    incidents.Add(incident);
                }

            }

            reader.Close();
            conn.Close();
            return incidents;

        }


        public object getIncData(int id)
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "LrProcess" + '\u0022' + "where " + '\u0022' + "Id" + '\u0022' + "= " + id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            object sqlQueryResult = null;
            Incident incident = new Incident();

            while (reader.Read())
            {

                if (reader.GetString(1) != null)
                {
                    incident.Id = reader.GetInt32(0);

                    incident.Number = reader.GetString(1);
                    incident.Type_Id = reader.GetInt32(2);
                    incident.Priority_Id = reader.GetInt32(3);
                    incident.Stage_Id = reader.GetInt32(4);
                    incident.Initiator_Id = reader.GetInt32(5);
                    try
                    {
                        incident.Description = reader.GetString(6);
                    }
                    catch
                    { }
                    incident.Classification_Id = reader.GetInt32(7);
                    incident.EventTime = reader.GetDateTime(8).ToLocalTime();
                    incident.LrRegistrationTime = reader.GetDateTime(9).ToLocalTime();
                    incident.Executor_Id = reader.GetInt32(10);
                    try
                    {
                        incident.WorkStartTime = reader.GetDateTime(11).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.Coordinator_Id = reader.GetInt32(12);
                    }
                    catch
                    { }
                    try
                    {
                        incident.WorkCompleteTime = reader.GetDateTime(13).ToLocalTime();
                    }
                    catch
                    { }
                    //incident.ClosedTime = reader.GetDateTime(14);
                    try
                    {
                        incident.Result = reader.GetString(16);
                    }
                    catch
                    { }
                    //int[] values = new int[5];
                    //incident.Solution_Id = reader.GetInt32(17);
                    //incident.WorkExecutors = reader.GetValues(values);
                    incident.NeedApproving = reader.GetBoolean(19);
                    try
                    {
                        incident.DurationStartDate = reader.GetDateTime(20).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.FirstStageUsedInElapsedTime = reader.GetDateTime(21).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.CreateUserLogin = reader.GetString(22);
                    }
                    catch
                    { }
                    //incident.UpdateUserLogin = reader.GetString(23);
                    try
                    {
                        incident.DeleteUserLogin = reader.GetString(24);
                    }
                    catch
                    { }
                    incident.CreateDate = reader.GetDateTime(25).ToLocalTime();
                    //incident.UpdateDate = reader.GetDateTime(26);
                    //incident.DeleteDate = reader.GetDateTime(27);


                    sqlQueryResult = incident;

                }
                else
                {

                    sqlQueryResult = null;
                }


            }
            reader.Close();
            conn.Close();
            return sqlQueryResult;


        }

        //Реестр запросов на изменение НАЧАЛО
        public object getChangeRequestList()
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            List<Incident> incidents = new List<Incident>();
            //select * from "Trs.Lr.Process"."LrProcess" where "Type_Id" = 5
            //За текущие сутки + AND "LrRegistrationTime" > DATE_TRUNC('day', NOW()) AND "LrRegistrationTime" < 'tomorrow'::timestamp

            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "LrProcess" + '\u0022' + " where " + '\u0022' + "Type_Id" + '\u0022' + " = 3" +
                " AND " + '\u0022' + "LrRegistrationTime" + '\u0022' + " > DATE_TRUNC('day', NOW()) AND " + '\u0022' + "LrRegistrationTime" + '\u0022' + " < " + "'tomorrow'::timestamp";
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Incident incident = new Incident();
                if (reader.GetString(1) != null)
                {
                    incident.Id           = reader.GetInt32(0);
                    incident.Number       = reader.GetString(1);
                    incident.Type_Id      = reader.GetInt32(2);
                    incident.Priority_Id  = reader.GetInt32(3);
                    incident.Stage_Id     = reader.GetInt32(4);
                    incident.Initiator_Id = reader.GetInt32(5);
                    try
                    {
                        incident.Description = reader.GetString(6);
                    }
                    catch
                    { }
                    incident.Classification_Id  = reader.GetInt32(7);
                    incident.EventTime          = reader.GetDateTime(8).ToLocalTime();
                    incident.LrRegistrationTime = reader.GetDateTime(9).ToLocalTime();
                    incident.Executor_Id        = reader.GetInt32(10);
                    try
                    {
                        incident.WorkStartTime = reader.GetDateTime(11).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.Coordinator_Id = reader.GetInt32(12);
                    }
                    catch
                    { }
                    try
                    {
                        incident.WorkCompleteTime = reader.GetDateTime(13).ToLocalTime();
                    }
                    catch
                    { }
                    //incident.ClosedTime = reader.GetDateTime(14);
                    try
                    {
                        incident.Result = reader.GetString(16);
                    }
                    catch
                    { }
                    //int[] values = new int[5];
                    //incident.Solution_Id = reader.GetInt32(17);
                    //incident.WorkExecutors = reader.GetValues(values);
                    incident.NeedApproving = reader.GetBoolean(19);
                    try
                    {
                    incident.DurationStartDate = reader.GetDateTime(20).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.FirstStageUsedInElapsedTime = reader.GetDateTime(21).ToLocalTime();
                    }
                    catch
                    { }
                    try
                    {
                        incident.CreateUserLogin = reader.GetString(22);
                    }
                    catch
                    { }
                    //incident.UpdateUserLogin = reader.GetString(23);
                    try
                    {
                        incident.DeleteUserLogin = reader.GetString(24);
                    }
                    catch
                    { }
                    incident.CreateDate = reader.GetDateTime(25).ToLocalTime();
                    incident.Type           = getType(incident.Type_Id);
                    incident.Priority       = "Высший";
                    incident.Classification = "Другой";
                    incident.Stage          = getStage(incident.Stage_Id);
                    incident.Coordinator    = getEmpl(incident.Coordinator_Id);
                    incident.Executor       = getEmpl(incident.Executor_Id);
                    incident.Initiator      = getEmpl(incident.Initiator_Id);

                    incident.Reason    = getReason(getReasonId(incident.Id));
                    incident.Parent_Id = getParentId(incident.Id);

                    incidents.Add(incident);
                }

            }

            reader.Close();
            conn.Close();
            return incidents;

        }
        //Реестр запросов на изменение КОНЕЦ


        //Справочник Stage НАЧАЛО
        public object getStages()
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            List<Stage> stages = new List<Stage>();
            //select * from "Trs.Lr.Process"."LrProcess" where "Type_Id" = 5
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "Stage" + '\u0022';
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Stage stage = new Stage();
                try
                {
                    stage.Id = reader.GetInt32(0);
                    stage.Name = reader.GetString(1);
                    stage.isBase = reader.GetBoolean(2);
                }
                catch
                { }
                stages.Add(stage);
            }
            reader.Close();
            conn.Close();

            return stages;
        }
        //Справочник Stage КОНЕЦ



        //Связанные процессы НАЧАЛО
        public object getRelatedProcess(int Related_Id)
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            List<RelatedProcess> Processes = new List<RelatedProcess>();
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "RelatedProcess" + '\u0022' + " where " + '\u0022' + "Related_Id" + '\u0022' + " = " + Related_Id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                RelatedProcess rProcess = new RelatedProcess();
                try
                {
                    rProcess.Id              = reader.GetInt32(0);
                    rProcess.Parent_Id       = reader.GetInt32(1);
                    rProcess.Related_Id      = reader.GetInt32(2);
                    rProcess.RelationType_Id = reader.GetInt32(3);
                }
                catch
                { }
                Processes.Add(rProcess);
            }
            reader.Close();
            conn.Close();

            return Processes;
        }

        //Связанные процессы КОНЕЦ

        //Type НАЧАЛО
        public String getType(int Type_Id)
        {
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";
            string Type = "";
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select * from "Trs.Lr.Process"."Stage"
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "ProcessType" + '\u0022' + " " + "where " + '\u0022' + "Id" + '\u0022' + "= " + Type_Id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Type = reader.GetString(1);
            }
            reader.Close();
            conn.Close();
            return Type;

        }
        //Type КОНЕЦ*/

        //Parent_Id НАЧАЛО
        public int getParentId(int Id)
        {
            int    Parent_Id = 0;
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "mobile";
            string Password = "djkufvjcn";
            string Port = "64005";

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            // List<RelatedProcess> Processes = new List<RelatedProcess>();
            string sqlQuery = "select * from " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "RelatedProcess" + '\u0022' + " where " + '\u0022' + "Related_Id" + '\u0022' + " = " + Id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                RelatedProcess rProcess = new RelatedProcess();
                try
                {
                  //  rProcess.Id = reader.GetInt32(0);
                      Parent_Id = reader.GetInt32(1);
                  //  rProcess.Related_Id = reader.GetInt32(2);
                  //  rProcess.RelationType_Id = reader.GetInt32(3);
                }
                catch
                { }
                //Processes.Add(rProcess);
            }
            reader.Close();
            conn.Close();

            return Parent_Id;
        }
        //Parent_Id КОНЕЦ*/
        //Событий за сутки НАЧАЛО
        public int getAlarmCount()
        {
            int quantity             = 1;
            string sqlQuery          = string.Empty;
            string sWorkStartTime    = string.Empty;
            string sWorkCompleteTime = string.Empty;
            string Host     = ConnectionSettings.eHost;
            string User     = ConnectionSettings.eUser;
            string DBname   = ConnectionSettings.eDBname;
            string Password = ConnectionSettings.ePassword;
            string Port     = ConnectionSettings.ePort;

            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select count("Id") from "Trs.CiEvent"."CiEvent" where "CreateDate" > DATE_TRUNC('day', NOW()) AND "CreateDate" < 'tomorrow'::timestamp 
            sqlQuery = "select count(" + '\u0022' + "Id" + '\u0022' + ")  from " + '\u0022' + "Trs.CiEvent" + '\u0022' + "." + '\u0022' +
                "CiEvent" + '\u0022' + " " + "where " + '\u0022' + "CreateDate" + '\u0022' + "> DATE_TRUNC('day', NOW()) AND " +
                '\u0022' + "CreateDate" + '\u0022' + " < 'tomorrow'::timestamp";
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    quantity = reader.GetInt32(0);
                }
                catch
                { }

            }
            reader.Close();
            conn.Close();
            return quantity + 1;

        }
        //Событий за сутки КОНЕЦ*/

        //Получить перевод type
        public string getRU(string ENType)
        {
            string RUType   = string.Empty;
            string Host     = ConnectionSettings.eHost;
            string User     = ConnectionSettings.eUser;
            string DBname   = ConnectionSettings.eDBname;
            string Password = ConnectionSettings.ePassword;
            string Port     = ConnectionSettings.ePort;
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            //select * from "Trs.CiEvent"."EventDictionary" WHERE "Value" ILIKE 'equipment'
            string sqlQuery = "select * from " + '\u0022' + "Trs.CiEvent" + '\u0022' + "." + '\u0022' + "EventDictionary" + '\u0022' +
                " WHERE " + '\u0022' + "Value" + '\u0022' + " ILIKE '" + ENType + "' LIMIT 1";
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    RUType = reader.GetString(3);
                }
                catch
                { }

            }
            reader.Close();
            conn.Close();
            return RUType;
        }
    }

}



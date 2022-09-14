using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using ApiServer.Controllers;
using Npgsql;

namespace ApiServer
{
    public class ToDB
    {
        //Reason НАЧАЛО
        public string setReason(int Reason_Id, int Inc_id)
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
            string sqlQuery = "UPDATE " + '\u0022' + "Trs.Lr.Incident" + '\u0022' + "." + '\u0022' + "Incident" + '\u0022' + " SET " + '\u0022' + "Reason_Id" + '\u0022' + "=" + Reason_Id + " WHERE " + '\u0022' + "Process_Id" + '\u0022' + "=" + Inc_id;
            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteNonQuery();
            /* while (reader.Read())
             {
                 try
                 {
                     //reason = reader.GetString(4);
                 }
                 catch
                 { }

             }*/
            //reader.Close();
            conn.Close();
            return "123";

        }
        //Reason КОНЕЦ
        public string updateReason(int Id, int Reason_Id)

        {
            //UPDATE "Trs.Lr.Incident"."Incident"  SET "Reason_Id" = 1 WHERE "Process_Id" = 2; 
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

            var uг = new NpgsqlCommand("UPDATE " + '\u0022' + "Trs.Lr.Incident" + '\u0022' + "." + '\u0022' + "Incident" + '\u0022' + " SET " + '\u0022' + "Reason_Id" + '\u0022' + "=" + Reason_Id + " WHERE " + '\u0022' + "Process_Id" + '\u0022' + "=" + Id);
            uг.ExecuteNonQuery();
            return "Данные успешно обновлены";
        }


        public string createInc(int Id, string Number, Int32 Type_Id, Int32 Priority_Id, Int32 Stage_Id, Int32 Initiator_Id,
            string Description, Int32 Classification_Id, DateTime EventTime, DateTime LrRegistrationTime, Int32 Executor_Id,
            DateTime WorkStartTime, Int32 Coordinator_Id, DateTime WorkCompleteTime, DateTime ClosedTime, TimeSpan Duration,
            string Result, Int32 Solution_Id, int[] WorkExecutors, bool NeedApproving, DateTime DurationStartDate, DateTime FirstStageUsedInElapsedTime, string CreateUserLogin, string UpdateUserLogin, string DeleteUserLogin, DateTime CreateDate, DateTime UpdateDate, DateTime DeleteDate)
        {
            const string q = "'\u0022'";
            string Host = "mobile.demo.transset.ru";
            string User = "postgres";
            string DBname = "itsm";
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
            /*   string sqlQuery = "INSERT INTO " + '\u0022' + "LrProcess" + '\u0022' + " (" + '\u0022' + "Id" + '\u0022' + ", " + '\u0022' + "Number" + '\u0022' + ", " + '\u0022' + "Initiator_Id" + '\u0022' + ", " +

             '\u0022' + "Type_Id" + '\u0022' + ", " + '\u0022' + "Priority_Id" + '\u0022' + ", " + '\u0022' + "Stage_Id" + '\u0022' + ", " + '\u0022' + "Classification_Id" + '\u0022' + ", " + '\u0022' + "EventTime" + '\u0022' + ", " +
             q + "Executor_Id" + '\u0022' + ", " + '\u0022' + "CreateDate" + '\u0022' + ", " + '\u0022' + "LrRegistrationTime" + '\u0022' + ", " + '\u0022' + "CreateUserLogin" + '\u0022' + ")" +
             " VALUES (" + Id + ", " + Number + ", " + Initiator_Id + ", " + Type_Id + ", " + Priority_Id + ", " + Stage_Id + ", " + Classification_Id + ", " + EventTime + ", " +
            +Executor_Id + ", " + CreateDate + ", " + LrRegistrationTime + ", " + CreateUserLogin + ")";
               //var command = new NpgsqlCommand(sqlQuery, conn);
               //var reader = command.ExecuteNonQuery();
            "Id","Number","Type_Id","Priority_Id","Stage_Id","Initiator_Id","Description","Classification_Id","EventTime","LrRegistrationTime","Executor_Id","WorkStartTime","Coordinator_Id","WorkCompleteTime",
            "ClosedTime","Duration","Result","Solution_Id","WorkExecutors","NeedApproving","DurationStartDate","FirstStageUsedInElapsedTime","CreateUserLogin","UpdateUserLogin","DeleteUserLogin","CreateDate","UpdateDate","DeleteDate"
             */

            var cmd3 = new NpgsqlCommand("insert into " + '\u0022' + "LrProcess" + '\u0022' + " values(@Id, @Number, @Type_Id,  @Priority_Id, @Stage_Id, @Initiator_Id, @Description, @Classification_Id, " +
                "@EventTime, @LrRegistrationTime, @Executor_Id, @WorkStartTime, @Coordinator_Id, @WorkCompleteTime, @ClosedTime,@Duration, @Result, @Solution_Id, @WorkExecutors, @NeedApproving, @DurationStartDate, @FirstStageUsedInElapsedTime, @CreateUserLogin, @UpdateUserLogin, @DeleteUserLogin, @CreateDate, @UpdateDate, @DeleteDate)", conn);


            cmd3.Parameters.AddWithValue("@Id", Id);
            cmd3.Parameters.AddWithValue("@Number", Number);
            cmd3.Parameters.AddWithValue("@Type_Id", Type_Id);
            cmd3.Parameters.AddWithValue("@Priority_Id", Priority_Id);
            cmd3.Parameters.AddWithValue("@Stage_Id", Stage_Id);
            cmd3.Parameters.AddWithValue("@Initiator_Id", Initiator_Id);
            cmd3.Parameters.AddWithValue("@Description", Description);
            cmd3.Parameters.AddWithValue("@Classification_Id", Classification_Id);
            cmd3.Parameters.AddWithValue("@EventTime", EventTime);
            cmd3.Parameters.AddWithValue("@LrRegistrationTime", LrRegistrationTime);
            cmd3.Parameters.AddWithValue("@Executor_Id", Executor_Id);
            cmd3.Parameters.AddWithValue("@WorkStartTime", WorkStartTime);
            cmd3.Parameters.AddWithValue("@Coordinator_Id", Coordinator_Id);
            cmd3.Parameters.AddWithValue("@WorkCompleteTime", WorkCompleteTime);
            cmd3.Parameters.AddWithValue("@ClosedTime", ClosedTime);
            cmd3.Parameters.AddWithValue("@Duration", Duration);
            cmd3.Parameters.AddWithValue("@Result", Result);
            cmd3.Parameters.AddWithValue("@Solution_Id", Solution_Id);
            cmd3.Parameters.AddWithValue("@WorkExecutors", WorkExecutors);
            cmd3.Parameters.AddWithValue("@NeedApproving", NeedApproving);
            cmd3.Parameters.AddWithValue("@DurationStartDate", DurationStartDate);
            cmd3.Parameters.AddWithValue("@FirstStageUsedInElapsedTime", FirstStageUsedInElapsedTime);
            cmd3.Parameters.AddWithValue("@CreateUserLogin", CreateUserLogin);
            cmd3.Parameters.AddWithValue("@UpdateUserLogin", UpdateUserLogin);
            cmd3.Parameters.AddWithValue("@DeleteUserLogin", DeleteUserLogin);

            cmd3.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd3.Parameters.AddWithValue("@UpdateDate", UpdateDate);
            cmd3.Parameters.AddWithValue("@DeleteDate", DeleteDate);

            // cmd3.ExecuteNonQuery();

            return "OK";
        }

        //Обновить ЛР ЗИ НАЧАЛО
        public object updateChangeRequest(int Id, int Stage_Id, string Result, DateTime WorkStartTime, DateTime WorkCompleteTime)
        {
            string sqlQuery          = string.Empty;
            string sWorkStartTime    = string.Empty;
            string sWorkCompleteTime = string.Empty;
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
            // update "Trs.Lr.Process"."LrProcess"
            // set "Stage_Id" = 2, "Result" = 'взял в работу', "WorkStartTime" = NOW()
            // where "Id" = 84

            sWorkStartTime    =    WorkStartTime.Year + "-" + nullPlus(   WorkStartTime.Month.ToString())+ "-" + nullPlus(   WorkStartTime.Day.ToString())+ " " + nullPlus(   WorkStartTime.Hour.ToString())+ ":" + nullPlus(   WorkStartTime.Minute.ToString())+ ":" + nullPlus(   WorkStartTime.Second.ToString());
            sWorkCompleteTime = WorkCompleteTime.Year + "-" + nullPlus(WorkCompleteTime.Month.ToString())+ "-" + nullPlus(WorkCompleteTime.Day.ToString())+ " " + nullPlus(WorkCompleteTime.Hour.ToString())+ ":" + nullPlus(WorkCompleteTime.Minute.ToString())+ ":" + nullPlus(WorkCompleteTime.Second.ToString());
            sqlQuery = "update " + '\u0022' + "Trs.Lr.Process" + '\u0022' + "." + '\u0022' + "LrProcess" + '\u0022' +
             " set " + '\u0022' + "Stage_Id" + '\u0022' + " = " + Stage_Id + ", " + '\u0022' + "Result" + '\u0022' + " = " +
             "'" + Result + "'" + ", " + '\u0022' + "WorkStartTime"    + '\u0022' + " = " + "'" + sWorkStartTime + "'"  
                                + ", " + '\u0022' + "WorkCompleteTime" + '\u0022' + " = " + "'" + sWorkCompleteTime + "'"
                                + " where " + '\u0022' + "Id" + '\u0022' + " = " + Id;

            var command = new NpgsqlCommand(sqlQuery, conn);
            var query = command.ExecuteNonQuery();
            return sWorkStartTime;
            conn.Close();
        }
        //Обновить ЛР ЗИ КОНЕЦ

        //Создать СОБЫТИЕ НАЧАЛО
        public int alarmCreate(string alarmId, string number, string alarmType, string RuAlarmType,
            string perceivedSeverity, string RuPerceivedSeverity, string probableCause, string RuProbableCause,
            string SpecificProblem, string alarmDetails,
            DateTime alarmRaisedTime, int eventState_Id, bool hasTCA, string createUserLogin)
        {
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

            string Users = '\u0022' + "Trs.CiEvent" + '\u0022' + "." + '\u0022' + "CiEvent" + '\u0022';
            sqlQuery = "INSERT INTO " + Users + " (" + '\u0022' + "AlarmId" + '\u0022' + "," +
                '\u0022' + "Number" + '\u0022' + "," +
                '\u0022' + "AlarmType" + '\u0022' + "," +
                '\u0022' + "RuAlarmType" + '\u0022' + "," +
                '\u0022' + "PerceivedSeverity" + '\u0022' + "," +
                '\u0022' + "RuPerceivedSeverity" + '\u0022' + "," +
                '\u0022' + "ProbableCause" + '\u0022' + "," +
                '\u0022' + "RuProbableCause" + '\u0022' + "," +
                '\u0022' + "SpecificProblem" + '\u0022' + "," +
                '\u0022' + "AlarmDetailes" + '\u0022' + "," +
                '\u0022' + "AlarmRaisedTime" + '\u0022' + "," +
                '\u0022' + "EventState_Id" + '\u0022' + "," +
                '\u0022' + "HasTCA" + '\u0022' + "," +
                '\u0022' + "CreateUserLogin" + '\u0022' + "," +
                '\u0022' + "CreateDate" + '\u0022' +

                ") " + "VALUES (" + "'" + alarmId + "'" + "," +
                "'" + number + "'" + "," +
                "'" + alarmType + "'" + "," +
                "'" + RuAlarmType + "'" + "," +
                "'" + perceivedSeverity + "'" + "," +
                "'" + RuPerceivedSeverity + "'" + "," +
                "'" + probableCause + "'" + "," +
                "'" + RuProbableCause + "'" + "," +
                "'" + SpecificProblem + "'" + "," +
                "'" + alarmDetails + "'" + "," +
                "'" + alarmRaisedTime + "'" + "," +
                eventState_Id + "," +
                hasTCA + "," +
               "'" + createUserLogin + "'" + "," +
                "NOW()" +
                ")" + " RETURNING " + '\u0022' + "Id" + '\u0022';


            var command = new NpgsqlCommand(sqlQuery, conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int eventId = reader.GetInt32(0);
                return eventId;
            }
            return 0;
            reader.Close();
            conn.Close();
        }
            //Создать СОБЫТИЕ КОНЕЦ

            //Закрыть СОБЫТИЕ НАЧАЛО
          /* public int alarmClear(DateTime alarmClearedTime, string clearUserLogin, string clearSystem)
            {
                string sqlQuery          = string.Empty;
                string sWorkStartTime    = string.Empty;
                string sWorkCompleteTime = string.Empty;
                string Host              = "stack.transset.ru";
                string User              = "postgres";
                string DBname            = "dev";
                string Password          = "123";
                string Port              = "30044";

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



            }*/
            //Закрыть СОБЫТИЕ КОНЕЦ
        












        public string nullPlus(string Value)
        {

            if      (Value == "1") Value = "01";
            else if (Value == "2") Value = "02";
            else if (Value == "3") Value = "03";
            else if (Value == "4") Value = "04";
            else if (Value == "5") Value = "05";
            else if (Value == "6") Value = "06";
            else if (Value == "7") Value = "07";
            else if (Value == "8") Value = "08";
            else if (Value == "9") Value = "09";
            else if (Value == "0") Value = "00";
            return Value;  

        }
    }

}
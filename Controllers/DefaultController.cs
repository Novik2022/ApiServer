using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ApiServer.Controllers

    
{
      public class ConnectionSettings
    {
        public const string eHost     = "bpo.dev.transset.ru";
        public const string eUser     = "postgres";
        public const string eDBname   = "bpo";
        public const string ePassword = "djkufjvnc";
        public const string ePort     = "64060";
    }
      public class DefaultController : ApiController
    {    
       
        [AcceptVerbs("GET")]
        [Route("getIncidentData/{id}")]
        [Route("getChangeRequestList/{id}")]
        public async Task<IHttpActionResult> getIncidentData(int id)
        {
            FromDB dbData = new FromDB();
            object sqlQueryResult = dbData.getIncData(id);
            Incident incident = new Incident();
            incident = (Incident)dbData.getIncData(id);
            if (incident != null)
            {
                return Ok(new
                {
                    Id = incident.Id,
                    Number = incident.Number,
                    Type = incident.Type_Id,
                    Priority = incident.Priority_Id,
                    Stage = incident.Stage_Id,
                    Iniciator = incident.Initiator_Id,
                    Description = incident.Description,
                    Classification = incident.Classification_Id,
                    EventTime = incident.EventTime,
                    LrRegistrationTime = incident.LrRegistrationTime,
                    Executor = incident.Executor_Id,
                    WorkStartTime = incident.WorkStartTime,
                    Coordinator = incident.Coordinator_Id,
                    WorkCompleteTime = incident.WorkCompleteTime,
                    Result = incident.Result,
                    NeedApproving = incident.NeedApproving,
                    CreateUserLogin = incident.CreateUserLogin,
                    CreateDate = incident.CreateDate
                });
            }
            else
            {
                return Ok(new { Id = -1 });
            }

            //return Ok(new { data = sqlQueryResult });
        }

        [AcceptVerbs("GET")]
        [Route("getIncidentList")]
        public async Task<IHttpActionResult> getIncList()
        {
            FromDB dbData2 = new FromDB();
            var incList = dbData2.getIncList();
            return Ok(new { incList });
        }

        [AcceptVerbs("GET")]
        [Route("getChangeRequestList")]
        public async Task<IHttpActionResult> getChangeRequestList()
        {
            FromDB dbData2 = new FromDB();
            var incList = dbData2.getChangeRequestList();
            return Ok(new { incList });
        }

        [AcceptVerbs("GET")]
        [Route("getStages")]
        public async Task<IHttpActionResult> getStages()
        {
            FromDB dbData3 = new FromDB();
            var stageList = dbData3.getStages();

            return Ok(new { stageList });
        }

        [AcceptVerbs("GET")]
        [Route("getRelatedProcess/{Related_Id}")]
        public async Task<IHttpActionResult> getRelatedProcess(int Related_Id)
        {
            FromDB dbData4 = new FromDB();
            var RelatedProcess = dbData4.getRelatedProcess(Related_Id);

            return Ok(new { RelatedProcess });
        }


        [AcceptVerbs("GET")]
        [Route("setReason/{Id}/{Reason_Id}")]
        public async Task<IHttpActionResult> updateReason(int Id, int Reason_Id)

        {
            ToDB dbData2 = new ToDB();
            string sqlQueryResult = dbData2.updateReason(Id, Reason_Id);
            return Ok(sqlQueryResult);
        }

        //updateChangeRequest(int Id, int Stage_Id,string Result)
        public class dataCR
        {
            public int Id { get; set; }
            public int Stage_Id { get; set; }
            public string Result { get; set; }
            public DateTime WorkStartTime { get; set; }
            public DateTime WorkCompleteTime { get; set; }
        }

        // класс Исходное Сообщение
        public class Request
        {
            [Required]
            public string Id { get; set; }
            //public int eventId { get; set; }
            public string externalAlarmId { get; set; }
            public string alarmType { get; set; }
            public string perceivedSeverity { get; set; }
            public string probableCause { get; set; }
            public string specificProblem { get; set; }
            public string alarmedObjectType { get; set; }
            public string alarmedObjectId { get; set; }
            public string sourceSystem { get; set; }
            public string idCI { get; set; }
            public string alarmDetails { get; set; }
            public string alarmState { get; set; }
            public DateTime alarmRaisedTime { get; set; }
          //  public DateTime alarmClearedTime { get; set; }
            public string thresholdId { get; set; }
            public string indicatorName { get; set; }
            public string observedValue { get; set; }
            public string indicatorUnit { get; set; }
            public string granularity { get; set; }
            public string direction { get; set; }
            public string thresholdCrossingDescription { get; set; }
           
        }

        // класс событие
        public class Event
        {
            [Required]
            public string Id { get; set; }
            public int eventId { get; set; }
            public string externalAlarmId { get; set; }
            public string alarmType { get; set; }
            public string perceivedSeverity { get; set; }
            public string probableCause { get; set; }
            public string specificProblem { get; set; }
            public string alarmedObjectType { get; set; }
            public string alarmedObjectId { get; set; }
            public string sourceSystem { get; set; }
            public string idCI { get; set; }
            public string alarmDetails { get; set; }
            public string alarmState { get; set; }
            public DateTime alarmRaisedTime { get; set; }
            public DateTime alarmClearedTime { get; set; }
            public string thresholdId { get; set; }
            public string indicatorName { get; set; }
            public string observedValue { get; set; }
            public string indicatorUnit { get; set; }
            public string granularity { get; set; }
            public string direction { get; set; }
            public string thresholdCrossingDescription { get; set; }
            public string incomingMessage { get; set; }
            //public string errorType { get; set; }

        }
        public string finalErrorType = string.Empty; // итоговое описание ошибки

        public class Events
        {
            List<Event> events = new List<Event>();
            public Events(List<Event> events)
            {
                this.events = events;
            }
        }

        [AcceptVerbs("POST")]
        [Route("updateChangeRequest")]

        public async Task<IHttpActionResult> updateChangeRequest([FromBody] dataCR data)

        {
            ToDB dbData5 = new ToDB();
            var sqlQueryResult = dbData5.updateChangeRequest(data.Id, data.Stage_Id, data.Result, data.WorkStartTime, data.WorkCompleteTime);
            return Ok(data);
        }

        [AcceptVerbs("POST")]
        [Route("alarmGroupeCreate")]
        public async Task<IHttpActionResult> alarmGroupeCreate([FromBody] Events eventsData)

        {

            return Ok(eventsData);
        }


        /*  [AcceptVerbs("POST")]
          [Route("setIncidentData")]
          public async Task<IHttpActionResult> setIncidentData([FromBody] string data)

          {
              int[] WorkExecutors = new int[5];
              WorkExecutors[0] = 1;
              bool NeedApproving         = false;
              DateTime DurationStartDate = new DateTime(2022, 2, 1, 8, 0, 15);
              DateTime FirstStageUsedInElapsedTime = new DateTime(2022, 2, 18, 13, 30, 30);
              DateTime date1 = new DateTime(2022, 2, 1, 8, 0, 15); //01.02.2022 08:00:15
              DateTime date2 = new DateTime(2022, 2, 18, 13, 30, 30);//018.02.2022 13:30:30
              TimeSpan interval = date1.Subtract(date2);
              DateTime dateTime = DateTime.Now;
              string CreateUserLogin = "admin";
              string UpdateUserLogin = "admin";
              string DeleteUserLogin = "admin";
              ToDB dbData1 = new ToDB();
              string sqlQueryResult = dbData1.createInc(12, "И_12", 1, 4, 1, 10, "", 13, dateTime, dateTime, 10, dateTime, 10, dateTime, dateTime, interval, "result", 1, WorkExecutors, NeedApproving, DurationStartDate, FirstStageUsedInElapsedTime, CreateUserLogin, UpdateUserLogin, DeleteUserLogin, dateTime, dateTime, dateTime);
              // return Ok(new { data = sqlQueryResult });
              return Ok(new { data });
          }
          /*(int Id, string Number, Int32 Type_Id, Int32 Priority_Id, Int32 Stage_Id, Int32 Initiator_Id, 
          string Description, Int32 Classification_Id, DateTime EventTime, DateTime LrRegistrationTime, Int32 Executor_Id, WorkStartTime
          DateTime CreateDate, string CreateUserLogin)
          Id,"Number","Type_Id","Priority_Id","Stage_Id","Initiator_Id","Description","Classification_Id","EventTime","LrRegistrationTime","Executor_Id","WorkStartTime","Coordinator_Id","WorkCompleteTime","ClosedTime","Duration",
          "Result","Solution_Id","WorkExecutors","NeedApproving","DurationStartDate","FirstStageUsedInElapsedTime","CreateUserLogin","UpdateUserLogin","DeleteUserLogin","CreateDate","UpdateDate","DeleteDate"
           */
        [AcceptVerbs("POST")]
        [Route("create")]
        public async Task<IHttpActionResult> create([FromBody] Event eventData)

        {
            string eventNumber = generateEventNumber(); //генерируем номер События
            bool incorrectAtributNoEvent  = false;      // ошибка когда не создаем событие
            bool incorrectAtributGetEvent = false;      // ошибка когда создаем событие
            int eventState_Id = 1;                      //стартовый статус
            bool hasTCA = false;                        //наличие вкладки пороги
            string createUserLogin = "admin";           //логин
            string errorType = string.Empty;            //Описание ошибки
            Request request = new Request();
            FromDB fromDB = new FromDB();
            ToDB dbData6  = new ToDB();
            //проверяем не пустой ли объект
            if (eventData != null)
            {
                string jsonString = JsonSerializer.Serialize(eventData); //получаем строку JSON
                var modelState = new ModelStateDictionary();
                //проверяем условие, заполнено ли Id тревожного Сообщения
                if (string.IsNullOrEmpty(eventData.Id) | string.IsNullOrWhiteSpace(eventData.Id))
                    
                {
                    eventData.Id = string.Empty;
                    incorrectAtributNoEvent = true;
                    addErrorType("Ошибка! Id alarm пустой или не существует. Событие не создано.");

                }
                //проверяем макс длину Id
                if (eventData.Id.Length>256)
                {
                    incorrectAtributGetEvent = true;
                    addErrorType("Ошибка! Длина Id превышает 256 символов.Событие создано с укороченным идентификатором");
                    //modelState.AddModelError("errorType", "Ошибка! Длина Id превышает 256 символов.Событие создано с укороченным идентификатором");
                    eventData.Id = eventData.Id.Substring(0, 256);
                }
                //проверяем условие, Во входящем сообщении об alarm отсутствует "IdCI", "alarmedObjectId", "sourceSystem",
                //а также атрибуты ("alarmType", "perceivedSeverity", "probableCause", "specificProblem", "idCI", "alarmDetails",
                //"alarmState", "alarmRaisedTime", "thresholdId", "indicatorName",
                //"observedValue", "indicatorUnit", "granularity", "direction", "thresholdCrossingDescription")
                if (string.IsNullOrEmpty(eventData.idCI) | string.IsNullOrWhiteSpace(eventData.idCI))
                    /*& string.IsNullOrEmpty(eventData.alarmedObjectId) & string.IsNullOrEmpty(eventData.sourceSystem) 
                    & string.IsNullOrEmpty(eventData.alarmState) & (eventData.alarmRaisedTime==null) & string.IsNullOrEmpty(eventData.thresholdId) &
                    string.IsNullOrEmpty(eventData.observedValue) & string.IsNullOrEmpty(eventData.indicatorUnit) & string.IsNullOrEmpty(eventData.granularity) &
                    string.IsNullOrEmpty(eventData.direction) & string.IsNullOrEmpty(eventData.thresholdCrossingDescription))*/
                {
                    incorrectAtributNoEvent = true;
                    addErrorType("Ошибка! Некорректное заполнение списка реквизитов");
                }
                //проверяем на соответствие тип аварии
                if (fromDB.getRU(eventData.alarmType)==string.Empty)
                {
                    eventData.alarmType = "Untyped";
                    incorrectAtributGetEvent = true;
                    addErrorType("Некорректное значение alarmType. Заменено на значение по умолчанию Untyped.");
                }
                //проверяем на соответствие приоритет
                if (fromDB.getRU(eventData.perceivedSeverity) == string.Empty)
                {
                    eventData.perceivedSeverity = "Critical";
                    incorrectAtributGetEvent = true;
                    addErrorType("Некорректное значение perceivedSeverity. Заменено на значение по умолчанию Critical.");
                }
                //проверяем на соответствие причину
                if (fromDB.getRU(eventData.probableCause) == string.Empty)
                {
                    eventData.specificProblem = eventData.specificProblem + " @Неизвестная причина аварии: " + eventData.probableCause;
                    eventData.probableCause = "Unknwon";
                    incorrectAtributGetEvent = true;
                    addErrorType("Некорректное значение probableCause. Заменено на значение по умолчанию Unknown");
                }
                if (incorrectAtributNoEvent == true) //не создаем событие
                {
                    modelState.AddModelError("incomingMessage", jsonString);
                    modelState.AddModelError("errorType", finalErrorType);
                    return BadRequest(modelState);
                }
                else if (incorrectAtributGetEvent == true) //создаем событие с ошибкой
                {
                    modelState.AddModelError("incomingMessage", jsonString);
                    modelState.AddModelError("errorType", finalErrorType);
                    //Добавляем запись в таблицу Событий
                    var sqlQueryResult = dbData6.alarmCreate(eventData.Id, eventNumber, eventData.alarmType, fromDB.getRU(eventData.alarmType),
                    eventData.perceivedSeverity, fromDB.getRU(eventData.perceivedSeverity), 
                    eventData.probableCause, fromDB.getRU(eventData.probableCause), eventData.specificProblem, eventData.alarmDetails, eventData.alarmRaisedTime, eventState_Id, hasTCA, createUserLogin);
                    eventData.eventId = sqlQueryResult;
                    return BadRequest(modelState);                   
                }
                else 
                {

                    //Добавляем запись в таблицу Событий
                    var sqlQueryResult = dbData6.alarmCreate(eventData.Id, eventNumber, eventData.alarmType, fromDB.getRU(eventData.alarmType),
                    eventData.perceivedSeverity, fromDB.getRU(eventData.perceivedSeverity),
                    eventData.probableCause, fromDB.getRU(eventData.probableCause), eventData.specificProblem, eventData.alarmDetails, eventData.alarmRaisedTime, eventState_Id, hasTCA, createUserLogin);
                    eventData.eventId = sqlQueryResult;
                    eventData.incomingMessage = jsonString;
                   
                    return Ok (eventData);
                }
            }
            else
            {
                return BadRequest("Ошибка!Пустой запрос");
            }

        }
        //генерируем номер События в пределах суток
        public string generateEventNumber()
        {
            string eventNumber;
            ToDB nullPlus = new ToDB();
            FromDB quantity = new FromDB();
            eventNumber = DateTime.Today.Year.ToString() + "." + nullPlus.nullPlus(DateTime.Today.Month.ToString()) + "." + 
                  nullPlus.nullPlus(DateTime.Today.Day.ToString()) + "_" + quantity.getAlarmCount();

            return eventNumber;
        }

        public void addErrorType(string errorType)
        {
            string auxiliary = string.Empty;
            finalErrorType = finalErrorType + " " + errorType;
            //finalErrorType = auxiliary;//.Substring(2, auxiliary.Length - 2);
                      
        }

    }
}

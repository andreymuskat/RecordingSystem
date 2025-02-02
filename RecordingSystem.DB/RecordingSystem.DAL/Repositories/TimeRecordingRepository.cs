﻿  using Dapper;
using Microsoft.Data.SqlClient;
using RecordingSystem.DAL.Interfaces;
using RecordingSystem.DAL.Models;
using System.Data;
using RecordingSystem.DAL.Options;
using System.Collections.Generic;
using System.Xml;

namespace RecordingSystem.DAL.Repositories
{
    public class TimeRecordingRepository : ITimeRecordingRepository
    {

        public void AddTimeRecording(TimeRecordingDto timeRecording)
        {
            using (var sqlConnection = new SqlConnection(Сonnection.sqlConnection))
            {
                sqlConnection.Open();

                sqlConnection.Execute(StoredNamesProcedures.AddTimeRecording,
                    new
                    {
                        timeRecording.Date,
                        timeRecording.TimeTableId,
                        timeRecording.Occupied
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public List<TimeRecordingDto> GetAllTimeRecordingsByDoctorId(int id)
        {
            using (var sqlConnection = new SqlConnection(Сonnection.sqlConnection))
            {
                List<TimeRecordingDto> result = new List<TimeRecordingDto>();

                sqlConnection.Open();
                sqlConnection.Query<DoctorDto, TimeRecordingDto, TimeTableDto, TimeSpanDto, TimeRecordingDto>(StoredNamesProcedures.GetAllTimeRecordingsByDoctorId,
                    (doctor, timeRecording, timeTable, timeSpan) =>
                    {
                        if (result.Count == 0 || !result.Any(tr => tr.TimeTable.Id == timeTable.Id && tr.Date == timeRecording.Date))
                        {
                            AddTimeRecordingInList(timeRecording, timeTable, timeSpan, doctor, result);
                        }
                        else
                        {
                            TimeRecordingDto crnt = result.Find(tr => tr.TimeTable.Id == timeTable.Id && tr.Date == timeRecording.Date)!;

                            if (timeRecording.Occupied == true && crnt.Occupied == false) 
                            { 
                                result.Remove(crnt);
                                AddTimeRecordingInList(timeRecording, timeTable, timeSpan, doctor, result);
                            }
                        }

                        return timeRecording;
                    },
                    new { id },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        private void AddTimeRecordingInList(TimeRecordingDto timeRecording, TimeTableDto timeTable, TimeSpanDto timeSpan, DoctorDto doctor, List<TimeRecordingDto> result)
        {
            timeRecording.TimeTable = timeTable;

            if(timeRecording.TimeTable is not null)
            {
                timeRecording.TimeTableId = timeRecording.TimeTable.Id;
            }

            timeTable.TimeSpan = timeSpan;
            timeTable.Doctor = doctor;
            result.Add(timeRecording);
        }


        public void UpdateTimeRecordingById(TimeRecordingDto timeRecordingById)
        {
            using (var sqlConnection = new SqlConnection(Сonnection.sqlConnection))
            {
                sqlConnection.Open();

                sqlConnection.Execute(StoredNamesProcedures.UpdateTimeRecordingById,
                    new
                    {
                        timeRecordingById.Id,
                        timeRecordingById.Date,
                        timeRecordingById.TimeTableId,
                        timeRecordingById.Occupied
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        private static List<TimeRecordingDto> GetAllTimeRecording()
        {
            using (var sqlConnection = new SqlConnection(Сonnection.sqlConnection))
            {
                sqlConnection.Open();
                return sqlConnection.Query<TimeRecordingDto>(StoredNamesProcedures.GetAllTimeRecording,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TimeRecordingDto> GetAllDaysInTimeRecording() 
        {
            List <TimeRecordingDto> result = new List<TimeRecordingDto>();

            foreach (var t in TimeRecordingRepository.GetAllTimeRecording())
            {
                if(!result.Any(tr => tr.Date == t.Date))
                {
                    result.Add(t);
                }
            }

            return result;
        }

        public TimeRecordingDto GetTimeRecordingById(int id)
        {
            using (var sqlConnection = new SqlConnection(Сonnection.sqlConnection))
            {
                TimeRecordingDto result = new TimeRecordingDto();
                sqlConnection.Open();
                sqlConnection.Query<TimeRecordingDto,TimeTableDto,TimeSpanDto,DoctorDto,TimeRecordingDto>(StoredNamesProcedures.GetTimeRecordingById,
                    (timeRecording, timeTable, timeSpan, doctor) =>
                    {
                        timeTable.TimeSpan = timeSpan;
                        timeTable.Doctor = doctor;
                        timeRecording.TimeTable = timeTable;

                        if (timeRecording.TimeTable is not null)
                        {
                            timeRecording.TimeTableId = timeRecording.TimeTable.Id;
                        }

                        result = timeRecording;

                        return timeRecording;
                    },
                    new { Id = id },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}


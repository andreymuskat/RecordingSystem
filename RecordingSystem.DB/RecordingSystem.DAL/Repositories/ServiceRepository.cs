﻿using Dapper;
using Microsoft.Data.SqlClient;
using RecordingSystem.DAL.Models;
using System.Data;


namespace RecordingSystem.DAL.Repositories
{
    public class ServiceRepository
    {
        public void AddService(string name, float price, int? specializationId, bool? male)
        {
            using (var sqlConnection = new SqlConnection(Options.sqlConnection))
            {
                sqlConnection.Open();

                sqlConnection.Execute(StoredNamesProcedures.AddService,
                    new { name, price, specializationId, male },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateService(ServiceDto service)
        {
            using (var sqlConnection = new SqlConnection(Options.sqlConnection))
            {
                sqlConnection.Open();

                sqlConnection.Execute(StoredNamesProcedures.UpdatePatientById,
                    new
                    {
                        service.Id,
                        service.Name,
                        service.Price,
                        service.SpecializationId,
                        service.IsDeleted,
                        service.Male
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateServiceById(ServiceDto service)
        {
            using (var sqlConnection = new SqlConnection(Options.sqlConnection))
            {
                sqlConnection.Open();

                sqlConnection.Execute(StoredNamesProcedures.UpdateServiceById,
                    new
                    {
                        service.Id,
                        service.Name,
                        service.Price,
                        service.SpecializationId,
                        service.IsDeleted,
                        service.Male
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<DoctorDto> GetAllServicesByDoctorId(int Id_doctor)
        {
            using (var sqlConnection = new SqlConnection(Options.sqlConnection))
            {
                List<ServiceDto> result = null;

                sqlConnection.Open();
                sqlConnection.Query< DoctorDto, ServiceDto, DoctorDto > (StoredNamesProcedures.GetAllServicesByDoctorId,
                    (doctor,service) =>
                    {
                        foreach (var a in result)
                        {
                            if (a.Id == Id_doctor)
                            {
                                result[result.FindIndex(a => a.Id == Id_doctor)].Services.Add(doctor;
                            }
                            else
                            {
                                result.Add(service);
                            }
                        }

                        return doctor;
                    },
                    new { Id_doctor },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}

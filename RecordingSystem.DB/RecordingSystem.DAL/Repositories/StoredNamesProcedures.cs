﻿namespace RecordingSystem.DAL.Repositories
{
    public class StoredNamesProcedures
    {
        public const string GetAllDoctors = "GetAllDoctors";
        public const string AddPatient = "AddPatient";
        public const string GettAllPatients = "GetAllPatients";
        public const string AddCabinet = "AddCabinet";
        public const string AddService = "AddService";
        public const string AddTimeSpan = "AddTimeSpan";
        public const string GetAllSpecializations = "GetAllSpecializations";
        public const string GetAllCabinets = "GetAllCabinets";
        public const string UpdatePatientById = "UpdatePatientById";
        public const string AddDoctor = "AddDoctor";
        public const string AddSpecialization = "AddSpecialization";
        public const string UpdateCabinetById = "UpdateCabinetById";
        public const string UpdateDoctortById = "UpdateDoctortById";
        public const string GetAllServiceByMale = "GetAllServiceByMale";
        public const string UpdateServiceById = "UpdateServiceById";
        public const string UpdateIsDeletedDoctorById = "UpdateIsDeletedDoctorById";
        public const string UpdateIsDeletedPatientById = "UpdateIsDeletedPatientById";
        public const string UpdateIsDeletedServiceById = "UpdateIsDeletedServiceById";
        public const string AddActiveRecording = "AddActiveRecording";
        public const string UpdateComingInActiveRecordingById = "AddActiveRecording";
        public const string UpdateIsDeletedActiveRecordingById = "UpdateIsDeletedActiveRecordingById";
        public const string GetAllPatientsByStatusId = "GetAllPatientsByStatusId";
        public const string GetAllServiceByDoctorId = "GetAllServiceByDoctorId";
        public const string GetAllDoctorsByServiceId = "GetAllDoctorsByServiceId";
        public const string GetTimeTableByDoctorId = "GetTimeTableByDoctorId";
        public const string GetAllDoctorBySpecializationId = "GetAllDoctorBySpecializationId";
        public const string GetAllActiveRecordingsByPatientId = "GetAllActiveRecordingsByPatientId";
        public const string GetRecordingHistoryByPatientId = "GetRecordingHistoryByPatientId";
        public const string AddDiagnosis = "AddDiagnosis";
        public const string AddRecordingHistory = "AddRecordingHistory";
    }
}

﻿using Moq;
using RecordingSystem.BLL.Models;
using RecordingSystem.BLL.Tests.TestCaseSource;
using RecordingSystem.DAL.Interfaces;
using RecordingSystem.DAL.Models;

namespace RecordingSystem.BLL.Tests
{
    public class DoctorManagerTests
    {
        private DoctorManager _doctorManager;
        private Mock<IDoctorRepository> _mock;

        [SetUp]
        public void Setup()
        {
            _doctorManager = new DoctorManager();
            _mock = new Mock<IDoctorRepository>();
            _doctorManager.DoctorRepository = _mock.Object;
        }

        [TestCaseSource(typeof(DoctorManagerTestCaseSource), nameof(DoctorManagerTestCaseSource.GetAllDoctorsTestCaseSource))]
        public void GetAllDoctors(List<DoctorDto> doctors, List<DoctorOutputModel> expectedDoctors)
        {
            _mock.Setup(o => o.GetAllDoctors()).Returns(doctors).Verifiable();
            List<DoctorOutputModel> expected = expectedDoctors;
            List<DoctorOutputModel> actual = _doctorManager.GetAllDoctors();
            _mock.VerifyAll();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DoctorManagerTestCaseSource), nameof(DoctorManagerTestCaseSource.GetAllDoctorBySpecializationIdTestCaseSource))]
        public void GetAllDoctorBySpecializationId(List<DoctorDto> doctors, List<DoctorOutputModel> expectedDoctors, int SpecializationId)
        {
            _mock.Setup(o => o.GetAllDoctorBySpecializationId(SpecializationId)).Returns(doctors).Verifiable();
            List<DoctorOutputModel> expected = expectedDoctors;
            List<DoctorOutputModel> actual = _doctorManager.GetAllDoctorBySpecializationId(SpecializationId);
            _mock.VerifyAll();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DoctorManagerTestCaseSource), nameof(DoctorManagerTestCaseSource.GetAllDoctorsByServiceIdTestCaseSource))]
        public void GetAllDoctorsByServiceId(List<DoctorDto> doctors, List<DoctorOutputModel> expectedDoctors, int ServiceId)
        {
            _mock.Setup(o => o.GetAllDoctorsByServiceId(ServiceId)).Returns(doctors).Verifiable();
            List<DoctorOutputModel> expected = expectedDoctors;
            List<DoctorOutputModel> actual = _doctorManager.GetAllDoctorsByServiceId(ServiceId);
            _mock.VerifyAll();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DoctorManagerTestCaseSource), nameof(DoctorManagerTestCaseSource.GetAllFreeDoctorsByDayOfWeekIdTestCaseSource))]
        public void GetAllFreeDoctorsByDayOfWeekId(List<DoctorDto> doctors, List<DoctorOutputModel> expectedDoctors, int DayOfWeekId)
        {
            _mock.Setup(o => o.GetAllFreeDoctorsByDayOfWeekId(DayOfWeekId)).Returns(doctors).Verifiable();
            List<DoctorOutputModel> expected = expectedDoctors;
            List<DoctorOutputModel> actual = _doctorManager.GetAllFreeDoctorsByDayOfWeekId(DayOfWeekId);
            _mock.VerifyAll();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DoctorManagerTestCaseSource), nameof(DoctorManagerTestCaseSource.AddDoctorTestCaseSource))]
        public void AddDoctor(DoctorInputModel inputDoctor, DoctorInputModel expectedDoctor)
        {
            _doctorManager.AddDoctor(inputDoctor);
            DoctorInputModel expected = expectedDoctor;
            DoctorInputModel actual = inputDoctor;
            _mock.VerifyAll();
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DoctorManagerTestCaseSource), nameof(DoctorManagerTestCaseSource.UpdateDoctorTestCaseSource))]
        public void AddDoUpdateDoctorctor(DoctorInputModel inputDoctor, DoctorInputModel expectedDoctor)
        {
            _doctorManager.UpdateDoctor(inputDoctor);
            DoctorInputModel expected = expectedDoctor;
            DoctorInputModel actual = inputDoctor;
            _mock.VerifyAll();
            Assert.AreEqual(expected, actual);
        }
    }
}
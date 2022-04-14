using System;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using TestTaskApiPrototype2.Models;

namespace TestTaskApiPrototype2.Utils
{
    internal static class Mocker
    {
        private static readonly Faker _faker = new Faker("ru");
        private static readonly Random rng = new Random();

        public static Client CreateRandomClient()
        {


            Client result = new Client();
            result.Id = Guid.NewGuid();
            result.Name = _faker.Name.FirstName();
            result.Surname = _faker.Name.LastName();
            result.Patronymic = _faker.Name.FirstName() + "ич";
            result.DateOfBirth = _faker.Date.Past(); //TODO: настроить диапозон

            result.Spouse = null; //recursion?

            result.Children = new List<Child>();
            for (int i = 0; i < rng.Next(0, 4); i++)
                 result.Children.Add(CreateRandomChild(result.Name + "ич"));
            result.Passport = CreateRandomDocumentPassport();
            result.LivingAddress = CreateRandomAddress();
            result.RegAddress = CreateRandomAddress();
            result.Jobs = new List<Job>();
            for (int i = 0; i < rng.Next(0, 4); i++)
                result.Jobs.Add(CreateRandomJob());
            result.GeneralExp = _faker.Random.Double(0, 1000000.0);
            result.CurFieldExp = _faker.Random.Double(0, 1000000.0);
            result.Status = RandomEnumValue<StatusType>();
            result.TypeEducation = RandomEnumValue<EducationType>();
            result.MaritalStatus = RandomEnumValue<MaritalStatusType>();
            result.TypeEmp = RandomEnumValue<EmpType>();
            result.MonthIncome = _faker.Random.Double(0, 100000.0);
            result.MonthExpense = _faker.Random.Double(0, 100000.0);
            result.Documents = new List<Document>();
            for (int i = 0; i < rng.Next(0, 4); i++)
                result.Documents.Add(CreateRandomDocumetn());
            result.Communications = new List<ClientCommunication>();
            for (int i = 0; i < rng.Next(0, 4); i++)
                result.Communications.Add(CreateRandomClientCommunication());
            result.CreatedAt = _faker.Date.Past();
            result.UpdatedAt = _faker.Date.Past();

            return result;
        }

        public static Child CreateRandomChild(string patronymic)
        {
            Child result = new Child();

            result.Name = _faker.Name.FirstName();
            result.Surname = _faker.Name.LastName();
            result.Patronymic = patronymic ?? _faker.Name.FirstName() + "ич";
            result.DateOfBirth = _faker.Date.Past(); //TODO: настроить диапозон

            return result;
        }

        public static DocumentPassport CreateRandomDocumentPassport()
        {
            DocumentPassport result = new DocumentPassport();

            result.Id = Guid.NewGuid();
            result.Series = _faker.Random.String(4, '0', '9');
            result.Number = _faker.Random.String(3, '0', '9') + ' '
                                                              + _faker.Random.String(3, '0', '9');
            result.Giver = _faker.Company.CompanyName();
            result.DateIssued = _faker.Date.Past();
            result.BirthPlace = _faker.Address.City();
            result.CreatedAt = _faker.Date.Past();
            result.UpdatedAt = _faker.Date.Past();

            return result;
        }

        public static Address CreateRandomAddress()
        {
            Address result = new Address();

            result.Id = Guid.NewGuid();
            result.ZipCode = _faker.Random.String(6, '0', '9');
            result.Country = _faker.Address.Country();
            result.Region = _faker.Address.State();
            result.City = _faker.Address.City();
            result.Street = _faker.Address.StreetName();
            result.House = _faker.Random.Int(-100, 100).ToString(); //или rng?
            result.Block = _faker.Random.String(1, 'a', 'z');
            result.Apartment = _faker.Random.String(1, 3);
            result.CreatedAt = _faker.Date.Past();
            result.UpdatedAt = _faker.Date.Past();

            return result;
        }

        public static Job CreateRandomJob()
        {
            Job result = new Job();

            result.CompanyName = _faker.Company.CompanyName();
            result.Type = RandomEnumValue<JobType>();
            result.DateEmp = _faker.Date.Past();
            result.DateDismissal = _faker.Date.Past();
            result.Tin = _faker.Random.String(10, 'a', 'z');
            result.Address = CreateRandomAddress();
            result.JobTitle = _faker.Random.String(10, 'a', 'z');
            result.MonthIncome = _faker.Random.Int(0, 7000);
            result.FioManager = _faker.Person.FullName;
            result.Site = new Uri(_faker.Internet.Url());
            result.PhoneNumbers = new List<PhoneNumber>();
            for (int i = 0; i < rng.Next(0, 4); i++)
                result.PhoneNumbers.Add(CreateRandomPhoneNumber());
            result.CreatedAt = _faker.Date.Past();
            result.UpdatedAt = _faker.Date.Past();

            return result;
        }

        public static PhoneNumber CreateRandomPhoneNumber()
        {
            PhoneNumber result = new PhoneNumber();

            result.Number = _faker.Person.Phone;

            return result;
        }

        public static Document CreateRandomDocumetn()
        {
            Document result = new Document();

            result.DocumentGuid = Guid.NewGuid();

            return result;
        }

        public static File CreateRandomFile()
        {
            File result = new File();

            result.FileGuid = Guid.NewGuid();

            return result;
        }

        public static ClientCommunication CreateRandomClientCommunication()
        {
            ClientCommunication result = new ClientCommunication();

            result.Type = RandomEnumValue<ClientCommunicationType>();
            switch (result.Type)
            {
                case ClientCommunicationType.Email:
                    result.Value = _faker.Person.Email;
                    break;
                case ClientCommunicationType.Phone:
                    result.Value = _faker.Person.Phone;
                    break;
            }

            return result;
        }
        private static T RandomEnumValue<T> ()
        {
            var enumValues = Enum.GetValues (typeof (T));
            return (T) enumValues.GetValue (new Random ().Next(enumValues.Length));
        }

    }
}
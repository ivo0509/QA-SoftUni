using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{
    // TODO: write the setup method
    // ще си вдигаме всеки път инстанция на класа Person в тестовете

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        Person _person = new Person();
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Angel A001 35" };
        List<Person> expectedPeopleList = new List<Person>() 
        {
            { new Person() { Name = "Angel", Id = "A001", Age = 35 } },
            { new Person() { Name = "Bob", Id = "B002", Age = 30 } }
        };

        // Act
        List<Person> resultPeopleList = _person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));
        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        Person _person = new Person();
        List<Person> peopleList = new List<Person>()
        {
            { new Person() { Name = "Angel", Id = "A001", Age = 35 } },
            { new Person() { Name = "Dimitrichko", Id = "C003", Age = 10 } },
            { new Person() { Name = "Bob", Id = "B002", Age = 30 } }
        };

        string expected = $"Dimitrichko with ID: C003 is 10 years old.{Environment.NewLine}" +
                          $"Bob with ID: B002 is 30 years old.{Environment.NewLine}" +
                          $"Angel with ID: A001 is 35 years old.";

        // Act
        string result = _person.GetByAgeAscending(peopleList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

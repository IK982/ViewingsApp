using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Services;

namespace ViewingsApp.Tests
{
    public class AgentTest

    {
       [Test]

       public void AgentIsFreeDuringWokringHours()
       {
           //Arrange -setting up the agent and start time
           //Using Agent{StartTime} to set the value of starttime
           var newAgent = new Agent{StartTime = 9, EndTime = 17};
           var startTime = new DateTime(2020, 7, 22, 10, 0, 0);

           //Act - is the agent free at that start time
           var isFree = newAgent.IsFreeAt(startTime);

           //Assert

           isFree.Should().BeTrue();


       }

            [Test]

       public void AgentIsNotFreeBeforeWokringHours()
       {
           //Arrange -setting up the agent and start time
           //Using Agent{StartTime} to set the value of starttime
           var newAgent = new Agent{StartTime = 9, EndTime = 17};
           var startTime = new DateTime(2020, 7, 22, 8, 0, 0);

           //Act - is the agent free at that start time
           var isFree = newAgent.IsFreeAt(startTime);

           //Assert

           isFree.Should().BeFalse();


       }

                [Test]

       public void AgentIsNotFreeAfterWokringHours()
       {
           //Arrange -setting up the agent and start time
           //Using Agent{StartTime} to set the value of starttime
           var newAgent = new Agent{StartTime = 9, EndTime = 17};
           var startTime = new DateTime(2020, 7, 22, 18, 0, 0);

           //Act - is the agent free at that start time
           var isFree = newAgent.IsFreeAt(startTime);

           //Assert

           isFree.Should().BeFalse();


       }

    }
}
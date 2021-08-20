using System;
using Xunit;
using System.Collections.Generic;

namespace Album.Api.Tests
{
    public class greetingServerTest
    {
        [Fact]
        public void GivenName()
        {
            List<string> namesList = new List<string>() { "John", "Fatih", "Doe", "Jan", "Peter"};
            Random random = new Random();
            int randomNumber = random.Next(namesList.Count);
            var greeting = new GreetingService().helloFunction(namesList[randomNumber]);
            Assert.NotNull(greeting);
            Assert.NotEmpty(greeting);
            Assert.Equal("Hello " + namesList[randomNumber], greeting.Split("from")[0]);
        }
    }
}

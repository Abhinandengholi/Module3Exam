using Newtonsoft.Json;
using RestSharp;
using Serilog;
using SwaggerPet.Helper;
using SwaggerPet.Utilitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPet.TestScripts
{
    internal class SwaggerTest:CoreCodes
    {
        [Test]
        [Order(0)]
        [Category("GetallUser Test")]
        public void GetUserDetails()
        {
            test = extent.CreateTest("Get all user");
            Log.Information("Get all User Test Started");
            var request = new RestRequest("/string", Method.Get);
            var response = client.Execute(request);

            try
            {

                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response : {response.Content}");

                var users = JsonConvert.DeserializeObject<UserData>(response.Content);

                Assert.IsNotNull(users);
                Log.Information("Users not Empty");
                //Assert.That(users.username, Is.EqualTo("user7"));
                //Log.Information($"User name fetches with the response {users.username}");
                //Assert.That(users.Firstname, Is.EqualTo("Arjun"));
                //Log.Information($"First name fetches with the response {users.Firstname}");
                //Assert.That(users.Lastname, Is.EqualTo("L"));
               
                //Assert.That(users.UserStatus, Is.EqualTo(1));
                //Log.Information($"User Status fetches with the response {users.UserStatus}");


                Log.Information("Get all User Test Passed");
                test.Pass("Get all User Test Passed");
            }
            catch (AssertionException)
            {
                test.Fail("Get all UserTest Failed");
            }
        }
        [Test]
        [Order(1)]
        [Category("PostUser Test")]

        public void PostUserDetails()
        {
            test = extent.CreateTest("Post user");
            Log.Information("Post User Test Started");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                Id = 1234,
                username = "Abhi123",
                Firstname = "abhi",
                Lastname = "nand",
                Email = "abc123@gmail.com",
                Password = "1234567",
                Phone = "9876345612",
                UserStatus = 1

            });

            var response = client.Execute(request);

            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response : {response.Content}");

                var users = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);

                Assert.IsNotNull(users);
                Log.Information("Users not Empty");
                Assert.That(users.Code, Is.EqualTo(200));
                Log.Information($"Code matches with fetch {users.Code}");
                Assert.That(users.Type, Is.EqualTo("unknown"));
                Log.Information($"Type matches with fetch {users.Type}");
                Assert.That(users.Message, Is.EqualTo("1234"));
                Log.Information($"Message matches with fetch {users.Message}");

                Log.Information("Post User Test Passed");
                test.Pass("PostUser Test Passed");
            }
            catch (AssertionException)
            {
                test.Fail("PostUserTest Failed");
            }
        }
        [Test]
        [Order(2)]
        [Category("UpdateUser Test")]
        [TestCase("user5")]

        public void UpdateUserDetails(string uid)
        {

            test = extent.CreateTest("Update user");
            Log.Information("Update User Test Started");
            var request = new RestRequest("/" + uid, Method.Put);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                Id = 234,
                username = "user5",
                Firstname = "abhi",
                Lastname = "jith",
                Email = "abc@gmail.com",
                Password = "1234567",
                Phone = "876488326",
                UserStatus = 1
              
        });

            var response = client.Execute(request);

            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response : {response.Content}");

                var users = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);

                Assert.IsNotNull(users);
                Log.Information("Users not Empty");
                Assert.That(users.Code, Is.EqualTo(200));
                Log.Information($"Code matches with fetch {users.Code}");
                Assert.That(users.Type, Is.EqualTo("unknown"));
                Log.Information($"Type matches with fetch {users.Type}");
                Assert.That(users.Message, Is.EqualTo("234"));
                Log.Information($"Message matches with fetch {users.Message}");

                Log.Information("Update User Test Passed");
                test.Pass("UpdateUser Test Passed");
            }
            catch (AssertionException)
            {
                test.Fail("UpdateUserTest Failed");
            }
        }

        [Test]
        [Order(3)]
        [Category("DeleteUser Test")]
        [TestCase("user5")]
        public void DeleteUserDetails(string userId)
        {

            test = extent.CreateTest("Delete user");
            Log.Information("Delete User Test Started");
            var request = new RestRequest("" + userId, Method.Delete);
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request);

            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response : {response.Content}");

                var users = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);

                Assert.IsNotNull(users);
                Log.Information("Users not Empty");
                Assert.That(users.Code, Is.EqualTo(200));
                Log.Information($"Code matches with fetch {users.Code}");
                Assert.That(users.Type, Is.EqualTo("unknown"));
                Log.Information($"Type matches with fetch {users.Type}");
                Assert.That(users.Message, Is.EqualTo("user5"));
                Log.Information($"Message matches with fetch {users.Message}");

                Log.Information("Delete User Test Passed");
                test.Pass("DeleteUser Test Passed");
            }
            catch (AssertionException)
            {
                test.Fail("DeleteUserTest Failed");
            }

        }
    }
}

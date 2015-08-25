using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using AzureAppServiceDemoApi.Models;
using Dapper;

namespace AzureAppServiceDemoApi.Controllers
{
    [RoutePrefix("api/customers")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomersController : ApiController
    {
        // GET api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customerData = new CustomerStore();
            return customerData.GetCustomers();
        }

        // POST api/customers
        [HttpPost]
        public Customer Post(Customer newCustomer)
        {
            var customerData = new CustomerStore();
            return customerData.SaveCustomer(newCustomer);
        }

        [HttpGet, Route("getsignups")]
        public IEnumerable<Customer> GetSignUps()
        {
            var customerData = new CustomerStore();
            return customerData.GetNewSignUps();
        } 
    }

    public class CustomerStore
    {
        public IEnumerable<Customer> GetCustomers()
        {

           //var dbConnectionString = ConfigurationManager.ConnectionStrings["LocalDbConnection"].ConnectionString;
           var dbConnectionString = ConfigurationManager.ConnectionStrings["AzureDbConnection"].ConnectionString;

            using (var dbConnection = new SqlConnection(dbConnectionString))
            {
                dbConnection.Open();

                return dbConnection.Query<Customer>("[dbo].[GetCustomers]", commandType: CommandType.StoredProcedure);
            }

        }

        public IEnumerable<Customer> GetNewSignUps()
        {
            //var dbConnectionString = ConfigurationManager.ConnectionStrings["LocalDbConnection"].ConnectionString;
            var dbConnectionString = ConfigurationManager.ConnectionStrings["AzureDbConnection"].ConnectionString;

            using (var dbConnection = new SqlConnection(dbConnectionString))
            {
                dbConnection.Open();

                return dbConnection.Query<Customer>("[dbo].[GetNewSignups]", commandType: CommandType.StoredProcedure);
            }
        }


        public Customer SaveCustomer(Customer newCustomer)
        {
            //var dbConnectionString = ConfigurationManager.ConnectionStrings["LocalDbConnection"].ConnectionString;
            var dbConnectionString = ConfigurationManager.ConnectionStrings["AzureDbConnection"].ConnectionString;

            using (var dbConnection = new SqlConnection(dbConnectionString))
            {
                dbConnection.Open();

                var parms = new DynamicParameters();
                parms.Add("@FirstName", newCustomer.FirstName, DbType.String, ParameterDirection.Input);
                parms.Add("@LastName", newCustomer.LastName, DbType.String, ParameterDirection.Input);
                parms.Add("@Email", newCustomer.Email, DbType.String, ParameterDirection.Input);
                parms.Add("@Phone", newCustomer.Phone, DbType.String, ParameterDirection.Input);

                var customers = dbConnection.Query<Customer>("[dbo].[SaveCustomer]", parms, null, false, null,
                    CommandType.StoredProcedure);

                newCustomer = customers.ToList().FirstOrDefault();
            }

            return newCustomer;
        }
    }

}

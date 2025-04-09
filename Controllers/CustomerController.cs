using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyApiProject.Data;
using MyApiProject.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly IMongoCollection<Customer>? _customerCollection;
        public CustomerController(MongoDbService mongoDbService)
        {
            _customerCollection = mongoDbService.Database?.GetCollection<Customer>("customer");
        }



        // get: api/customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            //return await _customerCollection.Find(FilterDefinition<Customer>.Empty).ToListAsync();
            return await _customerCollection.Find(_ => true).ToListAsync();
        }


        // get: api/customer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            var customer = await _customerCollection.Find(filter).FirstOrDefaultAsync();
            return customer is not null ? Ok(customer) : NotFound();
        }


        // post: api/customer
        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            await _customerCollection.InsertOneAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }




        // put: api/customer/{id}
        [HttpPut]
        public async Task<IActionResult> Update(string id, Customer updatedCustomer)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            var update = Builders<Customer>.Update
                .Set(c => c.CustomerName, updatedCustomer.CustomerName)
                .Set(c => c.Email, updatedCustomer.Email);

            var result = await _customerCollection.UpdateOneAsync(filter, update);
            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
        // delete: api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            var result = await _customerCollection.DeleteOneAsync(filter);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }


        // private static List<Customer> customers = new List<Customer>
        // {
        //     new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
        //     new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        // };

        // // GET: api/customer
        // [HttpGet]
        // public ActionResult<IEnumerable<Customer>> GetAll()
        // {
        //     return Ok(customers);
        // }

        // // GET: api/customer/{id}
        // [HttpGet("{id}")]
        // public ActionResult<Customer> GetById(int id)
        // {
        //     var customer = customers.FirstOrDefault(c => c.Id == id);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(customer);
        // }

        // // POST: api/customer
        // [HttpPost]
        // public ActionResult<Customer> Create(Customer customer)
        // {
        //     customer.Id = customers.Max(c => c.Id) + 1;
        //     customers.Add(customer);
        //     return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        // }

        // // PUT: api/customer/{id}
        // [HttpPut("{id}")]
        // public ActionResult Update(int id, Customer updatedCustomer)
        // {
        //     var customer = customers.FirstOrDefault(c => c.Id == id);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }

        //     customer.Name = updatedCustomer.Name;
        //     customer.Email = updatedCustomer.Email;
        //     return NoContent();
        // }

        // // DELETE: api/customer/{id}
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var customer = customers.FirstOrDefault(c => c.Id == id);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }

        //     customers.Remove(customer);
        //     return NoContent();
        // }
    }

    // public class Customer
    // {
    //     public int Id { get; set; }
    //     public string? Name { get; set; }
    //     public string? Email { get; set; }
    // }
}
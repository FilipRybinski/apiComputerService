using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using net_core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_core.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        private readonly dataBase _dbcontext;
        public SimpleController(dataBase dbcontext)
        {
            _dbcontext = dbcontext;
        }
        // USERS ....
        [HttpGet("users")]
        public ActionResult <IEnumerable<singup>> getUsers()
        {
            if (_dbcontext.Singups.ToList().Count==0)
            {
                return NoContent();
            }
            var users = _dbcontext.Singups.ToList();
            return Ok(users);

        }
        [HttpPost("users")]
        public ActionResult postRegister([FromBody] singup user)
        {
            var newUser = new singup()
            {
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                password = user.password,
                type = user.type,
            };
            _dbcontext.Singups.Add(newUser);
            _dbcontext.SaveChanges();
            return Ok();
        }
        //REGISTRATION ....
        [HttpGet("registration_order")]
        public ActionResult<IEnumerable<registration_order>> getRegistrationl()
        {
            var registrations = _dbcontext.Registration_Orders.ToList();
            return Ok(registrations);

        }

        [HttpPost("registration_order")]
        public ActionResult postRegistration([FromBody] registration_order registration)
        {
            var newRegistration = new registration_order()
            {
                id=registration.id,
                firstName=registration.firstName,
                lastName=registration.lastName,
                email=registration.email,
                model_type=registration.model_type,
                des_of_problem= registration.des_of_problem,
                des_of_demage= registration.des_of_demage
            };
            _dbcontext.Registration_Orders.Add(newRegistration);
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete("registration_order/{id}")]
        public ActionResult deleteRegistration([FromRoute] int id)
        {
            var registartion= _dbcontext.Registration_Orders.FirstOrDefault(r=> r.id == id);
            if(registartion is null)
            {
                throw new Exception();
            }
            _dbcontext.Registration_Orders.Remove(registartion);
            _dbcontext.SaveChanges();
            return NoContent();
        }
        // ORDERS....
        [HttpGet("orders")]
        public ActionResult<IEnumerable<orders>> getOrders()
        {
            var orders = _dbcontext.Orders.ToList();
            return Ok(orders);

        }

        [HttpPost("orders")]
        public ActionResult postOrder([FromBody] orders order)
        {
            var newOrder = new orders()
            {
               id= order.id,
                accept_date= order.accept_date,
                description= order.description,
                completed= order.completed,
                email= order.email,
                wycena= order.wycena,
                date_collect= order.date_collect
            };
            _dbcontext.Orders.Add(newOrder);
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete("orders/{id}")]
        public ActionResult deleteOrder([FromRoute] int id)
        {
            var order = _dbcontext.Orders.FirstOrDefault(r => r.id == id);
            if (order is null)
            {
                throw new Exception();
            }
            _dbcontext.Orders.Remove(order);
            _dbcontext.SaveChanges();
            return NoContent();
        }
        [HttpPut("orders/{id}")]
        public ActionResult updateOrder([FromRoute] int id, [FromBody] orders order)
        {
            var orderr = _dbcontext.Orders.FirstOrDefault(r => r.id == id);
            if (order is null)
            {
                throw new Exception();
            }
            orderr.completed=order.completed;
            _dbcontext.SaveChanges();
            return Ok();
        }
        ///Messages....
        [HttpGet("message")]
        public ActionResult<IEnumerable<orders>> getMessage()
        {
            var messages = _dbcontext.Messages.ToList();
            return Ok(messages);

        }

        [HttpPost("message")]
        public ActionResult postMessage([FromBody] messages message)
        {
            var newMessage = new messages()
            {
                id= message.id,
                firstName= message.firstName,
                lastName= message.lastName,
                email= message.email,
                message=message.message
            };
            _dbcontext.Messages.Add(newMessage);
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete("message/{id}")]
        public ActionResult deleteMessage([FromRoute] int id)
        {
            var message = _dbcontext.Messages.FirstOrDefault(r => r.id == id);
            if (message is null)
            {
                throw new Exception();
            }
            _dbcontext.Messages.Remove(message);
            _dbcontext.SaveChanges();
            return NoContent();
        }
    }
}

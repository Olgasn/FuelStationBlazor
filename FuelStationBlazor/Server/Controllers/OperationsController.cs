using FuelStationBlazor.Server.Data;
using FuelStationBlazor.Server.ViewModels;
using FuelStationBlazor.Shared.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FuelStationBlazor.Server.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/[controller]")]

    public class OperationsController(FuelsContext context) : Controller
    {
        private readonly FuelsContext _context = context;

        /// <summary>
        /// Получение списка всех операций
        /// </summary>
        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public List<OperationViewModel> Get()
        {
            IQueryable<OperationViewModel> ovm = _context.Operations
                .Include(t => t.Tank)
                .Include(f => f.Fuel)
                .Select(o =>
                new OperationViewModel
                {
                    OperationID = o.OperationID,
                    TankID = o.TankID,
                    FuelID = o.FuelID,
                    FuelType = o.Fuel.FuelType,
                    TankType = o.Tank.TankType,
                    Inc_Exp = o.Inc_Exp,
                    Date = o.Date
                });
            return [.. ovm];
        }
        /// <summary>
        /// Получение списка операций, удовлетворяющих заданному условию
        /// </summary>
        /// <remarks>
        /// Описание параметров
        /// </remarks>
        /// <param name="FuelID">Код топлива</param>
        /// <param name="TankID">Код емкости</param>
        /// <returns>JSON</returns>
        [HttpGet("FilteredOperations")]
        [Produces("application/json")]
        public List<OperationViewModel> GetFilteredOperations(int FuelID, int TankID)
        {
            IQueryable<OperationViewModel> ovm = _context.Operations
                .Include(t => t.Tank)
                .Include(f => f.Fuel)
                .Select(o =>
                new OperationViewModel
                {
                    OperationID = o.OperationID,
                    TankID = o.TankID,
                    FuelID = o.FuelID,
                    FuelType = o.Fuel.FuelType,
                    TankType = o.Tank.TankType,
                    Inc_Exp = o.Inc_Exp,
                    Date = o.Date

                });
            if (TankID > 0)
            {
                ovm = ovm.Where(op => op.TankID == TankID);

            }
            if (FuelID > 0)
            {
                ovm = ovm.Where(op => op.FuelID == FuelID);

            }
            return [.. ovm];
        }


        /// <summary>
        /// Список видов топлива 
        /// </summary>
        [HttpGet("fuels")]
        [Produces("application/json")]
        public IEnumerable<Fuel> GetFuels()
        {
            return _context.Fuels.ToList();
        }



        /// <summary>
        /// Список емкостей 
        /// </summary>
        [HttpGet("tanks")]
        [Produces("application/json")]
        public IEnumerable<Tank> GetTanks()
        {
            return _context.Tanks.ToList();
        }

        /// <summary>
        /// Получение данных одной операции
        /// </summary>
        /// <remarks>
        /// Описание параметра
        /// </remarks>
        /// <param name="id">Код операции</param>
        /// <returns>JSON</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Operation operation = _context.Operations.FirstOrDefault(x => x.OperationID == id);
            if (operation == null)
                return NotFound();
            return new ObjectResult(operation);
        }

        /// <summary>
        /// Регистрация новой приходной или расходной операции
        /// </summary>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Operation operation)
        {
            if (operation == null)
            {
                return BadRequest();
            }

            _context.Operations.Add(operation);
            _context.SaveChanges();
            return Ok(operation);
        }
        /// <summary>
        /// Обновление данных одной операции
        /// </summary>
        /// <remarks>
        /// Объект передается в теле запроса
        /// </remarks>
        /// <param name="operation">объект, определяющий операцию</param>
        /// <returns>Статус</returns>
        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Operation operation)
        {
            if (operation == null)
            {
                return BadRequest();
            }
            if (!_context.Operations.Any(x => x.OperationID == operation.OperationID))
            {
                return NotFound();
            }

            _context.Update(operation);
            _context.SaveChanges();


            return Ok(operation);
        }
        /// <summary>
        /// Удаление данных одной операции
        /// </summary>
        /// <remarks>
        /// Описание параметра
        /// </remarks>
        /// <param name="id">Код операции</param>
        /// <returns>Статус</returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Operation operation = _context.Operations.FirstOrDefault(x => x.OperationID == id);
            if (operation == null)
            {
                return NotFound();
            }
            _context.Operations.Remove(operation);
            _context.SaveChanges();
            return Ok(operation);
        }
    }
}

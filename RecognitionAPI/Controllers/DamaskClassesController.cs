using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RecognitionAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

namespace RecognitionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamaskClassesController : ControllerBase {
        private readonly RecognitionDbContext _context;

        public DamaskClassesController(RecognitionDbContext context) {
            _context = context;
        }

        // GET: api/DamaskClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DamaskClass>>> GetDamaskClasse() {
            if (_context.DamaskClasse == null) {
                return NotFound();
            }
            var sortingDamask = await _context.DamaskClasse.ToListAsync();
            sortingDamask = sortingDamask.OrderByDescending(x => x.arrival_time).Where(w => w.ChannelName == "Камера 1").Where(e => e.ticket_id != null).Distinct().ToList();
            sortingDamask.ForEach(item => item.truck_number = item.truck_number.ToUpper());
            List<DamaskClass> uniqueCarList = new List<DamaskClass>();
            string previousCarNum = "";
            foreach (DamaskClass currentCar in sortingDamask) {
                if (currentCar.truck_number != previousCarNum) {
                    uniqueCarList.Add(currentCar);
                    previousCarNum = currentCar.truck_number;
                }
            }
            return Ok(uniqueCarList);
        }

        [HttpGet("page/")]
        public async Task<ActionResult<List<DamaskClass>>> Get(int currentPage = 1, int pageSize = 10) {
            var totalItems = await _context.DamaskClasse.CountAsync();

            var items = await _context.DamaskClasse
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet("test/")]
        public async Task<ActionResult<IEnumerable<DamaskClass>>> GetDamaskClasse(int pageNumber = 1, int pageSize = 100) {
            if (_context.DamaskClasse == null) {
                return NotFound();
            }
            var sortingDamask = await _context.DamaskClasse.ToListAsync();
            sortingDamask = sortingDamask.OrderByDescending(x => x.arrival_time).Where(w => w.ChannelName == "Камера 1").Where(e => e.ticket_id != null).Distinct().ToList();
            sortingDamask.ForEach(item => item.truck_number = item.truck_number.ToUpper());

            List<DamaskClass> uniqueCarList = new List<DamaskClass>();
            string previousCarNum = "";
            foreach (DamaskClass currentCar in sortingDamask) {
                if (currentCar.truck_number != previousCarNum) {
                    uniqueCarList.Add(currentCar);
                    previousCarNum = currentCar.truck_number;
                }
            }

            int totalCount = uniqueCarList.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            int skip = (pageNumber - 1) * pageSize;
            var pagedData = uniqueCarList.Skip(skip).Take(pageSize);

          
            return Ok(pagedData);
        }

        [HttpGet("update/")]
        public async void  GetUpdateDamaskTable() {
            try {
                HttpClient _client = new HttpClient();
                var response = await _client.GetAsync("http://192.168.0.41/api/DamaskClasses");
                if (response.IsSuccessStatusCode) {
                    CloneDamaskTable.GetUpdate();

                    return;
                }
            }
            catch (Exception) {

                throw;
            }
            
        }

        [HttpGet("search/")]
        public async Task<ActionResult<IEnumerable<DamaskClass>>> Search(string searchQuery) {

            if (_context.DamaskClasse == null) {
                return NotFound();
            }
            var sortingDamask = await _context.DamaskClasse.ToListAsync();
            sortingDamask = sortingDamask.OrderByDescending(x => x.arrival_time).Where(w => w.ChannelName == "Камера 1").Where(e => e.ticket_id != null).Where(w =>
            w.truck_number.Contains(searchQuery)).Distinct().ToList();
            sortingDamask.ForEach(item => item.truck_number = item.truck_number.ToUpper());

            //using RecognitionDbContext context = new RecognitionDbContext();
            //var searchResults = context.Set<DamaskClass>().Where(e =>
            //e.truck_number.Contains(searchQuery));
            List<DamaskClass> uniqueCarList = new List<DamaskClass>();
            
            foreach (DamaskClass currentCar in sortingDamask) {

                uniqueCarList.Add(currentCar);                                
            }
            return Ok(uniqueCarList);
           

        }


        [HttpGet("betweenDates/")]
        public async Task<ActionResult<IEnumerable<DamaskClass>>> GetDataBetweenDates(DateTime startDate, DateTime endDate) {
        


                var sortingDamask = await _context.DamaskClasse.ToListAsync();
                sortingDamask = sortingDamask.OrderByDescending(x => x.arrival_time)
                .Where(w => w.ChannelName == "Камера 1")
                .Where(e => e.ticket_id != null)
                .Where(x => x.arrival_time >= startDate && x.arrival_time <= endDate)
                .Distinct().ToList();
                sortingDamask.ForEach(item => item.truck_number = item.truck_number.ToUpper());

                List<DamaskClass> uniqueCarList = new List<DamaskClass>();

                foreach (DamaskClass currentCar in sortingDamask) {

                    uniqueCarList.Add(currentCar);
                }
                return Ok(uniqueCarList);

                //// Map the database objects to your model objects
                //var result = sortingDamask.Select(x => new DamaskClass {
                //    id = x.id,
                //    arrival_time = x.arrival_time,
                //    departure_time = x.departure_time,
                //    truck_number = x.truck_number,
                //    truck_id = x.truck_id,
                //    reg_time = x.reg_time,
                //    begin_service_time = x.begin_service_time,
                //    last_begin_service_time = x.last_begin_service_time,
                //    end_service_time = x.end_service_time,
                //    ticket_id = x.ticket_id,
                //    ticket_text = x.ticket_text

                //});

                //return result;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataApi.Hubs;
using SmartShop.DataApi.ViewModels.Data;
using SmartShop.DataApi.ViewModels.Input;
using SmartShop.DataLib.Models.Constants;
using SmartShop.DataLib.Models.Data;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SmartShopDbContext _context;
        private readonly IHubContext<OrderCreatedNotificationHub> _hubContext;

        public OrdersController(SmartShopDbContext context, IHubContext<OrderCreatedNotificationHub> hubContext)
        {
            _context = context;
            this._hubContext = hubContext;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        /*
         * Custom to get pending order count
         * 
         * */
        [HttpGet("PendingOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetPendingOrders()
        {
            return await _context
                .Orders
                
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .ToListAsync();
            
        }
        [HttpGet("Unfirmed")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUnfirmedOrders()
        {
            return await _context
                .Orders

                .Where(o => o.IsConfirmed == false)
                .ToListAsync();

        }
        [HttpGet("OfStatus/{status}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByStatus(OrderStatus status)
        {
            return await _context
                .Orders

                .Where(o => o.OrderStatus == status)
                .ToListAsync();

        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        /*
         * Custo to get summary
         * 
         * */
        [HttpGet("{id}/Summary")]
        public async Task<ActionResult<Order>> GetOrderSummary(int id)
        {
            var order = await _context
                .Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.OrderId == id);


            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        /*
         * Custom to get pending order count
         * 
         * */
        [HttpGet("Pending")]
        public async Task<ActionResult<int>> GetPendingOrderCount()
        {
            var orderCount = await _context.Orders
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .CountAsync();
            return orderCount;
        }
        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }
        /*
         * Custom to change order confirmation
         * 
         * */
        [HttpPost("{id}/Confirm")]
        public async Task<ActionResult<bool>> PostChangeIsConfirm(int id, ConfirmBoolData confirm)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            order.IsConfirmed = confirm.IsConfirm;
            var result= await _context.SaveChangesAsync();
            return result > 0;
        }
        /*
         * Custom to change order status
         * 
         * */
        [HttpPost("{id}/OrderStatus")]
        public async Task<ActionResult<bool>> PostChangeOrderStatus(int id, OrderStatusData status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            order.OrderStatus = status.Status;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }
        /*
         * Custom Action
         * 
         * */
        [HttpPost("Create")]
        public async Task<ActionResult<Order>> CreateOrder(OrderViewModel order)
        {
            var orderNew = new Order { CustomerId = order.CustomerId,  OrderDate = order.OrderDate };
            _context.Orders.Add(orderNew);
            await _context.SaveChangesAsync();
            await this._hubContext.Clients.All.SendAsync("orderCreated", new NotificationMessage { OrderId = orderNew.OrderId, CustomerId = orderNew.OrderId, Message = "Created" });
            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}

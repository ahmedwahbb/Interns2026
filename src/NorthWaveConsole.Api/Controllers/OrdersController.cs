using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWaveConsole.Application.DTOs;
using NorthWaveConsole.Application.Interfaces;

namespace NorthWaveConsole.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IValidator<CreateOrderRequest> _orderValidator;

        public OrdersController(IOrderService orderService, IValidator<CreateOrderRequest> orderValidator)
        {
            _orderService = orderService;
            _orderValidator = orderValidator;
        }

        
        [HttpPost]
        public ActionResult<OrderResult> Create([FromBody] CreateOrderRequest request)
        {
            var validationResult = _orderValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            var result = _orderService.ProcessOrder(request);
            _orderService.CommitOrders();

            return Ok(result);
        }

        
        [HttpPost("batch")]
        public ActionResult<BatchOrdersResponse> CreateBatch([FromBody] BatchOrdersRequest request)
        {
            var errors = new List<string>();

            foreach (var orderRequest in request.Orders)
            {
                var validationResult = _orderValidator.Validate(orderRequest);
                if (!validationResult.IsValid)
                {
                    errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
                }
            }

            if (errors.Any())
            {
                return BadRequest(errors);
            }

            var results = request.Orders.Select(_orderService.ProcessOrder).ToList();
            int committedCount = _orderService.CommitOrders();

            return Ok(new BatchOrdersResponse
            {
                Results = results,
                CommittedCount = committedCount
            });
        }

        
        [HttpGet("{id:int}")]
        public ActionResult<OrderResult> GetById(int id)
        {
            var result = _orderService.GetById(id);
            return result is null ? NotFound() : Ok(result);
        }
    }
}

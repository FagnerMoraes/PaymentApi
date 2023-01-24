using Microsoft.AspNetCore.Mvc;
using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.DTOs.Response;
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Interfaces.Services;

namespace PaymentApi.API.Controllers
{
    [ApiController]
    [Route("api/v1/venda")]
    public class SaleController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IProductRepository _productRepository;

        public SaleController(IOrderService orderService,
                               IOrderItemService orderItemService,
                               IOrderRepository orderRepository,
                               IProductRepository productRepository,
                               ISellerRepository sellerRepository,
                               IOrderItemRepository orderItemRepository)
        {            
            _orderService = orderService;
            _orderItemService = orderItemService;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _sellerRepository = sellerRepository;
            _orderItemRepository = orderItemRepository;
            
        }
       


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<SaleResponse>> Get(Guid id)
        {
                var sale = await _orderRepository.ObterDtoPorIdAsync(id);
                if (sale.OrderSale is null)
                    return NotFound($"Não existe venda com id={id}");

                var saleResponse = SaleResponse.CovertToResponse(sale);                
                return Ok(saleResponse);
        }

        [HttpPost("criar-venda")]
        public async Task<ActionResult> Post(CreateSaleRequest saleRequest)
        {
            var order = CreateOrderRequest.ConvertForEntity(saleRequest.OrderRequest);

            var id = (Guid)await _orderService.AdicionarAsync(order);

            var OrderItem = new List<OrderItem>();

            foreach (var item in saleRequest.OrderItemsSale) {
                var orderItem = CreateOrderItemRequest.ConvertForEntity(id,item);

                var OrderItemId = (int)await _orderItemService.CreateAsync(orderItem);
                
                if(OrderItemId == 0)    
                {
                    return BadRequest("Problema com cadastro");
                }

            }
            return AcceptedAtAction(nameof(Get), new { id = id }, id);
        }

        [HttpPost("aprovar-pagamento")]
        public async Task<ActionResult<OrderResponse>> ApprovedPayment(Guid id)
        {
            try
            {
                var order = (Order)await _orderService.UpdateOrderToApproved(id);
                var orderResponse = OrderResponse.CovertToResponse(order);
                return Ok(orderResponse);
            }catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
  
        }
        [HttpPost("cancelar-venda")]
        public async Task<ActionResult<OrderResponse>> CancelPayment(Guid id)
        {
            try { 
            var order = (Order)await _orderService.UpdateOrderToCancel(id);
            var orderResponse = OrderResponse.CovertToResponse(order);
            return Ok(orderResponse);
            }catch(ArgumentNullException e)
            {
                
                return NotFound(e.Message);
            }catch(InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("enviar-para-transportadora")]
        public async Task<ActionResult<OrderResponse>> SendToCarrier(Guid id)
        {
            try
            {
                var order = (Order)await _orderService.UpdateOrderToSendToCarrier(id);
                var orderResponse = OrderResponse.CovertToResponse(order);
                return Ok(orderResponse);
            }catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("entregar")]
        public async Task<ActionResult<OrderResponse>> Delivered(Guid id)
        {
            try
            {
                var order = (Order)await _orderService.UpdateOrderToDelivered(id);
                var orderResponse = OrderResponse.CovertToResponse(order);
                return Ok(orderResponse);
            }catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[products]")]

public class ProductController : ControllerBase
{
    public readonly IProductService _service;
    public ProductController(IProductService service){
        _service = service;   
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageSize, int page)
    {
        var products = await _service.GetAll(pageSize, page);
        if(products == null) throw new Exception("An error has occured");
        return Ok(products);
    
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _service.GetProduct(id);
        if(product == null) throw new Exception("An error has occured");
        return Ok(product);        
    }
}
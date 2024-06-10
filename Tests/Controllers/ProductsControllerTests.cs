using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tests.Controllers;
using Xunit;

public class ProductsControllerTests
{
    private readonly Mock<IProductService> _mockProductService;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _mockProductService = new Mock<IProductService>();
        _controller = new ProductsController(_mockProductService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfProducts()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Product1" },
            new ProductDto { Id = 2, Name = "Product2" }
        };
        _mockProductService.Setup(service => service.GetAllAsync())
                           .ReturnsAsync(products);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnProducts = Assert.IsType<List<ProductDto>>(okResult.Value);
        Assert.Equal(2, returnProducts.Count);
    }

    [Fact]
    public async Task GetById_ReturnsNotFoundResult_WhenProductDoesNotExist()
    {
        // Arrange
        _mockProductService.Setup(service => service.GetByIdAsync(1))
                           .ReturnsAsync((ProductDto)null);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtActionResult_WithProduct()
    {
        // Arrange
        var newProduct = new CreateProductDto { Id = 1, Name = "NewProduct" };
        _mockProductService.Setup(service => service.CreateAsync(newProduct))
                           .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Create(newProduct);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
        Assert.Equal(1, ((CreateProductDto)createdAtActionResult.Value).Id);
    }
}

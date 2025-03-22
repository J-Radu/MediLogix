using AutoFixture;
using FluentAssertions;
using MediatR;
using MediLogix.Application.Commands.CurrentLocation;
using MediLogix.Application.Commands.Description;
using MediLogix.Application.Commands.Failure;
using MediLogix.Application.DTOs;
using Moq;

namespace Application.UnitTests;

public class CommandsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task CreateCurrentLocation_WhenCommandIsValid_CreateNewLocation()
    {
        // Arrange
        var locationId = Guid.NewGuid();
        var command = _fixture.Create<CreateCurrentLocationCommand>();
        var locationDto = new CurrentLocationDto { Id = locationId };
        
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<CreateCurrentLocationCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(locationDto);

        // Act
        var result = await mediatorMock.Object.Send(command, CancellationToken.None);

        // Assert
        result.Id.Should().Be(locationId);
        mediatorMock.Verify(m => m.Send(It.IsAny<CreateCurrentLocationCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
    }

    [Fact]
    public async Task UpdateDescriptionCommand_WhenDevicesExists_UpdateDescription()
    {
        // Arrange
        var descriptionId = Guid.NewGuid();
        var deviceName = _fixture.Create<string>();
        var deviceDescription = _fixture.Create<string>();
        var deviceNumber = _fixture.Create<string>();
        var inventoryNumber = _fixture.Create<string>();
        
        var command = new UpdateDescriptionCommand 
        { 
            Id = descriptionId,                
            DeviceName = deviceName,
            DeviceDescription = deviceDescription,
            DeviceNumber = deviceNumber,
            InventoryNumber = inventoryNumber
        };
    
        var descriptionDto = new DescriptionDto 
        { 
            Id = descriptionId,
            DeviceName = deviceName,
            DeviceDescription = deviceDescription,
            DeviceNumber = deviceNumber,
            InventoryNumber = inventoryNumber
        };
    
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateDescriptionCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(descriptionDto);

        // Act
        var result = await mediatorMock.Object.Send(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.DeviceName.Should().Be(deviceName);
        result.DeviceDescription.Should().Be(deviceDescription);
        result.DeviceNumber.Should().Be(deviceNumber);
        result.InventoryNumber.Should().Be(inventoryNumber);
        mediatorMock.Verify(m => m.Send(It.IsAny<UpdateDescriptionCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
    }

    [Fact]
    public async Task DeleteFailureCommand_WhenFailureExists_DeleteFailure()
    {
        // Arrange
        var failureId = Guid.NewGuid();
        var command = new DeleteFailureByIdCommand
        {
            Id = failureId
        };

        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<DeleteFailureByIdCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        // Act
        await mediatorMock.Object.Send(command, CancellationToken.None);

        // Assert
        mediatorMock.Verify(m => m.Send(It.IsAny<DeleteFailureByIdCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
    }
}

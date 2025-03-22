using AutoFixture;
using FluentAssertions;
using MediatR;
using MediLogix.Application.Commands.Model;
using MediLogix.Application.DTOs;
using MediLogix.Application.Handlers.Queries.Failure;
using MediLogix.Application.Handlers.Queries.FinancialInfo;
using MediLogix.Application.Queries.Failure;
using MediLogix.Application.Queries.FinancialInfo;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

namespace Application.UnitTests;

public class HandlersTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task GetAllFailuresQueryHandler_WhenFailuresExist_ReturnsListOfFailures()
    {
        // Arrange
        var failures = _fixture.CreateMany<FailureDto>(3).ToList();
        
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllFailuresQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(failures);

        // Act
        var result = await mediatorMock.Object.Send(new GetAllFailuresQuery(), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().BeEquivalentTo(failures);
        mediatorMock.Verify(m => m.Send(It.IsAny<GetAllFailuresQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetAllFinancialInfosQueryHandler_WhenFinancialInfosExist_ReturnsListOfFinancialInfos()
    {
        // Arrange
        var financialInfos = _fixture.CreateMany<FinancialInfoDto>(2).ToList();
        
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllFinancialInfosQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(financialInfos);

        // Act
        var result = await mediatorMock.Object.Send(new GetAllFinancialInfosQuery(), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(financialInfos);
        mediatorMock.Verify(m => m.Send(It.IsAny<GetAllFinancialInfosQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreateModelCommandHandler_WhenModelIsValid_CreatesModel()
    {
        // Arrange
        var modelId = Guid.NewGuid();
        var dmModel = _fixture.Create<string>();
        var gMDN = _fixture.Create<string>();
        var manufacturer = _fixture.Create<string>();
        var country = _fixture.Create<string>();
        
        
        var command = new CreateModelCommand
        {
            DmModel = dmModel,
            GMDN = gMDN,
            Manufacturer = manufacturer,
            Country = country
        };
        
        var modelDto = new ModelDto
        {
            Id = modelId,
            DmModel = dmModel,            
            Manufacturer = "Manufacturer",  
            GMDN = _fixture.Create<string>(),
            Country = _fixture.Create<string>()
        };
        
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<CreateModelCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(modelDto);

        // Act
        var result = await mediatorMock.Object.Send(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(modelId);
        result.DmModel.Should().Be(dmModel);    
        result.Manufacturer.Should().NotBeNull();  
        result.GMDN.Should().NotBeNull();
        result.Country.Should().NotBeNull();
        mediatorMock.Verify(m => m.Send(It.IsAny<CreateModelCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
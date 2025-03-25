using AutoFixture;
using FluentAssertions;
using MediatR;
using MediLogix.Application.DTOs;
using MediLogix.Application.Queries.Device;
using MediLogix.Application.Queries.OperatingTerms;
using MediLogix.Application.Queries.PeriodicVerification;
using Moq;

namespace Application.UnitTests;

public class QueriesTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task GetAllDevicesQuery_WhenDevicesExists_ReturnListOfDevices()
    {
        // Arrange
        var devices = _fixture.CreateMany<FullDeviceDto>(3).ToList();
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllFullDevicesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(devices);

        // Act
        var result = await mediatorMock.Object.Send(new GetAllFullDevicesQuery(), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().BeEquivalentTo(devices);
        mediatorMock.Verify(m => m.Send(It.IsAny<GetAllFullDevicesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetAllOperatingTerms_WhenTermsExists_ReturnsListOfTerms()
    {
        // Arrange
        var terms = _fixture.CreateMany<OperatingTermsDto>(5).ToList();
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllOperatingTermsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(terms);

        // Act
        var result = await mediatorMock.Object.Send(new GetAllOperatingTermsQuery(), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(5);
        result.Should().BeEquivalentTo(terms);
        mediatorMock.Verify(m => m.Send(It.IsAny<GetAllOperatingTermsQuery>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task GetAllPeriodicVerifications_WhenVerificationsExists_ReturnsListOfPeriodicVerifications()
    {
        // Arrange
        var verifications = _fixture.CreateMany<PeriodicVerificationDto>(2).ToList();
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPeriodicVerificationsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(verifications);

        // Act
        var query = new GetAllPeriodicVerificationsQuery();
        var result = await mediatorMock.Object.Send(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(verifications);

        mediatorMock.Verify(m => m.Send(It.IsAny<GetAllPeriodicVerificationsQuery>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
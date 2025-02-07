using Domain.Entities.Events;
using MediatR;
using Services;


namespace Features.Products.EventHandlers;

public class ProductCreatedNotificationEventHandler : INotificationHandler<ProductCreatedEvent>
{
    private readonly ILogger<ProductCreatedNotificationEventHandler> _logger;
    private readonly IEmailSender _emailSender;

    public ProductCreatedNotificationEventHandler(
        ILogger<ProductCreatedNotificationEventHandler> logger,
        IEmailSender emailSender)
    {
        _logger = logger;
        _emailSender = emailSender;
    }

    public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Nueva notificación: Nuevo producto {Product}", notification.Product);

        await _emailSender.SendNotification("random@email.com", "Nuevo Producto", $"Producto {notification.Product.Name}");
    }
}
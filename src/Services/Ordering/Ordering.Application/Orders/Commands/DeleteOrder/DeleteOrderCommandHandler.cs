﻿namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(IApplicationDbContext dbContext): ICommandHandler<DeleteOrderCommand, DeleteOrderResult> 
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        // Delete Order entity from command object

        // save to database

        // return result

        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken: cancellationToken);

        if (order is null)
        {
            throw new OrderNotFoundException(command.OrderId);
        }

        return new DeleteOrderResult(true);
    }
}
/****** Object:  StoredProcedure [dbo].[GetOrdersByCustomerId]    Script Date: 2025-04-01 2:44:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOrdersByCustomerId]
    @CustomerId INT
AS
BEGIN
    SELECT id, customer_id, order_date
    FROM [Order]
    WHERE customer_id = @CustomerId
    ORDER BY order_date;
END
GO



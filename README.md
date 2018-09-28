# EFCore_OrderByCreatedAsStartDate

This repository is aimed to reproduce a bug in EF Core.

The problem is that EF Core generates a query that has an invalid `ORDER BY` clause. When ordering by an `int` column the query is generated correctly. But when ordering by a `datetimeoffset` column, the `ORDER BY` clause includes an `AS {COLUMN NAME}` section.

Example incorrect query:
``` sql
SELECT [c.CallStack.JobSupplier.Job].[Id] AS [JobId], [c.CallStack.JobSupplier].[Created] AS [StartDate], COUNT(*) AS [CallsMade]
FROM [telem_Calls] AS [c]
INNER JOIN [telem_CallStacks] AS [c.CallStack] ON [c].[CallStackId] = [c.CallStack].[Id]
INNER JOIN [telem_JobSuppliers] AS [c.CallStack.JobSupplier] ON [c.CallStack].[JobSupplierId] = [c.CallStack.JobSupplier].[Id]
INNER JOIN [telem_Jobs] AS [c.CallStack.JobSupplier.Job] ON [c.CallStack.JobSupplier].[JobId] = [c.CallStack.JobSupplier.Job].[Id]
GROUP BY [c.CallStack.JobSupplier.Job].[Id], [c.CallStack.JobSupplier].[Created]
ORDER BY [c.CallStack.JobSupplier].[Created] AS [StartDate]
```

**Note the `AS [StartDate]` at the end**

This query naturally thows a `SqlException` with the message `Incorrect syntax near the keyword 'AS'.`

Example correct query:
``` sql
SELECT [c.CallStack.JobSupplier.Job].[Id] AS [JobId], [c.CallStack.JobSupplier].[Created] AS [StartDate], COUNT(*) AS [CallsMade]
FROM [telem_Calls] AS [c]
INNER JOIN [telem_CallStacks] AS [c.CallStack] ON [c].[CallStackId] = [c.CallStack].[Id]
INNER JOIN [telem_JobSuppliers] AS [c.CallStack.JobSupplier] ON [c.CallStack].[JobSupplierId] = [c.CallStack.JobSupplier].[Id]
INNER JOIN [telem_Jobs] AS [c.CallStack.JobSupplier.Job] ON [c.CallStack.JobSupplier].[JobId] = [c.CallStack.JobSupplier.Job].[Id]
GROUP BY [c.CallStack.JobSupplier.Job].[Id], [c.CallStack.JobSupplier].[Created]
ORDER BY [JobId]
```

## Running the sample
When you start the program, it will use the connection string in `Program.cs` to delete and recreate the database.

The program will write updates of what it is doing to using `Console.WriteLine` and EFCore output is hooked up to `Microsoft.Extensions.Logging.Debug` in the `Program.GetServiceProvider()` method. You can find the generated query in this output.
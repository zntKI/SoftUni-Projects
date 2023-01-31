CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Logs FOR UPDATE
AS
	INSERT INTO Logs(LogId, AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance, GETDATE()
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.NewSum != d.OldSum
GO
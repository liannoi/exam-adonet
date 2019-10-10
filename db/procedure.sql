USE AddressPlan;
GO

IF (OBJECT_ID('dbo.GetData', 'P') IS NOT NULL)
DROP PROCEDURE dbo.GetData;
GO

CREATE PROCEDURE dbo.GetData
@StreetId INT = NULL, @SubdivisionId INT = NULL
AS
BEGIN

SELECT A.AddressId, S.StreetName, A.House, Sub.SubdivisionName
FROM dbo.Address AS A
LEFT OUTER JOIN dbo.Street AS S ON A.StreetId = S.StreetId
LEFT OUTER JOIN dbo.Subdivision AS Sub ON Sub.SubdivisionId = A.SubdivisionId
WHERE (A.SubdivisionId = @SubdivisionId OR @SubdivisionId IS NULL) AND (A.StreetId = @StreetId OR @StreetId IS NULL);

END;
GO

EXEC dbo.GetData NULL, NULL;

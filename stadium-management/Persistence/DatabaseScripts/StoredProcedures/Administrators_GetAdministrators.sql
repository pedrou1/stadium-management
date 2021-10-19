CREATE PROCEDURE [dbo].[Administrators_GetAdministrators]
	@PageIndex INT,  
	@PageSize INT,
	@TotalRows INT OUTPUT
AS  
BEGIN  
	 DECLARE @StartRowIndex INT 
	 DECLARE @EndRowIndex INT
 
	 SET @StartRowIndex = (@PageIndex * @PageSize) + 1;
	 SET @EndRowIndex = (@PageIndex + 1) * @PageSize;
 
 SELECT AdministratorId AS AdministratorId ,
		Name AS Name, 
		LastName AS LastName, 
		Username AS Username,
		Password AS Password,
		DocumentNumber AS DocumentNumber,
		Telephone AS Telephone
		FROM  
			(SELECT ROW_NUMBER() over (order by AdministratorId) as RowNumber,  
					AdministratorId AS AdministratorId ,
					Name AS Name, 
					LastName AS LastName, 
					Username AS Username,
					Password AS Password,
					DocumentNumber AS DocumentNumber,
					Telephone AS Telephone
			FROM Administrators 
			WHERE IsDeleted = 0) Administradores
		WHERE RowNumber >= @StartRowIndex and RowNumber <= @EndRowIndex  

		SELECT @TotalRows = COUNT(*) FROM Administrators WHERE IsDeleted = 0
END
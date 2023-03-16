USE BDCLINICA2022
GO

SELECT * FROM Pacientes
GO

CREATE OR ALTER PROCEDURE PA_CITAS_PACIENTE
@CODPAC CHAR(6)
AS
	SELECT C.nrocita, C.fecha, C.codmed,
		M.nommed, E.nomesp, C.pago
	FROM CITAS C INNER JOIN MEDICOS M
		ON C.codmed = M.codmed INNER JOIN ESPECIALIDAD E
			ON M.codesp = E.codesp
	WHERE C.codpac=@CODPAC 
GO

EXECUTE PA_CITAS_PACIENTE 'P00002'
GO

SELECT * FROM Medicos
GO

SELECT * FROM CITAS WHERE codmed='M0001'
GO

DELETE FROM Medicos WHERE codmed='M0001'
GO

-- LISTANDO LOS PACIENTES Y LA CANTIDAD DE CITAS POR 
-- CADA AÑO REGISTRADO
SELECT P.codpac, 
       P.nompac, 
	   YEAR(C.fecha) AS AÑO_CITA,
	   COUNT(C.nrocita) AS CANTIDAD,
       SUM(C.pago) AS SUMA_PAGOS
FROM Citas C INNER JOIN Pacientes P
	ON C.codpac = P.codpac
-- WHERE
GROUP BY P.codpac, 
       P.nompac, YEAR(C.fecha)
GO


SELECT  DISTINCT YEAR(fecha) AS AÑO FROM Citas
GO


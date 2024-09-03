SELECT EmployeeID, Name, Department, Salary 
FROM (
    SELECT EmployeeID, Name, Department, Salary,
           row_number() OVER (PARTITION BY Dno ORDER BY Salary DESC) as rank
    FROM Employee
) ranked
WHERE rank <= 3;

----------------------
-- i used row_number inside a sub queru 
-- row_number gave me resul with out any duplicate 
-- and i get only the first 3 by where <= 3 
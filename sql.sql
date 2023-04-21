-- Сотрудник с максимальной заработной платой  
SELECT `name`, salary
FROM employee
WHERE salary=(SELECT MAX(salary) FROM employee);

-- Вывести число максимальной длины цепочки руководителей
--  по таблице сотрудников(вычислить глубину дерева)

with recursive cte  as (
  select     id,
             `name`,
             chief_id,
             0 AS depth
  from       employee
  where      chief_id = null
  union all
  select     e.id,
             e.`name`,
             e.chief_id,
             cte.depth+1
  from       employee e
  inner join cte
          on e.chief_id = cte.id
)
SELECT MAX(depth) AS max_depth from cte;

-- отдел с максимальной суммарной зарплатой сотрудников 

SELECT d.`name`,
SUM(e.salary) AS sum_salary
FROM department d
JOIN employee e ON d.id = e.department_id
GROUP BY d.`name`
ORDER BY sum_salary DESC
LIMIT 1;

-- сотрудника чье имя начинается на "Р" и заканчивается на "н"

SELECT *
FROM employee
WHERE `name` LIKE "Р%н";

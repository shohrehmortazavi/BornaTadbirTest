select PersonId, 
       CAST(TransactionDate AS DATE) as StartDate,
	   Sum(Price) as Sum
into tab1
from BuyTransactions
group by CAST(TransactionDate AS DATE), PersonId


select p.PersonId,p.Name,p.Family,t.StartDate,
       Case when t.PersonId=LEAD(t.PersonId) over (order by t.PersonId) and
                 t.StartDate= LEAD(t.StartDate) over (order by t.StartDate)
            then (LEAD(t.StartDate) Over(partition by t.PersonId order by t.StartDate))
            else Null END
			as EndDate,
	   t.Sum
into tab2 
from tab1 t
join Persons p on t.PersonId=p.PersonId


select *,
	   Case when (LAG(t.PersonId) over (partition by t.PersonId order by t.PersonId)) =t.PersonId
	   then Sum+ LAG(t.Sum) over (partition by t.PersonId order by t.PersonId) else t.Sum end as total
from tab2 t
order by Name, t.StartDate

drop table tab1
drop table tab2


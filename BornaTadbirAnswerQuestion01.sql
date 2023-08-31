select PersonId, 
       CAST(TransactionDate AS DATE) as StartDate,
	   Sum(Price) as Sum
into tab1
from BuyTransactions
group by CAST(TransactionDate AS DATE), PersonId


select p.PersonId,p.Name,p.Family,t.StartDate,
       Case when  t.StartDate!= LEAD(t.StartDate) over (partition by t.PersonId order by t.PersonId)
            then (LEAD(t.StartDate) Over(partition by t.PersonId order by t.StartDate))
            else Null END
	   as EndDate,
	   t.Sum
into tab2 
from tab1 t
join Persons p on t.PersonId=p.PersonId


select *,
	   Case when (LAG(t.PersonId) over (partition by t.PersonId order by t.PersonId)) =t.PersonId
	   then  sum(t.Sum) over (Partition by t.PersonId order by t.StartDate, t.PersonId) else t.Sum end  as Total
	   into tab3
from tab2 t


select * from tab3 

drop table tab1
drop table tab2
drop table tab3

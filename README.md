Fun-With-DBs
============

Ongoing project with AdventureWorks DB (from MSDN) playing with LINQ, stored procedures, etc (using MVC3).

FwDB Rev 1.1 -- Base (12/17/13)
- Add dataTables() from Jovan P for much nicer looking index.
- Added filter for Department and salary (less or greater than).  Used ViewBag for dropdown.
- Next: I will add another table/data class and filter by view model instead of ViewBag. slh

FwDB Rev 1.0 -- Base (12/14/13)
- Use DB first with EF 4.1 to pull AdventureWorks Employees.
- Implement basic CRUD interface with full details, but abbreviated index.
- Next: Implement dataTables() index display by Jovan P.
- Next Next: Pull a view or stored procedure, work into the interface.  slh

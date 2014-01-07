Fun-With-DBs
============

Ongoing project with AdventureWorks DB (from MSDN) playing with LINQ, stored procedures, etc (using MVC3).

FwDB Rev 1.4 -- Base (1/7/14)
- Added a reset switch to the Filter, as one filter removes other category options
- After 2 filters, can't change anything, and couldn't reset except by going to Home.
- Next: Probably last update here, will go to VS2012 on System 7 next. slh

FwDB Rev 1.3 -- Base (1/5/14)
- Added filtering on the product page by SubCategory and Product Line w/ DropDownLists.
- Wanted to use ViewModel, but hit too many roadblocks with DB First framework/strong typed.
- Didn't want to use ViewBag, so I just put in the View (took a long time to figure out).
- Next: Not so efficient to put DDL's in View, need some type of refresh next. slh

FwDB Rev 1.2 -- Base (12/25/13)
- Added Products model and CRUD i/f with dataTables() for the index.
- Next: Will add some type of filtering based on Subcategory, Cost, or Product Line. slh

FwDB Rev 1.1 -- Base (12/17/13)
- Add dataTables() from Jovan P for much nicer looking index.
- Added filter for Department and salary (less or greater than).  Used ViewBag for dropdown.
- Next: I will add another table/data class and filter by view model instead of ViewBag. slh

FwDB Rev 1.0 -- Base (12/14/13)
- Use DB first with EF 4.1 to pull AdventureWorks Employees.
- Implement basic CRUD interface with full details, but abbreviated index.
- Next: Implement dataTables() index display by Jovan P.
- Next Next: Pull a view or stored procedure, work into the interface.  slh

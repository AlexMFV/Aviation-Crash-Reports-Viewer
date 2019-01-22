# Aviation-Crash-Reports-Viewer
App that gathers information from all reported crashes and incidents in aviation around the world, information gathered from reputable and highly credible sources

## To run the program and use the DB you need:

- SQL Server Express 2017 with LocalDB installed

### To check if you have it installed:

- go to "C:\Program Files\Microsoft SQL Server\"
- and check if you have a folder named **140** and inside that folder you have one called **LocalDB**

### If that doesn't work:
 - If you have another folder like **130**, open ***CMD*** and do the following command (without " "):
    - "cd C:\Program Files\Microsoft SQL Server\130\LocalDB\Binn"
 - Then stop the SQL Service with:
    - SQLLocalDB stop
 - Run both these commands (in order):
    - SqlLocalDB.exe delete "MSSQLLocalDB"
    - SqlLocalDB.exe create "MSSQLLocalDB"

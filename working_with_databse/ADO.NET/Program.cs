using ADO.NET;
//var connectionString = "Server=MY-WEAPON\\SQLEXPRESS;Database=CsharpB20;User Id=csharpb20;Password=123456;Trust Server Certificate = true;";

//SqlUtility sqlUtility = new SqlUtility(connectionString);

////var command = "Insert into Students (name,cgpa,DateOfBirth) values ('akbar',3.2,2002-04-04)";
//var command2 = "Insert into Students (name,cgpa,DateOfBirth) values ('Ali',3.1,'2001-04-04')";

////var effected = sqlUtility.ExecuteCommand(command);
//var effected2 = sqlUtility.ExecuteCommand(command2);
//Console.WriteLine(effected2);

var internsconnectionString = "Server=MY-WEAPON\\SQLEXPRESS;Database=InternsB20;User Id=internsb20;Password=123456;Trust Server Certificate = true;";
Interns interns = new Interns(internsconnectionString);

//var insertCommand = "Insert into Interns(Name,Score) values ('Rayhan',90.5)";
//var affected = interns.ExecuteIUD(insertCommand);
var selectCommand = "SELECT * FROM Interns;";
List<Dictionary<string,object>> Table = interns.ExecuteQuery(selectCommand);
foreach(var columnName in Table[0].Keys)
{
    Console.Write($"{columnName}, ");
}
Console.WriteLine();
for(int i=0;i<Table.Count;i++)
{
    foreach(var column in Table[i])
    {
        Console.Write($"{column.Value}, ");
    }
    Console.WriteLine();
}

//Console.WriteLine(affected);




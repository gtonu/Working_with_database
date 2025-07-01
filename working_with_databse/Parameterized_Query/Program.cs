using Parameterized_Query;

var connectionString = "Server = MY-WEAPON\\SQLEXPRESS; Database = Products; User Id = products; Password = 123456; Trust Server Certificate = true;";
Product product = new Product(connectionString);

//var insertCommand = "Insert into productInformation (productName,price) values ('ps5',55000)";
//int affected = product.ExecuteIUD(insertCommand);
//Console.WriteLine(affected);

//var deleteCommand = "Delete from productInformation where id = 3";
//int affected2 = product.ExecuteIUD(deleteCommand);
//Console.WriteLine(affected2);

//var updateCommand = "Update productInformation Set price = 52000 where productName = 'ps5';";
//int affected3 = product.ExecuteIUD(updateCommand);
//Console.WriteLine(affected3);

string name = Console.ReadLine();
var selectCommand = "Select * from productInformation where productName = @productName;";
Dictionary<string, object> parameters = new Dictionary<string,object>();
parameters.Add("productName", name);
List<Dictionary<string, object>> productInformation = product.ExecuteQuery(selectCommand,parameters);
foreach(var columnName in productInformation[0].Keys)
{
    Console.Write($"{columnName}, ");
}
Console.WriteLine();
foreach(var row in productInformation)
{
    foreach(var column in row)
    {
        Console.Write($"{column.Value}, ");
    }
    Console.WriteLine();
}
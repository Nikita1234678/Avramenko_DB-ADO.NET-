using MySqlConnector;
using MySqlBuilder;

var ConnectinStringBuilder = new MySqlConnectionStringBuilder();
ConnectinStringBuilder.Database = "mywokracademytop";
ConnectinStringBuilder.Server = "db4free.net";
ConnectinStringBuilder.Port = 3306;
ConnectinStringBuilder.UserID = "mywokracademytop";
ConnectinStringBuilder.Password = "mywokracademytop";
var connetionString = ConnectinStringBuilder.ConnectionString;

using (var mySqlConnection= new MySqlConnection(connetionString))
{
    mySqlConnection.Open();
    var command = mySqlConnection.CreateCommand();
    command.CommandType = System.Data.CommandType.Text;
    command.CommandText = @"select * from `workers`";
    var result = command.ExecuteReader();
    foreach (var column in result.GetColumnSchema())
    {
        Console.Write("{0,2}", column.ColumnName);
       
    } 
    Console.WriteLine();

    var isnextdataavailabe = result.HasRows;
    result.Read();
    while (isnextdataavailabe)
    {
        for(var counter = 0; counter < result.FieldCount; counter++)
        {
            
            Console.Write("{0,20}", result.GetValue(counter));
         
        }
        Console.WriteLine();
        isnextdataavailabe=result.Read();
    }
    Console.WriteLine("\n\n");
}


using (var mySqlConnection = new MySqlConnection(connetionString))
{
    mySqlConnection.Open();
    var command = mySqlConnection.CreateCommand();
    command.CommandType = System.Data.CommandType.Text;
    command.CommandText = @"select * from `cars`";
    var result = command.ExecuteReader();
    foreach (var column in result.GetColumnSchema())
    {
        Console.Write("{0,20}", column.ColumnName);
    }
    Console.WriteLine();

    var isnextdataavailabe = result.HasRows;
    result.Read();
    while (isnextdataavailabe)
    {
        for (var counter = 0; counter < result.FieldCount; counter++)
        {

            Console.Write("{0,20}", result.GetValue(counter));
        }
        Console.WriteLine();
        isnextdataavailabe = result.Read();
    }
    Console.WriteLine("\n\n");
}

using (var mySqlConnection = new MySqlConnection(connetionString))
{
    mySqlConnection.Open();
    var command = mySqlConnection.CreateCommand();
    command.CommandType = System.Data.CommandType.Text;
    
    command.CommandText = @"SELECT wa.Name as `accepter`, wr.Name as `repairer`, c.Model as `car model`, o.defect, o.fixed
from `workers` as wa, `cars` as c, `workers` as wr , `orders` as o
where wa.id=o.accepcerId and wr.id=o.repairerId and c.id=o.carId;";
    
    var result = command.ExecuteReader();
    foreach (var column in result.GetColumnSchema())
    {
        Console.Write("{0,25}", column.ColumnName);
    }

    var isnextdataavailabe = result.HasRows;
    
        
    result.Read();
    Console.WriteLine();
    while (isnextdataavailabe)
    {
        
        for (var counter = 0; counter < result.FieldCount; counter++)
        {
            
            
            Console.Write("{0,25}", result.GetValue(counter));
        }
        Console.WriteLine();
        isnextdataavailabe = result.Read();
    }
    Console.WriteLine();
}

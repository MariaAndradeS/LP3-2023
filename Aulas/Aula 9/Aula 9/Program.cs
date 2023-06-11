using Microsoft.Data.Sqlite;
using Aula09DB.Database;
using Aula09DB.Repositories;
using Aula09DB.Models;


var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var computerRepository = new ComputerRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {   
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {   
            Console.WriteLine($"{computer.Id}, {computer.Ram},{computer.Processor}");
        }   
    } 

    if(modelAction == "New")
    {
        Console.WriteLine("Computer New");
        var id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];
        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Computer Show");
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExitsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram},{computer.Processor}");
        }
            else
            {
                Console.WriteLine($"O computador com Id {id} não existe.");
            }

    }

    if(modelAction == "Update")
    {
        Console.WriteLine("Computer Update");
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExitsById(id))
        {
            string ram = args[3];
            string processor = args[4];
            var computer = new Computer(id, ram, processor);
            computerRepository.Update(computer);
        }
            else
            {
                Console.WriteLine($"O computador com Id {id} nãoexiste."); 
            } 
    }
    
    if(modelAction == "Delete")
    {
        Console.WriteLine("Computer Delete");
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExitsById(id))
        {
            computerRepository.Delete(id);
        }
            else
            {
                Console.WriteLine($"O computador com Id {id} não existe.");
            }   
        }
} 


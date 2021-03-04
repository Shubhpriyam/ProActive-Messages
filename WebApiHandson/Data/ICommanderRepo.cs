using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHandson.Models;

namespace WebApiHandson.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandByID(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}

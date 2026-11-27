using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{


    public class PlayerDoesNotExistException : Exception
    {
        public PlayerDoesNotExistException(string message) : base(message)
        {

        }
    }

    public class IncorrectPasswordException : Exception
    {
        public IncorrectPasswordException(string message) : base(message)
        {

        }
    }

    class NotEnoughPlayersException : Exception
    {
        public NotEnoughPlayersException(string message) : base(message)
        {

        }
    }

    public class EmptyRequestException : Exception
    {
        public EmptyRequestException(string message) : base(message)
        {

        }
    }

    public class InvalidNickOrPasException : Exception
    {
        public InvalidNickOrPasException(string message) : base(message)
        {

        }
    }

    public class NotUniqueNickException : Exception
    {
        public NotUniqueNickException(string message) : base(message) { }

    }
}

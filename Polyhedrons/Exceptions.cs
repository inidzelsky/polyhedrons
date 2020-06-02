using System;

namespace Polyhedrons
{
    public class InvalidCoordsOrderException : Exception
    {
        public InvalidCoordsOrderException(string message) :
            base(message)
        {
        }
    }

    public class InvalidVertexesCountException : Exception
    {
        public InvalidVertexesCountException(string message) :
            base(message)
        {
        }
    }

    public class InvalidFigureException : Exception
    {
        public InvalidFigureException(string message) :
            base(message)
        {
        }
    }

    public class InvalidBaseFigureException : Exception
    {
        public InvalidBaseFigureException(string message) :
            base(message)
        {
        }
    }
}
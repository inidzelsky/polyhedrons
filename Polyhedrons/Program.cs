using System.Linq;

namespace Polyhedrons
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase postgresDatabase = new PostgresDatabase();
            IInteractor interactor = new Interactor(postgresDatabase);
            IController controller = new Controller(interactor);

            controller.ShowMainMenu();
        }
    }
}
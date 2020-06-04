using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Controller : IController
    {
        private readonly IInteractor _interactor;

        public Controller(IInteractor interactor)
        {
            _interactor = interactor;
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("Main menu:\n" +
                              "Create a new figure - 1\n" +
                              "Load a figure - 2\n" +
                              "Show polygons count - 3\n" +
                              "Show polyhedrons count - 4\n" +
                              "Show figures count - 5\n" +
                              "Quit - q");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input.ToLower())
            {
                case "1":
                    Console.Clear();
                    CreateFigureMenu();
                    
                    break;

                case "2":
                    Console.Clear();
                    LoadFigureMenu();
                    
                    break;

                case "3":
                    Console.Clear();
                    ConsoleView.ColorizeInfo($"Polygons count : {_interactor.GetPolygonsCount()}");
                    Console.WriteLine();
                    
                    break;

                case "4":
                    Console.Clear();
                    ConsoleView.ColorizeInfo($"Polyhedrons count : {_interactor.GetPolyhedronsCount()}");
                    Console.WriteLine();
                    
                    break;

                case "5":
                    Console.Clear();
                    ConsoleView.ColorizeInfo(
                        $"Figures count : {_interactor.GetPolygonsCount() + _interactor.GetPolyhedronsCount()}");
                    Console.WriteLine();
                    
                    break;

                case "q":
                    return;
            }

            ShowMainMenu();
        }

        private void LoadFigureMenu()
        {
            Console.WriteLine("Load figure menu:\n" +
                              "Load a polygon - 1\n" +
                              "Load a polyhedron - 2\n" +
                              "Back to the main menu - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            string name;
            Figure figure;
            switch (input.ToLower())
            {
                case "1":
                    Console.Write("Enter the figure name : ");
                    name = Console.ReadLine();
                    Console.WriteLine();

                    figure = _interactor.LoadPolygon(name);

                    if (figure is Polygon)
                    {
                        Console.Clear();
                        _interactor.SetFigure(figure);
                        PolygonParamsMenu();
                    }

                    break;

                case "2":
                    Console.Write("Enter the figure name : ");
                    name = Console.ReadLine();
                    Console.WriteLine();

                    figure = _interactor.LoadPolyhedron(name);
                    if (figure is Polyhedron)
                    {
                        Console.Clear();
                        _interactor.SetFigure(figure);
                        PolyhedronParamsMenu();
                    }

                    break;

                case "b":
                    Console.Clear();
                    
                    return;

                default:
                    Console.Clear();
                    LoadFigureMenu();

                    break;
            }

            LoadFigureMenu();
        }

        private void CreateFigureMenu()
        {
            Console.WriteLine("Create figure menu:\n" +
                              "Create a polygon - 1\n" +
                              "Create a polyhedron - 2\n" +
                              "Back to the main menu - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            Console.Clear();
            switch (input.ToLower())
            {
                case "1":
                    PolygonCreationMenu();
                    
                    break;

                case "2":
                    PolyhedronCreationMenu();
                    
                    break;

                case "b":
                    return;

                default:
                    CreateFigureMenu();
                    
                    break;
            }

            CreateFigureMenu();
        }

        private List<Coords> ReadCoords(int amount)
        {
            List<Coords> coords = new List<Coords>();

            try
            {
                for (int i = amount; i > 0; i--)
                {
                    Console.WriteLine("Coords left : {0}", i);

                    Console.WriteLine("Enter coords: ");
                    Console.Write("X = ");
                    int x = Int32.Parse(Console.ReadLine());

                    Console.Write("Y = ");
                    int y = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();

                    coords.Add(new Coords(x, y));

                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                ConsoleView.ColorizeError("Input coords were not in a correct format");
                Console.WriteLine();

                return null;
            }

            return coords;
        }

        private void PolygonCreationMenu()
        {
            Console.WriteLine("Polygon creation menu:\n" +
                              "Choose a polygon to create\n" +
                              "Square - 1\n" +
                              "Rectangle - 2\n" +
                              "Parallelogram - 3\n" +
                              "Triangle - 4\n" + // #TODO Fix triangle exception
                              "Trapeze - 5\n" +
                              "Custom - 6\n" +
                              "Back - b\n");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            Figure figure = null;
            List<Coords> coords = null;

            Console.Clear();
            switch (input)
            {
                case "1":
                    coords = ReadCoords(4);
                    if (coords != null)
                        figure = _interactor.CreatePolygon("square", coords);

                    break;

                case "2":
                    coords = ReadCoords(4);

                    if (coords != null)
                        figure = _interactor.CreatePolygon("rectangle", coords);

                    break;

                case "3":
                    coords = ReadCoords(4);

                    if (coords != null)
                        figure = _interactor.CreatePolygon("parallelogram", coords);
                    
                    break;

                case "4":
                    coords = ReadCoords(3);

                    if (coords != null)
                        figure = _interactor.CreatePolygon("triangle", coords);

                    break;

                case "5":
                    coords = ReadCoords(4);

                    if (coords != null)
                        figure = _interactor.CreatePolygon("trapeze", coords);

                    break;

                case "6":
                    Console.Write("Enter the amount of apexes: ");
                    int amount = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();

                    coords = ReadCoords(amount);

                    if (coords != null)
                        figure = _interactor.CreatePolygon("custom", coords);

                    break;

                case "b":
                    Console.Clear();
                    return;
            }

            if (figure != null)
            {
                Console.Clear();
                _interactor.SetFigure(figure);
                PolygonParamsMenu();
            }
            else
                PolygonCreationMenu();
        }

        private Figure PolyhedronChoosingMenu()
        {
            Console.WriteLine("Polyhedron choosing menu:\n" +
                              "Create from current polygon - 1\n" +
                              "Create from saved polygon - 2\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            Figure figure = null;

            switch (input.ToLower())
            {
                case "1":
                    if (_interactor.GetFigure() is Polygon)
                    {
                        figure = _interactor.GetFigure();
                        Console.Clear();

                        return figure;
                    }

                    Console.Clear();
                    ConsoleView.ColorizeError("There is no current polygon");
                    Console.WriteLine();

                    break;

                case "2":
                    Console.Write("Enter the polygon name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine();

                    Console.Clear();
                    figure = _interactor.LoadPolygon(name);

                    if (figure != null)
                        return figure;

                    break;

                case "b":
                    Console.Clear();
                    
                    return null;
            }

            return PolyhedronChoosingMenu();
        }

        private void PolyhedronCreationMenu()
        {
            Figure polygon = PolyhedronChoosingMenu();

            if (polygon == null || polygon is Polygon == false)
            {
                CreateFigureMenu();
                
                return;
            }

            Console.WriteLine("Polyhedron creation menu:\n" +
                              "Choose a polyhedron to create\n" +
                              "Cube - 1\n" +
                              "Parallelepiped - 2\n" +
                              "Prism - 3\n" +
                              "Pyramid - 4\n" +
                              "Back - b\n");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            Figure figure = null;
            double height = 0;

            switch (input)
            {
                case "1":
                    Console.Clear();

                    figure = _interactor.CreatePolyhedron("cube", (Polygon) polygon);

                    break;

                case "2":
                    Console.Write("Enter the height : ");
                    height = Double.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Clear();

                    figure = _interactor.CreatePolyhedron("parallelepiped", (Polygon) polygon, height);

                    break;

                case "3":
                    Console.Write("Enter the height : ");
                    height = Double.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Clear();

                    figure = _interactor.CreatePolyhedron("prism", (Polygon) polygon, height);

                    break;

                case "4":
                    Console.Write("Enter the height : ");
                    height = Double.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Clear();

                    figure = _interactor.CreatePolyhedron("pyramid", (Polygon) polygon, height);

                    break;

                case "b":
                    Console.Clear();
                    
                    return;
            }

            if (figure != null)
            {
                _interactor.SetFigure(figure);
                PolyhedronParamsMenu();
            }
            else
                PolyhedronCreationMenu(); // #TODO Create a new line
        }

        private void PolygonParamsMenu()
        {
            Console.WriteLine("Polygon parameters menu:\n" +
                              "Perimeter - 1\n" +
                              "Area - 2\n" +
                              "Apexes amount - 3\n" +
                              "Save figure - 4\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Perimeter : {_interactor.GetPerimeter()}");
                        Console.WriteLine();

                        break;

                    case "2":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Area : {_interactor.GetArea()}");
                        Console.WriteLine();
                        
                        break;

                    case "3":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Apexes : {_interactor.GetApexes()}");
                        Console.WriteLine();

                        break;

                    case "4":
                        Console.WriteLine("Enter the figure name : ");
                        string name = Console.ReadLine();
                        Console.Clear();

                        if (_interactor.SavePolygon(name))
                        {
                            ConsoleView.ColorizeInfo("Polygon was successfully saved");
                            Console.WriteLine();
                        }

                        break;

                    case "b":
                        Console.Clear();
                        
                        return;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                ConsoleView.ColorizeError(e.Message);
                Console.WriteLine();
            }

            PolygonParamsMenu();
        }

        private void PolyhedronParamsMenu()
        {
            Console.WriteLine("Polyhedron parameters menu:\n" +
                              "Base area - 1\n" +
                              "Volume - 2\n" +
                              "Apexes amount - 3\n" +
                              "Edges amount - 4\n" +
                              "Brinks amount - 5\n" +
                              "Save polyhedron - 6\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Base area : {_interactor.GetBaseArea()}");
                        Console.WriteLine();

                        break;

                    case "2":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Volume : {_interactor.GetVolume()}");
                        Console.WriteLine();

                        break;

                    case "3":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Apexes : {_interactor.GetApexes()}");
                        Console.WriteLine();

                        break;

                    case "4":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Edges : {_interactor.GetEdges()}");
                        Console.WriteLine();

                        break;

                    case "5":
                        Console.Clear();
                        ConsoleView.ColorizeSuccess($"Brinks : {_interactor.GetBrinks()}");
                        Console.WriteLine();
                        break;

                    case "6":
                        Console.WriteLine("Enter the figure name : ");
                        string name = Console.ReadLine();
                        Console.Clear();

                        if (_interactor.SavePolyhedron(name))
                        {
                            ConsoleView.ColorizeInfo("Polyhedron was successfully saved");
                            Console.WriteLine();
                        }

                        break;

                    case "b":
                        Console.Clear();
                        return;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                ConsoleView.ColorizeError(e.Message);
                Console.WriteLine();
            }

            PolyhedronParamsMenu();
        }
    }
}
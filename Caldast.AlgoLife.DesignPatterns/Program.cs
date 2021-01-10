using Caldast.AlgoLife.DesignPatterns.BuilderPattern;
using Caldast.AlgoLife.DesignPatterns.CommandPattern.Command;
using Caldast.AlgoLife.DesignPatterns.CommandPattern.Invoker;
using Caldast.AlgoLife.DesignPatterns.CommandPattern.Receiver;
using Caldast.AlgoLife.DesignPatterns.CompositePattern;
using Caldast.AlgoLife.DesignPatterns.Iterator;
using Caldast.AlgoLife.DesignPatterns.IteratorPattern;
using Caldast.AlgoLife.DesignPatterns.MVC;
using Caldast.AlgoLife.DesignPatterns.ObserverPattern;
using Caldast.AlgoLife.DesignPatterns.VisitorPattern;
using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //CommandPattern();
            // IteratorPattern();
            //CompositePattern();
            //ObserverPattern();
            //MvcPattern();
            //BuilderPattern();
            //VisitorPattern();
        }

        public static void VisitorPattern()
        {
            Employees employees = new Employees();
            employees.Attach(new Clerk("James Bond"));
            employees.Attach(new Manager("Liam Neeson"));

            employees.Accept(new IncomeVisitor());
            employees.Accept(new VacationVisitor());

           IEnumerable<IEmployee> allEmployees =  employees.GetEmployees();

            foreach (IEmployee employee in allEmployees)
            {
                Console.WriteLine($"Income: {employee.Income}, Vacation: {employee.VacationDays}");
            }
            

        }
        public static void BuilderPattern()
        {
            IHouseBuilder builder = new ConcreteHouseBuilder();
            EngineerDirector director = new EngineerDirector(builder);
            director.Construct();

            HouseProduct house = director.GetHouse();
            Console.WriteLine(house);
        }

        public static void MvcPattern()
        {
          IFlightModel model = new AirplaneFlightModel();
          IFlightController controller = new AirplaneFlightController(model);
       
        }
        public static void ObserverPattern()
        {
            IWeatherSubject weatherData = new WeatherDataSubject();

            IWeatherObserver currentConditionDisplay = new CurrentConditionsDisplayObserver(weatherData);
            IWeatherObserver weatherStatisticsDisplay = new WeatherStatisticsDisplayObserver(weatherData);
            IWeatherObserver simpleForecastDisplay = new SimpleForecastDisplayObserver(weatherData);           

            weatherData.Notify();

            weatherData.UnSubscribe(simpleForecastDisplay);

            weatherData.Notify();

        }

        private static void CommandPattern()
        {
            Light light = new Light();
            LightOnCommand lightCommand = new LightOnCommand(light);
            RemoteControl remoteControl = new RemoteControl();
            remoteControl.SetCommand(lightCommand);

            Garage garage = new Garage();
            GarageOnCommand garageCommand = new GarageOnCommand(garage);
            remoteControl.SetCommand(garageCommand);

            GarageOffCommand garageOffCommand = new GarageOffCommand(garage);

            remoteControl.SetCommand(garageOffCommand);

            LightOffCommand lightOffCommand = new LightOffCommand(light);
            remoteControl.SetCommand(lightOffCommand);

            remoteControl.Do();
            remoteControl.Do();
            remoteControl.Undo();
            remoteControl.Undo();

            remoteControl.PrintHistory();


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void IteratorPattern()
        {

            Waiter waiter = new Waiter(new BreakfastMenu(), new DinnerMenu());
            Console.WriteLine("--breakfast menu--");
            waiter.PrintBreakfastMenu();
            Console.WriteLine("--dinner menu--");
            waiter.PrintDinnerMenu();
        }
        private static void CompositePattern()
        {

            CMenuComponent menu = new CMenu("Taaj Restaurant Menu", "Indian food menu for Taaj");

            CMenuComponent dinnerMenu = new CMenu("Dinner Menu", "Indian food dinner menu");            
            dinnerMenu.Add(new CMenuItem("Chicken Tikka", 10.99));
            dinnerMenu.Add(new CMenuItem("Veg Butter Naan", 5.99));

           
            CMenuComponent lunchMenu = new CMenu("Lunch Menu", "Indian food lunch menu");
            lunchMenu.Add(new CMenuItem("Eggplant curry", 7.99));

            menu.Add(dinnerMenu);
            menu.Add(lunchMenu);

            CWaiter cWaiter = new CWaiter(menu);
            cWaiter.Print();

        }
    }
}

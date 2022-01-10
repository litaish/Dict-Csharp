using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    public class Car
    {
        public string name;
        public double engineDisplacement;
        public Car(string name, double engineDisplacement)
        {
            this.name = name;
            this.engineDisplacement = engineDisplacement;
        }
        public Car()
        {

        }
    }
    class Program
    {
        public static void AddCar(Dictionary<string, Car> cars)
        {
            Console.WriteLine("How many cars to add? ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter car {0} key:", i + 1);
                string key = Console.ReadLine();
                Console.WriteLine("Enter car {0} name: ", i + 1);
                string carName = Console.ReadLine();
                Console.WriteLine("Enter car {0} engine displacement (Liter): ", i + 1);
                double engineDisplacement = Convert.ToDouble(Console.ReadLine());
                cars.Add(key, new Car(carName, engineDisplacement));
            }
        }
        public static void DisplayCars(Dictionary<string, Car> cars)
        {
            foreach (KeyValuePair<string, Car> item in cars) //displaying key with value of dictionary
            {
                Console.WriteLine("Key: {0}, Car name: {1}, Engine displacement: {2}", item.Key, item.Value.name, item.Value.engineDisplacement);
            }
        }
        public static void DeleteByKey(Dictionary<string, Car> cars)
        {
            Console.WriteLine("Enter key of car you would like to delete (string): ");
            string keyToDelete = Console.ReadLine();
            if (cars.ContainsKey(keyToDelete))
            {
                cars.Remove(keyToDelete);
                Console.WriteLine("Car with key {0} removed!", keyToDelete);
            }
            else
            {
                Console.WriteLine("No such key found!");
            }
        }
        public static void CopyKey(Dictionary<string, Car> cars)
        {
            Console.WriteLine("Copying all keys to List<string> keyCars..");
            List<string> keyCars = new List<string>(cars.Keys); //saving all keys in a string List
            Console.WriteLine("List keys:\n");
            foreach (var item in keyCars)
            {
                Console.WriteLine(item); //displaying each key in key list
            }
            Console.WriteLine();
        }
        public static void CopyCar(Dictionary<string, Car> cars)
        {
            Console.WriteLine("Copying all cars to List<Car> valueCars..");
            List<Car> valueCars = new List<Car>(cars.Values); //saving all car info in car object list
            Console.WriteLine("List cars:\n");
            foreach (var item in valueCars)
            {
                Console.WriteLine("Car name: {0}, Engine Displacement: {1}", item.name, item.engineDisplacement);
            }
            Console.WriteLine();
        }
        public static void InfoByKey(Dictionary<string, Car> cars)
        {
            Console.WriteLine("Enter key to search by: ");
            string keyToSearch = Console.ReadLine();
            if (cars.ContainsKey(keyToSearch))
            {
                Console.WriteLine("Key found!");
                Car foundCar = new Car();
                foundCar = cars[keyToSearch];
                Console.WriteLine("Car name: {0}, Engine displacement: {1}", foundCar.name, foundCar.engineDisplacement);
            }
            else
            {
                Console.WriteLine("No such key found!");
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            Console.WriteLine("MENU");
            Console.WriteLine("=====================");
            int choice = 0;
            do
            {
                Console.WriteLine("Choose your action: \n\n[1] Add a new car to dictionary\n[2] Display car dictionary\n[3] Delete a car by its key\n[4] Copy dictionary keys to List\n[5] Copy dictionary values (cars) to List\n[6] Get car info by key\n[7] Clear List\n[8] Exit");
                Console.WriteLine("");
                int userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (userInput)
                {
                    case 1:
                        AddCar(cars);
                        break;
                    case 2:
                        DisplayCars(cars);
                        break;
                    case 3:
                        DeleteByKey(cars);
                        break;
                    case 4:
                        CopyKey(cars);
                        break;
                    case 5:
                        CopyCar(cars);
                        break;
                    case 6:
                        InfoByKey(cars);
                        break;
                    case 7:
                        cars.Clear();
                        Console.Clear();
                        Console.WriteLine("List cleared!");
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Theres no such choice");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 8);
        }
    }
}

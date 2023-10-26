using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
// класс Vehicle
public abstract class Vehicle
{
    private int speed;
    private int capacity;

    protected Vehicle(int speed, int capacity)
    {
        this.speed = speed;
        this.capacity = capacity;
    }
}

public int Speed { get; set; }
public int Capacity { get; set; }

public static Vehicle (int speed, int capacity)
{
    int Speed = speed;
    capacity = capacity;
}

public abstract void Move();
}
public class Human
{
    public int Speed { get; set; }

    public Human(int speed)
    {
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine("The person is moving");
    }
}

public class Bus : Vehicle
{
    public Bus(int speed, int capacity) : base(speed, capacity) { }

    public override void Move() => Console.WriteLine("The bus is driving");
}

public class Train : Vehicle
{
    public Train(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("The train is running");
    }
}

public class Route
{
    public string Start { get; set; }
    public string End { get; set; }

    public Route(string start, string end)
    {
        Start = start;
        End = end;
    }
}

public class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void CalculateOptimalRoute(Vehicle vehicle, Route route)
    {
        if (vehicle is Car)
        {
            Console.WriteLine($"Calculating optimal route for Car from {route.Start} to {route.End}");
        }
        else if (vehicle is Bus)
        {
            Console.WriteLine($"Calculating optimal route for Bus from {route.Start} to {route.End}");
        }
        else if (vehicle is Train)
        {
            Console.WriteLine($"Calculating optimal route for Train from {route.Start} to {route.End}");
        }
    }

    public void HandlePassengers(Vehicle vehicle, Route route)
    {
        if (vehicle is Car)
        {
            Console.WriteLine("Handling passengers in Car");
        }
        else if (vehicle is Bus)
        {
            Console.WriteLine("Handling passengers in Bus");
        }
        else if (vehicle is Train)
        {
            Console.WriteLine("Handling passengers in Train");
        }
    }
}

internal class Car : Vehicle
{
    public Car(int speed, int capacity) : base(speed, capacity)
    {
    }
}

static void Main()
{
    Car car = new Car(speed: 50, capacity: 3);
    Bus bus = new Bus(speed: 30, capacity: 30);
    Train train = new Train(speed: 150, capacity: 250);

    Human human = new Human(speed: 5);

    Route route = new Route(start: "A", end: "B");

    TransportNetwork network = new TransportNetwork();
    network.AddVehicle(car);
    network.AddVehicle(bus);
    network.AddVehicle(train);

    foreach (var vehicle in network.Vehicles)
    {
        vehicle.Move();
        network.CalculateOptimalRoute(vehicle, route);
        network.HandlePassengers(vehicle, route);
    }

    human.Move();
}
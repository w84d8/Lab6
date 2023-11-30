using System.Security.Cryptography;

class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void PlanRoute(Route route, Vehicle vehicle)
    {
        Console.WriteLine($"Planning route from {route.StartPoint} to {route.EndPoint} for {vehicle.GetType().Name}.");

    }

    public void TransportPassengers(Human passenger, Vehicle vehicle)
    {
        if (vehicle.Capacity > 0)
        {
            Console.WriteLine($"Passenger boards the {vehicle.GetType().Name}.");
            vehicle.Capacity--;
        }
        else
        {
            Console.WriteLine($"The {vehicle.GetType().Name} is full. Unable to board more passengers.");
        }
    }

    public void DisembarkPassengers(Human passenger, Vehicle vehicle)
    {
        Console.WriteLine($"Passenger disembarks from the {vehicle.GetType().Name}.");
        vehicle.Capacity++;
    }
}
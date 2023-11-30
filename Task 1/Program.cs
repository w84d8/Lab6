using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        Car car = new Car();
        Bus bus = new Bus();
        Train train = new Train();

        Human passenger = new Human();

        TransportNetwork network = new TransportNetwork();
        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        Route carRoute = new Route("A", "B");
        Route busRoute = new Route("X", "Y");
        Route trainRoute = new Route("P", "Q");

        network.PlanRoute(carRoute, car);
        network.PlanRoute(busRoute, bus);
        network.PlanRoute(trainRoute, train);

        network.TransportPassengers(passenger, car);
        network.TransportPassengers(passenger, bus);
        network.TransportPassengers(passenger, train);

        network.DisembarkPassengers(passenger, car);
        network.DisembarkPassengers(passenger, bus);
        network.DisembarkPassengers(passenger, train);
    }
}
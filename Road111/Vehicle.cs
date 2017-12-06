using System;
using System.Collections.Generic;
namespace Road111
{
    public class Vehicle
    {
        protected String type;
        protected static Fuel fuel;
        // protected List<Fuel> fuel;
        protected static List<Strip> stripType = new List<Strip>();
        //protected bool[3] stripType;
        //protected Strip strip;
        protected double maxSpeed;
        protected double speed;
        protected double distance;

        //---------------------------Constructors---------------------------------------
        public Vehicle()
        { }
        //---------------------------Get/Set--------------------------------------------
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public static Fuel Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public double MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public static List<Strip> stripList()
        {
            return stripType;
        }
    }

    public class Car : Vehicle
    {
        //String type = "Passenger";
        double amountFuel;
        String brand;
        int nWheels;
        double maxDist;

        //---------------------------Constructors---------------------------------------
        public Car()
        {
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 180.0;
            speed = 0.0;
            amountFuel = 0.0;
            distance = 0.0;
            brand = "Ford";
            nWheels = 4;
            maxDist = 800;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountOfFuel { get { return amountFuel; } }
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
    }

    public class Moto : Vehicle
    {
        //String type = "Passenger";
        double amountFuel;
        String brand;
        int nWheels;
        double maxDist;

        //---------------------------Constructors---------------------------------------
        public Moto()
        {
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 250.0;
            speed = 0.0;
            amountFuel = 0.0;
            distance = 0.0;
            brand = "Kawasaki";
            nWheels = 2;
            maxDist = 500;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountOfFuel { get { return amountFuel; } }
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
    }

    public class Truck : Vehicle
    {
        //String type = "Cargo";
        double amountFuel;
        String brand;
        int nWheels;
        double maxDist;
        double carrying;

        //---------------------------Constructors---------------------------------------
        public Truck()
        {
            type = "Cargo";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 180.0;
            speed = 0.0;
            amountFuel = 0.0;
            distance = 0.0;
            brand = "MAN";
            nWheels = 6;
            maxDist = 1000;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountOfFuel { get { return amountFuel; } }
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
        public double Carrying { get { return carrying; } }
    }

    public class Loader : Vehicle
    {
        //String type = "Cargo";
        double amountFuel;
        String brand;
        int nWheels;
        double maxDist;
        double carrying;

        //---------------------------Constructors---------------------------------------
        public Loader()
        {
            type = "Cargo";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 90.0;
            speed = 0.0;
            amountFuel = 0.0;
            distance = 0.0;
            brand = "CAT";
            nWheels = 4;
            maxDist = 200;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountOfFuel { get { return amountFuel; } }
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
        public double Carrying { get { return carrying; } }
    }

    public class Bus : Vehicle
    {
        //String type = "Public";
        double amountFuel;
        String brand;
        int nWheels;
        double maxDist;
        int passengers;
        int maxPassengers;

        //---------------------------Constructors---------------------------------------
        public Bus()
        {
            type = "Public";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 150.0;
            speed = 0.0;
            amountFuel = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 6;
            maxDist = 500;
            passengers = 0;
            maxPassengers = 50;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountOfFuel { get { return amountFuel; } }
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
    }

    public class Trolleybus : Vehicle
    {
        //String type = "Public";
        String brand;
        int nWheels;
        int passengers;
        int maxPassengers;

        //---------------------------Constructors---------------------------------------
        public Trolleybus()
        {
            type = "Public";
            stripType.Add(new Strip("Электро"));
            //stripType[] = { 1, 1, 1 };
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 150.0;
            speed = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 6;
            passengers = 0;
            maxPassengers = 50;
        }
        //---------------------------Get/Set--------------------------------------------
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
    }

    public class Tram : Vehicle
    {
        //String type = "Public";
        String brand;
        int nWheels;
        int passengers;
        int maxPassengers;

        //---------------------------Constructors---------------------------------------
        public Tram()
        {
            type = "Public";
            stripType.Add(new Strip("Рельсы"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 100.0;
            speed = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 8;
        }
        //---------------------------Get/Set--------------------------------------------
        public String Brand { get { return brand; } }
        public int N_Wheels { get { return nWheels; } }
        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
    }

    public class Horse : Vehicle
    {
        //String type = "Public";
        int nWheels;
        double carrying;

        //---------------------------Constructors---------------------------------------
        public Horse()
        {
            type = "Cargo";
            //stripType[] = { 1, 1, 1 };
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 150.0;
            speed = 0.0;
            distance = 0.0;
            nWheels = 6;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double Carrying { get { return carrying; } }
    }

}

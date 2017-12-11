using System;
using System.Collections.Generic;
namespace Road111
{
    public class Vehicle
    {
        protected String type;
        protected String name;
        protected String brand;
        protected  Fuel fuel;
        protected List<Fuel> fuelType = new List<Fuel>();
        protected  List<Strip> stripType = new List<Strip>();
        //protected bool[3] stripType;
        protected Strip strip;
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
        public String Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public  Fuel Fuel
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
        public List<Strip> stripList()
        {
            return stripType;
        }
        public List<Fuel> FuelList()
        {
            return fuelType;
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public Strip Strip
        {
            get { return strip; }
            set { strip = value; }
        }

    }

    public class Car : Vehicle
    {
        //String type = "Passenger";
        int nWheels;
        double maxDist;
        double amoutFuel;
        double rashodF;
        int passengers;
        //---------------------------Constructors---------------------------------------
        public Car()
        {
            name = "Автомобиль";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            fuelType.Add(new Fuel("Электричество"));
            fuelType.Add(new Fuel("Газ"));
            fuel = new Fuel("Бензин");
            maxSpeed = 180.0;
            speed = 0.0;
            amoutFuel = 0.0;
            distance = 0.0;
            brand = "Ford";
            nWheels = 4;
            maxDist = 800;
        }
        public Car(double maxSp, double sp,double amFuel,double rashod,int pass,String _brand )
        {
            name = "Автомобиль";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            fuelType.Add(new Fuel("Электричество"));
            fuelType.Add(new Fuel("Газ"));
            fuel = new Fuel("Бензин");
            maxSpeed = maxSp;
            speed = sp;
            amoutFuel = amFuel;
            rashodF = rashod;
            distance = 0.0;
            brand = _brand;
            nWheels = 4;
            passengers = pass;
            maxDist = amoutFuel * 100 / rashodF;
        }
       
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
        public int Pass
        {
            get { return passengers; }
            set { passengers = value; }  
        }
        public double amFuel
        {
            get { return amoutFuel; }
            set { amoutFuel = value; }
        }
        public double rasF
        {
            get { return rashodF; }
            set { rashodF = value; }
        }
    }

    public class Moto : Vehicle
    {
        //String type = "Passenger";
        double amoutFuel;
        double rashodF;
        int nWheels;
        double maxDist;

        //---------------------------Constructors---------------------------------------
        public Moto()
        {
            name = "Мотоцикл";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuelType.Add(new Fuel("Бензин"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 250.0;
            speed = 0.0;
            amoutFuel = 0.0;
            distance = 0.0;
            brand = "Kawasaki";
            nWheels = 2;
            maxDist = 500;
        }
        public Moto(double maxSp, double sp, double amFuel, double rashod, String _brand)
        {
            name = "Мотоцикл";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuelType.Add(new Fuel("Бензин"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            amoutFuel = amFuel;
            rashodF = rashod;
            distance = amoutFuel * 100 / rashodF;;
            brand = _brand;
            nWheels = 2;
            maxDist = amoutFuel * 100 / rashodF;
        }
        public double amFuel
        {
            get { return amoutFuel; }
            set { amoutFuel = value; }
        }
        public double rasF
        {
            get { return rashodF; }
            set { rashodF = value; }
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
    }

    public class Truck : Vehicle
    {
        //String type = "Cargo";
        int nWheels;
        double maxDist;
        double carrying;
        double amoutFuel;
        double rashodF;

        //---------------------------Constructors---------------------------------------
        public Truck()
        {
            name = "Грузовик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 180.0;
            speed = 0.0;
            amoutFuel = 0.0;
            distance = 0.0;
            brand = "MAN";
            nWheels = 6;
            maxDist = 1000;
        }
        public Truck(double maxSp, double sp, double amFuel, double rashod, String _brand,double carr)
        {
            name = "Грузовик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            amoutFuel = amFuel;
            distance = rashod;
            brand = _brand;
            nWheels = 6;
            maxDist = amoutFuel * 100 / rashodF;
            carrying = carr;
        }
        //---------------------------Get/Set--------------------------------------------
        public double amFuel
        {
            get { return amoutFuel; }
            set { amoutFuel = value; }
        }
        public double rasF
        {
            get { return rashodF; }
            set { rashodF = value; }
        }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
        public double Carrying { get { return carrying; } }
    }

    public class Loader : Vehicle
    {
        //String type = "Cargo";
        double amoutFuel;
        double rashodF;
        int nWheels;
        double maxDist;
        double carrying;
        //---------------------------Constructors---------------------------------------
        public Loader()
        {
            name = "Погрузчик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 90.0;
            speed = 0.0;
            amoutFuel = 0.0;
            distance = 0.0;
            brand = "CAT";
            nWheels = 4;
            maxDist = 200;
        }
        public Loader(double maxSp, double sp, double amFuel, double rashod, String _brand, double carr)
        {
            name = "Погрузчик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            amoutFuel = amFuel;
            rashodF = rashod;
            distance = 0.0;
            brand = _brand;
            nWheels = 4;
            maxDist = amoutFuel * 100 / rashodF;
            carrying = carr;
        }
        //---------------------------Get/Set--------------------------------------------
        public double amFuel
        {
            get { return amoutFuel; }
            set { amoutFuel = value; }
        }
        public double rasF
        {
            get { return rashodF; }
            set { rashodF = value; }
        }
        public int N_Wheels { get { return nWheels; } }
        public double Dist
        { get { return maxDist; } }
        public double Carrying { get { return carrying; } }
    }

    public class Bus : Vehicle
    {
        //String type = "Public"
        int nWheels;
        double maxDist;
        int passengers;
        int maxPassengers;
        double amoutFuel;
        double rashodF;

        //---------------------------Constructors---------------------------------------
        public Bus()
        {
            name = "Автобус";
            type = "Public";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            fuelType.Add(new Fuel("Электричество"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 150.0;
            speed = 0.0;
            amoutFuel = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 6;
            maxDist = 500;
            passengers = 0;
            maxPassengers = 50;
        }
        public Bus(double maxSp, double sp, double amFuel, double rashod, int pass,String _brand)
        {
            name = "Автобус";
            type = "Public";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            fuelType.Add(new Fuel("Электричество"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            amoutFuel = amFuel;
            rashodF = rashod;
            distance = 0.0;
            brand = _brand;
            nWheels = 6;
            maxDist = amoutFuel * 100 / rashodF;
            passengers = pass;
            maxPassengers = 50;
        }
        //---------------------------Get/Set--------------------------------------------
        public double amFuel
        {
            get { return amoutFuel; }
            set { amoutFuel = value; }
        }
        public double rasF
        {
            get { return rashodF; }
            set { rashodF = value; }
        }
        public int N_Wheels { get { return nWheels; } }
        public double Dist { get { return maxDist; } }
        public int Pass
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
    }

    public class Trolleybus : Vehicle
    {
        //String type = "Public";
        int nWheels;
        int passengers;
        int maxPassengers;

        //---------------------------Constructors---------------------------------------
        public Trolleybus()
        {
            name = "Троллейбус";
            type = "Public";
            fuelType.Add(new Fuel("Электричество"));
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
        public Trolleybus(double maxSp, double sp, int pass, String _brand)
        {
            name = "Троллейбус";
            type = "Public";
            fuelType.Add(new Fuel("Электричество"));
            stripType.Add(new Strip("Электро"));
            //stripType[] = { 1, 1, 1 };
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            distance = 0.0;
            brand = _brand;
            nWheels = 6;
            passengers = pass;
            maxPassengers = 50;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public int Pass
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
    }

    public class Tram : Vehicle
    {
        //String type = "Public";
        int nWheels;
        int passengers;
        int maxPassengers;

        //---------------------------Constructors---------------------------------------
        public Tram()
        {
            name = "Трамвай";
            type = "Public";
            stripType.Add(new Strip("Рельсы"));
            fuelType.Add(new Fuel("Электричество"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 100.0;
            speed = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 8;
        }
        public Tram(double maxSp, double sp, int pass, String _brand)
        {
            name = "Трамвай";
            type = "Public";
            stripType.Add(new Strip("Рельсы"));
            fuelType.Add(new Fuel("Электричество"));
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            distance = 0.0;
            brand = _brand;
            nWheels = 8;
            passengers = pass;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public int Pass
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
            name = "Гужевая повозка";
            type = "Cargo";
            //stripType[] = { 1, 1, 1 };
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = 150.0;
            speed = 0.0;
            distance = 0.0;
            nWheels = 6;
        }
        public Horse(double maxSp, double sp, String _brand, double carr)
        {
            name = "Гужевая повозка";
            type = "Cargo";
            //stripType[] = { 1, 1, 1 };
            //fuel = new Fuel("Бензин");
            //strip = strip[0];
            maxSpeed = maxSp;
            speed = sp;
            distance = 0.0;
            nWheels = 6;
            carrying = carr;
            brand =_brand;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double Carrying { get { return carrying; } }
    }

}

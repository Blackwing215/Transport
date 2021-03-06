using System;
using System.Collections.Generic;
using Cairo;

namespace Road111
{
    public class Vehicle
    {
        protected String type;
        protected String name;
        protected String brand;
        protected Fuel fuel;
        protected List<Fuel> fuelType = new List<Fuel>();
        protected List<Strip> stripType = new List<Strip>();
        protected Strip strip;
        protected double maxSpeed;
        protected double speed;
		protected double startSpeed;
        protected double distance;
        protected int stop_counter = 0;//количество записей в журнал
		protected ImageSurface image;
        //---------------------------Constructors---------------------------------------
        public Vehicle()
        { }
        //---------------------------Get/Set--------------------------------------------
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Stop_C
        {
            get { return stop_counter; }
            set { stop_counter = value; }
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
		public double StartSpeed
		{
			get { return startSpeed; }
			set { startSpeed = value; }
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
		public ImageSurface Image
		{
			get { return image; }
		}
    }

    public class Car : Vehicle
    {
        int nWheels;
        double maxDist;
		double amountFuel;
		double consFuel;
        int passengers;
		bool lights;
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
			startSpeed = 0.0;
            amountFuel = 0.0;
			consFuel = 0.0;
            distance = 0.0;
            brand = "Ford";
            nWheels = 4;
            maxDist = 0;
			image = new ImageSurface("pictures\\Car.png");
			lights = false;
        }
		public Car(double maxSp, double sp,double amFuel,double consF,int pass,String _brand )
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
			startSpeed = sp;
			speed = sp+0.1;
            amountFuel = amFuel;
			consFuel = consF != 0 ? consF : 1;
            distance = 0.0;
            brand = _brand;
            nWheels = 4;
            passengers = pass;
            maxDist = amountFuel * 100 / consFuel;
			image = new ImageSurface("pictures\\Car.png");
			lights = false;
        }
       
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double MaxDist { get { return maxDist; } }
        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }  
        }
       	public double AmountFuel
		{
			get { return amountFuel; }
			set { amountFuel = value; }
		}
		public double ConsFuel { get { return consFuel; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }

    public class Moto : Vehicle
    {
		double amountFuel;
		double consFuel;
        int nWheels;
        double maxDist;
		bool lights;
        //---------------------------Constructors---------------------------------------
        public Moto()
        {
            name = "Мотоцикл";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuelType.Add(new Fuel("Бензин"));
			fuelType.Add(new Fuel("Электричество"));
            maxSpeed = 250.0;
            speed = 0.0;
			startSpeed = 0.0;
            amountFuel = 0.0;
			consFuel = 0.0;
            distance = 0.0;
            brand = "Kawasaki";
            nWheels = 2;
            maxDist = 0;
			image = new ImageSurface("pictures\\Moto.png");
			lights = false;
        }
		public Moto(double maxSp, double sp, double amFuel, double consF, String _brand)
        {
            name = "Мотоцикл";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            fuelType.Add(new Fuel("Бензин"));
			fuelType.Add(new Fuel("Электричество"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            amountFuel = amFuel;
			consFuel = consF != 0 ? consF : 1;
            distance = 0.0;
            brand = _brand;
            nWheels = 2;
            maxDist = amountFuel * 100 / consFuel;
			image = new ImageSurface("pictures\\Moto.png");
			lights = false;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double MaxDist { get { return maxDist; } }
		public double AmountFuel
		{
			get { return amountFuel; }
			set { amountFuel = value; }
		}
		public double ConsFuel { get { return consFuel; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }

    public class Truck : Vehicle
    {
        int nWheels;
        double maxDist;
        double carrying;
		double amountFuel;
		double consFuel;
		bool lights;
        //---------------------------Constructors---------------------------------------
        public Truck()
        {
            name = "Грузовик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = 180.0;
            speed = 0.0;
			startSpeed = 0.0;
            amountFuel = 0.0;
			consFuel = 0.0;
            distance = 0.0;
            brand = "MAN";
            nWheels = 6;
            maxDist = 0;
			carrying = 0;
			image = new ImageSurface("pictures\\Truck.png");
			lights = false;
        }
		public Truck(double maxSp, double sp, double amFuel, double consF, String _brand,double carr)
        {
            name = "Грузовик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            amountFuel = amFuel;
			consFuel = consF != 0 ? consF : 1;
            distance = 0;
            brand = _brand;
            nWheels = 6;
            maxDist = amountFuel * 100 / consFuel;
            carrying = carr;
			image = new ImageSurface("pictures\\Truck.png");
			lights = false;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountFuel
		{
			get { return amountFuel; }
			set { amountFuel = value; }
		}
		public double ConsFuel { get { return consFuel; } }
        public int N_Wheels { get { return nWheels; } }
        public double MaxDist { get { return maxDist; } }
        public double Carrying { get { return carrying; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }

    public class Loader : Vehicle
    {
		double amountFuel;
		double consFuel;
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
            maxSpeed = 90.0;
            speed = 0.0;
			startSpeed = 0.0;
            amountFuel = 0.0;
            consFuel = 0.0;
            distance = 0.0;
            brand = "CAT";
            nWheels = 4;
            maxDist = 0;
			carrying = 0;
			image = new ImageSurface("pictures\\Loader.png");
        }
		public Loader(double maxSp, double sp, double amFuel, double consF, String _brand, double carr)
        {
            name = "Погрузчик";
            type = "Cargo";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            amountFuel = amFuel;
			consFuel = consF != 0 ? consF : 1;
            distance = 0.0;
            brand = _brand;
            nWheels = 4;
            maxDist = amountFuel * 100 / consFuel;
            carrying = carr;
			image = new ImageSurface("pictures\\Loader.png");
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountFuel
        {
            get { return amountFuel; }
            set { amountFuel = value; }
        }
        public double ConsFuel { get { return consFuel; } }
        public int N_Wheels { get { return nWheels; } }
        public double MaxDist { get { return maxDist; } }
        public double Carrying { get { return carrying; } }
    }

    public class Bus : Vehicle
    {
        int nWheels;
        double maxDist;
        int passengers;
        int maxPassengers;
		double amountFuel;
        double consFuel;
		bool lights;
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
            maxSpeed = 150.0;
            speed = 0.0;
			startSpeed = 0.0;
            amountFuel = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 6;
            maxDist = 0;
            passengers = 0;
            maxPassengers = 50;
			image = new ImageSurface("pictures\\Bus.png");
			lights = false;
        }
		public Bus(double maxSp, double sp, double amFuel, double consF, int pass,String _brand)
        {
            name = "Автобус";
            type = "Public";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            fuelType.Add(new Fuel("Электричество"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            amountFuel = amFuel;
			consFuel = consF != 0 ? consF : 1;
            distance = 0.0;
            brand = _brand;
            nWheels = 6;
            maxDist = amountFuel * 100 / consFuel;
            passengers = pass;
            maxPassengers = pass;
			image = new ImageSurface("pictures\\Bus.png");
			lights = false;
        }
        //---------------------------Get/Set--------------------------------------------
        public double AmountFuel
		{
			get { return amountFuel; }
			set { amountFuel = value; }
		}
		public double ConsFuel { get { return consFuel; } }
        public int N_Wheels { get { return nWheels; } }
        public double MaxDist { get { return maxDist; } }
		public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }

    public class Trolleybus : Vehicle
    {
        int nWheels;
        int passengers;
        int maxPassengers;
		bool lights;
        //---------------------------Constructors---------------------------------------
        public Trolleybus()
        {
            name = "Троллейбус";
            type = "Public";
            fuelType.Add(new Fuel("Электричество"));
            stripType.Add(new Strip("Электро"));
            maxSpeed = 150.0;
            speed = 0.0;
			startSpeed = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 6;
            passengers = 0;
            maxPassengers = 50;
			image = new ImageSurface("pictures\\Trolley.png");
			lights = false;
        }
        public Trolleybus(double maxSp, double sp, int pass, String _brand)
        {
            name = "Троллейбус";
            type = "Public";
            fuelType.Add(new Fuel("Электричество"));
            stripType.Add(new Strip("Электро"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            distance = 0.0;
            brand = _brand;
            nWheels = 6;
            passengers = pass;
            maxPassengers = pass;
			image = new ImageSurface("pictures\\Trolley.png");
			lights = false;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }

    public class Tram : Vehicle
    {
        int nWheels;
        int passengers;
        int maxPassengers;
		bool lights;
        //---------------------------Constructors---------------------------------------
        public Tram()
        {
            name = "Трамвай";
            type = "Public";
            stripType.Add(new Strip("Рельсы"));
            fuelType.Add(new Fuel("Электричество"));
            maxSpeed = 100.0;
            speed = 0.0;
			startSpeed = 0.0;
            distance = 0.0;
            brand = "MAZ";
            nWheels = 8;
			passengers = 0;
			maxPassengers = 0;
			image = new ImageSurface("pictures\\Tram.png");
			lights = false;
        }
        public Tram(double maxSp, double sp, int pass, String _brand)
        {
            name = "Трамвай";
            type = "Public";
            stripType.Add(new Strip("Рельсы"));
            fuelType.Add(new Fuel("Электричество"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            distance = 0.0;
            brand = _brand;
            nWheels = 8;
            passengers = pass;
			maxPassengers = pass;
			image = new ImageSurface("pictures\\Tram.png");
			lights = false;
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public int MaxPassengers { get { return maxPassengers; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }

    public class Horse : Vehicle
    {
        int nWheels;
        double carrying;

        //---------------------------Constructors---------------------------------------
        public Horse()
        {
            name = "Гужевая повозка";
            type = "Cargo";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = 150.0;
            speed = 0.0;
			startSpeed = 0.0;
            distance = 0.0;
            nWheels = 6;
			image = new ImageSurface("pictures\\Horse.png");
        }
        public Horse(double maxSp, double sp, String _brand, double carr)
        {
            name = "Гужевая повозка";
            type = "Cargo";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            distance = 0.0;
            nWheels = 6;
            carrying = carr;
            brand =_brand;
			image = new ImageSurface("pictures\\Horse.png");
        }
        //---------------------------Get/Set--------------------------------------------
        public int N_Wheels { get { return nWheels; } }
        public double Carrying { get { return carrying; } }
    }
    public class Bike: Vehicle
    {
        public Bike()
        {
            name = "Велосипед";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = 50.0;
			speed = 0.0;
			startSpeed = 0.0;
			image = new ImageSurface("pictures\\Bike.png");
        }
        public Bike(double maxSp, double sp, String _brand)
        {
            name = "Велосипед";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            brand = _brand;
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
			image = new ImageSurface("pictures\\Bike.png");
        }
    }
    public class Kscooter: Vehicle
    {
        public Kscooter()
        {
            name = "Самокат";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = 50.0;
			speed = 0.0;
			startSpeed = 0.0;
			image = new ImageSurface("pictures\\Kick.png");
        }
        public Kscooter(double maxSp, double sp, String _brand)
        {
            name = "Самокат";
            type = "Passenger";
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            brand = _brand;
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
			image = new ImageSurface("pictures\\Kick.png");
        }
    }
    public class Tank: Vehicle
    {
        double amountFuel;
		double consFuel;
        double maxDist;
		bool lights;
		public Tank()
		{
			name = "Танк";
			type = "Passenger";
			fuelType.Add(new Fuel("Бензин"));
			fuelType.Add(new Fuel("Дизель"));
			stripType.Add(new Strip("Электро"));
			stripType.Add(new Strip("Обычная"));
			maxSpeed = 60;
			speed = 0.0;
			startSpeed = 0.0;
			amountFuel = 0.0;
			consFuel = 0.0;
			distance = 0.0;
			brand = "M60";
			maxDist = amountFuel * 100 / consFuel;
			image = new ImageSurface("pictures\\Tank.png");
			lights = false;
		}
		public Tank(double maxSp, double sp, double amFuel, double consF, int pass, String _brand)
        {
            name = "Танк";
            type = "Passenger";
            fuelType.Add(new Fuel("Бензин"));
            fuelType.Add(new Fuel("Дизель"));
            stripType.Add(new Strip("Электро"));
            stripType.Add(new Strip("Обычная"));
            maxSpeed = maxSp;
			startSpeed = sp;
			speed = sp;
            amountFuel = amFuel;
			consFuel = consF != 0 ? consF : 1;
            distance = 0.0;
            brand = _brand;
            maxDist = amountFuel * 100 / consFuel;
			image = new ImageSurface("pictures\\Tank.png");
			lights = false;
        }
        public double MaxDist { get { return maxDist; } }
        public double AmountFuel
        {
            get { return amountFuel; }
			set { amountFuel = value; }
        }
        public double ConsFuel { get { return consFuel; } }
		public bool Lights
		{
			get { return lights; }
			set { lights = value; }
		}
    }


}

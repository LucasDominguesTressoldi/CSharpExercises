using System;

class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distance = 0;
    private int battery = 100;
    private bool batteryDrained = false;
    
    public RemoteControlCar(int speed, int batteryDrain) 
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => batteryDrained;

    public int DistanceDriven() => distance;

    public void Drive()
    {
        bool canDrive = battery - batteryDrain >= 0;

        if (!batteryDrained && canDrive)
        {
            battery -= batteryDrain;
            distance += speed;
        }

        bool cantDriveAnymore = battery == 0 || battery < batteryDrain;

        if (cantDriveAnymore) {
            batteryDrained = true;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int distance;
    
    public RaceTrack(int distance) => this.distance = distance;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(!car.BatteryDrained())
        {
            car.Drive();
        }

        if (car.DistanceDriven() >= distance)
        {
            return true;
        }
        return false;
    }
}
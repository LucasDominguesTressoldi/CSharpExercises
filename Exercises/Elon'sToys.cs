using System;

class RemoteControlCar
{

    private int _battery = 100;
    private int _distance = 0;

    public static RemoteControlCar Buy()
    {
        return new();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        if (_battery != 0) return $"Battery at {_battery}%";
        return $"Battery empty";
    }

    public void Drive()
    {
        if (_battery != 0) {
            _distance += 20;
            _battery -= 1;
        }
    }
}
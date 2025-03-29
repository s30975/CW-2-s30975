namespace ConsoleApp2_s30975;

public class Kontener_Gas : Kontener_classic,IHazardNotifier
{
    public double Pressure { get; private set; }
    
    public Kontener_Gas(double weight_of_cargo, double height, double self_weight, double depth, double max_weight, double pressure)
        : base(weight_of_cargo, height, self_weight, depth, max_weight,"G")
    {
        Pressure = pressure;
    }
    
    public override void Cargo_out()
    {
        weight_of_cargo *= 0.05;
    }

    public override void Cargo_in(double mass)
    {
        if (mass > weight_of_cargo)
        {
            Hazard_alarm(con_name);
            throw new OverfillException($"Niebeczpieczna operacja: próba załadowania {mass} kg, gdy maksymalna ładowność to {max_weight} kg");
        }
        base.Cargo_in(mass);
    } 
    
    public void Hazard_alarm(string con_id)
    {
        Console.WriteLine($"UWAGA: Niebezpieczna operacja na kontenerze {con_id} z gazem pod ciśnieniem {Pressure} !");
    }
    
    public override string Cargo_info()
    {
        return base.Cargo_info() + $", Typ: Gaz, Ciśnienie: {Pressure} atm";
    }
}
namespace ConsoleApp2_s30975;

public class Kontener_L : Kontener_classic,IHazardNotifier
{
    public bool Ishazard { get; private set; }

    public Kontener_L(double weight_of_cargo, double height, double self_weight, double depth, double max_weight,bool ishazard)
        : base(weight_of_cargo, height, self_weight, depth, max_weight, "L")
    {
        Ishazard = ishazard;
    }

    public override void Cargo_in(double mass)
    {
        double max_weight_allowed;
        if (Ishazard) {
            max_weight_allowed = max_weight*0.5;
        }
        else {
            max_weight_allowed = max_weight*0.9;
        }

        if (mass > max_weight_allowed)
        {
            Hazard_alarm(con_name);
            throw new OverfillException($"Niebeczpieczna operacja: próba załadowania {mass} kg, gdy maksymalna ładowność to {max_weight} kg");
        }
        base.Cargo_in(mass);
    }
    
    public void Hazard_alarm(string con_id)
    {
        Console.WriteLine($"UWAGA: Niebezpieczna operacja na kontenerze {con_id}!");
    }
    
    public override string Cargo_info()
    {
        return base.Cargo_info() + $", Typ: Płyny, Niebezpieczny: {(Ishazard ? "Tak" : "Nie")}";
    }
}
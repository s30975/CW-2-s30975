namespace ConsoleApp2_s30975;

public abstract class Kontener_classic {
    public string con_name { get; protected set; }
    public double weight_of_cargo { get; protected set; }
    public double height { get; protected set; }
    public double self_weight { get; protected set; }
    public double depth { get; protected set; }
    public double max_weight { get; protected set; }
    
    protected static int _nextId = 1;

    protected Kontener_classic(double weight_of_cargo, double height, double self_weight, double depth,double max_weight, string con_type) {
        con_name = $"KON-{con_type}-{_nextId++}";
        this.weight_of_cargo = weight_of_cargo;
        this.height = height;
        this.self_weight = self_weight;
        this.depth = depth;
        this.max_weight = max_weight;
    }

    public virtual  void Cargo_out() {
        weight_of_cargo = 0;
    }

    public virtual void Cargo_in(double mass) {
        if (mass > max_weight) {
            throw new OverfillException($"Próba załadowania {mass} kg, gdy maksymalna ładowność to {max_weight} kg");
        }
        weight_of_cargo = mass;
    }

    public virtual string Cargo_info() {
        return $"Kontener {con_name}: Masa ładunku: {weight_of_cargo} kg, Wysokość: {height} cm, Waga własna: {self_weight} cm, Głębokość: {depth} cm, Maks. ładowność: {max_weight} kg";
    }
}
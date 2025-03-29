namespace ConsoleApp2_s30975;

public class Kontener_C : Kontener_classic
{
    public string product_type { get; private set; }
    public double Temp { get; private set; }
    
    private static readonly Dictionary<string, double> ProductTemperatures = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    public Kontener_C(double weight_of_cargo, double height, double self_weight, double depth, double max_weight,
        string productType, double temperature)
        : base(weight_of_cargo, height, self_weight, depth, max_weight, "C")
    {
        if (!ProductTemperatures.ContainsKey(productType))
        {
            throw new ArgumentException($"Nieznany typ produktu: {productType}");
        }

        double requiredTemp = ProductTemperatures[productType];
        if (temperature < requiredTemp)
        {
            throw new ArgumentException(
                $"Temperatura {temperature}°C jest niższa niż wymagana {requiredTemp}°C dla {productType}");
        }

        product_type = productType;
        Temp = temperature;
    }

    public override string Cargo_info()
    {
        return base.Cargo_info() + $", Typ: Gaz, Teperatura: {Temp} \u2103";
    }
}
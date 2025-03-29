namespace ConsoleApp2_s30975;

public class kontenerowiec
{
    public string ship_name { get; private set; }
    public List<Kontener_classic> containers { get; private set; }
    public double max_speed { get; private set; }
    public int max_container_count { get; private set; }
    public double max_weight { get; private set; }

    public kontenerowiec(string ship_name, double max_speed, int max_container_count, double max_weight) {
        this.ship_name = ship_name;
        this.max_speed = max_speed;
        this.max_container_count = max_container_count;
        this.max_weight = max_weight;
        this.containers=new List<Kontener_classic>();
    }

    public void containers_in_check(Kontener_classic container) {
        if (containers.Count >= max_container_count) {
            throw new InvalidOperationException($"Maksymalna ilość kontenerów została osiągnięta Maksymalna liczba: {max_container_count}");
        }
        double containers_total_weight =  containers.Sum(c => c.weight_of_cargo + c.self_weight) + container.weight_of_cargo + container.self_weight;
        if (containers_total_weight / 1000 > max_weight) {
            throw new OverfillException($"Przekroczona maksymalna waga statku. Aktualna waga: {containers_total_weight / 1000}t, Maksymalna: {max_weight}t");
        }

        containers.Add(container);
    }

    public void containers_in(List<Kontener_classic> containers) {
        foreach (var c in containers) {
            containers_in_check(c);
        }
    }

    public void containers_out_check(string con_id) {
        var con = containers.FirstOrDefault(c => c.con_name == con_id);
        if (con != null) {
            containers.Remove(con);
        }
        else {
            throw new KeyNotFoundException($"Kontener o numerze {con_id} nie został znaleziony na statku.");
        }
    }

    public void containers_replace(string con_id, Kontener_classic new_container) {
        var index = containers.FindIndex(c => c.con_name == con_id);
        if (index != -1) {
            containers[index] = new_container;
        }
        else {
            throw new KeyNotFoundException($"Kontener o numerze {con_id} nie został znaleziony na statku.");
        }
    }

    public void containers_transfer(string con_id, kontenerowiec ship_to_replace)
    {
        var con = containers.FirstOrDefault(c => c.con_name == con_id);
        if (con == null)
        {
            throw new KeyNotFoundException($"Kontener o numerze {con_id} nie został znaleziony na statku.");
        }
        
        try
        {
            ship_to_replace.containers_in_check(con);
            containers.Remove(con);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Nie można przenieść kontenera: {ex.Message}");
        }
    }

    public string ship_info()
    {
        double current_weight = containers.Sum(c => c.weight_of_cargo + c.self_weight)/1000;
        return $"Statek {ship_name}: Prędkość maks.: {max_speed} węzłów, Liczba kontenerów: {containers.Count}/{max_container_count}, Waga: {current_weight}/{max_weight}t";
    }
        
    public string GetContainersInfo()
    {
        return string.Join("\n", containers.Select(c => c.Cargo_info()));
    }
}
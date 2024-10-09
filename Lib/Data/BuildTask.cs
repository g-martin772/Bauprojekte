using System.Security.Cryptography.X509Certificates;

namespace Lib.Data;

public enum BuildTaskType
{
    House,
    Garden,
    Garage,
    Shed,
    Fence,
    Driveway,
    Street,
    Highway,
    Bridge,
    Tunnel,
    Railway,
    Airport,
    Port,
    Dam,
    Canal,
    Pipeline,
    Powerline,
    Substation,
    Windfarm,
    Solarfarm,
    Hydroelectric,
    Nuclear,
    Gas,
    Oil,
    Coal,
    Biomass,
    Waste,
    Recycling,
    Water,
    Sewage,
    Telecom,
    Room,
    Wall,
    Floor,
    Ceiling,
    Roof,
    Door,
    Window,
    Stairs,
    Elevator,
    Escalator,
    Ramp,
    Balcony,
    Porch,
    Patio,
    Deck,
    Veranda,
    Terrace
}

public record BuildTask
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required BuildTaskType Type { get; init; }
    public MaterialCollection Materials { get; set; } = new();
    public SubTaskCollection SubTasks { get; set; } = new();

    internal Project? project;

    public void AddSubTask(BuildTask subTask)
    {
        project?.InvokeProjectChangedEvent(this, new ProjectChangedEventArgs("SubTask Added", subTask));

        subTask.project = project;
        SubTasks.Add(subTask);
    }

    public void AddMaterial(Material material, int quantity)
    {
        project?.InvokeProjectChangedEvent(this, new ProjectChangedEventArgs("Material Added", new {
            Material = material,
            Quantity = quantity
        }));

        if (Materials.ContainsKey(material))
        {
            Materials[material] += quantity;
            return;
        }
        Materials.Add(material, quantity);
    }
}

public class SubTaskCollection : List<BuildTask> {
    public override string ToString()
    {
        return string.Join(", ", this.Select(x => x.Name));
    }
}
namespace Lib.Data;

public record ProjectChangedEventArgs(string Info, object Data);

public record Project
{
    public string Name { get; init; }
    public string Description { get; init; }

    public List<BuildTask> BuildTasks { get; set; } = new();

    public Project(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddBuildTask(BuildTask buildTask)
    {
        buildTask.project = this;
        BuildTasks.Add(buildTask);
        ProjectChangedEvent(this, new ProjectChangedEventArgs("BuildTask added", buildTask));
    }

    public void InvokeProjectChangedEvent(object sender, ProjectChangedEventArgs e)
    {
        ProjectChangedEvent(sender, e);
    }

    public event EventHandler<ProjectChangedEventArgs> ProjectChangedEvent = delegate { };
}
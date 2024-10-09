using Lib.Data;
using Microsoft.Extensions.Logging;

namespace Lib.Services;

public class ProjectManager(ILogger<ProjectManager> logger) {
    public List<Project> Projects { get; set; } = new();

    public void AddProject(Project project) {
        Projects.Add(project);
        logger.LogInformation("Project added: {Project}", project);
        project.ProjectChangedEvent += ProjectChangedEventHandler;
    }

    public void RemoveProject(Project project) {
        Projects.Remove(project);
        project.ProjectChangedEvent -= ProjectChangedEventHandler;
        logger.LogInformation("Project removed: {Project}", project);
    }

    private void ProjectChangedEventHandler(object? sender, ProjectChangedEventArgs e) {
        if (sender is Project project) {
            logger.LogInformation("Project {ProjectName} changed: {Info} - {Data}", project.Name , e.Info, e.Data);
        } else if (sender is BuildTask task) {
            logger.LogInformation("Task {TaskName} changed: {Info} - {Data}", task.Name , e.Info, e.Data);
        }
        else {
            logger.LogWarning("ProjectChangedEventHandler called with invalid sender");
        }
    }
}
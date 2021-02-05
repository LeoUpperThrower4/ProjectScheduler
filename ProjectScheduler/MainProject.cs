using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
class MainProject : ISerializable
{
    // file ID
    private string id;

    // create and initialize the variable where all projects will be saved
    private List<Project> projectsList = new List<Project>();

    // properties initializer
    public string ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public List<Project> ProjectList
    {
        get
        {
            return this.projectsList;
        }
    }

    /// <summary>
    /// Empty constructor
    /// </summary>
    public MainProject() { ID = "404"; }

    /// <summary>
    /// Creates a project with the given parameters and adds it to the projectsList list
    /// </summary>
    /// <param name="name">Project name</param>
    /// <param name="date">Limit Date</param>
    /// <param name="materia">Materia</param>
    /// <param name="description">Project description</param>
    /// <param name="ID">Unique ID of yout main project</param>
    public void CreateProject(string name, DateTimeOffset date, string materia, string description)
    {
        var proj = new Project(name, date, materia, description);
        projectsList.Add(proj);
    }

    /// <summary>
    /// Populate projectsList with the projects saved on the dat file. Internal only, should not be called directly. Responsable for one part of the serialization process
    /// </summary>
    public MainProject(SerializationInfo info, StreamingContext context)
    {
        projectsList = (List<Project>)info.GetValue("ProjectsList", typeof(List<Project>));
    }

    /// <summary>
    /// Internal, should not be called directly. Responsable for one part of the serialization process
    /// </summary>
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("ProjectsList", projectsList);
    }
}

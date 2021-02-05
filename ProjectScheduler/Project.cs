using System;

[Serializable]
class Project
{
    private string projectName;
    private string projectMateria;
    private DateTimeOffset limitDate;
    private string projectDescription;

    // properties constructors
    public string ProjectName
    {
        get
        {
            return this.projectName;
        }
        set
        {
            this.projectName = value;
        }
    }
    public string ProjectMateria
    {
        get
        {
            return this.projectMateria;
        }
        set
        {
            this.projectMateria = value;
        }
    }
    public DateTimeOffset ProjectLimitdate
    {
        get
        {
            return this.limitDate;
        }
        set
        {
            this.limitDate = value;
        }
    }
    public string ProjectDescription
    {
        get
        {
            return this.projectDescription;
        }
        set
        {
            this.projectDescription = value;
        }
    }

    /// <summary>
    /// Empty constructor
    /// </summary>
    public Project() { }

    /// <summary>
    /// Initializes a Project object with the given parameters
    /// </summary>
    /// <param name="name">Project name</param>
    /// <param name="date">Limit Date</param>
    /// <param name="materia">Materia</param>
    /// <param name="description">Project description</param>
    public Project(string name, DateTimeOffset date, string materia, string description)
    {
        this.ProjectName = name;
        this.ProjectLimitdate = date;
        this.ProjectMateria = materia;
        this.ProjectDescription = description;
    }

    /// <summary>
    /// Overriden method to show all Project properties at once
    /// </summary>
    /// <returns>string containing every project property</returns>
    override public string ToString()
    {
        return $"Name: {this.ProjectName}\nMatéria: {this.ProjectMateria}\nLimit Date: {this.ProjectLimitdate.Date}\nDescription: {this.ProjectDescription}";
    }
}

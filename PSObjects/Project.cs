using System;

namespace PSObjects
{
    [Serializable]
    public class Project
    {

        public string ProjectName { get; set; }
        public string ProjectMateria { get; set; }
        public DateTimeOffset ProjectLimitdate { get; set; }
        public string ProjectDescription { get; set; }

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

}

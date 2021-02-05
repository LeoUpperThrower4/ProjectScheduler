using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PSObjects
{
    [Serializable]
    public class MainProject : ISerializable
    {
        // properties initializer
        public string ID { get; set; }

        // create and initialize the variable where all projects will be saved
        public List<Project> ProjectList { get; private set; } = new List<Project>();

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
            ProjectList.Add(proj);
        }

        /// <summary>
        /// Populate projectsList with the projects saved on the dat file. Internal only, should not be called directly. Responsable for one part of the serialization process
        /// </summary>
        public MainProject(SerializationInfo info, StreamingContext context)
        {
            ProjectList = (List<Project>)info.GetValue("ProjectsList", typeof(List<Project>));
        }

        /// <summary>
        /// Internal, should not be called directly. Responsable for one part of the serialization process
        /// </summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ProjectsList", ProjectList);
        }
    }

}

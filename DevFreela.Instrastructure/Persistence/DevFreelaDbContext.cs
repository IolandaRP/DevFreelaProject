using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Instrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Descrição projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Descrição projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Descrição projeto 3", 1, 1, 30000),
            };

            Users = new List<User>
            {
                new User("Iolanda Rodrigues", "iolanda@gmail.com", new DateTime(1995,4,4)),
                new User("Luis Felipe", "luisFelipe@gmail.com", new DateTime(1992,1,1))
            };

            Skills = new List<Skill>
            {
                new Skill("C#"),
                new Skill("ASPNET Core"),
                new Skill("JavaScript"),
                new Skill("Sql Server"),
                new Skill("MongoDB"),
                new Skill("Java"),
                new Skill("React"),
                new Skill("Angular")
            };

            Comments = new List<ProjectComments>();
            
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComments> Comments { get; set; }
    }
}

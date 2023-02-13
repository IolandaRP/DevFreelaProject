using System.Reflection.Metadata.Ecma335;

namespace DevFreela.Core.Entities
{
    public class ProjectComments : BaseEntity
    {
        public ProjectComments(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
            CreatedAt= DateTime.Now;
        }

        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public Project Project { get; set; }
        public int IdUser { get; private set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}
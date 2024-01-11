namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        public const double subjectRate = 1.15;

        public HumanitySubject(int id, string name)
            : base(id, name, subjectRate)
        {
        }
    }
}

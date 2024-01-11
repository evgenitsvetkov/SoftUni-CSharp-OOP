namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        public const double subjectRate = 1.0;

        public EconomicalSubject(int id, string name)
            : base(id, name, subjectRate)
        {
        }
    }
}

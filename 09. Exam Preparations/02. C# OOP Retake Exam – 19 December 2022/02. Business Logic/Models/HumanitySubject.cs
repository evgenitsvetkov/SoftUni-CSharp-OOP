namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        //Fields
        public const double subjectRate = 1.15;

        //Constructor
        public HumanitySubject(int id, string name)
            : base(id, name, subjectRate)
        {
        }
    }
}

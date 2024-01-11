using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        //Methods
        public string AddStudent(string firstName, string lastName)
        {
            //Already Added Student
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            //Adding Student
            students.AddModel(new Student(students.Models.Count + 1, firstName, lastName));

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {

            //Subject Type Not Supported
            if (subjectType != nameof(TechnicalSubject) 
                && subjectType != nameof(EconomicalSubject) 
                && subjectType != nameof(HumanitySubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            //Already Added Subject
            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            //Adding The Subject
            ISubject subject;

            if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
            }
            else
            {
                subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
            }

            subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {

            //Already Added University
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            //Converting And Adding
            ICollection<int> convertedRequiredSubjects = new List<int>();

            foreach (var subName in requiredSubjects)
            {
                convertedRequiredSubjects.Add(subjects.FindByName(subName).Id);
            }

            universities.AddModel(new University(universities.Models.Count + 1, universityName, category, capacity, convertedRequiredSubjects));

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);

        }
        public string TakeExam(int studentId, int subjectId)
        {
            //Student Doesn't Exist
            if (students.FindById(studentId) == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            //Subject Doesn't Exist
            if (subjects.FindById(subjectId) == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);


            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            //Successfully Covered The Exam
            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            //Student Doesn't Exist
            string firstName = studentName.Split(" ")[0];
            string lastName = studentName.Split(" ")[1];

            var student = this.students.FindByName(studentName);
            var university = this.universities.FindByName(universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            //University Doesn't Exist
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            //Student Hasn't Covered All The Required Exams For The University
            foreach (var subject in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(subject))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            //Student Has Already Joined The University
            if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            //Joining The University
            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }


        public string UniversityReport(int universityId)
        {
            IUniversity university = this.universities.FindById(universityId);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"*** {university.Name} ***");
            stringBuilder.AppendLine($"Profile: {university.Category}");
            stringBuilder.AppendLine($"Students admitted: {this.students.Models.Where(s => s.University == university).Count()}");
            stringBuilder.AppendLine($"University vacancy: {university.Capacity - this.students.Models.Where(s => s.University == university).Count()}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}

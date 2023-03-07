using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class CV
    {
        // objective, summery, profession, yearsOdExperience, languages, languageCodes, certifications, publications, referees, skills, educations, workExperiences
        private string _objective;
        private string _summery;
        private string _profession;
        private int _yearsOfExperience;
        private string[] _languages;
        private string[] _languageCodes;
        private string[] _certifications;
        private string[] _publications;
        private string[] _referees;
        private Skill[] _skills;
        private Education[] _educations;
        private WorkExperience[] _workExperiences;

        public CV(string objective, string summery, string profession, int yearsOfExperience, string[] languages, 
            string[] languageCodes, string[] certifications, string[] publications, string[] referees,
            Skill[] skills, Education[] educations, WorkExperience[] workExperiences)
        {
            _objective = objective;
            _summery = summery;
            _profession = profession;
            _yearsOfExperience = yearsOfExperience;
            _languages = languages;
            _languageCodes = languageCodes;
            _certifications = certifications;
            _publications = publications;
            _referees = referees;
            _skills = skills;
            _educations = educations;
            _workExperiences = workExperiences;
        }

        public string Objective
        {
            get { return _objective; }
        }
        public string Summery
        {
            get { return _summery; }
        }
        public string Profession
        {
            get { return _profession; }
        }
        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
        }
        public string[] Languages
        {
            get { return _languages; }
        }
        public string[] LanguageCodes
        {
            get { return _languageCodes; }
        }
        public string[] Certifications
        {
            get { return _certifications; }
        }
        public string[] Publications
        {
            get { return _publications; }
        }
        public string[] Referees
        {
            get { return _referees; }
        }
        public Skill[] Skills
        {
            get { return _skills; }
        }
        public Education[] Educations
        {
            get { return _educations; }
        }
        public WorkExperience[] WorkExperiences
        {
            get { return _workExperiences; }
        }
        

    }
}

using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using WinFormsApp1.CV;

namespace WinFormsApp1.Json
{
    internal static class JsonReader
    {
        public static Applicant GetApplicant(string file)
        {
            dynamic? data = ReadJson(file) ?? throw new FileNotFoundException(file);

            // Create the CV object
            string objective = data.Objective;
            string summary = data.Summary;
            string profession = data.Profession;
            int yearsOfExperience = data.TotalYearsExperience;
            string[] languages = data.Languages.ToObject<string[]>();
            string[] langCodes = data.LanguageCodes.ToObject<string[]>();
            string[] certifications = data.Certifications.ToObject<string[]>();
            string[] publications = data.Publications.ToObject<string[]>();
            string[] referees = data.Referees.ToObject<string[]>();
            Skill[] skills = ExtractSkills(data.Skills);
            Education[] education = ExtractEducation(data.Education);
            WorkExperience[] workExperience = ExtractWorkExperience(data.WorkExperience);
                
            CV.CV cv = new (objective, summary, profession, yearsOfExperience, languages, langCodes, 
                certifications, publications, referees, skills, education, workExperience);

            // Create applicant object
            Name name = new ((string) data.Name.First, (string?) data.Name.Middle, (string) data.Name.Last, (string?) data.Name.Title);
            string[] phones = data.PhoneNumbers.ToObject<string[]>();
            string[] emails = data.Emails.ToObject<string[]>();
            string[] websites = data.Websites.ToObject<string[]>();
            Location? location = ExtractLocation(data.Location);
            DateTime? dateOfBirth = ExtractDate(data.DateOfBirth);
            string? headshot = data.Headshot;

            // add linkedin to websites
            string? linkedin = data.LinkedIn;
            if(linkedin != null && !websites.Contains(linkedin))
                websites = websites.Append(linkedin).ToArray();

            Applicant applicant = new (name, cv, phones, emails, websites, location, dateOfBirth, headshot);

            return applicant;
        }

        public static dynamic? ReadJson(string file)
        {
            // read the json file
            string json = File.ReadAllText(file);
            dynamic data = JsonConvert.DeserializeObject(json);
            return data?.Value.Data;
        }

        private static Location? ExtractLocation(dynamic loc)
        {
            if (loc == null)
                return null;
            
            return new Location((string) loc.Country, (string?) loc.CountryCode, (string?) loc.State,
                (string?) loc.City, (string?) loc.Street, (string?) loc.StreetNumber, 
                (string?) loc.ApartmentNumber, (string?) loc.PostalCode);
        }

        private static DateTime? ExtractDate(dynamic date)
        {
            if (date == null)
                return null;

            return DateTime.Parse((string) date);
        }

        private static TimePeriod? ExtractTimePeriod(dynamic period)
        {
            if (period == null)
                return null;

            // Create applicant time period object
            DateTime? start = null;
            DateTime? end = null;
            if(period.CompletionDate != null)
                end = DateTime.Parse((string) period.CompletionDate);
            if (period.StartDate != null)
                end = DateTime.Parse((string) period.StartDate);
            return new TimePeriod(start, end);
        }

        private static Education[] ExtractEducation(dynamic edu)
        {
            // Create applicant education object
            Education[] education = new Education[edu.Count];
            for (int i = 0; i < edu.Count; i++)
            {
                dynamic e = edu[i];

                Location location = ExtractLocation(e.Location);
                TimePeriod period = ExtractTimePeriod(e.Dates);
                string? gradeMetric = null;
                string? gradeValue = null;
                if (e.grade != null)
                {
                    gradeMetric = (string) e.grade.Metric;
                    gradeValue = (string) e.grade.Value;
                }
                
                education[i] = new Education((int) e.Id, (string) e.Organization, (string) e.Accreditation.Education, 
                    period, gradeMetric, gradeValue, location, (string?) e.Accreditation.EducationLevel );
            }

            return education;
        }

        private static Skill[] ExtractSkills(dynamic skills)
        {
            // Create applicant skills object
            Skill[] applicantSkills = new Skill[skills.Count];
            for (int i = 0; i < skills.Count; i++)
            {
                dynamic s = skills[i];
                DateTime? lastUsed = ExtractDate(s.LastUsed);
                int? monthsOfExperience = s.MonthsOfExperience;
                Source[] sources = ExtractSources(s.Sources);
            
                Skill skill = new Skill((int) s.Id, (string) s.EsmId, (string) s.Name, (string) s.Type, sources, lastUsed, monthsOfExperience);
                applicantSkills[i] = skill;
            }

            return applicantSkills;
        }

        private static Source[] ExtractSources(dynamic sources)
        {
            Source[] applicantSources = new Source[sources.Count];
            for (int i = 0; i < sources.Count; i++)
            {
                dynamic s = sources[i];
                applicantSources[i] = new Source((string) s.Section, (int?) s.WorkExperienceId, (int?) s.Position);
            }

            return applicantSources;
        }

        private static WorkExperience[] ExtractWorkExperience(dynamic workExperience)
        {
            WorkExperience[] applicantWorkExperience = new WorkExperience[workExperience.Count];
            for (int i = 0; i < workExperience.Count; i++)
            {
                dynamic w = workExperience[i];
                int id = w.Id;
                string title = w.JobTitle;
                int? socCode = w.SocCode;
                string? socName = w.SocName;
                string organization = w.Organization;
                string? industry = w.Industry;
                string description = w.JobDescription;
                int? managementLevel = w.Occupation.ManagementLevel;
                TimePeriod period = ExtractTimePeriod(w.Dates);
                Location? loc = ExtractLocation(w.Location);
                JobClassification? classification = ExtractJobClassification(w.Occupation.Classification);

                applicantWorkExperience[i] = new WorkExperience(id, title, organization, description, 
                    managementLevel, period, socCode, socName, industry, loc, classification);
            }

            return applicantWorkExperience;
        }

        private static JobClassification? ExtractJobClassification(dynamic classification)
        {
            if (classification == null)
                return null;

            return new JobClassification((string) classification.Title, (string) classification.MinorGroup,
                (string) classification.SubMajorGroup, (string) classification.MajorGroup, (int) classification.SocCode);
        }
    }
}

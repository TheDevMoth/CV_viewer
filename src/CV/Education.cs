using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class Education
    {
        private int _id;
        private string _organization;
        private string _accreditation;
        private string? _gradeMetric;
        private string? _grade;
        private TimePeriod? _period;
        private string? _educationLevel;
        private Location? _loc;

        public Education(int id, string organization, string accreditation, TimePeriod? period = null,
        string? gradeMetric = null, string? grade = null, Location? loc = null,  string? educationLevel = null)
        {
            _id = id;
            _organization = organization;
            _accreditation = accreditation;
            _gradeMetric = gradeMetric;
            _grade = grade;
            _educationLevel = educationLevel;
            _period = period;
            _loc = loc;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Accreditation);
            sb.Append(", at ");
            sb.Append(Organization);
            sb.Append(". ");
            if (_period != null)
                sb.Append(Period.ToString());
            if (_gradeMetric != null && _grade != null)
            {
                sb.Append("\n");
                sb.Append(GradeMetric);
                sb.Append(": ");
                sb.Append(Grade);
            }
            return sb.ToString();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }
        public string Accreditation
        {
            get { return _accreditation; }
            set { _accreditation = value; }
        }
        public string GradeMetric
        {
            get { return _gradeMetric ?? throw new Exception("Grade metric is not stored");}
            set { _gradeMetric = value; }
        }
        public string Grade
        {
            get { return _grade ?? throw new Exception("Grade is not stored"); }
            set { _grade = value; }
        }
        public string EducationLevel
        {
            get { return _educationLevel ?? throw new Exception("Education level is not stored"); }
            set { _educationLevel = value; }
        }
        public TimePeriod Period
        {
            get { return _period ?? throw new Exception("Education level is not stored"); }
            set { _period = value; }
        }
        public Location Loc
        {
            get { return _loc ?? throw new Exception("Location is not stored"); }
            set { _loc = value; }
        }

    }
}

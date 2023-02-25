using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class WorkExperience
    {
        private int _id;
        private string _title;
        private int? _socCode;
        private string? _socName;
        private string _organization;
        private string? _industry;
        private string _description;
        private int? _managementLevel;
        private TimePeriod _period;
        private Location? _loc;
        private JobClassification? _classification;

        public WorkExperience(int id, string title, string organization, string description, int? managementLevel, TimePeriod period,
            int? socCode = null, string? socName = null, string? industry = null, Location? loc = null, JobClassification? classification = null)
        {
            _id = id;
            _title = title;
            _socCode = socCode;
            _socName = socName;
            _organization = organization;
            _industry = industry;
            _description = description;
            _managementLevel = managementLevel;
            _period = period;
            _loc = loc;
            _classification = classification;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int? SocCode
        {
            get { return _socCode ?? throw new Exception("socCode is not stored"); }
            set { _socCode = value; }
        }
        public string? SocName
        {
            get { return _socName ?? throw new Exception("socName is not stored"); }
            set { _socName = value; }
        }
        public string Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }
        public string? Industry
        {
            get { return _industry ?? throw new Exception("industry is not stored"); }
            set { _industry = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int? ManagementLevel
        {
            get { return _managementLevel ?? throw new Exception("management level is not stored"); }
            set { _managementLevel = value; }
        }
        public TimePeriod Period
        {
            get { return _period; }
            set { _period = value; }
        }
        public Location Loc
        {
            get { return _loc ?? throw new Exception("location is not stored"); }
            set { _loc = value; }
        }

    }
}

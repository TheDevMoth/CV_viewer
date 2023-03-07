using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class Skill
    {
        private int _id;
        private string _esmId;
        private string _name;
        private string _type;
        private Source[] _sources;
        private DateTime? _lastUsed;
        private int? _monthsOfExperience;

        public Skill(int id, string esmId, string name, string type, Source[] sources, DateTime? lastUsed = null, int? monthsOfExperience = null)
        {
            _id = id;
            _esmId = esmId;
            _name = name;
            _type = type;
            _sources = sources;
            _lastUsed = lastUsed;
            _monthsOfExperience = monthsOfExperience;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" (");
            sb.Append(Type);
            sb.Append(")");
            if (_lastUsed != null)
            {
                sb.Append(", last used ");
                sb.Append(LastUsed.ToString("yyyy-MM"));
            }
            if (_monthsOfExperience != null)
            {
                sb.Append(", with ");
                sb.Append(MonthsOfExperience);
                sb.Append(" months of experience");
            }
            return sb.ToString();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string EsmId
        {
            get { return _esmId; }
            set { _esmId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Source[] Sources
        {
            get { return _sources.ToArray(); }
            set { _sources = value; }
        }
        public DateTime LastUsed
        {
            get { return _lastUsed ?? throw new Exception("lastUsed date is not stored"); }
            set { _lastUsed = value; }
        }
        public int MonthsOfExperience
        {
            get { return _monthsOfExperience ?? throw new Exception("monthsOfExperience is not stored"); }
            set { _monthsOfExperience = value; }
        }
    }
}

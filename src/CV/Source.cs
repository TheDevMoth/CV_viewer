using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class Source
    {
        private int? _workExperienceId;
        private int? _position;
        private string _section;

        public Source( string section, int? workExperience = null, int? position = null)
        {
            _workExperienceId = workExperience;
            _position = position;
            _section = section;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Section);
            if (_workExperienceId != null && _position != null)
            {
                sb.Append(", from position as ");
                sb.Append(Position);
            }
            return sb.ToString();
        }
        public int WorkExperienceId
        {
            get { return _workExperienceId ?? throw new Exception("Work experience is not stored"); }
            set { _workExperienceId = value; }
        }
        public int Position
        {
            get { return _position ?? throw new Exception("Position is not stored"); }
            set { _position = value; }
        }
        public string Section
        {
            get { return _section; }
            set { _section = value; }
        }
    }
}

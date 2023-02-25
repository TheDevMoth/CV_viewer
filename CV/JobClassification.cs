using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class JobClassification
    {
        private string _title;
        private string _minorGroup;
        private string _subMajorGroup;
        private string _majorGroup;
        private int _socCode;

        public JobClassification(string title, string minorGroup, string subMajorGroup, string majorGroup, int socCode)
        {
            _title = title;
            _minorGroup = minorGroup;
            _subMajorGroup = subMajorGroup;
            _majorGroup = majorGroup;
            _socCode = socCode;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string MinorGroup
        {
            get { return _minorGroup; }
            set { _minorGroup = value; }
        }
        public string SubMajorGroup
        {
            get { return _subMajorGroup; }
            set { _subMajorGroup = value; }
        }
        public string MajorGroup
        {
            get { return _majorGroup; }
            set { _majorGroup = value; }
        }
        public int SocCode
        {
            get { return _socCode; }
            set { _socCode = value; }
        }
        
    }
}

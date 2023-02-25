using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class Applicant
    {
        private Name _name;
        private CV _cv;
        private string[] _phones;
        private string[] _emails;
        private string[] _websites;
        private Location? _loc;
        private DateTime? _dateOfBirth;
        private string _headshot;

        public Applicant(Name name, CV cv, string[]? phones = null, string[]? emails = null, string[]? websites = null, 
            Location? loc = null, DateTime? dateOfBirth = null, string? headshot = null)
        {
            _name = name;
            _cv = cv;
            _phones = phones ?? new string[0];
            _emails = emails ?? new string[0];
            _websites = websites ?? new string[0];
            _loc = loc;
            _dateOfBirth = dateOfBirth;
            _headshot = headshot ?? "";
        }
        public Applicant(string fullName, CV cv, string[]? phones = null, string[]? emails = null, string[]? websites = null, Location? loc = null, DateTime? dateOfBirth = null, string? headshot = null)
            :this(new Name(fullName), cv, phones, emails, websites, loc, dateOfBirth, headshot){}

        public string LinkedIn()
        {
            foreach (string website in _websites)
            {
                if (website.Contains("linkedin"))
                    return website;
            }
            return "";
        }

        public string NameShorten()
        {
            return _name.FullShorten();
        }
        public string Name
        {
            get { return _name.Full(); }
        }
        public CV Cv
        {
            get { return _cv; }
        }
        public string[] Phones
        {
            // Return a copy of the array
            get { return _phones.ToArray(); }
        }
        public string[] Emails
        {
            get { return _emails.ToArray(); }
        }
        public string[] Websites
        {
            get { return _websites.ToArray(); }
        }
        public Location Loc
        {
            get { return _loc ?? throw new Exception("Location is not stored"); }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth ?? throw new Exception("Date of birth is not stored"); }
        }
        public string Headshot
        {
            get { return _headshot ?? throw new Exception("Headshot is not stored"); }
        }

    }
}

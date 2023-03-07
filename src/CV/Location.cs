using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class Location
    {
        private string _country;
        private string? _countryCode;
        private string? _state;
        private string? _city;
        private string? _street;
        private string? _streetNumber;
        private string? _apartmentNumber;
        private string? _postalCode;

        public Location(string country, string? countryCode = null, string? state = null, string? city = null, string? street = null, string? streetNumber = null, string? apartmentNumber = null, string? postalCode = null)
        {
            _country = country;
            _countryCode = countryCode;
            _state = state;
            _city = city;
            _street = street;
            _streetNumber = streetNumber;
            _apartmentNumber = apartmentNumber;
            _postalCode = postalCode;
        }

        public override string ToString()
        {
            return Formatted();
        }
        public string Formatted()
        {
            StringBuilder sb = new StringBuilder();
            if (_apartmentNumber != null)
                sb.Append(_apartmentNumber + ", ");
            if (_streetNumber != null)
                sb.Append(_streetNumber + " ");
            if (_street != null)
                sb.Append(_street + ", ");
            if (_city != null)
                sb.Append(_city + ", ");
            if (_state != null)
                sb.Append(_state + ", ");
            if (_postalCode != null)
                sb.Append(_postalCode + ", ");
            sb.Append(_country);

            return sb.ToString();
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string CountryCode
        {
            get { return _countryCode ?? throw new Exception("Country code is not stored"); }
            set { _countryCode = value; }
        }
        public string State
        {
            get { return _state ?? throw new Exception("State is not stored"); }
            set { _state = value; }
        }
        public string City
        {
            get { return _city ?? throw new Exception("City is not stored"); }
            set { _city = value; }
        }
        public string Street
        {
            get { return _street ?? throw new Exception("Street is not stored"); }
            set { _street = value; }
        } 
        public string StreetNumber
        {
            get { return _streetNumber ?? throw new Exception("Street number is not stored"); }
            set { _streetNumber = value; }
        }
        public string ApartmentNumber
        {
            get { return _apartmentNumber ?? throw new Exception("Apartment number is not stored"); }
            set { _apartmentNumber = value; }
        }
        public string PostalCode
        {
            get { return _postalCode ?? throw new Exception("Postal code is not stored"); }
            set { _postalCode = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class TimePeriod
    {
        private DateTime? _startDate;
        private DateTime? _endDate;

        public TimePeriod(DateTime? startDate = null, DateTime? endDate = null)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public DateTime StartDate
        {
            get { return _startDate ?? throw new Exception("Start date is not stored"); }
            set { _startDate = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate ?? throw new Exception("End date is not stored"); }
            set { _endDate = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_startDate?.ToString("yyyy MMM") ?? "Unknown");
            sb.Append(" - ");
            sb.Append(_endDate?.ToString("yyyy MMM") ?? "Present");
            return sb.ToString();
        }
        public bool IsCurrent()
        {
            if (_endDate == null)
                return true;
            else
                return _endDate > DateTime.Now;
                
        }
        public int? MonthsInPeriod()
        {
            if (IsCurrent())
                throw new Exception("Time period still ongoing");
            else if (_startDate == null || _endDate == null)
                throw new Exception("Start date is not stored");
            else
                return (_endDate.Value.Year - _startDate?.Year) * 12 + _endDate.Value.Month - _startDate?.Month;
        }
    }
}

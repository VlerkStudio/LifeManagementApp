using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    class BasicTask
    {
		public DateTime Start;
		public TimeSpan Duration;
		public required string Text;
		public required string Name;
		public DateTime End => Start + Duration;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifi.Domain
{
    public class BaseDto
    {
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    _id = Guid.NewGuid();
                else
                    _id = value;
            }
        }
        protected BaseDto()
        {
            _id = Guid.NewGuid();
        }

        private Guid _id;
    }
}

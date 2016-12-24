using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dumpfilekiller
{
    class deleteConfig
    {
        private deleteConfig() { }
        private string fileTypes;
        private string dupFileStandr;
        // Fields
        private static deleteConfig deleteConfiginstance;



        // Methods
        public static deleteConfig Instance()
        {
            // Uses "Lazy initialization"
            if (deleteConfiginstance == null)
                deleteConfiginstance = new deleteConfig();

            return deleteConfiginstance;
        }

        public string FileTypes
        {
            get
            {
                return fileTypes;
            }

            set
            {
                fileTypes = value;
            }
        }

        public string DupFileStandr
        {
            get
            {
                return dupFileStandr;
            }

            set
            {
                dupFileStandr = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBReader
{
    public class DBUploader
    {
        public void DbInit()
        {
            var min = Implementation.ConstantsHelper.ParseIntegerParameter(Implementation.Constants.MinCount);
            var path = Implementation.Constants.Path;
            var connectionString = DBConstants.ConnectionString;
            DatabaseWriter dbWriter = new DatabaseWriter(connectionString);
            var fileReader = new FileReader(_display, path, min);
            var words = fileReader.ParseText();
            dbWriter.DatabaseInit(words);
        }
    }
}

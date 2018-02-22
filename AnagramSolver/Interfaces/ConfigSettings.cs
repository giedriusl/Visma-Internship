using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class ConfigSettings : IConfigSettings
    {
        public string Path { get; private set; }
        public int MinCount { get; private set; }
        public int MaxResult { get; private set; }
        public string ConnectionString { get; private set; }

        public ConfigSettings()
        {
            Path = @"C:\Users\giedrius.lukocius\source\repos\AnagramsSolver\Visma-Internship\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            MinCount = 2;
            MaxResult = 10;
            ConnectionString = @"'metadata=res://*/AnagramGeneratorEntityModel.csdl|res://*/AnagramGeneratorEntityModel.ssdl|res://*/AnagramGeneratorEntityModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=LT-LIT-SC-0015;Initial Catalog=AnagramsContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False&quot;' providerName = 'System.Data.EntityClient'";
        }
    }
}

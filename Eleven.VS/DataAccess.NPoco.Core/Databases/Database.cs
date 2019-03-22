using NPoco;

namespace $ext_safesolutionname$.DataAccess.NPoco.Core.Databases
{
    public class $ext_mainconnectionname$Database : Database
    {
        private static string ConnectionStringName = "$ext_mainconnectionname$";

        public $ext_mainconnectionname$Database() : this(ConnectionStringName)
        {

        }

        public $ext_mainconnectionname$Database(string connectionStringName) : base(connectionStringName)
        {

        }
    }
}

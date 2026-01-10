using lib_repositories.Interfaces;
using System.Collections.Generic;

namespace lib_repositories.Implementations
{
    public class ApisRepository : IApisRepository
    {
        private IConnection? IConnection = null;

        public ApisRepository(IConnection iConnection)
        {
            this.IConnection = iConnection;
        }

        public void Configurar(string StringConexion)
        {
            this.IConnection!.StringConexion = StringConexion;
        }

        public Dictionary<string, object> Select()
        {
            var response = new Dictionary<string, object>();
            response["Protocol"] = "http://";
            response["Host"] = "localhost";

            var hash_select = new Dictionary<string, object>();
            hash_select["Request-Type"] = "Get";
            hash_select["Types"] = ":5230/Types/Select";
            hash_select["Products"] = ":5230/Products/Select";
            hash_select["Users"] = ":5230/Users/Select";
            response["Select"] = hash_select;

            var hash_where = new Dictionary<string, object>();
            hash_where["Request-Type"] = "Post";
            hash_where["Types"] = ":5230/Types/Where";
            hash_where["Products"] = ":5230/Products/Where";
            hash_where["Users"] = ":5230/Users/Where";
            response["Where"] = hash_where;

            var hash_insert = new Dictionary<string, object>();
            hash_insert["Request-Type"] = "Post";
            hash_insert["Types"] = ":5230/Types/Insert";
            hash_insert["Products"] = ":5230/Products/Insert";
            hash_insert["Users"] = ":5230/Users/Insert";
            response["Insert"] = hash_insert;

            var hash_update = new Dictionary<string, object>();
            hash_update["Request-Type"] = "Put";
            hash_update["Types"] = ":5230/Types/Update";
            hash_update["Products"] = ":5230/Products/Update";
            hash_update["Users"] = ":5230/Users/Update";
            response["Update"] = hash_update;

            var hash_delete = new Dictionary<string, object>();
            hash_delete["Request-Type"] = "Delete";
            hash_delete["Types"] = ":5230/Types/Update";
            hash_delete["Products"] = ":5230/Products/Update";
            hash_delete["Users"] = ":5230/Users/Update";
            response["Delete"] = hash_delete;
            return response;
        }
    }
}
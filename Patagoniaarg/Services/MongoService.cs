using System;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Patagoniaarg;

namespace Patagoniaar
{
    public class MongoService
    {


        string dbName = "Otra";
        string collectionName = "Otra";


        IMongoCollection<User> userCollection;
        IMongoCollection<User> UserCollection{
            get{
                if(userCollection ==null){
                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                            new MongoUrl(APIKeys.ConnectionString)
                          );
                    settings.SslSettings =
                               new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    var mongoclient = new MongoClient(settings);
                    var db = mongoclient.GetDatabase(dbName);
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    userCollection = db.GetCollection<User>(collectionName, collectionSettings);

                }
                return userCollection;

            }

        }

        public async Task<User> GetUserByUserName(String UserName)
          {

            
              var singleUser = await UserCollection
                .Find(f=> f.Username.Equals(UserName))
                  .FirstOrDefaultAsync();

              return singleUser;
          }
    }
}

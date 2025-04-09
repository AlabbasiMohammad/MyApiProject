using MongoDB.Bson;
using MongoDB.Driver;

namespace MyApiProject.Data
{
public class MongoDbService
{
    private readonly IMongoDatabase? _database;
    private readonly IConfiguration _configuration;

    public MongoDbService(IConfiguration configuration)
    {
        this._configuration = configuration;
        var connectionString = this._configuration.GetConnectionString("DbConnection");
        var mongoUrl  = MongoUrl.Create(connectionString);
        var client = new MongoClient(mongoUrl);
        _database = client.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase? Database => _database;

    // private readonly IMongoClient _client;
    // private readonly IMongoDatabase _database;

    // public MongoDbService(string connectionString, string databaseName)
    // {
    //     _client = new MongoClient(connectionString);
    //     _database = _client.GetDatabase(databaseName);
    // }

    // private IMongoCollection<BsonDocument> GetCollection(string collectionName)
    // {
    //     return _database.GetCollection<BsonDocument>(collectionName);
    // }

    // public void InsertOne(string collectionName, BsonDocument document)
    // {
    //     var collection = GetCollection(collectionName);
    //     collection.InsertOne(document);
    // }

    // public BsonDocument FindOne(string collectionName, FilterDefinition<BsonDocument> filter)
    // {
    //     var collection = GetCollection(collectionName);
    //     return collection.Find(filter).FirstOrDefault();
    // }

    // public List<BsonDocument> FindMany(string collectionName, FilterDefinition<BsonDocument> filter)
    // {
    //     var collection = GetCollection(collectionName);
    //     return collection.Find(filter).ToList();
    // }

    // public UpdateResult UpdateOne(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
    // {
    //     var collection = GetCollection(collectionName);
    //     return collection.UpdateOne(filter, update);
    // }

    // public DeleteResult DeleteOne(string collectionName, FilterDefinition<BsonDocument> filter)
    // {
    //     var collection = GetCollection(collectionName);
    //     return collection.DeleteOne(filter);
    // }

    // public void CloseConnection()
    // {
    //     // MongoDB C# driver manages connections automatically, so no explicit close is needed.
    // }
}
}
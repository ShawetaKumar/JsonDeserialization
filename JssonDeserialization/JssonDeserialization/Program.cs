using System;
using JsonApiSerializer;
using JssonDeserialization;
using Newtonsoft.Json;

namespace JsonDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var json = "{ \"data\": {  \"id\": \"1\",  \"type\" : \"product\",  \"attributes\" : {    \"name\": \"name\",    \"summary\": \"summary\"  } }}";

                var jsonApiSerializerSettings = new JsonApiSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                };

                var product = JsonConvert.DeserializeObject<Product>(json, jsonApiSerializerSettings);

                Console.WriteLine($"Product id:{product.Id}");

                json = "{  \"id\": \"1\",  \"type\" : \"product\",  \"name\": \"name\", \"summary\": \"summary\" }";

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                };

                product = JsonConvert.DeserializeObject<Product>(json, jsonSerializerSettings);

                Console.WriteLine(product.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}

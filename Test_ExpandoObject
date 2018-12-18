using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        test01();
    }

    static void test01()
    {
        /*
        * ExpandoObjectの便利な点
        * IDictionary<string, Object> や ICollection<KeyValuePair<string, Object>> を実装している
        */

        //ダイナミックでエクスパンドゥなオブジェクト
        dynamic d = new ExpandoObject();
        d.Value1 = "Hello";
        d.Value2 = "World";

        foreach(KeyValuePair<String, object> o in d)
        {
            Console.WriteLine("{0} = {1}", o.Key, o.Value);                
        }

        Console.WriteLine(((IDictionary<String, Object>)d).ContainsKey("Value1"));  //True
        Console.WriteLine(((IDictionary<String, Object>)d).ContainsKey("Value3"));  //False
    
        //メンバーの削除はRemoveで
        ((IDictionary<String, Object>)d).Remove("Value2");
        Console.WriteLine(((IDictionary<String, Object>)d).ContainsKey("Value2"));  //False
    
        //メソッドを追加する
        d.Calc = (Func<int, int, int>)((a, b) => a + b);
        Console.WriteLine(d.Calc(2, 3));

        //JSONを扱うのに便利
        ReadJson();
    }
    
    static void ReadJson()
    {
        string url = @"http://weather.livedoor.com/forecast/webservice/json/v1?city=270000";

        Task.Run(async () => {

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var obj = JsonConvert.DeserializeObject<dynamic>(json);
                var pinpointLocations = obj.pinpointLocations;
                foreach(var data in pinpointLocations)
                {
                    Console.WriteLine("Location:{0} ", data.name);
                }
            }

        }).Wait();
    }
}

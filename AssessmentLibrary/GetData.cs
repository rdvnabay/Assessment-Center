using System;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentLibrary
{
    public static class GetData
    {
        public static List<Account> GetDataList()
        {
            var random = new Random();
            var dataList = new List<Account>();
            for (int i = 0; i <= 25000; i++)
            {
                var data = new Account { HashData = Guid.NewGuid() };

                if (random.Next(0, 100) <= 10)
                {
                    dataList.Add(data);
                }

                data = new Account
                {
                    Id = i,
                    HashData = Guid.NewGuid(),
                    Pin = random.Next(1000, 9999),
                    Pan = random.Next(999999999).ToString("0000 00000 00"),
                    Balance = random.Next(0, 200000)
                };
                dataList.Add(data);

            }
            return dataList.OrderBy(o => o.HashData).ToList();
        }
    }

    public class Account
    {
        public int? Id { get; set; }
        public Guid HashData { get; set; }
        public int Pin { get; set; }
        public string Pan { get; set; }
        public decimal Balance { get; set; }
    }
}

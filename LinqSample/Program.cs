using System;
using System.Linq;  // Linqを利用する場合は必要になるパッケージ
using System.Collections.Generic;

namespace LinqSample {
    class Program {
        enum GENDER {
            MALE, FEMALE
        };

        class User {
            public string name { get; set; }    // 名前
            public string email { get; set; }   // メールアドレス
            public int age { get; set; }        // 年齢
            public string pref { get; set; }    //　住所(県）
            public GENDER gender { get; set; }     // 性別（1：男性、2：女性）
            public override string ToString() {
                return "名前：" + name + "\nメールアドレス：" + email + "\n年齢" + age + "\n住所（県）：" + pref + "\n性別：" + gender + "\n";
            }
        }

        static void Main(string[] args) {

            int[] sampleArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // クエリ構文
            var underFiveQuery = from x in sampleArray
                                 where x < 5
                                 select x;
            Console.WriteLine("underFiveQuery : " + string.Join(", ", underFiveQuery));

            // メソッド構文
            int[] underFiveMethod = sampleArray.Where(x => x < 5).ToArray();
            Console.WriteLine("underFiveMethod : " + string.Join(", ", underFiveMethod));

            List<User> userList = new List<User>();
            userList.Add(new User() { name = "テスト　太郎", email = "tarou@test.com", age = 25, pref = "愛知県", gender = GENDER.MALE });
            userList.Add(new User() { name = "テスト　次郎", email = "jirou@test.com", age = 23, pref = "愛知県", gender = GENDER.MALE });
            userList.Add(new User() { name = "テスト　三郎", email = "saburou@test.com", age = 21, pref = "愛知県", gender = GENDER.MALE });
            userList.Add(new User() { name = "テスト　春子", email = "haruko@test.com", age = 24, pref = "愛知県", gender = GENDER.FEMALE });
            userList.Add(new User() { name = "テスト　夏子", email = "natsuko@test.com", age = 22, pref = "愛知県", gender = GENDER.FEMALE });
            userList.Add(new User() { name = "サンプル　太郎", email = "tarou@sample.com", age = 45, pref = "愛知県", gender = GENDER.MALE });
            userList.Add(new User() { name = "サンプル　次郎", email = "jirou@sample.com", age = 22, pref = "愛知県", gender = GENDER.MALE });
            userList.Add(new User() { name = "サンプル　三郎", email = "saburou@sample.com", age = 12, pref = "愛知県", gender = GENDER.MALE });
            userList.Add(new User() { name = "サンプル　秋子", email = "akiko@sample.com", age = 43, pref = "愛知県", gender = GENDER.FEMALE });
            userList.Add(new User() { name = "サンプル　冬子", email = "fuyuko@example.com", age = 16, pref = "愛知県", gender = GENDER.FEMALE });

            // 男性のみ抽出
            User[] men = userList.Where(x => x.gender == GENDER.MALE).ToArray();
            Console.Write(string.Join<User>("------\n", men));

            // 20代の人数を抽出
            int num20 = userList.Count(x => x.age >= 20 && x.age < 30);
            Console.WriteLine("\n20代の人数：" + num20 + "人");

            // 年齢の最大値取得
            int maxAge = userList.Max(x => x.age);
            Console.WriteLine("\n最大の年齢：" + maxAge + "歳");

            // 年齢の最小値取得
            int minAge = userList.Min(x => x.age);
            Console.WriteLine("\n最小の年齢：" + minAge + "歳");

            // 年齢の平均値取得
            double aveAge = userList.Average(x => x.age);
            Console.WriteLine("\n年齢の平均：" + aveAge + "歳");

            // 1件だけ検索（成功）
            User oneOK = userList.Single<User>(x => x.age == 45);
            Console.Write("\n1件だけ検索(成功）\n" + oneOK);

            // 1件だけ検索（失敗）
            try {
                User oneNG = userList.Single<User>(x => x.age == 22);
            } catch(Exception ex) {
                Console.Write("\n1件だけ検索(失敗）\n" + ex.StackTrace);
            }

            // 男性だけ年齢順に並べる
            List<User> orderMen = userList.Where(x => x.gender == GENDER.MALE).OrderBy(x => x.age).ToList();
            Console.WriteLine("\n男性年齢順：\n" + string.Join<User>("------\n", orderMen));

            // 男性だけ年齢順に名前と年齢だけ並べる
            var selected = userList.Where(x => x.gender == GENDER.MALE).OrderBy(x => x.age).Select(x => new{ x.name, x.age}).ToArray();
            Console.WriteLine("\n男性名前と年齢のみ");
            foreach (var item in selected) {
                Console.WriteLine("name:" + item.name + " age:" + item.age);
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RpgMap
{
    internal class MonsterConfig
    {
        public int ID { get; set; }    // ID
        public string Name { get; set; } = ""; 
        public int Level { get; set; }
        public int PropID { get; set; } // 属性配置ID
        public int PatrolDistance { get; set; } // 巡逻距离
        public int PursueDistance { get; set; } // 追击距离
        public int AttackDistance { get; set; } // 攻击距离
        public string Skill { get; set; } = string.Empty;
        public List<int> Skills = new();
        public int RebornTime { get; set; } // 复活时间
    }

    internal class MonsterReader
    {
        public static Dictionary<int, MonsterConfig> MonsterList = new();

        public static List<int> GetMonsterIDs()
        {
            return MonsterList.Keys.ToList();
        }

        public static MonsterConfig? GetConfig(int MonsterID)
        {
            if(MonsterList.ContainsKey(MonsterID))
                return MonsterList[MonsterID];
            return null;
        }

        public static void Read()
        {
            string json = File.ReadAllText("../../../config/monsters.json");
            var configs = JsonSerializer.Deserialize<List<MonsterConfig>>(json);
            foreach (var conf in configs)
            {
                conf.Skills = Common.StrToList(conf.Skill);
                MonsterList[conf.ID] = conf;

                //Show(conf.ID);
            }
        }

        public static void Show(int ID)
        {
            var config = GetConfig(ID);
            if (config != null)
            {
                Log.R($"ID: {config.ID}");
                Log.R($"Name: {config.Name}");
                Log.R($"Level: {config.Level}");
                Log.R($"PropID: {config.PropID}");
                Log.R($"Patrol Distance: {config.PatrolDistance}");
                Log.R($"Pursue Distance: {config.PursueDistance}");
                Log.R($"Attack Distance: {config.AttackDistance}");
                Console.Write($"Skills : ");
                foreach (var Sid in config.Skills)
                    Console.Write($"{Sid} ,");
                Log.P();
            }
            else
                Log.E($"config {ID} not found");
        }
    }
}

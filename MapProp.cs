﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMap
{
    public struct Prop
    {
        public long HP {  get; set; }
        public long MaxHp { get; set; }
        public int Attack { get; set; }
        public int Defense {  get; set; }
        public int Speed { get; set; }
        public Prop() {}

    }
}
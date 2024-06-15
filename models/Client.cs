﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iCantine.models
{
    public class Client:User
    {
        public decimal Balance { get; set; }
        public virtual string DisplayName => $"{name} (Balance: {Balance:C})";
        public virtual string Name => $"{name}";
        public virtual Receipt Receipt { get; set; }
        public Client()
        {
        }

        public Client( string name, int nif): base(name, nif) 
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

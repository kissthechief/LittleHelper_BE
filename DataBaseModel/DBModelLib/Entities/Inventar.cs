﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;

namespace DBModelLib.Entities
{
    public class Inventar
    {
        public virtual int Id { get; set; }

        public string Guid { get; set; }

        public virtual Food Food { get; set; }

        public virtual int Amount { get; set; }

        public virtual User User { get; set; }
    }
}
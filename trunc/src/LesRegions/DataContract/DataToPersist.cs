using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContract
{
    [DataContract]
    public class DataToPersist
    {
        [DataMember]
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
        [DataMember]
        public List<Region> Regions { get; set; } = new List<Region>();
    }
}

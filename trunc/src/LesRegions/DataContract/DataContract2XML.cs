using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContract
{
    public class DataContract2XML : IPersistanceManager
    {
        public string DossierSauvegarde { get; set; } = Path.Combine(Directory.GetCurrentDirectory(),"..\\XML");

        public string NomFichierSauvegarde { get; set; } = "LesRégions.xml"; 

        public string FichierSauvegarde => Path.Combine(DossierSauvegarde, NomFichierSauvegarde);

        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(DataToPersist),
                                new DataContractSerializerSettings()
                                {
                                    PreserveObjectReferences = true
                                });

        /// <summary>
        /// Sauvegarde des données dans FichierSauvegarde grâce à un serializer
        /// </summary>
        /// <param name="utilisateurs">IEnumerable d'utilisateur</param>
        public void Sauvegarde(IEnumerable<Utilisateur> utilisateurs, IEnumerable<Region> regions)
        {

            if (!Directory.Exists(DossierSauvegarde))
            {
                Directory.CreateDirectory(DossierSauvegarde);
            }

            DataToPersist data = new DataToPersist();
            data.Utilisateurs.AddRange(utilisateurs);
            data.Regions.AddRange(regions);

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(FichierSauvegarde))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
        }


        /// <summary>
        /// Chargement des données depuis le FichierSauvergarde grâce à un serializer
        /// </summary>
        /// <returns>IEnumerable d'utilisateur et IEnumerable de région</returns>
        (IEnumerable<Utilisateur> utilisateurs, IEnumerable<Region> regions) IPersistanceManager.Charge()
        {
            if (!File.Exists(FichierSauvegarde))
            {
                throw new FileNotFoundException("The persitance file is missing");
            }


            DataToPersist data;

            using (Stream s = File.OpenRead(FichierSauvegarde))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }
            return (data.Utilisateurs, data.Regions);
        }
    }
}

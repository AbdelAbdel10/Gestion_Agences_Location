﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Agences_Location.Controllers;
using Gestion_Agences_Location.Models;

namespace Gestion_Agences_Location.Controllers
{
    class Controller_Agence
    {

        List<Agence> lisetAgences = new List<Agence>();
        //todo: lazy loading à corrigé
        public List<Agence> getAll()
        {
            using (Gestion_Agence_LocationEntities _context = new Gestion_Agence_LocationEntities())
            {
                //_context.Configuration.LazyLoadingEnabled = false;
                lisetAgences = _context.Agences.ToList();
            }
            return lisetAgences;
        }

        public List<Agence> getByName( string nom)
        {
            using (Gestion_Agence_LocationEntities _context = new Gestion_Agence_LocationEntities())
            {
                lisetAgences = _context.Agences.Where(e => e.NOM.Contains(nom)).ToList();
            }
            return lisetAgences;
        }

        public List<Agence> getByVille(string ville)
        {
            using (Gestion_Agence_LocationEntities _context = new Gestion_Agence_LocationEntities())
            {
                lisetAgences = _context.Agences.Where(e => e.Ville.NOM == ville).ToList();
            }
            return lisetAgences;
        }




        public void Modifier(Agence agence)
        {
            Agence _agence = new Agence();
            using (Gestion_Agence_LocationEntities _context = new Gestion_Agence_LocationEntities())
            {
                _agence = _context.Agences.FirstOrDefault(e => e.NOM==agence.NOM);
                if (_agence !=null)
                {
                    _agence.NOM = agence.NOM;
                    _agence.ADRESSE = agence.ADRESSE;
                    _agence.TELE = agence.TELE;
                    _context.SaveChanges();
                }
            }
        }

        public void Suprimer(int idAgence)
        {
            Agence _agence = new Agence();
            using (Gestion_Agence_LocationEntities _context = new Gestion_Agence_LocationEntities())
            {
                _agence = _context.Agences.FirstOrDefault(e => e.IDAGENCE == idAgence);
                if (_agence != null)
                {
                    _context.Agences.Remove(_agence);
                    _context.SaveChanges();
                }
            }
        }

        public void Ajouter(Agence agence)
        {
            using (Gestion_Agence_LocationEntities _context = new Gestion_Agence_LocationEntities())
            {
                _context.Agences.Add(agence);
                _context.SaveChanges();
            }
        }

    }
}

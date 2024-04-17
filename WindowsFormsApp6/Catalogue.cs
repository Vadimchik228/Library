using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class Catalogue
    {
        public List<Thematics> Thematicses{ get; private set; }
        public int NumberOfPublications { get; set; }

        public Catalogue()
        {
            Thematicses = new List<Thematics>();
            NumberOfPublications = 0;

            Thematicses.Add(Thematics.Physics());
            NumberOfPublications += Thematics.Physics().Count;
            Thematicses.Add(Thematics.Biology());
            NumberOfPublications += Thematics.Biology().Count;
            Thematicses.Add(Thematics.Chemistry());
            NumberOfPublications += Thematics.Chemistry().Count;

            SortCatalogue();

        }

        

        private void SortThematics(Thematics thematics)
        {
            foreach (var publication in thematics.Publications)
            {
                thematics.Publications.Sort((x, y) => x.Name.CompareTo(y.Name));
            }
        }
        private void SortCatalogue()
        {
            Thematicses.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach (var thematics in Thematicses)
                SortThematics(thematics);
        }

        public bool ExistsInCatalogue(Publication publication)
        {
            foreach (var thematics in Thematicses)
            {
                foreach (var _publication in thematics.Publications)
                {
                    if (_publication.Name.CompareTo(publication.Name) == 0)
                        return true;
                }
            }
            return false;
        }

        public void AddPublicationToCatalogue(Publication publication)
        {
            foreach (var thematics in Thematicses)
            {
                foreach (var _publication in thematics.Publications)
                {
                    if (_publication.Name.CompareTo(publication.Name) == 0)
                    {
                        thematics.Publications.Add(publication);
                        NumberOfPublications++;
                        SortThematics(thematics);
                        return;
                    }
                } 
            }     
        }

        public void AddPublicationsToCatalogue(List<Publication> Publications)
        {
            foreach (var publication in Publications)
                AddPublicationToCatalogue(publication);
        }

        public List<Publication> GetPublicationsFromCatalogue(List<Publication> Publications)
        {
            List<Publication> result = new List<Publication>();
            foreach (var publication in Publications)
            {
                if (ExistsInCatalogue(publication))
                {
                    result.Add(publication);
                    TakePublicationFromCatalogue(publication);
                }
            }
            return result;
        }

        public void TakePublicationFromCatalogue(Publication publication)
        {
            int index;
            foreach (var thematics in Thematicses)
            {
                index = 0;
                foreach (var _publication in thematics.Publications)
                {
                    if (_publication.Name.CompareTo(publication.Name) == 0)
                    {
                        thematics.Publications.RemoveAt(index);
                        NumberOfPublications--;
                        return;
                    }
                    index++;
                }
            }
        }
    }
}

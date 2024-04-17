using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class Thematics
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public List<Publication> Publications { get; set; }

        
        public Thematics()
        {         
            Publications = new List<Publication>();
        }

        
        public static Thematics Physics() 
        {
            Thematics result = new Thematics();

            for (int i = 0; i < 2; ++i)
            {
                result.Publications.Add(Publication.ABriefHistoryOfTime);
                result.Publications.Add(Publication.GeorgeAndTheSecretsOfTheUniverse);
                result.Publications.Add(Publication.DialogueAboutTwoSystemsOfTheWorld);
                result.Publications.Add(Publication.GeneralPhysicsCourse);
                result.Publications.Add(Publication.IntensivePhysicsCourse);
                result.Publications.Add(Publication.ClassicalElectrodynamics);
                result.Publications.Add(Publication.TheoreticalMechanicsDynamics);
                result.Publications.Add(Publication.PhysicsInTablesAndFormulas);
                result.Publications.Add(Publication.FundamentalsOfPhysicsExercisesAndTasks);
            }

            result.Count = 18;
            
            result.Name = "Physics"; 

            return result;
        }

        public static Thematics Biology()
        {
            Thematics result = new Thematics();

            for (int i = 0; i < 2; ++i)
            {
                result.Publications.Add(Publication.PlantLife);
                result.Publications.Add(Publication.AnimalLife);
                result.Publications.Add(Publication.SilentSpring);
                result.Publications.Add(Publication.ClinicalGenetics);
                result.Publications.Add(Publication.HumanAnatomy);
                result.Publications.Add(Publication.FundamentalsOfMolecularBiologyOfTheCell);
                result.Publications.Add(Publication.GeneralBiologyTheoryAndPractice);
                result.Publications.Add(Publication.BiologyInDiagramsTablesAndFigures);
                result.Publications.Add(Publication.LecturesOnBiology);
            }

            result.Count = 18;

            result.Name = "Biology";

            return result;
        }

        public static Thematics Chemistry()
        {
            Thematics result = new Thematics();

            for (int i = 0; i < 2; ++i)
            {
                result.Publications.Add(Publication.ButtonsOfNapoleon);
                result.Publications.Add(Publication.GreatMedicinesInTheStruggleForLife);
                result.Publications.Add(Publication.KillerMoleculesOrChemicalDetective);
                result.Publications.Add(Publication.MethodsForObtainingNanoscaleOxideMaterials);
                result.Publications.Add(Publication.MarchOrganicChemistry);
                result.Publications.Add(Publication.AnalyticalChemistry);
                result.Publications.Add(Publication.WorkshopOnGeneralAndInorganicChemistry);
                result.Publications.Add(Publication.LaboratoryWorkInChemistry);
                result.Publications.Add(Publication.LaboratoryAndSeminarClassesInInorganicChemistry);
            }

            result.Count = 18;

            result.Name = "Chemistry";

            return result;
        }
    }
}

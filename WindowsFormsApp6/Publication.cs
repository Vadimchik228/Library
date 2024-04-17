using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    // Типы изданий
    public enum PublicationType { Scientific /*Научные*/, Educational /*Учебные*/, Reference /*Справочные*/ }


    // Издание
    public class Publication
    {
        
        public string Name { get; set; } 
        public PublicationType Type { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////

        // Научные издания

        // По физике
        public static Publication ABriefHistoryOfTime => new Publication() { Name = "A brief history of time", Type = PublicationType.Scientific };
        public static Publication GeorgeAndTheSecretsOfTheUniverse => new Publication() { Name = "George and the Secrets of the universe", Type = PublicationType.Scientific };
        public static Publication DialogueAboutTwoSystemsOfTheWorld => new Publication() { Name = "Dialogue about two systems of the world", Type = PublicationType.Scientific };

        // По биологии
        public static Publication PlantLife => new Publication() { Name = "Plant life", Type = PublicationType.Scientific };
        public static Publication AnimalLife => new Publication() { Name = "Animal Life", Type = PublicationType.Scientific };
        public static Publication SilentSpring => new Publication() { Name = "Silent Spring", Type = PublicationType.Scientific };
     
        // По химии
        public static Publication ButtonsOfNapoleon => new Publication() { Name = "Buttons of Napoleon", Type = PublicationType.Scientific };
        public static Publication GreatMedicinesInTheStruggleForLife => new Publication() { Name = "Great medicines.In the struggle for life", Type = PublicationType.Scientific };
        public static Publication KillerMoleculesOrChemicalDetective => new Publication() { Name = "Killer Molecules, or Chemical Detective", Type = PublicationType.Scientific };

        //////////////////////////////////////////////////////////////////////////////////////////////
        
        // Учебные издания

        // По физике
        public static Publication GeneralPhysicsCourse => new Publication() { Name = "General Physics Course", Type = PublicationType.Educational };
        public static Publication IntensivePhysicsCourse => new Publication() { Name = "Intensive Physics course", Type = PublicationType.Educational };
        public static Publication ClassicalElectrodynamics => new Publication() { Name = "Classical electrodynamics", Type = PublicationType.Educational };

        // По биологии
        public static Publication ClinicalGenetics => new Publication() { Name = "Clinical genetics", Type = PublicationType.Educational };
        public static Publication HumanAnatomy => new Publication() { Name = "Human anatomy", Type = PublicationType.Educational };
        public static Publication FundamentalsOfMolecularBiologyOfTheCell => new Publication() { Name = "Fundamentals of molecular biology of the cell", Type = PublicationType.Educational };

        // По химии
        public static Publication MethodsForObtainingNanoscaleOxideMaterials => new Publication() { Name = "Methods for obtaining nanoscale oxide materials", Type = PublicationType.Educational };
        public static Publication MarchOrganicChemistry => new Publication() { Name = "March's Organic Chemistry", Type = PublicationType.Educational };
        public static Publication AnalyticalChemistry => new Publication() { Name = "Analytical Chemistry", Type = PublicationType.Educational };

        
        //////////////////////////////////////////////////////////////////////////////////////////////
        
        // Справочные издания

        // По физике
        public static Publication TheoreticalMechanicsDynamics => new Publication() { Name = "Theoretical mechanics. Dynamics", Type = PublicationType.Reference };
        public static Publication PhysicsInTablesAndFormulas => new Publication() { Name = "Physics in tables and formulas", Type = PublicationType.Reference };
        public static Publication FundamentalsOfPhysicsExercisesAndTasks => new Publication() { Name = "Fundamentals of physics. Exercises and tasks", Type = PublicationType.Reference };


        // По биологии
        public static Publication GeneralBiologyTheoryAndPractice => new Publication() { Name = "General biology.Theory and practice", Type = PublicationType.Reference };
        public static Publication BiologyInDiagramsTablesAndFigures => new Publication() { Name = "Biology in diagrams, tables and figures", Type = PublicationType.Reference };
        public static Publication LecturesOnBiology => new Publication() { Name = "Lectures on biology", Type = PublicationType.Reference };
       
        // По химии
        public static Publication WorkshopOnGeneralAndInorganicChemistry => new Publication() { Name = "Workshop on general and inorganic chemistry using a semi-micrometer", Type = PublicationType.Reference };
        public static Publication LaboratoryWorkInChemistry => new Publication() { Name = "Laboratory work in chemistry", Type = PublicationType.Reference };
        public static Publication LaboratoryAndSeminarClassesInInorganicChemistry => new Publication() { Name = "Laboratory and seminar classes in inorganic chemistry", Type = PublicationType.Reference };

    }
}

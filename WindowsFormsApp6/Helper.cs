using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp6
{
    public class Helper
    {
        static public Point ExitPoint;
        static public Point TablePointFromReaderSide;
        static public Point TablePointFromEmployeeSide;
        static public Point BookcasePoint;
        static public Point ReaderSpawnPoint;
        static public void SetExitPoint(Form form)
        {
            ExitPoint = new Point(form.Width / 2, 2 * form.Height);
        }

        static public void SetTablePointFromReaderSide(Form form)
        {
            TablePointFromReaderSide = new Point(form.Width - 400, form.Height - 220);
        }

        static public void SetTablePointFromEmployeeSide(Form form)
        {
            TablePointFromEmployeeSide = new Point(form.Width - 150, form.Height - 220);
        }

        static public void SetBookcasePoint(Form form)
        {
            BookcasePoint = new Point(form.Width, form.Height - 220);
        }

        static public void SetReaderSpawnPoint(Form form)
        {
            ReaderSpawnPoint = new Point(-200, form.Height - 220);
        }


        static public List<Publication> ExistingPublications()
        {
            List<Publication> ListOfExistingPublications = new List<Publication>();

            ListOfExistingPublications.Add(Publication.ABriefHistoryOfTime);
            ListOfExistingPublications.Add(Publication.GeorgeAndTheSecretsOfTheUniverse);
            ListOfExistingPublications.Add(Publication.DialogueAboutTwoSystemsOfTheWorld);
            ListOfExistingPublications.Add(Publication.GeneralPhysicsCourse);
            ListOfExistingPublications.Add(Publication.IntensivePhysicsCourse);
            ListOfExistingPublications.Add(Publication.ClassicalElectrodynamics);
            ListOfExistingPublications.Add(Publication.TheoreticalMechanicsDynamics);
            ListOfExistingPublications.Add(Publication.PhysicsInTablesAndFormulas);
            ListOfExistingPublications.Add(Publication.FundamentalsOfPhysicsExercisesAndTasks);
            ListOfExistingPublications.Add(Publication.PlantLife);
            ListOfExistingPublications.Add(Publication.AnimalLife);
            ListOfExistingPublications.Add(Publication.SilentSpring);
            ListOfExistingPublications.Add(Publication.ClinicalGenetics);
            ListOfExistingPublications.Add(Publication.HumanAnatomy);
            ListOfExistingPublications.Add(Publication.FundamentalsOfMolecularBiologyOfTheCell);
            ListOfExistingPublications.Add(Publication.GeneralBiologyTheoryAndPractice);
            ListOfExistingPublications.Add(Publication.BiologyInDiagramsTablesAndFigures);
            ListOfExistingPublications.Add(Publication.LecturesOnBiology);
            ListOfExistingPublications.Add(Publication.ButtonsOfNapoleon);
            ListOfExistingPublications.Add(Publication.GreatMedicinesInTheStruggleForLife);
            ListOfExistingPublications.Add(Publication.KillerMoleculesOrChemicalDetective);
            ListOfExistingPublications.Add(Publication.MethodsForObtainingNanoscaleOxideMaterials);
            ListOfExistingPublications.Add(Publication.MarchOrganicChemistry);
            ListOfExistingPublications.Add(Publication.AnalyticalChemistry);
            ListOfExistingPublications.Add(Publication.WorkshopOnGeneralAndInorganicChemistry);
            ListOfExistingPublications.Add(Publication.LaboratoryWorkInChemistry);
            ListOfExistingPublications.Add(Publication.LaboratoryAndSeminarClassesInInorganicChemistry);

            return ListOfExistingPublications;
        }

        static public List<Publication> GenerateListOfPublications()
        {
            List<Publication> GeneratedListOfTakenPublications = new List<Publication>();
            List<Publication> ListOfExistingPublications = Helper.ExistingPublications();
            Random rnd = new Random();
            int NumberOfTakenPublications = rnd.Next(1, 6);

            for (int i = 0; i < NumberOfTakenPublications; ++i)
            {
                GeneratedListOfTakenPublications.Add(ListOfExistingPublications[rnd.Next(0, ListOfExistingPublications.Count)]);
            }
            return GeneratedListOfTakenPublications;
        }

    }
}

//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        // Se utiliza el princpio SRP ya que asigno la responsabilidad de caclular el costo de producción a un metodo        
        // separado, en este caso GetProductionCost()        

        public double GetProductionCost()
        {
            double costInsumos = 0;
            double costEquipamiento = 0;

            foreach (Step step in this.steps)
            {
                // Calculo el costo de insumos 
                costInsumos += step.Input.UnitCost * step.Quantity;

                // Calculo el costo de equipamiento 
                costEquipamiento += (step.Time / 60) * step.Equipment.HourlyCost;
            }

            // Calculo el costo total
            double totalCost = costInsumos + costEquipamiento;
            return totalCost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

            // Aquí muestro el costo total de producción
            double productionCost = GetProductionCost();
            Console.WriteLine($"Costo total de producción: {productionCost:C}");
        }
    }
}
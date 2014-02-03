﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneticAlgorithm : MonoBehaviour {

	// --- constants
	public static int CHROMOSOME_SIZE=10;
	public static int POPULATION_SIZE=500;
	
	// --- variables:
	
	/**
     * The population contains an ArrayList of genes (the choice of arrayList over
     * a simple array is due to extra functionalities of the arrayList, such as sorting)
     */
	public List<Gene> mPopulation;
	
	// --- functions:
	
	/**
     * Creates the starting population of Gene classes, whose chromosome contents are random
     * @param size: The size of the popultion is passed as an argument from the main class
     */
	public GeneticAlgorithm(int size){
		// initialize the arraylist and each gene's initial weights HERE
		mPopulation = new List<Gene>();
		for(int i = 0; i < size; i++){
			Gene entry = new Gene();
			entry.randomizeChromosome();
			mPopulation.Add(entry);
		}
	}
	/**
     * For all members of the population, runs a heuristic that evaluates their fitness
     * based on their phenotype. The evaluation of this problem's phenotype is fairly simple,
     * and can be done in a straightforward manner. In other cases, such as agent
     * behavior, the phenotype may need to be used in a full simulation before getting
     * evaluated (e.g based on its performance)
     */
	public void evaluateGeneration(){
		for(int i = 0; i < mPopulation.Count; i++){
			// evaluation of the fitness function for each gene in the population goes HERE
		}
	}
	/**
     * With each gene's fitness as a guide, chooses which genes should mate and produce offspring.
     * The offspring are added to the population, replacing the previous generation's Genes either
     * partially or completely. The population size, however, should always remain the same.
     * If you want to use mutation, this function is where any mutation chances are rolled and mutation takes place.
     */
	public void produceNextGeneration(){
		// use one of the offspring techniques suggested in class (also applying any mutations) HERE
		
		
	}
	
	// accessors
	/**
     * @return the size of the population
     */
	public int size(){ return mPopulation.Count; }
	/**
     * Returns the Gene at position <b>index</b> of the mPopulation arrayList
     * @param index: the position in the population of the Gene we want to retrieve
     * @return the Gene at position <b>index</b> of the mPopulation arrayList
     */
	public Gene getGene(int index){ return mPopulation[index]; }
	
	// Genetic Algorithm maxA testing method
	public static void main( String[] args ){
		// Initializing the population (we chose 500 genes for the population,
		// but you can play with the population size to try different approaches)
		GeneticAlgorithm population = new GeneticAlgorithm(POPULATION_SIZE);
		int generationCount = 0;
		// For the sake of this sample, evolution goes on forever.
		// If you wish the evolution to halt (for instance, after a number of
		//   generations is reached or the maximum fitness has been achieved),
		//   this is the place to make any such checks
		while(true){
			// --- evaluate current generation:
			population.evaluateGeneration();
			// --- print results here:
			// we choose to print the average fitness,
			// as well as the maximum and minimum fitness
			// as part of our progress monitoring
			float avgFitness=0f;
			float minFitness=float.PositiveInfinity;
			float maxFitness=float.NegativeInfinity;
			string bestIndividual="";
			string worstIndividual="";
			for(int i = 0; i < population.size(); i++){
				float currFitness = population.getGene(i).getFitness();
				avgFitness += currFitness;
				if(currFitness < minFitness){
					minFitness = currFitness;
					worstIndividual = population.getGene(i).getPhenotype();
				}
				if(currFitness > maxFitness){
					maxFitness = currFitness;
					bestIndividual = population.getGene(i).getPhenotype();
				}
			}
			if(population.size()>0){ avgFitness = avgFitness/population.size(); }
			string output = "Generation: " + generationCount;
			output += "\t AvgFitness: " + avgFitness;
			output += "\t MinFitness: " + minFitness + " (" + worstIndividual +")";
			output += "\t MaxFitness: " + maxFitness + " (" + bestIndividual +")";
			Debug.Log(output);
			// produce next generation:
			population.produceNextGeneration();
			generationCount++;
		}
	}
}

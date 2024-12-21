#include <iostream>
#include "TextViewer.h"
#include "Systeme.h"
#include "IntegrateurEuler.h"
#include "IntegrateurNewmark.h"
using namespace std;

int main()
{
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	Masse masse1(10);
	Masse masse2(50.,7, Vecteur3D(19, 20, 21), Vecteur3D(22, 23, 24));
	vector<Masse> Mes_masses({masse1, masse2});
	
	for (auto masse : Mes_masses)
	{
		cout << masse << endl;
		
		cout << "Tests de get() : " << endl
		<< "position = " << masse.get_position() << endl
		<< "vitesse = " << masse.get_vitesse() << endl
		<< "acceleration = " << masse.acceleration() << endl << endl;
		
		cout << "Tests de ajoute_force() : " << endl
		<< "test 1 : " << endl
		<< "forces = " << masse.get_force_subie() << endl
		<< "ajout de (2.7, 5.6, 8.9)" << endl << endl;
		masse.ajoute_force(Vecteur3D(2.7, 5.6, 8.9));
		cout << "test 2 : " << endl
		<< "forces = " << masse.get_force_subie() << endl << 
		endl;
		
		cout << "Test de mise_a_jour_forces() : " << endl
		<< "force = " << masse.get_force_subie() << endl
		<< "acceleration = " << masse.acceleration() << endl;
	}
	
	return 0;
}

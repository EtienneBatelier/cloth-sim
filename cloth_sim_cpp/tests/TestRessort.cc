#include <iostream>
#include "TextViewer.h"
#include "Systeme.h"
#include "IntegrateurEuler.h"
#include "IntegrateurNewmark.h"

using namespace std;


void affiche_force_exercee_par_ressort(Ressort* R,Masse* M)
{
	cout<<"Ressort "<<R<<" Sur massse "<<M<<R->force_rappel(M)<<endl;
}

int main()
{
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	//Ressort(Masse* depart,Masse* arrivee, double k_, double l0_)
	
	try {
	//Test de la gestion d'erreur
	//~ Masse M1(1,.3,Vecteur3D(0.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	//~ Masse M2(2,.3,Vecteur3D(1.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	//~ Ressort R1(&M1,&M1,3.0,1.0);
	
	//Test1
	Masse M1(1,.3,Vecteur3D(0.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse M2(2,.3,Vecteur3D(1.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Ressort R1(&M1,&M2,3.0,1.0);
	cout<<R1;
	Masse M3(3,.3,Vecteur3D(2.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Ressort R2(&M2,&M3,4.0,5.0);
	cout<<R2;
	
	//Test2
	cout<<"Test2"<<endl;
	cout<<R1;
	cout<<R2;
	
	//Test3
	//Modification de la masse2
	cout<<"Test3"<<endl;
	M2.set_vitesse(Vecteur3D(42.0,42.0,42.0));
	M2.set_position(Vecteur3D(42.0,42.0,42.0));
	M2.set_force_subie(Vecteur3D(42.0,42.0,42.0));
	cout<<R1;
	cout<<R2;
	
	//Test4
	cout<<"Test4"<<endl;
	affiche_force_exercee_par_ressort(&R1,&M1);
	affiche_force_exercee_par_ressort(&R1,&M2);
	affiche_force_exercee_par_ressort(&R1,&M3);
	affiche_force_exercee_par_ressort(&R2,&M1);
	affiche_force_exercee_par_ressort(&R2,&M2);
	affiche_force_exercee_par_ressort(&R2,&M3);
	}
	catch(string const& e)
	{
		
		cout<<e;
	}
	return 0;
}

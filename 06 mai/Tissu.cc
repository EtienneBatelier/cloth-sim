#include "Tissu.h"
using namespace std;

//Fonctions privees
void Tissu::connecte(size_t depart, size_t arrivee, double k_, double l0_){
	ressorts.emplace_back(masses[depart], masses[arrivee], k_, l0_);

}

void Tissu::connecte_masses(){
	for (auto& m : masses)
	{
		m->clear_ressorts();
	}
	for (auto& r : ressorts)
	{
		r.ajouter();
	}
}

//Constructeur
Tissu::Tissu(vector<Masse*> const& masses_,SupportADessin* support_)
:Dessinable(support_),masses(masses_){}			//Pour l'instant, on "connecte" les masses "a la main" avec les fonctions connecte2 et connecte_masses2 qui disparaitront.
							
//Gets
vector<Masse> Tissu::get_masses() const{
	vector<Masse> retour;
	for (auto m : masses)
	{
		retour.push_back(*m);
	}
	return retour;
}
vector<Ressort> Tissu::get_ressorts() const{
	return ressorts;
}

//Fonctions
bool Tissu::check() const{
	int compteur(0);
	for (auto const& m : masses)
	{
		++compteur;
		cout << "Verification de la masse " << compteur << ", d'adresse " << &m << endl;
		if (m->seule()) 				{cerr << "La masse " << compteur << " est seule." << endl; return false;}
		if (m->ressortsOK()==false) 	{return false;}
	}
	for (auto const& r : ressorts)
	{
		++compteur;
		cout << "Verification du ressort " << compteur << ", d'adresse " << &r << endl;
		//~ if ((r.get_depart())==nullptr or (r.get_arrivee())==nullptr) 	 	return false;
		if ((r.get_depart()).chercher_ressort(&r) == false){
			cerr << "La masse de depart du ressort " << compteur << " n'a pas ce ressort dans sa collection." << endl; 
			return false;}
			
		if ((r.get_arrivee()).chercher_ressort(&r) == false){
			cerr << "La masse de depart du ressort " << compteur << " n'a pas ce ressort dans sa collection." << endl; 
			return false;}
	}
	return true;
}

void Tissu::mise_a_jour_forces(){
	for (auto& m : masses){
		m->mise_a_jour_forces();
	}
}

void Tissu::evolue(Integrateur& I, double dt){
	for (auto& m : masses){
		I.integre(*m, dt);
	}
	
}

void Tissu::affiche(ostream& flot) const{
	flot << "Tissu : " << this << endl;
	for (auto m : masses)
	{
		flot << *m << endl << endl;
	}
	flot << endl;
}

void Tissu::ajoute_force(Vecteur3D force){
	for (auto& m : masses)
	{
		m->ajoute_force(force);
	}
}

//Operateur d'affichage
ostream& operator<<(ostream& sortie, Tissu const& tissu)
{
	tissu.affiche(sortie);
	return sortie;
}

//Dessine
void Tissu::dessine() const
{support->dessine(*this);}


//Fonctions EPHEMERES (existe deja en prive mais utile pour TestTissu1 et 2)
void Tissu::connecte2(size_t depart, size_t arrivee, double k_, double l0_){
	ressorts.emplace_back(masses[depart], masses[arrivee], k_, l0_);
}

void Tissu::connecte_masses2(){
	for (auto& m : masses)
	{
		m->clear_ressorts();
	}
	for (auto& r : ressorts)
	{
		r.ajouter();
	}
}


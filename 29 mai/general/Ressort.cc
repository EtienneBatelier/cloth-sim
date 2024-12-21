#include "Ressort.h"
#include <iostream>
using namespace std;


//Gets
Masse Ressort::get_depart() const
{return *depart;}
Masse Ressort::get_arrivee() const
{return *arrivee;}
double Ressort::get_k() const
{return k;}
double Ressort::get_l0() const
{return l0;}

//Constructeur
Ressort::Ressort(Masse* depart,Masse* arrivee, double const& k_, double const& l0_)
:depart(depart),arrivee(arrivee), k(k_), l0(l0_)
{
	if(depart==arrivee)
	{
		throw string("La masse d'arrivée et de départ du ressort ne sont pas les mêmes");
	}
	depart->attache_ressort(this);
	arrivee->attache_ressort(this);
}
/*
//Destructeur
Ressort::~Ressort()
{
    depart->remove(this);
    arrivee->remove(this);
}
*/
//Fonctions
double Ressort::force() const
{
    return force_rappel(depart).norme();
}
Vecteur3D Ressort::force_rappel(Masse* M) const
{
	Vecteur3D L;
	if(M!=arrivee and M!=depart)
	{return Vecteur3D();}
	if(M==arrivee)
	{
		L=(*depart).get_position()-(*arrivee).get_position();
	}
	else if(M==depart)
	{
		L=(*arrivee).get_position()-(*depart).get_position();
	}
	double l(L.norme());
	Vecteur3D D((1.0/l)*L);
	Vecteur3D F(k*(l-l0)*D);
	return F;
}

void Ressort::affiche(ostream&  sortie) const{
	sortie << "Ressort : " << this << endl 
	<< k << " cste raideur" << endl
	<< l0 << " longueur au repos" << endl 
	<< "#Masse de départ : " << depart << endl
	<< *depart << endl
	<< "#Masse d'arrivee : " << arrivee << endl
	<< *arrivee << endl << endl;
}

//Operateur affiche
ostream& operator<<(ostream& sortie, Ressort const& ressort)
{
	ressort.affiche(sortie);
	return sortie;
}

//Actions sur les masses
bool Ressort::chercher_masse(const Masse* m_) const{
	return (m_==depart or m_==arrivee);
}

void Ressort::ajouter()
{
	depart->attache_ressort(this);
	arrivee->attache_ressort(this);
}

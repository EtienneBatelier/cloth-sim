#ifndef PRJ_RESSORT_H
#define PRJ_RESSORT_H
#include "Masse.h"


class Ressort
{
	private :
	Masse* depart;
	Masse* arrivee;
	double k;
	double l0;
	
	public :
	//Gets
	Masse get_depart() const;
	Masse get_arrivee() const;
	double get_k() const;
	double get_l0() const;

	//Constructeur
	Ressort(Masse*, Masse*, double const&, double const&);
	//Fonctions
	Vecteur3D force_rappel(Masse*) const;
	void affiche(std::ostream& ) const;
	//Actions sur les masses
	bool chercher_masse(const Masse*) const;
	void ajouter();
};

std::ostream& operator<<(std::ostream&,Ressort  const&);
#endif // PRJ_RESSORT_H

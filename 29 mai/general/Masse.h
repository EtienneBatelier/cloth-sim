#ifndef PRJ_MASSE_H
#define PRJ_MASSE_H
#include "Vecteur3D.h"
#include "Dessinable.h"
#include <vector>


class Ressort;

class Masse:public Dessinable
{
	private :
	Vecteur3D position;
	Vecteur3D vitesse;
	Vecteur3D force_subie;
	std::vector<Ressort*> ressorts_associes;
    double m;
    double lambda;
	
	public :
	//Gets
	Vecteur3D get_position() const;
	Vecteur3D get_vitesse() const;
	Vecteur3D get_force_subie() const;
	double get_m() const;
	double get_lambda() const;
    std::vector<Ressort*> get_ressorts_associes() const;
    Vecteur3D get_acceleration();
	//Set
	void set_position(Vecteur3D const&);
	void set_vitesse(Vecteur3D const&);
	void set_force_subie(Vecteur3D const&);
	void set_m(double const&);
	void set_lambda(double const&);
	//Constructeurs
    Masse(double const&, double const&, Vecteur3D const&, Vecteur3D const&, std::vector<Ressort*> res={},SupportADessin* support = nullptr);
    Masse(double const&,SupportADessin* support=nullptr);
    /*//Destructeur
    ~Masse();*/
    //Remove
    void remove(Ressort*);
	//Fonctions
	void ajoute_force(Vecteur3D const&);
	Vecteur3D acceleration() const;
	void mise_a_jour_forces();
	void affiche(std::ostream& sortie) const;
	//Attache Ressort
	void attache_ressort(Ressort*);
	void clear_ressorts();
	bool seule() const;
	bool chercher_ressort(const Ressort*) const;
	bool ressortsOK() const;
	//Dessine
    virtual void dessine() const override;
};
//Opérateurs
std::ostream& operator<<(std::ostream& sortie, Masse const& masse);


#endif // PRJ_MASSE_H
